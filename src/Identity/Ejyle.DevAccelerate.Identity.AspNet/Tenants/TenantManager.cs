// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class TenantManager : TenantManager<int, int?, Tenant, TenantUser, TenantRepository>
    {
        public TenantManager(TenantRepository repository)
            : base(repository)
        { }
    }

    public class TenantManager<TKey, TNullableKey, TTenant, TTenantUser, TTenantRepository>
        : IDisposable
        where TKey : IEquatable<TKey>
        where TTenant : ITenant<TKey, TNullableKey>
        where TTenantUser : ITenantUser<TKey>
        where TTenantRepository : ITenantRepository<TKey, TNullableKey, TTenant, TTenantUser>
    {
        private bool _disposed = false;

        public TenantManager(TTenantRepository repository)
        {
            Repository = repository;
        }

        protected TTenantRepository Repository { get; private set; } = default(TTenantRepository);

        public Task CreateAsync(TTenant tenant)
        {
            return Repository.CreateAsync(tenant);
        }

        public Task<TTenant> FindByIdAsync(TKey tenantId)
        {
            return Repository.FindByIdAsync(tenantId);
        }

        public void Create(TTenant tenant)
        {
            Repository.Create(tenant);
        }

        public void Update(TTenant tenant)
        {
            Repository.Update(tenant);
        }

        public TTenant FindById(TKey tenantId)
        {
            return Repository.FindById(tenantId);
        }

        public Task<TTenant> FindByKeyAsync(string tenantKey)
        {
            return Repository.FindByKeyAsync(tenantKey);
        }

        public TTenant FindByKey(string tenantKey)
        {
            return Repository.FindByKey(tenantKey);
        }

        public Task UpdateAsync(TTenant tenant)
        {
            return Repository.UpdateAsync(tenant);
        }

        public void CreateTenantUser(TTenantUser tenantUser)
        {
            Repository.CreateTenantUser(tenantUser);
        }

        public Task CreateTenantUserAsync(TTenantUser tenantUser)
        {
            return Repository.CreateTenantUserAsync(tenantUser);
        }

        public Task<List<TTenant>> FindByUserIdAsync(TKey userId)
        {
            return Repository.FindByUserIdAsync(userId);
        }

        public List<TTenant> FindByUserId(TKey userId)
        {
            return Repository.FindByUserId(userId);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                    Repository = default(TTenantRepository);
                }

                _disposed = true;
            }
        }
    }
}
