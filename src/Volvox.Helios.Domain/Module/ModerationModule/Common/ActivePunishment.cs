﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvox.Helios.Domain.Module.ModerationModule.Common
{
    [Table("mod_ActivePunishments")]
    public class ActivePunishment
    {
        [Key] public int Id { get; set; }

        [Required] public int UserId { get; set; }

        [ForeignKey("UserId")] public virtual UserWarnings User { get; set; }

        // ID of punishment in punishments table. This is used to check if a user already has a certain punishment applied.
        [Required] public int PunishmentId { get; set; }

        public ulong? RoleId { get; set; }

        [Required] public PunishType PunishType { get; set; }

        [Required] public DateTimeOffset PunishmentExpires { get; set; }

        // This field is used to mark whether this punishment should be removed as specified by the user on the front end.
        [NotMapped] public bool Remove { get; set; }
    }
}