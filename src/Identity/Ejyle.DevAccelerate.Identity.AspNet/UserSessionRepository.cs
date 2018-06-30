// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using System;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserSessionRepository : UserSessionRepository<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, AspNetIdentityDbContext>
    {
        public UserSessionRepository(AspNetIdentityDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class UserSessionRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        : EntityRepositoryBase<TKey, TUserSession, TDbContext>, IUserSessionRepository<TKey, TUserSession>
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
        public UserSessionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        public Task CreateAsync(TUserSession userSession)
        {
            DbContext.UserSessions.Add(userSession);
            return DbContext.SaveChangesAsync();
        }

        public void Create(TUserSession userSession)
        {
            DbContext.UserSessions.Add(userSession);
            DbContext.SaveChanges(); ;
        }

        public Task<TUserSession> FindByIdAsync(TKey id)
        {
            return DbContext.UserSessions.Where(m => m.Equals(id)).SingleOrDefaultAsync();
        }

        public TUserSession FindById(TKey id)
        {
            return DbContext.UserSessions.Where(m => m.Equals(id)).SingleOrDefault();
        }

        public Task<TUserSession> FindByKeyAsync(string key)
        {
            return DbContext.UserSessions.Where(m => m.SessionKey == key).SingleOrDefaultAsync();
        }

        public TUserSession FindByKey(string key)
        {
            return DbContext.UserSessions.Where(m => m.SessionKey == key).SingleOrDefault();
        }
    }
}
