// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Lists.Geography;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class DateFormatManager : DateFormatManager<int, DateFormat, DateFormatRepository>
    {
        public DateFormatManager(DateFormatRepository repository)
            : base(repository)
        { }
    }

    public class DateFormatManager<TKey, TDateFormat, TRepository>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDateFormat<TKey>
        where TRepository : IDateFormatRepository<TKey, TDateFormat>
    {
        private bool _isDisposed = false;

        public DateFormatManager(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository
        {
            get;
            private set;
        }

        public List<TDateFormat> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TDateFormat>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TDateFormat FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TDateFormat> FindByIdAsync(TKey id)
        {
            return Repository.FindByIdAsync(id);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                    Repository = default(TRepository);
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