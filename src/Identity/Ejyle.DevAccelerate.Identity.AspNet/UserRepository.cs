// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a repository for storing and retrieving users from an underlying data store.
    /// </summary>
    public class UserRepository : UserRepository<string, User, Role, UserLogin, UserRole, UserClaim, AspNetIdentityDbContext>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRepository{TContext}"/> class.
        /// </summary>
        /// <param name="context">The underlying <see cref="DbContext"/> used to commit changes in the underlying data store.</param>
        public UserRepository(AspNetIdentityDbContext context)
            : base(context)
        { }

        /// <summary>
        /// Asynchronously stores a new user in the underlying data store.
        /// </summary>
        /// <param name="user">The new user to store.</param>
        /// <returns>The task representing the asynchronous operation.</returns>
        public override Task CreateAsync(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            return base.CreateAsync(user);
        }
    }

    /// <summary>
    /// Represents a repository for storing and retrieving users from an underlying data store.
    /// </summary>
    /// <typeparam name="TKey">The type of the user ID.</typeparam>
    /// <typeparam name="TUser">The type of the user entity.</typeparam>
    /// <typeparam name="TRole">The type of the role entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TContext">The type of the data context representing the underlying data store.</typeparam>
    public class UserRepository<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext> : UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TContext : AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRepository{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> used to commit changes in the underlying data store.</param>
        public UserRepository(TContext context)
            : base(context)
        { }

        /// <summary>
        /// Gets the instance of the repository's <see cref="DbContext"/>.
        /// </summary>
        protected TContext DaContext
        {
            get
            {
                return Context as TContext;
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
    }
}
