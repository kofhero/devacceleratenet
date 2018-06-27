using System;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps
{
    public interface IAppFeatureBundle<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey AppId { get; set; }
        TKey FeatureId { get; set; }
    }
}
