// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Lists.Geography;
using Ejyle.DevAccelerate.Lists.System;

namespace Ejyle.DevAccelerate.Lists
{
    public class CurrencyRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext> : ICurrencyRepository<TKey, TCurrency>
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

        public CurrencyRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext
        {
            get;
            private set;
        }

        public List<TCurrency> FindAll()
        {
            return DbContext.Currencies.ToList();
        }

        public Task<List<TCurrency>> FindAllAsync()
        {
            return DbContext.Currencies.ToListAsync();
        }

        public TCurrency FindById(TKey id)
        {
            return DbContext.Currencies.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TCurrency> FindByIdAsync(TKey id)
        {
            return DbContext.Currencies.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
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
