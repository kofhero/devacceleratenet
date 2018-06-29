// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;

namespace Ejyle.DevAccelerate.Files
{
    public interface IFile<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
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
