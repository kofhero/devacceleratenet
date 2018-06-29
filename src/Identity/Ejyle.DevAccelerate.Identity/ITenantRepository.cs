// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    public interface ITenantRepository<TKey, TNullableKey, TTenant, TTenantUser> : IEntityRepository<TKey, TTenant>
        where TKey : IEquatable<TKey>
        where TTenant : ITenant<TKey, TNullableKey>
        where TTenantUser : ITenantUser<TKey>
    {
        Task CreateAsync(TTenant tenant);
        void Create(TTenant tenant);

        Task UpdateAsync(TTenant tenant);
        void Update(TTenant tenant);

        Task<TTenant> FindByIdAsync(TKey tenantId);
        TTenant FindById(TKey tenantId);

        Task<TTenant> FindByKeyAsync(string tenantKey);
        TTenant FindByKey(string tenantKey);

        Task<List<TTenant>> FindByUserIdAsync(TKey userId);
        List<TTenant> FindByUserId(TKey userId);

        void CreateTenantUser(TTenantUser tenantUser);
        Task CreateTenantUserAsync(TTenantUser tenantUser);
    }
}
