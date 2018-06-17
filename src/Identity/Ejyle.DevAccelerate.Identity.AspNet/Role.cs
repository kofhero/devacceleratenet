// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents the non-generics version of the <see cref="Role{TKey, TOptionalKey, TUserRole}"/> class.
    /// </summary>
    public class Role : Role<string, UserRole>
    {
        /// <summary>
        /// Creates an instance of the <see cref="Role"/> class.
        /// </summary>
        public Role()
            : base()
        { }
    }

    /// <summary>
    /// Represents a role.
    /// </summary>
    /// <typeparam name="TKey">The type of the role ID.</typeparam>
    /// <typeparam name="TOptionalKey">The type of an optional ID.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    public class Role<TKey, TUserRole> : IdentityRole<TKey, TUserRole>, IRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserRole : UserRole<TKey>
    {
        /// <summary>
        /// Creates an instance of the Role class.
        /// </summary>
        public Role()
            : base()
        { }
    }
}
