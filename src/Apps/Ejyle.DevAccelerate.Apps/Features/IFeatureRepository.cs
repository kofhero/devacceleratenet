// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Apps.Features
{
    public interface IFeatureRepository<TKey, TFeature> : IEntityRepository<TKey, TFeature>
        where TKey : IEquatable<TKey>
        where TFeature : IFeature<TKey>
    {
        Task<List<TFeature>> FindAllAsync();
    }
}
