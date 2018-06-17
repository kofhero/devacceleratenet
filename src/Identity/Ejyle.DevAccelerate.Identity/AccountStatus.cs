// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Identity
{
    /// <summary>
    /// Represents the status of a user or a tenant account.
    /// </summary>
    public enum AccountStatus
    {
        /// <summary>
        /// Account is not activve.
        /// </summary>
        Inactive = 0,
        /// <summary>
        /// Account is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Account is suspended.
        /// </summary>
        Suspended = 2,
        /// <summary>
        /// Account is closed.
        /// </summary>
        Closed = 3
    }
}
