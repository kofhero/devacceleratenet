using System;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IRoleRepository<TKey, TRole>
        where TKey : IEquatable<TKey>
        where TRole : IRole<TKey>
    {
        Task CreateAsync(TRole role);
        Task DeleteAsync(TRole role);
        Task<TRole> FindByIdAsync(TKey roleId);
        Task<TRole> FindByNameAsync(string roleName);
        Task UpdateAsync(TRole role);
    }
}
