// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a user with <see cref="int"/> as key type.
    /// </summary>
    public class User : User<int, int?, UserLogin, UserRole, UserClaim>
    { }

    /// <summary>
    /// Represents a user.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key of an entity.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login entity.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role entity.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim entity.</typeparam>
    public class User<TKey, TNullableKey, TUserLogin, TUserRole, TUserClaim> : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim>, IUser<TKey, TNullableKey>
        where TKey : IEquatable<TKey>
        where TUserLogin: UserLogin<TKey>
        where TUserRole: UserRole<TKey>
        where TUserClaim: UserClaim<TKey>
    {
        /// <summary>
        /// Gets or sets the status of the user account.
        /// </summary>
        public AccountStatus Status { get; set; }

        /// <summary>
        /// Determines if the user is flagged as deleted. This property is used for soft-deletion mechanism.
        /// </summary>
        [Required]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The ID of the user account which deleted the user through a soft deletion mechanism.
        /// </summary>
        public TNullableKey DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was deleted through a soft-deletion mechanism.
        /// </summary>
        public DateTime? DeletedDateUtc { get; set; }

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
