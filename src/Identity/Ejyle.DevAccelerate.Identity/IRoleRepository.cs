// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

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
