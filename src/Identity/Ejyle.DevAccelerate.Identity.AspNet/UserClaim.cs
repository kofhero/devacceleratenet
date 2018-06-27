// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a user's claim in the system.
    /// </summary>
    public class UserClaim : UserClaim<int>
    { }

    /// <summary>
    /// Represents a user's claim in the system.
    /// </summary>
    /// <typeparam name="TKey">The Type of the user ID.</typeparam>
    public class UserClaim<TKey> : IdentityUserClaim<TKey>
        where TKey : IEquatable<TKey>
    { }
}
