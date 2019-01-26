﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Volvox.Helios.Core.Modules.ModerationModule.PunishmentService;
using Volvox.Helios.Core.Modules.ModerationModule.UserWarningsService;
using Volvox.Helios.Core.Modules.ModerationModule.Utils;
using Volvox.Helios.Core.Modules.ModerationModule.WarningService;
using Volvox.Helios.Core.Services.MessageService;
using Volvox.Helios.Domain.Module.ModerationModule;
using Volvox.Helios.Domain.Module.ModerationModule.Common;

namespace Volvox.Helios.Core.Modules.ModerationModule.ViolationService
{
    public class ViolationService : IViolationService
    {
        private readonly IMessageService _messageService;

        private readonly IModerationModuleUtils _moderationModuleUtils;

        private readonly IPunishmentService _punishmentService;

        private readonly IUserWarningsService _userWarningService;

        private readonly IWarningService _warningService;

        public ViolationService(IMessageService messageService, IPunishmentService punishmentService,
            IWarningService warningService, IUserWarningsService userWarningService,
            IModerationModuleUtils moderationModuleUtils)
        {
            _messageService = messageService;

            _punishmentService = punishmentService;

            _warningService = warningService;

            _userWarningService = userWarningService;

            _moderationModuleUtils = moderationModuleUtils;
        }

        /// <inheritdoc />
        public async Task HandleViolation(SocketMessage message, FilterType warningType)
        {
            var user = (SocketGuildUser)message.Author;

            await message.DeleteAsync();

            await _messageService.Post(message.Channel.Id, $"Message by <@{user.Id}> deleted\nReason: {warningType}");

            // Get user entry from db, this is where a users warnings etc are stored.
            var userData =
                await _userWarningService.GetUser(user.Id, user.Guild.Id, u => u.Warnings, u => u.ActivePunishments);

            await AddWarning(user, userData, warningType);

            await ApplyPunishments(user, userData, warningType);
        }

        private async Task AddWarning(SocketGuildUser user, UserWarnings userData, FilterType warningType)
        {
            // Add warning to database.
            var newWarning = await _warningService.AddWarning(user, warningType);

            // Update cached version.
            userData.Warnings.Add(newWarning);
        }

        private async Task ApplyPunishments(SocketGuildUser user, UserWarnings userData, FilterType warningType)
        {
            var punishments = await GetPunishmentsToApply(userData, warningType);

            await _punishmentService.ApplyPunishments(punishments, user);
        }

        private async Task<List<Punishment>> GetPunishmentsToApply(UserWarnings userData, FilterType warningType)
        {
            var moderationSettings = await _moderationModuleUtils.GetModerationSettings(userData.GuildId);

            // Get all warnings that haven't expired.
            var userWarnings = userData.Warnings.Where(x => x.WarningExpires > DateTimeOffset.Now);

            // Count warnings of violation type.
            var specificWarningCount = userWarnings.Count(x => x.WarningType == warningType);

            // Count total number of warnings.
            var allWarningsCount = userWarnings.Count();

            var punishments = new List<Punishment>();

            // Global punishments
            punishments.AddRange(moderationSettings.Punishments.Where(x =>
                x.WarningType == FilterType.Global && x.WarningThreshold == allWarningsCount));

            // Punishments for specific type. I.E. profanity violation.
            punishments.AddRange(moderationSettings.Punishments.Where(x =>
                x.WarningType == warningType && x.WarningThreshold == specificWarningCount));

            return punishments;
        }
    }
}