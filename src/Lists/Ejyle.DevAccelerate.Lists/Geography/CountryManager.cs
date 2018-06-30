// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public class CountryManager : CountryManager<int, int?, Country, CountryRegion, CountryRepository>
    {
        public CountryManager(CountryRepository repository) : base(repository)
        { }
    }

    public class CountryManager<TKey, TNullableKey, TCountry, TCountryRegion, TRepository>
        : EntityManagerBase<TKey, TCountry, TRepository>
        where TKey : IEquatable<TKey>
        where TCountry : ICountry<TKey>
        where TCountryRegion : ICountryRegion<TKey, TNullableKey>
        where TRepository : ICountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>
    {
        public CountryManager(TRepository repository)
            : base(repository)
        { }

        public List<TCountry> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TCountry>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TCountry FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            return Repository.FindByIdAsync(id);
        }

        public TCountryRegion FindCountryRegionById(TKey id)
        {
            return Repository.FindCountryRegionById(id);
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            return Repository.FindCountryRegionByIdAsync(id);
        }

        public TCountry FindByName(string name)
        {
            return Repository.FindByName(name);
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            return Repository.FindByNameAsync(name);
        }
    }
}
