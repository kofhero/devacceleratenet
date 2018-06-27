using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    public interface ITenantRepository<TKey, TTenant, TTenantUser> : IEntityRepository<TKey, TTenant>
        where TKey : IEquatable<TKey>
        where TTenant : ITenant<TKey>
        where TTenantUser : ITenantUser<TKey>
    {
        Task CreateAsync(TTenant tenant);
        Task UpdateAsync(TTenant tenant);
        Task<TTenant> FindByIdAsync(TKey tenantId);
        Task<TTenant> FindByKey(string tenantKey);
    }
}
