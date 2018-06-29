// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps.Features
{
    public class Feature : Feature<int>
    { }

    public class Feature<TKey> : EntityBase<TKey>, IFeature<TKey>
        where TKey : IEquatable<TKey>
    {
        public string Name { get; set; }
        public string FeatureKey { get; set; }
    }
}
