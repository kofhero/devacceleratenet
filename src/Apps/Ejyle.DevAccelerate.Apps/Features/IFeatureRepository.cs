using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
