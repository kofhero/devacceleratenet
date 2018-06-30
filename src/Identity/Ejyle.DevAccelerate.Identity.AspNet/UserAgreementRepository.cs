// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EntityFramework;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserAgreementRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        : EntityRepositoryBase<TKey, TUserAgreement, TDbContext>, IUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion>
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
        public UserAgreementRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            DbContext.UserAgreements.Add(userAgreement);
            return DbContext.SaveChangesAsync();
        }

        public Task<TUserAgreement> FindByIdAsync(TKey userAgreementId)
        {
            return DbContext.UserAgreements.Where(m => m.Id.Equals(userAgreementId)).SingleOrDefaultAsync();
        }

        public Task<TUserAgreement> FindByKey(string userAgreementKey)
        {
            return DbContext.UserAgreements.Where(m => m.UserAgreementKey == userAgreementKey).SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            DbContext.Entry(userAgreement).State = EntityState.Modified;
            return DbContext.SaveChangesAsync();
        }
    }
}
