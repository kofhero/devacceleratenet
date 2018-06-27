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
