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
    public class GlobalTimeZoneRepository : GlobalTimeZoneRepository<int, int?, GlobalTimeZone, DateFormat, SystemLanguage, Currency, Country, CountryRegion, ListsDbContext>
    {
        public GlobalTimeZoneRepository(ListsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class GlobalTimeZoneRepository<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion, TDbContext>
        : EntityRepositoryBase<TKey, TGlobalTimeZone, TDbContext>, IGlobalTimeZoneRepository<TKey, TNullableKey, TGlobalTimeZone>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : GlobalTimeZone<TKey, TNullableKey, TDateFormat, TCountry>
        where TDateFormat : DateFormat<TKey, TNullableKey, TGlobalTimeZone>
        where TSystemLanguage : SystemLanguage<TKey, TCountry>
        where TCurrency : Currency<TKey, TCountry>
        where TCountry : Country<TKey, TNullableKey, TCurrency, TGlobalTimeZone, TCountryRegion, TSystemLanguage>
        where TCountryRegion : CountryRegion<TKey, TNullableKey, TCountryRegion, TCountry>
        where TDbContext : ListsDbContext<TKey, TNullableKey, TGlobalTimeZone, TDateFormat, TSystemLanguage, TCurrency, TCountry, TCountryRegion>
    {
        public GlobalTimeZoneRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public List<TGlobalTimeZone> FindAll()
        {
            return DbContext.GlobalTimeZones.ToList();
        }

        public Task<List<TGlobalTimeZone>> FindAllAsync()
        {
            return DbContext.GlobalTimeZones.ToListAsync();
        }

        public TGlobalTimeZone FindById(TKey id)
        {
            return DbContext.GlobalTimeZones.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TGlobalTimeZone> FindByIdAsync(TKey id)
        {
            return DbContext.GlobalTimeZones.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public List<TGlobalTimeZone> FindByCountryId(TKey countryId)
        {
            return DbContext.GlobalTimeZones.Where(m => m.Countries.Any(x => x.Equals(countryId))).ToList();
        }

        public Task<List<TGlobalTimeZone>> FindByCountryIdAsync(TKey countryId)
        {
            return DbContext.GlobalTimeZones.Where(m => m.Countries.Any(x => x.Equals(countryId))).ToListAsync();
        }
    }
}