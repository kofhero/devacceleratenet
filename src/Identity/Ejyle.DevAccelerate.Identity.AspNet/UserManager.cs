// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Ejyle.DevAccelerate.Core;
using Ejyle.DevAccelerate.Identity.AspNet.Tenants;
using Ejyle.DevAccelerate.Identity.Configuration;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    public class UserManager : UserManager<int, int?, User, Role, UserLogin, UserRole, UserClaim, Tenant, TenantUser, UserSession, UserAgreement, UserAgreementVersion, UserRepository, AspNetIdentityDbContext>
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
                    manager.UserValidator = new UserValidator<User, int>(manager)
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

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<User, int>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<User, int>
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
                    new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }

    /// <summary>
    /// Represents the core functionality for creating and managing user accounts.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key of an entity.</typeparam>
    /// <typeparam name="TUser">The type of a user entity.</typeparam>
    /// <typeparam name="TRole">The type of a role entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of a user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of a user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of a user claim entity.</typeparam>
    /// <typeparam name="TTenant">The type of an <see cref="ITenant{TKey}"/> entity.</typeparam>
    /// <typeparam name="TTenantUser">The type of an <see cref="ITenantUser{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserAgreement">The type of an <see cref="IUserAgreement{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserAgreementVersion">The type of an <see cref="IUserAgreementVersion{TKey}"/> entity.</typeparam>
    /// <typeparam name="TUserRepository">The type of the user repository entity.</typeparam>
    /// <typeparam name="TDbContext">The type fo the database context for identity.</typeparam>
    public class UserManager<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TUserRepository, TDbContext> : Microsoft.AspNet.Identity.UserManager<TUser, TKey>
        where TKey : IEquatable<TKey>
        where TUser : User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim>
        where TRole: Role<TKey, TUserRole>, new()
        where TUserLogin : UserLogin<TKey>, new()
        where TUserRole : UserRole<TKey>, new()
        where TUserClaim : UserClaim<TKey>, new()
        where TTenant : Tenant<TKey, TTenantUser>
        where TTenantUser : TenantUser<TKey, TNullableKey, TTenant, TUser>
        where TUserSession : UserSession<TKey>
        where TUserAgreement: UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TUserRepository: UserRepository<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion, TDbContext>
        where TDbContext : AspNetIdentityDbContext<TKey, TNullableKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TTenant, TTenantUser, TUserSession, TUserAgreement, TUserAgreementVersion>
    {
        /// <summary>
        /// Creates an instance of the <see cref="User{TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim}"/> class.
        /// </summary>
        /// <param name="repository">The user repository to be used by the <see cref="UserManager{TKey, TUser, TRole, TUserLogin, TUserRole, TUserClaim, TRepository, TContext}"/>.</param>
        public UserManager(TUserRepository repository)
            : base(repository)
        {
        }
    }
}
