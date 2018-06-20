// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    public interface ITenant<TKey> : IEntity<TKey>
    {
        string Name { get; set; }
        string Domain { get; set; }
        bool IsDomainVerified { get; set; }
        string FriendlyName { get; set; }
        TKey OwnerUserId { get; set; }
        bool IsActive { get; set; }
    }
}
