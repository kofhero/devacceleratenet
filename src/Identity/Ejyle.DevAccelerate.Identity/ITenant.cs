﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the core interface for a tenant.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface ITenant<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the type of a tenant.
        /// </summary>
        TenantType TenantType { get; set; }

        /// <summary>
        /// Gets the name of a tenant.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the unique text key of a tenant.
        /// </summary>
        string TenantKey { get; set; }

        /// <summary>
        /// Gets the unique domain of a tenant.
        /// </summary>
        string Domain { get; set; }

        /// <summary>
        /// Determines if the domain's ownership is verified or not.
        /// </summary>
        bool IsDomainOwnershipVerified { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who owns the tenant.
        /// </summary>
        TKey OwnerUserId { get; set; }

        /// <summary>
        /// Gets or sets the status of the tenant.
        /// </summary>
        AccountStatus Status { get; set; }
    }
}
