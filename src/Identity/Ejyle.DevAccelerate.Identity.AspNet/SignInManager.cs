// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class SignInManager : SignInManager<string, UserManager, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserRepository, AspNetIdentityDbContext>
    {
        public SignInManager(UserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((UserManager)this.UserManager);
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class SignInManager<TKey, TUserManager, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TRepository, TContext> : SignInManager<TUser, TKey>
        where TKey : IEquatable<TKey>
        where TUserManager : UserManager<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TRepository, TContext>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole : Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TTenant, TUser>
        where TRepository : UserRepository<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TContext>
        where TContext : AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser>
    {
        public SignInManager(TUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static SignInManager Create(IdentityFactoryOptions<SignInManager> options, IOwinContext context)
        {
            return new SignInManager(context.GetUserManager<UserManager>(), context.Authentication);
        }
    }
}
