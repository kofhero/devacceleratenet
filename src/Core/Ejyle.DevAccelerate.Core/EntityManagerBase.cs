// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Core
{
    /// <summary>
    /// Represents the base class for entity managers with common properties and methods.
    /// </summary>
    /// <typeparam name="TKey">The type of the entity's ID.</typeparam>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TEntityRepository">The type of the entity repository.</typeparam>
    public class EntityManagerBase<TKey, TEntity, TEntityRepository> : IEntityManager<TKey, TEntity, TEntityRepository>
        where TEntity : IEntity<TKey>
        where TEntityRepository : IEntityRepository<TKey, TEntity>
    {
        private bool _isDisposed = false;

        /// <summary>
        /// Creates an instance of the <see cref="EntityRepositoryBase{TKey, TEntity, TDbContext}"/> class.
        /// </summary>
        /// <param name="repository">The repository to be used by the entity manager.</param>
        /// <remarks>The <see cref="TEntityRepository"/> argument cannot be null.</remarks>
        public EntityManagerBase(TEntityRepository repository)
        {
            if(repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            Repository = repository;
        }

        /// <summary>
        /// Gets the <see cref="TEntityRepository"/> used by entity manager.
        /// </summary>
        protected TEntityRepository Repository { get; private set; }

        /// <summary>
        /// Disposes the resources of the entity manager. Do not call this method explicitly.
        /// </summary>
        /// <param name="disposing">Determines if the resources are being disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                    Repository = default(TEntityRepository);
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the resources of the entity manager.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
