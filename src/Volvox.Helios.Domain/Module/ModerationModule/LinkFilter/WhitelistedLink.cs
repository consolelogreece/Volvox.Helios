﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Volvox.Helios.Domain.Module.ModerationModule.LinkFilter
{
    public class WhitelistedLink
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("FilterId")]
        public virtual LinkFilter LinkFilter { get; set; }

        // Id of channel to allow link in. null == allow link everywhere
        public ulong? ChannelId { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
