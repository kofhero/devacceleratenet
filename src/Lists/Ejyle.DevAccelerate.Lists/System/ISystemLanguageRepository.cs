// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public interface ISystemLanguageRepository<TKey, TSystemLanguage> : IEntityRepository<TKey, TSystemLanguage>
        where TKey : IEquatable<TKey>
        where TSystemLanguage : ISystemLanguage<TKey>
    {
        TSystemLanguage FindById(TKey id);
        Task<TSystemLanguage> FindByIdAsync(TKey id);

        List<TSystemLanguage> FindAll();
        Task<List<TSystemLanguage>> FindAllAsync();

        List<TSystemLanguage> FindByCountryId(TKey countryId);
        Task<List<TSystemLanguage>> FindByCountryIdAsync(TKey countryId);
    }
}