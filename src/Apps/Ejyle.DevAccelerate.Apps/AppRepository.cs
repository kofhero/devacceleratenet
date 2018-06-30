// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;
using Ejyle.DevAccelerate.Core.EntityFramework;

namespace Ejyle.DevAccelerate.Apps
{
    public class AppRepository : AppRepository<int, App, AppFeature, AppsDbContext>
    {
        public AppRepository(AppsDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class AppRepository<TKey, TApp, TAppFeature, TDbContext>
        : EntityRepositoryBase<TKey, TAppFeature, TDbContext>, IAppRepository<TKey, TApp, TAppFeature>
        where TKey : IEquatable<TKey>
        where TApp : App<TKey, TAppFeature>
        where TAppFeature : AppFeature<TKey, TApp>
        where TDbContext : AppsDbContext<TKey, TApp, TAppFeature>
    {
        public AppRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public List<TApp> FindAll()
        {
            return DbContext.Apps.ToList();
        }

        public Task<List<TApp>> FindAllAsync()
        {
            return DbContext.Apps.ToListAsync();
        }

        public TApp FindById(TKey id)
        {
            return DbContext.Apps.Where(m => m.Id.Equals(id)).SingleOrDefault();
        }

        public Task<TApp> FindByIdAsync(TKey id)
        {
            return DbContext.Apps.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public TApp FindByKey(string key)
        {
            return DbContext.Apps.Where(m => m.AppKey == key).SingleOrDefault();
        }

        public Task<TApp> FindByKeyAsync(string key)
        {
            return DbContext.Apps.Where(m => m.AppKey == key).SingleOrDefaultAsync();
        }
    }
}
