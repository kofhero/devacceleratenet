// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Apps
{
    public class App : App<int, AppFeature>
    { }

    public class App<TKey, TAppFeature> : EntityBase<TKey>, IApp<TKey>
        where TKey : IEquatable<TKey>
        where TAppFeature : IAppFeature<TKey>
    {
        public App()
        {
            AppFeatures = new HashSet<TAppFeature>();
        }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [Index("IX_Apps_AppKey", IsUnique = true)]
        public string AppKey { get; set; }

        public virtual ICollection<TAppFeature> AppFeatures { get; set; }
    }
}
