// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserAgreementVersion : UserAgreementVersion<int, UserAgreement>
    { }

    public class UserAgreementVersion<TKey, TUserAgreement> : EntityBase<TKey>, IUserAgreementVersion<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreement : IUserAgreement<TKey>
    {
        [Required]
        public TKey UserAgreementId
        {
            get;
            set;
        }

        [Required]
        public int VersionNumber
        {
            get;
            set;
        }

        [Required]
        public string Text
        {
            get;
            set;
        }

        [Required]
        public bool IsCurrent
        {
            get;
            set;
        }

        [Required]
        public bool IsPublished
        {
            get;
            set;
        }

        public DateTime? PublishedDateUtc
        {
            get;
            set;
        }

        public virtual TUserAgreement UserAgreement
        {
            get;
            set;
        }
    }
}
