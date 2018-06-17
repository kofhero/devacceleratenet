// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Ejyle.DevAccelerate.Core.Logging
{
    /// <summary>
    /// Represents the default implementation of <see cref="ILogMessage"/> interface.
    /// </summary>
    public class LogMessage : ILogMessage
    {
        /// <summary>
        /// Gets or sets the title of the log message.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the text of the log message.
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the priority value of the log message.
        /// </summary>
        public int Priority
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date of the log message.
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of categories of the log message.
        /// </summary>
        public ICollection<string> Categories
        {
            get;
            set;
        }
    }
}
