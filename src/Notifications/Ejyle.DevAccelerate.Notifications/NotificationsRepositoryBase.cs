// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ---------------------------------------------------------------------------------------------------------------------- 

using System;
using System.Data.Entity;

namespace Ejyle.DevAccelerate.Notifications
{
    public abstract class NotificationsRepositoryBase<TDbContext> : IDisposable
        where TDbContext : DbContext
    {
        private bool _isDisposed = false;

        public NotificationsRepositoryBase(TDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException("dbContext");
        }

        protected TDbContext DbContext
        {
            get;
            private set;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                    DbContext = null;
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
