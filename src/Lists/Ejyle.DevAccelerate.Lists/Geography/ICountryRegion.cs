// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public interface ICountryRegion<TKey, TNullableKey> : IList<TKey>
        where TKey : IEquatable<TKey>
    {
        TNullableKey ParentId { get; set; }
        TKey CountryId { get; set; }
        string RegionCode { get; set; }
        bool IsVerified { get; set; }
    }
}
