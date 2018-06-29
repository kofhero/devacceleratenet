// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IUserRepository<TKey, TNullableKey, TUser, TUserSession>
        where TKey : IEquatable<TKey>
        where TUser : IUser<TKey, TNullableKey>
        where TUserSession : IUserSession<TKey>
    {
        Task AddToRoleAsync(TUser user, string roleName);
        Task CreateAsync(TUser user);
        Task DeleteAsync(TUser user);
        Task<TUser> FindByEmailAsync(string email);
        Task<TUser> FindByIdAsync(TKey userId);
        Task<TUser> FindByNameAsync(string userName);
        Task<int> GetAccessFailedCountAsync(TUser user);
        Task<string> GetEmailAsync(TUser user);
        Task<bool> GetEmailConfirmedAsync(TUser user);
        Task<bool> GetLockoutEnabledAsync(TUser user);
        Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user);
        Task<string> GetPasswordHashAsync(TUser user);
        Task<string> GetPhoneNumberAsync(TUser user);
        Task<bool> GetPhoneNumberConfirmedAsync(TUser user);
        Task<IList<string>> GetRolesAsync(TUser user);
        Task<string> GetSecurityStampAsync(TUser user);
        Task<bool> GetTwoFactorEnabledAsync(TUser user);
        Task<bool> HasPasswordAsync(TUser user);
        Task<int> IncrementAccessFailedCountAsync(TUser user);
        Task<bool> IsInRoleAsync(TUser user, string roleName);
        Task RemoveFromRoleAsync(TUser user, string roleName);
        Task ResetAccessFailedCountAsync(TUser user);
        Task SetEmailAsync(TUser user, string email);
        Task SetEmailConfirmedAsync(TUser user, bool confirmed);
        Task SetLockoutEnabledAsync(TUser user, bool enabled);
        Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd);
        Task SetPasswordHashAsync(TUser user, string passwordHash);
        Task SetPhoneNumberAsync(TUser user, string phoneNumber);
        Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed);
        Task SetSecurityStampAsync(TUser user, string stamp);
        Task SetTwoFactorEnabledAsync(TUser user, bool enabled);
        Task UpdateAsync(TUser user);

        void CreateUserSession(TUserSession userSession);
        Task CreateUserSessionAsync(TUserSession userSession);
        Task<List<TUserSession>> FindUserSessionsByUserId(TKey userId);
        Task<TUserSession> FindUserSessionById(TKey userSessionId);
    }
}
