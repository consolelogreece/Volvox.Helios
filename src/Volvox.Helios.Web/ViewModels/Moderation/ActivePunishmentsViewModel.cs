using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volvox.Helios.Domain.Module.ModerationModule;

namespace Volvox.Helios.Web.ViewModels.Moderation
{
    public class ActivePunishmentsViewModel
    {
        public virtual List<UserWarnings> Users { get; set; }
    }
}
