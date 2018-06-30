// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Core.EntityFramework
{
    public abstract class EntityRepositoryBase<TKey, TEntity, TDbContext> : IEntityRepository<TKey, TEntity>
        where TKey : IEquatable<TKey>
        where TEntity : IEntity<TKey>
        where TDbContext : DbContext
    {
        private bool _isDisposed = false;
        private TDbContext _dbContext;
        private bool _applyDispose = true;

        public EntityRepositoryBase(TDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
        }

        public EntityRepositoryBase(TDbContext dbContext, bool applyDispose)
        {
            if(dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }

            _dbContext = dbContext;
            _applyDispose = applyDispose;
        }

        protected TDbContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_applyDispose)
            {
                if (!_isDisposed)
                {
                    if (disposing)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }

                    _isDisposed = true;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
