// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents an interface for a user session.
    /// </summary>
    /// <typeparam name="TKey">The type of a non-nullable key of an entity.</typeparam>
    public interface IUserSession<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the Id of the user associated with the session.
        /// </summary>
        TKey UserId { get; set; }

        /// <summary>
        /// Gets or sets the unique key of the session.
        /// </summary>
        string SessionKey { get; set; }

        /// <summary>
        /// Gets or sets the system session ID.
        /// </summary>
        string SystemSessionId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user session is created.
        /// </summary>
        DateTime CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of when the user session is expired.
        /// </summary>
        DateTime? ExpiryDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of when the user session actually got expired.
        /// </summary>
        DateTime? ExpiredDateUtc { get; set; }
    }
}
