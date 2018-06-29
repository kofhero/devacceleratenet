// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps
{
    public interface IApp<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string AppKey { get; set; }
    }
}
