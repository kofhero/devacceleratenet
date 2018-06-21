using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Files
{
    public interface IFileLocation<TKey> : IEntity<TKey>
    {
        string Name
        {
            get;
            set;
        }
    }
}
