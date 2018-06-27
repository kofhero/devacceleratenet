// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class RoleRepository : RoleRepository<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, AspNetIdentityDbContext>
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
    /// <typeparam name="TDbContext">The <see cref="DbContext"/> of the role repository.</typeparam>
    public class RoleRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext> : RoleStore<TRole, TKey, TUserRole>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession: UserSession<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleRepository{TContext}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> of the role repository.</param>
        public RoleRepository(TDbContext context)
            : base(context)
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
    }
}
