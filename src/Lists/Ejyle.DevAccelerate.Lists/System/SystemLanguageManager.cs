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
    public class SystemLanguageManager : SystemLanguageManager<int, SystemLanguage, SystemLanguageRepository>
    {
        public SystemLanguageManager(SystemLanguageRepository repository)
            : base(repository)
        { }
    }

    public class SystemLanguageManager<TKey, TSystemLanguage, TRepository>
        : EntityManagerBase<TKey, TSystemLanguage, TRepository>
        where TKey : IEquatable<TKey>
        where TSystemLanguage : ISystemLanguage<TKey>
        where TRepository : ISystemLanguageRepository<TKey, TSystemLanguage>
    {
        public SystemLanguageManager(TRepository repository)
            : base(repository)
        { }

        public List<TSystemLanguage> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TSystemLanguage FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
        {
            return Repository.FindByIdAsync(id);
        }

        public List<TSystemLanguage> FindByCountryId(TKey countryId)
        {
            return Repository.FindByCountryId(countryId);
        }

        public Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId)
        {
            return Repository.FindByCountryIdAsync(countryId);
        }
    }
}