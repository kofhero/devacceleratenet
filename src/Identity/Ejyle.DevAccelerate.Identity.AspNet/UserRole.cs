// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a user's role.
    /// </summary>
    public class UserRole : UserRole<int>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRole"/> class.
        /// </summary>
        public UserRole()
            : base()
        { }
    }

    /// <summary>
    /// Represents a user's role.
    /// </summary>
    /// <typeparam name="TKey">The type of the user and role IDs.</typeparam>
    public class UserRole<TKey> : IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Creates an instance of the <see cref="UserRole{TKey}"/> class.
        /// </summary>
        public UserRole()
            : base()
        { }
    }
}
