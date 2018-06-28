// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Lists.Geography;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class GlobalTimeZone : GlobalTimeZone<int, int?, DateFormat, Country>
    {
        public GlobalTimeZone()
            : base()
        { }
    }

    public class GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry> : ListBase<TKey>, IGlobalTimeZone<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDateFormat<TKey>
        where TCountry: ICountry<TKey>
    {
        public GlobalTimeZone()
        {
            Countries = new HashSet<TCountry>();
        }

        [Required]
        [StringLength(256)]
        public string TimeZoneId { get; set; }

        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }

        public TNullableKey DefaultDateFormatId { get; set; }

        public virtual TDateFormat DefaultDateFormat { get; set; }

        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
