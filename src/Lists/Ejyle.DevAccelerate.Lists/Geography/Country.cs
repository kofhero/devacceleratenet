// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Lists.System;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public class Country : Country<int, int?, Currency, GlobalTimeZone, CountryRegion, SystemLanguage>
    {
        public Country()
            : base()
        {
        }
    }

    public class Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage> : ListBase<TKey>, ICountry<TKey>
        where TKey : IEquatable<TKey>
        where TCurrency : ICurrency<TKey>
        where TGlobalTimeZone : IGlobalTimeZone<TKey, TNullableKey>
        where TCountryRegion : ICountryRegion<TKey, TNullableKey>
        where TSystemLanguage : ISystemLanguage<TKey>
    {
        public Country()
        {
            GlobalTimeZones = new HashSet<TGlobalTimeZone>();
            Regions = new HashSet<TCountryRegion>();
            SystemLanguages = new HashSet<TSystemLanguage>();
        }

        [StringLength(5)]
        public string DialingCode { get; set; }

        [StringLength(5)]
        public string CountryCode { get; set; }

        public TKey CurrencyId { get; set; }

        [Required]
        public bool HasRegions { get; set; }

        public virtual ICollection<TGlobalTimeZone> GlobalTimeZones { get; set; }

        public virtual ICollection<TSystemLanguage> SystemLanguages { get; set; }

        public virtual TCurrency Currency { get; set; }

        public virtual ICollection<TCountryRegion> Regions { get; set; }
    }
}
