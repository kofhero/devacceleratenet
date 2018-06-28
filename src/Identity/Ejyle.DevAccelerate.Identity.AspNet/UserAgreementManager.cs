// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserAgreementManagery<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TUserAgreementRepository, TDbContext>
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
        where TUserAgreementRepository : UserAgreementRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        private bool _disposed = false;

        public UserAgreementManagery(TUserAgreementRepository repository)
        {
            Repository = repository;
        }

        protected TUserAgreementRepository Repository { get; private set; } = default(TUserAgreementRepository);

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            return Repository.CreateAsync(userAgreement);
        }

        public Task<TUserAgreement> FindByIdAsync(TKey userAgreementId)
        {
            return Repository.FindByIdAsync(userAgreementId);
        }

        public Task<TUserAgreement> FindByKey(string userAgreementKey)
        {
            return Repository.FindByKey(userAgreementKey);
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            return Repository.UpdateAsync(userAgreement);
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
