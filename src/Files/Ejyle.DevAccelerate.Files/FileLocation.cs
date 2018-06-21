using Ejyle.DevAccelerate.Core;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Files
{
    public class FileLocation<TKey, TFile> : EntityBase<TKey>
        where TFile : IFile<TKey>
    {
        public FileLocation()
        {
            Files = new HashSet<TFile>();
        }

        public string Name
        {
            get;
            set;
        }

        public virtual ICollection<TFile> Files
        {
            get;
            set;
        }
    }
}
