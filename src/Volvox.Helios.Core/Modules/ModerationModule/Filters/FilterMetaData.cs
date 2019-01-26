﻿using Volvox.Helios.Domain.Module.ModerationModule.Common;

namespace Volvox.Helios.Core.Modules.ModerationModule.Filters
{
    public class FilterMetaData
    {
        public FilterMetaData(FilterType filterType)
        {
            FilterType = filterType;
        }

        public FilterType FilterType { get; }
    }
}