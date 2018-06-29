// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserSessionManager : UserSessionManager<int, int?, UserSession, UserSessionRepository>
    {
        public UserSessionManager(UserSessionRepository repository)
            : base(repository)
        {

        }
    }

    public class UserSessionManager<TKey, TNullableKey, TUserSession, TUserSessionRepository>
        : IDisposable
        where TKey : IEquatable<TKey>
        where TUserSession : IUserSession<TKey>
        where TUserSessionRepository : IUserSessionRepository<TKey, TUserSession>
    {
        private bool _disposed = false;

        public UserSessionManager(TUserSessionRepository repository)
        {
            Repository = repository;
        }

        protected TUserSessionRepository Repository { get; private set; } = default(TUserSessionRepository);

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

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Repository.Dispose();
                    Repository = default(TUserSessionRepository);
                }

                _disposed = true;
            }
        }
    }
}
