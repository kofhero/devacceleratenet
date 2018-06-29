using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserSessionRepository : UserSessionRepository<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, AspNetIdentityDbContext>
    {
        public UserSessionRepository(AspNetIdentityDbContext dbContext)
            : base(dbContext)
        { }
    }

    public class UserSessionRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        : IUserSessionRepository<TKey, TUserSession>
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
        private TDbContext _dbContext;

        public UserSessionRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _dbContext = default(TDbContext);
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public Task CreateAsync(TUserSession userSession)
        {
            _dbContext.UserSessions.Add(userSession);
            return _dbContext.SaveChangesAsync();
        }

        public void Create(TUserSession userSession)
        {
            _dbContext.UserSessions.Add(userSession);
            _dbContext.SaveChanges(); ;
        }

        public Task<TUserSession> FindByIdAsync(TKey id)
        {
            return _dbContext.UserSessions.Where(m => m.Equals(id)).SingleOrDefaultAsync();
        }

        public TUserSession FindById(TKey id)
        {
            return _dbContext.UserSessions.Where(m => m.Equals(id)).SingleOrDefault();
        }

        public Task<TUserSession> FindByKeyAsync(string key)
        {
            return _dbContext.UserSessions.Where(m => m.SessionKey == key).SingleOrDefaultAsync();
        }

        public TUserSession FindByKey(string key)
        {
            return _dbContext.UserSessions.Where(m => m.SessionKey == key).SingleOrDefault();
        }
    }
}
