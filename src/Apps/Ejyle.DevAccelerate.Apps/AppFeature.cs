// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ejyle.DevAccelerate.Core;

namespace Ejyle.DevAccelerate.Apps
{
    public class AppFeature : AppFeature<int, App>
    { }

    public class AppFeature<TKey, TApp> : EntityBase<TKey>, IAppFeature<TKey>
        where TKey : IEquatable<TKey>
        where TApp : IApp<TKey>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [Index("IX_AppFeatures_AppFeatureKey", IsUnique = true)]
        public string AppFeatureKey { get; set; }

        [Required]
        public TKey AppId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual TApp App { get; set; }
    }
}
