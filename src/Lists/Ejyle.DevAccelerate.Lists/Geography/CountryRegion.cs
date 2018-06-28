// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public class CountryRegion : CountryRegion<int, int?, CountryRegion, Country>
    {
        public CountryRegion()
            : base()
        {
        }
    }

    public class CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry> : ListBase<TKey>, ICountryRegion<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TCountryRegion : ICountryRegion<TKey, TNullableKey>
        where TCountry : ICountry<TKey>

    {
        public CountryRegion()
        {
            Children = new HashSet<TCountryRegion>();
        }

        public TKey CountryId { get; set; }
        public string RegionCode { get; set; }
        public virtual TCountry Country { get; set; }
        public bool IsVerified { get; set; }
        public TNullableKey ParentId { get; set; }
        public virtual ICollection<TCountryRegion> Children { get; set; }
        public virtual TCountryRegion Parent { get; set; }
    }
}
