// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Files
{
    public class FileLocation<TKey, TFile> : EntityBase<TKey>
        where TKey : IEquatable<TKey>
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
