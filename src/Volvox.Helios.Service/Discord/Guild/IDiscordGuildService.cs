﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Volvox.Helios.Domain.Discord;

namespace Volvox.Helios.Service.Discord.Guild
{
    public interface IDiscordGuildService
    {
        /// <summary>
        /// Get all of the channels for the specififed guild.
        /// </summary>
        /// <param name="guildId">Id of the guild.</param>
        /// <returns>List opf channels in the guild.</returns>
        Task<List<Channel>> GetChannels(ulong guildId);
    }
}