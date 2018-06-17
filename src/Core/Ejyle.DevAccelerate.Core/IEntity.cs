// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the basic interface for an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    public interface IEntity<TKey>
    {
        /// <summary>
        /// Gets or sets the unique ID of the entity.
        /// </summary>
        TKey Id
        {
            get;
            set;
        }
    }
}
