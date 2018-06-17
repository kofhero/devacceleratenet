// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class User : User<string, UserLogin, UserRole, UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    /// <summary>
    /// Represents a user.
    /// </summary>
    /// <typeparam name="TKey">The type of the user ID.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim entity.</typeparam>
    public class User<TKey, TUserLogin, TUserRole, TUserClaim> : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>, IUser<TKey>
        where TKey: IEquatable<TKey>
        where TUserLogin: UserLogin<TKey>
        where TUserRole: UserRole<TKey>
        where TUserClaim: UserClaim<TKey>
    {
        /// <summary>
        /// Gets or sets the status of the user account.
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account is created.
        /// </summary>
        public DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account was last modified.
        /// </summary>
        public DateTime LastUpdatedDateUtc { get; set; }
    }
}
