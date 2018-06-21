using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Files
{
    public interface IFile<TKey> : IEntity<TKey>
    {
        string Name
        {
            get;
            set;
        }

        FileType FileType
        {
            get;
            set;
        }

        string MimeType
        {
            get;
            set;
        }

        TKey FileLocationId
        {
            get;
            set;
        }
    }
}
