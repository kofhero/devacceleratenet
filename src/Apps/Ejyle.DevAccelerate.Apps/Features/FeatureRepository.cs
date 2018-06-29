// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Apps.Features
{
    public class FeatureRepository<TKey, TFeature> : IFeatureRepository<TKey, TFeature>
        where TKey : IEquatable<TKey>
        where TFeature : IFeature<TKey>
    {
        public Task<List<TFeature>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
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
