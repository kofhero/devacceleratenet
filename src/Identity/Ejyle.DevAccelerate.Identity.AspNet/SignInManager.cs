// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the core functionality for signing in and signing out users.
    /// </summary>
    /// <typeparam name="TKey">The type of a main entity key.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable entity key.</typeparam>
    /// <typeparam name="TUserManager">The type of a user manager class.</typeparam>
    /// <typeparam name="TUser">The type of a <see cref="IUser{TKey, TNullableKey}"/> entity.</typeparam>
    /// <typeparam name="TRole">The type of a <see cref="IRole{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of a user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of a user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of a user claim entity.</typeparam>
    /// <typeparam name="TTenant">The type of a tenant entity.</typeparam>
    /// <typeparam name="TTenantUser">The type of a tenant user.</typeparam>
    /// <typeparam name="TUserAgreement">The type of a <see cref="IUserAgreement{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserAgreementVersion">The type of a <see cref="IUserAgreementVersion{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserRepository">The type of a user repository.</typeparam>
    /// <typeparam name="TDbContext">The type of a <see cref="AspNetIdentityDbContext"/> database context.</typeparam>
    public class SignInManager<TKey, TNullableKey, TUserManager, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TUserRepository, TDbContext> : SignInManager<TUser, TKey>
        where TKey : IEquatable<TKey>
        where TUserManager : UserManager<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TUserRepository, TDbContext>
        where TUser : User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TNullableKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession: UserSession<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TUserRepository : UserRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="SignInManager{TKey, TNullableKey, TUserManager, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserAgreement, TUserAgreementVersion, TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="userManager">An instance of the <see cref="TUserManager"/> class.</param>
        /// <param name="authenticationManager">An instance of the <see cref="IAuthenticationManager"/> type.</param>
        public SignInManager(TUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}
