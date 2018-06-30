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
using Ejyle.DevAccelerate.Core.EntityFramework;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class DateFormatRepository : DateFormatRepository<int, int?, GlobalTimeZone, DateFormat, SystemLanguage, Currency, Country, CountryRegion, ListsDbContext>
    {
        public DateFormatRepository(ListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class DateFormatRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : EntityRepositoryBase<TKey, TDateFormat, TDbContext>, IDateFormatRepository<TKey, TDateFormat>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry>
        where TDateFormat : DateFormat<TKey, TNullableKey, TGlobalTimeZone>
        where TSystemLanguage : SystemLanguage<TKey, TCountry>
        where TCurrency : Currency<TKey, TCountry>
        where TCountry : Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : ListsDbContext<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        public DateFormatRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public List<TDateFormat> FindAll()
        {
            return DbContext.DateFormats.ToList();
        }

        public Task<List<TDateFormat>> FindAllAsync()
        {
            return DbContext.DateFormats.ToListAsync();
        }

        public TDateFormat FindById(TKey id)
        {
            return DbContext.DateFormats.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TDateFormat> FindByIdAsync(TKey id)
        {
            return DbContext.DateFormats.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public TDateFormat FindByDateFormatExpression(string expr)
        {
            return DbContext.DateFormats.Where(m => m.DateFormatExpression == expr).SingleOrDefault();
        }

        public Task<TDateFormat> FindByDateFormatExpressionAsync(string expr)
        {
            return DbContext.DateFormats.Where(m => m.DateFormatExpression == expr).SingleOrDefaultAsync();
        }
    }
}