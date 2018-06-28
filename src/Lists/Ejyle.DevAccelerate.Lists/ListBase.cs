// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Lists
{
    public abstract class ListBase<TKey> : EntityBase<TKey>, IList<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
