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
    public class SystemLanguage : SystemLanguage<int, Country>
    {
        public SystemLanguage()
            : base()
        { }
    }

    public class SystemLanguage<TKey, TCountry> : ListBase<TKey>, ISystemLanguage<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : ICountry<TKey>
    {
        public SystemLanguage()
        {
            Countries = new HashSet<TCountry>();
        }

        [Required]
        [StringLength(256)]
        public string DisplayName { get; set; }

        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
