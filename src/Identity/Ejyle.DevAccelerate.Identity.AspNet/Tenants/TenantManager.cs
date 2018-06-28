// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class TenantManagery<TKey, TNullableKey, TTenant, TTenantUser, TTenantRepository>
        : IDisposable
        where TKey : IEquatable<TKey>
        where TTenant : ITenant<TKey, TNullableKey>
        where TTenantUser : ITenantUser<TKey>
        where TTenantRepository : ITenantRepository<TKey, TNullableKey, TTenant, TTenantUser>
    {
        private bool _disposed = false;

        public TenantManagery(TTenantRepository repository)
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

        public Task<TTenant> FindByKey(string tenantKey)
        {
            return Repository.FindByKey(tenantKey);
        }

        public Task UpdateAsync(TTenant tenant)
        {
            return Repository.UpdateAsync(tenant);
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
