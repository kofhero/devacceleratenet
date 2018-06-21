using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
