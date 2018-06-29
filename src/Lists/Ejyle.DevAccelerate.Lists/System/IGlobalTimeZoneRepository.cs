// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public interface IGlobalTimeZoneRepository<TKey, TNullableKey, TGlobalTimeZone> : IEntityRepository<TKey, TGlobalTimeZone>
        where TKey : IEquatable<TKey>
        where TGlobalTimeZone : IGlobalTimeZone<TKey, TNullableKey>
    {
        TGlobalTimeZone FindById(TKey id);
        Task<TGlobalTimeZone> FindByIdAsync(TKey id);

        List<TGlobalTimeZone> FindAll();
        Task<List<TGlobalTimeZone>> FindAllAsync();

        List<TGlobalTimeZone> FindByCountryId(TKey countryId);
        Task<List<TGlobalTimeZone>> FindByCountryIdAsync(TKey countryId);
    }
}