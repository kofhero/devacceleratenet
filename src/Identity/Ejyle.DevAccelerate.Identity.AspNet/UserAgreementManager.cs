// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserAgreementManagery<TKey, TUserAgreement, TUserAgreementVersion, TUserAgreementRepository>
        : EntityManagerBase<TKey, TUserAgreement, TUserAgreementRepository>
        where TKey : IEquatable<TKey>
        where TUserAgreement : UserAgreement<TKey, TUserAgreementVersion>
        where TUserAgreementVersion : UserAgreementVersion<TKey, TUserAgreement>
        where TUserAgreementRepository : IUserAgreementRepository<TKey, TUserAgreement, TUserAgreementVersion>
    {
        public UserAgreementManagery(TUserAgreementRepository repository)
            : base(repository)
        { }

        public Task CreateAsync(TUserAgreement userAgreement)
        {
            return Repository.CreateAsync(userAgreement);
        }

        public Task<TUserAgreement> FindByIdAsync(TKey userAgreementId)
        {
            return Repository.FindByIdAsync(userAgreementId);
        }

        public Task<TUserAgreement> FindByKey(string userAgreementKey)
        {
            return Repository.FindByKey(userAgreementKey);
        }

        public Task UpdateAsync(TUserAgreement userAgreement)
        {
            return Repository.UpdateAsync(userAgreement);
        }
    }
}
