// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Lists.Geography;

namespace Ejyle.DevAccelerate.Lists
{
    public class Currency : Currency<int, Country>
    {
        public Currency()
            : base()
        { }
    }

    public class Currency<TKey, TCountry> : ListBase<TKey>, ICurrency<TKey>
        where TKey : IEquatable<TKey>
        where TCountry : ICountry<TKey>
    {
        public Currency()
        {
            Countries = new HashSet<TCountry>();
        }

        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public virtual ICollection<TCountry> Countries { get; set; }
    }
}
