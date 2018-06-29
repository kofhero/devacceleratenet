// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Lists.System;

namespace Ejyle.DevAccelerate.Lists.Geography
{
    public class CountryRepository : CountryRepository<int, int?, GlobalTimeZone, DateFormat, SystemLanguage, Currency, Country, CountryRegion, ListsDbContext>
    {
        public CountryRepository(ListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class CountryRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext> : ICountryRepository<TKey, TNullableKey, TCountry, TCountryRegion>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry>
        where TDateFormat : DateFormat<TKey, TNullableKey, TGlobalTimeZone>
        where TSystemLanguage : SystemLanguage<TKey, TCountry>
        where TCurrency : Currency<TKey, TCountry>
        where TCountry : Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : ListsDbContext<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        private bool _isDisposed = false;

        public CountryRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext
        {
            get;
            private set;
        }

        public List<TCountry> FindAll()
        {
            return DbContext.Countries.ToList();
        }

        public Task<List<TCountry>> FindAllAsync()
        {
            return DbContext.Countries.ToListAsync();
        }

        public TCountry FindById(TKey id)
        {
            return DbContext.Countries.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TCountry> FindByIdAsync(TKey id)
        {
            return DbContext.Countries.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public TCountryRegion FindCountryRegionById(TKey id)
        {
            return DbContext.CountryRegions.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TCountryRegion> FindCountryRegionByIdAsync(TKey id)
        {
            return DbContext.CountryRegions.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public TCountry FindByName(string name)
        {
            return DbContext.Countries.Where(m => m.Name == name).SingleOrDefault();
        }

        public Task<TCountry> FindByNameAsync(string name)
        {
            return DbContext.Countries.Where(m => m.Name == name).SingleOrDefaultAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                    DbContext = null;
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
