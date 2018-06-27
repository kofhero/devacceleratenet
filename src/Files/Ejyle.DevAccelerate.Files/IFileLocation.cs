using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Files
{
    public interface IFileLocation<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        string Name
        {
            get;
            set;
        }
    }
}
