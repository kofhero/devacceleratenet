// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public interface IDateFormatRepository<TKey, TDateFormat> : IEntityRepository<TKey, TDateFormat>
        where TKey : IEquatable<TKey>
        where TDateFormat : IDateFormat<TKey>
    {
        TDateFormat FindById(TKey id);
        Task<TDateFormat> FindByIdAsync(TKey id);

        List<TDateFormat> FindAll();
        Task<List<TDateFormat>> FindAllAsync();
    }
}