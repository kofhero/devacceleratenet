using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps.Features
{
    public interface IFeature<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name { get; set; }
        string FeatureKey { get; set; }
    }
}
