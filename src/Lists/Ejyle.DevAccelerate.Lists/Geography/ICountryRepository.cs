// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public interface ICountryRepository<TKey, TNullableKey, TCountry, TCountryRegion> : IEntityRepository<TKey, TCountry>
        where TKey : IEquatable<TKey>
        where TCountry : ICountry<TKey>
        where TCountryRegion : ICountryRegion<TKey, TNullableKey>
    {
        TCountry FindById(TKey id);
        Task<TCountry> FindByIdAsync(TKey id);

        TCountry FindByName(string name);
        Task<TCountry> FindByNameAsync(string name);

        List<TCountry> FindAll();
        Task<List<TCountry>> FindAllAsync();

        TCountryRegion FindCountryRegionById(TKey id);
        Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id);
    }
}
