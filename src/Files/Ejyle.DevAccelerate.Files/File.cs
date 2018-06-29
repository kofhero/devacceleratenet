// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Files
{
    public class File<TKey, TFileLocation> : EntityBase<TKey>
        where TKey : IEquatable<TKey>
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
