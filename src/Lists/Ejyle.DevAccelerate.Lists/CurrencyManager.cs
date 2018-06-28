// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists
{
    public class CurrencyManager : CurrencyManager<int, Currency, CurrencyRepository>
    {
        public CurrencyManager(CurrencyRepository repository)
            : base(repository)
        { }
    }

    public class CurrencyManager<TKey, TCurrency, TRepository>
        where TKey : IEquatable<TKey>
        where TCurrency : ICurrency<TKey>
        where TRepository : ICurrencyRepository<TKey, TCurrency>
    {
        private bool _isDisposed = false;

        public CurrencyManager(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository
        {
            get;
            private set;
        }

        public List<TCurrency> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TCurrency>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TCurrency FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TCurrency> FindByIdAsync(TKey id)
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
