// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Apps
{
    public interface IAppRepository<TKey, TApp, TAppFeature> : IEntityRepository<TKey, TApp>
        where TKey : IEquatable<TKey>
        where TApp : IApp<TKey>
        where TAppFeature : IAppFeature<TKey>
    {
        Task<List<TApp>> FindAllAsync();
        List<TApp> FindAll();

        Task<TApp> FindByIdAsync(TKey id);
        TApp FindById(TKey id);

        Task<TApp> FindByKeyAsync(string key);
        TApp FindByKey(string key);
    }
}
