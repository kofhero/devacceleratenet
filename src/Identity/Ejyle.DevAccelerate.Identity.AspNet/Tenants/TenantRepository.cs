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
    public class TenantRepository : TenantRepository<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, AspNetIdentityDbContext>
    {
        public TenantRepository(AspNetIdentityDbContext dbContext)
            : base(dbContext)
        {

        }
    }

    public class TenantRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        : ITenantRepository<TKey, TNullableKey, TTenant, TTenantUser>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TNullableKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession : UserSession<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        private bool _disposed = false;

        public TenantRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected TDbContext DbContext { get; private set; } = default(TDbContext);

        public Task CreateAsync(TTenant tenant)
        {
            DbContext.Tenants.Add(tenant);
            return DbContext.SaveChangesAsync();
        }

        public void Create(TTenant tenant)
        {
            DbContext.Tenants.Add(tenant);
            DbContext.SaveChanges();
        }

        public void Update(TTenant tenant)
        {
            DbContext.Entry(tenant).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        public TTenant FindById(TKey tenantId)
        {
            return DbContext.Tenants.Where(m => m.Id.Equals(tenantId)).SingleOrDefault();
        }

        public Task<TTenant> FindByKeyAsync(string tenantKey)
        {
            return DbContext.Tenants.Where(m => m.TenantKey == tenantKey).SingleOrDefaultAsync();
        }

        public TTenant FindByKey(string tenantKey)
        {
            return DbContext.Tenants.Where(m => m.TenantKey == tenantKey).SingleOrDefault();
        }

        public Task<TTenant> FindByIdAsync(TKey tenantId)
        {
            return DbContext.Tenants.Where(m => m.Id.Equals(tenantId)).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TTenant tenant)
        {
            DbContext.Entry(tenant).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }

        public void CreateTenantUser(TTenantUser tenantUser)
        {
            DbContext.TenantUsers.Add(tenantUser);
            DbContext.SaveChanges();
        }

        public Task CreateTenantUserAsync(TTenantUser tenantUser)
        {
            DbContext.TenantUsers.Add(tenantUser);
            return DbContext.SaveChangesAsync();
        }

        public Task<List<TTenant>> FindByUserIdAsync(TKey userId)
        {
            return DbContext.Tenants.Where(m => m.TenantUsers.Any(x => x.UserId.Equals(userId))).ToListAsync();
        }

        public List<TTenant> FindByUserId(TKey userId)
        {
            return DbContext.Tenants.Where(m => m.TenantUsers.Any(x => x.UserId.Equals(userId))).ToList();
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
                    DbContext.Dispose();
                    DbContext = null;
                }

                _disposed = true;
            }
        }
    }
}
