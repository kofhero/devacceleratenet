// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps
{ 
    public class AppManager : AppManager<int, App, AppFeature, AppRepository>
    {
        public AppManager(AppRepository repository)
            : base(repository)
        { }

        public AppManager()
            : base(new AppRepository(new AppsDbContext()))
        { }
    }

    public class AppManager<TKey, TApp, TAppFeature, TAppRepository> : EntityManagerBase<TKey, TApp, TAppRepository>
        where TKey : IEquatable<TKey>
        where TApp : IApp<TKey>
        where TAppFeature : IAppFeature<TKey>
        where TAppRepository : IAppRepository<TKey, TApp, TAppFeature>
    {
        public AppManager(TAppRepository repository) : base(repository)
        { }

        public List<TApp> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TApp>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TApp FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TApp> FindByIdAsync(TKey id)
        {
            return FindByIdAsync(id);
        }

        public TApp FindByKey(string key)
        {
            return Repository.FindByKey(key);
        }

        public Task<TApp> FindByKeyAsync(string key)
        {
            return Repository.FindByKeyAsync(key);
        }
    }
}
