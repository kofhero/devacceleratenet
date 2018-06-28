// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejyle.DevAccelerate.Identity.AspNet
{
    public class UserAgreement : UserAgreement<int, UserAgreementVersion>
    {
        public UserAgreement() : base()
        { }
    }

    public class UserAgreement<TKey, TUserAgreementVersion> : UserAgreement<TKey>
        where TKey : IEquatable<TKey>
        where TUserAgreementVersion : IUserAgreementVersion<TKey>
    {
        public UserAgreement()
        {
            UserAgreementVersions = new HashSet<TUserAgreementVersion>();
        }

        public ICollection<TUserAgreementVersion> UserAgreementVersions { get; set; }
    }

    public class UserAgreement<TKey> : EntityBase<TKey>, IUserAgreement<TKey>
        where TKey : IEquatable<TKey>
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public string UserAgreementKey { get; set; }
    }
}
