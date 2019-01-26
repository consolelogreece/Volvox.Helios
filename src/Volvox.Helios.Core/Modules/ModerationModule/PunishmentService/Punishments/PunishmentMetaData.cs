﻿using Volvox.Helios.Domain.Module.ModerationModule.Common;

namespace Volvox.Helios.Core.Modules.ModerationModule.PunishmentService.Punishments
{
    public class PunishmentMetaData
    {
        public PunishType PunishType { get; set; }

        public bool RemovesUserFromGuild { get; set; }
    }
}