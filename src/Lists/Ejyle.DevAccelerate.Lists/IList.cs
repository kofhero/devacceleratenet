// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists
{
    public interface IList<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        bool IsActive { get; set; }
    }
}
