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
