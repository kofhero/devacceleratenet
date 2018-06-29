// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Lists.Geography;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class SystemLanguageRepository : SystemLanguageRepository<int, int?, GlobalTimeZone, DateFormat, SystemLanguage, Currency, Country, CountryRegion, ListsDbContext>
    {
        public SystemLanguageRepository(ListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class SystemLanguageRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext> : ISystemLanguageRepository<TKey, TSystemLanguage>
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

        public SystemLanguageRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext
        {
            get;
            private set;
        }

        public List<TSystemLanguage> FindAll()
        {
            return DbContext.SystemLanguages.ToList();
        }

        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            return DbContext.SystemLanguages.ToListAsync();
        }

        public TSystemLanguage FindById(TKey id)
        {
            return DbContext.SystemLanguages.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
        {
            return DbContext.SystemLanguages.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public List<TSystemLanguage> FindByCountryId(TKey countryId)
        {
            return DbContext.SystemLanguages.Where(m => m.Countries.Any(x => x.Equals(countryId))).ToList();
        }

        public Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId)
        {
            return DbContext.SystemLanguages.Where(m => m.Countries.Any(x => x.Equals(countryId))).ToListAsync();
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