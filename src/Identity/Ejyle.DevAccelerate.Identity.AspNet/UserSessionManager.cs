﻿// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserSessionManager : UserSessionManager<int, int?, UserSession, UserSessionRepository>
    {
        public UserSessionManager(UserSessionRepository repository)
            : base(repository)
        { }
    }

    public class UserSessionManager<TKey, TNullableKey, TUserSession, TUserSessionRepository>
        : EntityManagerBase<TKey, TUserSession, TUserSessionRepository>
        where TKey : IEquatable<TKey>
        where TUserSession : IUserSession<TKey>
        where TUserSessionRepository : IUserSessionRepository<TKey, TUserSession>
    {
        public UserSessionManager(TUserSessionRepository repository)
            : base(repository)
        { }

        public Task CreateAsync(TUserSession userSession)
        {
            return Repository.CreateAsync(userSession);
        }

        public void Create(TUserSession userSession)
        {
            Repository.Create(userSession);
        }

        public TUserSession FindById(TKey userSessionId)
        {
            return Repository.FindById(userSessionId);
        }

        public Task<TUserSession> FindByIdAsync(TKey userSessionId)
        {
            return Repository.FindByIdAsync(userSessionId);
        }

        public Task<TUserSession> FindByKeyAsync(string key)
        {
            return Repository.FindByKeyAsync(key);
        }

        public TUserSession FindByKey(string key)
        {
            return Repository.FindByKey(key);
        }
    }
}
