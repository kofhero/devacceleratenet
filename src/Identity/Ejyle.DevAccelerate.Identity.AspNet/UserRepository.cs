// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a repository for storing and retrieving users from an underlying data store.
    /// </summary>
    public class UserRepository : UserRepository<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, AspNetIdentityDbContext>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRepository{TContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The underlying <see cref="DbContext"/> used to commit changes in the underlying data store.</param>
        public UserRepository(AspNetIdentityDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// Asynchronously stores a new user in the underlying data store.
        /// </summary>
        /// <param name="user">The new user to store.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task CreateAsync(User user)
        {
            return base.CreateAsync(user);
        }
    }

    /// <summary>
    /// Represents a repository for storing and retrieving users from an underlying data store.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key of an entity.</typeparam>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TTenant">The type of an <see cref="ITenant{TKey}"/> entity.</typeparam>
    /// <typeparam name="TTenantUser">The type of an <see cref="ITenantUser{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserSession">The type of an <see cref="IUserSession{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserAgreement">The type of an <see cref="IUserAgreement{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserAgreementVersion">The type of an <see cref="IUserAgreementVersion{TKey}"/> entity.</typeparam>
    /// <typeparam name="TDbContext">The type of the data context representing the underlying data store.</typeparam>
    public class UserRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        : UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>,
        IUserRepository<TKey, TNullableKey, TUser, TUserSession>
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
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRepository{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext}"/> class.
        /// </summary>
        /// <param name="dbContext">The <see cref="DbContext"/> used to commit changes in the underlying data store.</param>
        public UserRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        /// <summary>
        /// Gets the instance of the repository's <see cref="DbContext"/>.
        /// </summary>
        protected TDbContext DaContext
        {
            get
            {
                return Context as TDbContext;
            }
        }

        /// <summary>
        /// Asynchronously creates a user.
        /// </summary>
        /// <param name="user">User to create.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task CreateAsync(TUser user)
        {
            user.CreatedDateUtc = DateTime.UtcNow;
            user.LastUpdatedDateUtc = DateTime.UtcNow;
            return base.CreateAsync(user);
        }

        /// <summary>
        /// Asynchronously update a user.
        /// </summary>
        /// <param name="user">User to be updated.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task UpdateAsync(TUser user)
        {
            user.LastUpdatedDateUtc = DateTime.UtcNow;
            return base.UpdateAsync(user);
        }

        /// <summary>
        /// Asynchronously creates a user session.
        /// </summary>
        /// <param name="userSession">User session to create.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task CreateUserSessionAsync(TUserSession userSession)
        {
            var context = Context as TDbContext;
            context.UserSessions.Add(userSession);
            return context.SaveChangesAsync();
        }

        public Task<TUserSession> FindUserSessionById(TKey userSessionId)
        {
            var context = Context as TDbContext;
            return context.UserSessions.Where(m => m.Id.Equals(userSessionId)).SingleOrDefaultAsync();
        }

        public Task<List<TUserSession>> FindUserSessionsByUserId(TKey userId)
        {
            var context = Context as TDbContext;
            return context.UserSessions.Where(m => m.UserId.Equals(userId)).ToListAsync();
        }
    }
}
