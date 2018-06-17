// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class RoleRepository : RoleRepository<string, User, Role, UserLogin, UserRole, UserClaim, AspNetIdentityDbContext>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleRepository{TContext}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> of the role repository.</param>
        public RoleRepository(AspNetIdentityDbContext context)
            : base(context)
        { }
    }

    /// <summary>
    /// Represents an extension for <see cref="RoleStore{TRole, TKey, TUserRole}"/> class.
    /// </summary>
    /// <typeparam name="TContext">The <see cref="DbContext"/> of the role repository.</typeparam>
    public class RoleRepository<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext> : RoleStore<TRole, TKey, TUserRole>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>
        where TContext : AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleRepository{TContext}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> of the role repository.</param>
        public RoleRepository(TContext context)
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
    }
}
