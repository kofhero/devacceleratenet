﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class GlobalTimeZoneManager : GlobalTimeZoneManager<int, int?, GlobalTimeZone, GlobalTimeZoneRepository>
    {
        public GlobalTimeZoneManager(GlobalTimeZoneRepository repository)
            : base(repository)
        { }
    }

    public class GlobalTimeZoneManager<TKey, TNullableKey, TGlobalTimeZone, TRepository>
        : EntityManagerBase<TKey, TGlobalTimeZone, TRepository>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : IGlobalTimeZone<TKey, TNullableKey>
        where TRepository : IGlobalTimeZoneRepository<TKey, TNullableKey, TGlobalTimeZone>
    {
        private bool _isDisposed = false;

        public GlobalTimeZoneManager(TRepository repository)
            : base(repository)
        { }

        public List<TGlobalTimeZone> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TGlobalTimeZone>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TGlobalTimeZone FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TGlobalTimeZone> FindByIdAsync(TKey id)
        {
            return Repository.FindByIdAsync(id);
        }

        public List<TGlobalTimeZone> FindByCountryId(TKey countryId)
        {
            return Repository.FindByCountryId(countryId);
        }

        public Task<List<TGlobalTimeZone>> FindByCountryIdAsync(TKey countryId)
        {
            return Repository.FindByCountryIdAsync(countryId);
        }
    }
}