using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps
{
    public interface IAppFeature<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey AppId { get; set; }
        TKey FeatureId { get; set; }
        bool IsActive { get; set; }
    }
}
