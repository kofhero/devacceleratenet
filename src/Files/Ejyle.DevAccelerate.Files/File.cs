using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Files
{
    public class File<TKey, TFileLocation> : EntityBase<TKey>
        where TFileLocation : IFileLocation<TKey>
    {
        public string Name
        {
            get;
            set;
        }

        public FileType FileType
        {
            get;
            set;
        }

        public string MimeType
        {
            get;
            set;
        }

        public TKey FileLocationId
        {
            get;
            set;
        }

        public virtual TFileLocation FileContainer
        {
            get;
            set;
        }
    }
}
