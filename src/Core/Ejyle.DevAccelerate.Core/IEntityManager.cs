// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the basic interface for managing an entity.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TEntityRepository">The type of the entity's repository.</typeparam>
    public interface IEntityManager<TKey, TEntity, TEntityRepository> : IDisposable
        where TEntity : IEntity<TKey>
        where TEntityRepository : IEntityRepository<TKey, TEntity>
    {
    }
}
