// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    /// <summary>
    /// Represents a user's external login.
    /// </summary>
    public class UserLogin : UserLogin<string>
    { }

    /// <summary>
    /// Represents a user's external login.
    /// </summary>
    /// <typeparam name="TKey">The type of the user ID.</typeparam>
    public class UserLogin<TKey> : IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>
    { }
}
