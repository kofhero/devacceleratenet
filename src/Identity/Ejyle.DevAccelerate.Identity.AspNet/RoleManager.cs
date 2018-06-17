// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class RoleManager : RoleManager<string, User, Role, UserLogin, UserRole, UserClaim, RoleRepository, AspNetIdentityDbContext>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleManager{TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="repository">The repository that saves changes to a role.</param>
        public RoleManager(RoleRepository repository)
            : base(repository)
        {
        }
    }

    /// <summary>
    /// Represents an extension for <see cref="Microsoft.AspNet.Identity.RoleManager{TRole, TKey}"/> class.
    /// </summary>
    /// <typeparam name="TRepository">The role repository.</typeparam>
    /// <typeparam name="TContext">The <see cref="DbContext"/> of the role repository.</typeparam>
    public class RoleManager<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRepository, TContext> : Microsoft.AspNet.Identity.RoleManager<TRole, TKey>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TRepository: RoleRepository<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TContext>
        where TContext : AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleManager{TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="repository">The repository that saves changes to a role.</param>
        public RoleManager(TRepository repository)
            : base(repository)
        {
        }
    }
}
