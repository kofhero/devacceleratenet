// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Lists.System;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public class CountryManager<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TRepository, TDbContext>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry>
        where TDateFormat : DateFormat<TKey, TNullableKey, TGlobalTimeZone>
        where TSystemLanguage : SystemLanguage<TKey, TCountry>
        where TCurrency : Currency<TKey, TCountry>
        where TCountry : Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TRepository : CountryRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        where TDbContext : ListsDbContext<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
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
                    Repository = null;
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
