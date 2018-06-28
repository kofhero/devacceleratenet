// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

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
        where TKey : IEquatable<TKey>
        where TCountry : ICountry<TKey>
        where TCountryRegion : ICountryRegion<TKey, TNullableKey>
        where TRepository : ICountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>
    {
        private bool _isDisposed = false;

        public CountryManager(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository
        {
            get;
            private set;
        }

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

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                    Repository = default(TRepository);
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
