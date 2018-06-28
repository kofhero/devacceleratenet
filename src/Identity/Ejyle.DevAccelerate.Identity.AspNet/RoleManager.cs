// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class RoleManager : RoleManager<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, RoleRepository, AspNetIdentityDbContext>
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
    /// <typeparam name="TRoleRepository">The role repository.</typeparam>
    /// <typeparam name="TDbContext">The <see cref="DbContext"/> of the role repository.</typeparam>
    public class RoleManager<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TRoleRepository, TDbContext> : Microsoft.AspNet.Identity.RoleManager<TRole, TKey>
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
        where TRoleRepository: RoleRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="RoleManager{TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="repository">The repository that saves changes to a role.</param>
        public RoleManager(TRoleRepository repository)
            : base(repository)
        {
        }
    }
}
