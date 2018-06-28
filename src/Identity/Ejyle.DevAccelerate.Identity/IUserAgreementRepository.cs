// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    public interface IUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion> : IEntityRepository<TKey, TUserAgreement>
        where TKey : IEquatable<TKey>
        where TUserAgreement : IUserAgreement<TKey>
        where TUserAgreementVersion : IUserAgreementVersion<TKey>
    {
        Task CreateAsync(TUserAgreement userAgreement);
        Task UpdateAsync(TUserAgreement userAgreement);
        Task<TUserAgreement> FindByIdAsync(TKey userAgreementId);
        Task<TUserAgreement> FindByKey(string userAgreementKey);
    }
}
