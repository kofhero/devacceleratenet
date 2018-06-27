﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the base class for an entity. The type of the entity ID is Integer.
    /// </summary>
    public abstract class EntityBase : EntityBase<int>
    { }

    /// <summary>
    /// Represents the base class for an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public abstract class EntityBase<TKey> : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        [Key]
        public TKey Id
        {
            get;
            set;
        }
    }
}
