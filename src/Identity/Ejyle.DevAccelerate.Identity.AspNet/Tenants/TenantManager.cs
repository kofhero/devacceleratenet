using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Identity.AspNet.Tenants
{
    public class TenantManagery<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TTenantRepository, TDbContext>
        : IDisposable
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession : UserSession<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TTenantRepository : TenantRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
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
                    Repository = null;
                }

                _disposed = true;
            }
        }
    }
}
