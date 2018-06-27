﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the basic interface for a user.
    /// </summary>
    /// <typeparam name="TKey">The type of a nullable key of an entity.</typeparam>
    /// <typeparam name="TNullableKey">The type of a nullable key of an entity.</typeparam>
    public interface IUser<TKey, TNullableKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the user's account.
        /// </summary>
        string Email { get; set; }
        
        /// <summary>
        /// Determines if the email address is confirmed.
        /// </summary>
        bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the hashed password.
        /// </summary>
        string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the security stamp of the user account.
        /// </summary>
        string SecurityStamp { get; set; }
        
        /// <summary>
        /// Gets or sets the user's phone number.
        /// </summary>
        string PhoneNumber { get; set; }
        
        /// <summary>
        /// Determines if the phone number is confirmed.
        /// </summary>
        bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Determines if the two-factor authentication is enabled for the user.
        /// </summary>
        bool TwoFactorEnabled { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time (in UTC) when user account is no longer considered locked out.
        /// </summary>
        DateTime? LockoutEndDateUtc { get; set; }
        
        /// <summary>
        /// Determines if the user account is locked out at the moment.
        /// </summary>
        bool LockoutEnabled { get; set; }
        
        /// <summary>
        /// Gets or sets the number of failed login attempts. It is used for lockout purposes.
        /// </summary>
        int AccessFailedCount { get; set; }

        /// <summary>
        /// Gets or sets the status of the user's account.
        /// </summary>
        AccountStatus Status { get; set; }

        /// <summary>
        /// Determines if the user is flagged as deleted. This property is used for soft-deletion mechanism.
        /// </summary>
        bool IsDeleted { get; set; }

        /// <summary>
        /// The ID of the user account which deleted the user through a soft deletion mechanism.
        /// </summary>
        TNullableKey DeletedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was deleted through a soft-deletion mechanism.
        /// </summary>
        DateTime? DeletedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account is created.
        /// </summary>
        DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time when the user account was last modified.
        /// </summary>
        DateTime LastUpdatedDateUtc { get; set; }
    }
}
