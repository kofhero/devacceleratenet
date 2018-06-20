// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Identity
{
    public interface ITenantUser<TKey> : IEntity<TKey>
    {
        TKey UserId { get; set; }
        TKey TenantId { get; set; }
    }
}
