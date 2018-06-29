// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IUserSessionRepository<TKey, TUserSession> : IEntityRepository<TKey, TUserSession>
        where TKey : IEquatable<TKey>
        where TUserSession : IUserSession<TKey>
    {
        Task CreateAsync(TUserSession userSession);
        void Create(TUserSession userSession);

        Task<TUserSession> FindByIdAsync(TKey id);
        TUserSession FindById(TKey id);

        Task<TUserSession> FindByKeyAsync(string key);
        TUserSession FindByKey(string key);
    }
}
