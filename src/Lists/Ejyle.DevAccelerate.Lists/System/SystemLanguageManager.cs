// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Lists.System
{
    public class SystemLanguageManager : SystemLanguageManager<int, SystemLanguage, SystemLanguageRepository>
    {
        public SystemLanguageManager(SystemLanguageRepository repository)
            : base(repository)
        { }
    }

    public class SystemLanguageManager<TKey, TSystemLanguage, TRepository>
        where TKey : IEquatable<TKey>
        where TSystemLanguage : ISystemLanguage<TKey>
        where TRepository : ISystemLanguageRepository<TKey, TSystemLanguage>
    {
        private bool _isDisposed = false;

        public SystemLanguageManager(TRepository repository)
        {
            Repository = repository;
        }

        protected TRepository Repository
        {
            get;
            private set;
        }

        public List<TSystemLanguage> FindAll()
        {
            return Repository.FindAll();
        }

        public Task<List<TSystemLanguage>> FindAllAsync()
        {
            return Repository.FindAllAsync();
        }

        public TSystemLanguage FindById(TKey id)
        {
            return Repository.FindById(id);
        }

        public Task<TSystemLanguage> FindByIdAsync(TKey id)
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