﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volvox.Helios.Domain.Module.ModerationModule.Common;

namespace Volvox.Helios.Domain.Module.ModerationModule.ProfanityFilter
{
    [Table("mod_profanity_filters")]
    public class ProfanityFilter : FilterBase
    {
        [Required] public List<BannedWord> BannedWords { get; set; } = new List<BannedWord>();

        // Toggle whether user wants to use our own premade list of curse words.
        [Required] public bool UseDefaultList { get; set; }
    }
}