// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public interface ICountry<TKey> : IList<TKey>
        where TKey : IEquatable<TKey>
    {
        string DialingCode { get; set; }
        string CountryCode { get; set; }
        TKey CurrencyId { get; set; }
        bool HasRegions { get; set; }
    }
}
