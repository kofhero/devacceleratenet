﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the association of a user with a tenant.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface ITenantUser<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        TKey UserId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the tenant.
        /// </summary>
        TKey TenantId { get; set; }

        /// <summary>
        /// Determines if the tenant and user association is active.
        /// </summary>
        bool IsActive { get; set; }
    }
}
