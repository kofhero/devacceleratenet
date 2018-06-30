// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
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

    public class CurrencyManager<TKey, TCurrency, TRepository> : EntityManagerBase<TKey, TCurrency, TRepository>
        where TKey : IEquatable<TKey>
        where TCurrency : ICurrency<TKey>
        where TRepository : ICurrencyRepository<TKey, TCurrency>
    {
        public CurrencyManager(TRepository repository)
            : base(repository)
        { }

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
    }
}
