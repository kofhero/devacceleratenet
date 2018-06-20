// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Ejyle.DevAccelerate.Identity.Configuration;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    public class UserManager : UserManager<string, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserRepository, AspNetIdentityDbContext>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserManager"/> class.
        /// </summary>
        /// <param name="repository">The user repository to be used by <see cref="UserManager"/>.</param>
        public UserManager(UserRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="UserManager"/> class from the current OWIN context.
        /// </summary>
        /// <param name="options">Configuration otpions for identity factory middleware.</param>
        /// <param name="context">Current OWIN context.</param>
        /// <returns>Returns an instance of the <see cref="UserManager"/> class.</returns>
        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(new UserRepository(context.Get<AspNetIdentityDbContext>()));

            var configSection = DaApplicationContext.GetConfiguration<IdentityConfigurationSection>("daIdentityConfiguration");

            if (configSection != null)
            {
                var userNamePolicy = configSection.UserNamePolicy;

                if (userNamePolicy != null)
                {
                    manager.UserValidator = new UserValidator<User>(manager)
                    {
                        AllowOnlyAlphanumericUserNames = userNamePolicy.AllowOnlyAlphanumericUserNames,
                        RequireUniqueEmail = userNamePolicy.RequireUniqueEmail
                    };
                }

                var passwordPolicy = configSection.PasswordPolicy;

                if (passwordPolicy != null)
                {
                    manager.PasswordValidator = new PasswordValidator
                    {
                        RequiredLength = passwordPolicy.MinRequiredLength,
                        RequireNonLetterOrDigit = passwordPolicy.RequireSpecialCharacters,
                        RequireDigit = passwordPolicy.RequireDigits,
                        RequireLowercase = passwordPolicy.RequireLowerCase,
                        RequireUppercase = passwordPolicy.RequireUpperCase,
                    };
                }

                var userLockoutPolicy = configSection.UserLockoutPolicy;

                if (userLockoutPolicy != null)
                {
                    manager.UserLockoutEnabledByDefault = userLockoutPolicy.UserLockoutEnabledByDefault;
                    manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(userLockoutPolicy.DefaultLockoutTimeSpan);
                    manager.MaxFailedAccessAttemptsBeforeLockout = userLockoutPolicy.MaxFailedAccessAttemptsBeforeLockout;
                }
            }

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;

            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    /// <typeparam name="TKey">The type of the user ID.</typeparam>
    /// <typeparam name="TUser">The type of a user entity.</typeparam>
    /// <typeparam name="TRole">The type of a role entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of a user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of a user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of a user claim entity.</typeparam>
    /// <typeparam name="TRepository">The type of the user repository entity.</typeparam>
    /// <typeparam name="TContext">The type fo the database context for identity.</typeparam>
    public class UserManager<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TRepository, TContext> : Microsoft.AspNet.Identity.UserManager<TUser, TKey>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TUserLogin, TUserRole, TUserClaim>
        where TRole: Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TTenant, TUser>
        where TRepository: UserRepository<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TContext>
        where TContext : AspNetIdentityDbContext<TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserManager{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRepository, TContext}"/> class.
        /// </summary>
        /// <param name="repository">The user repository to be used by the <see cref="UserManager{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRepository, TContext}"/>.</param>
        public UserManager(TRepository repository)
            : base(repository)
        {
        }
    }
}
