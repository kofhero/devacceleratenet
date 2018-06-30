// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class DateFormatManager : DateFormatManager<int, DateFormat, DateFormatRepository>
    {
        public DateFormatManager(DateFormatRepository repository)
            : base(repository)
        { }
    }

    public class DateFormatManager<TKey, TDateFormat, TRepository>
        : EntityManagerBase<TKey, TDateFormat, TRepository>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDateFormat<TKey>
        where TRepository : IDateFormatRepository<TKey, TDateFormat>
    {
        public DateFormatManager(TRepository repository)
            : base(repository)
        { }

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

        public TDateFormat FindByDateFormatExpression(string expr)
        {
            return Repository.FindByDateFormatExpression(expr);
        }

        public Task<TDateFormat> FindByDateFormatExpressionAsync(string expr)
        {
            return Repository.FindByDateFormatExpressionAsync(expr);
        }
    }
}