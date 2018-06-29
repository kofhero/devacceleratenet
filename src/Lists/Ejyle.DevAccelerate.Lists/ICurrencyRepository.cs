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
    public interface ICurrencyRepository<TKey, TCurrency> : IEntityRepository<TKey, TCurrency>
        where TKey : IEquatable<TKey>
        where TCurrency : ICurrency<TKey>
    {
        TCurrency FindById(TKey id);
        Task<TCurrency> FindByIdAsync(TKey id);

        List<TCurrency> FindAll();
        Task<List<TCurrency>> FindAllAsync();
    }
}
