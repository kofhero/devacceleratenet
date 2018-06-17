// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    /// <summary>
    /// Contains a collections of the <see cref="NamedConfigurationElement"/> objects.
    /// </summary>
    /// <typeparam name="TNamedConfigurationElement">The type of the <see cref="NamedConfigurationElement"/> type.</typeparam>
    public abstract class NamedConfigurationElementCollection<TNamedConfigurationElement> : ConfigurationElementCollection
        where TNamedConfigurationElement : NamedConfigurationElement
    {
        /// <summary>
        /// Gets the element name (key) for a specified named configuration element.
        /// </summary>
        /// <param name="element">
        /// The <see cref="ConfigurationElement"/> to return the key for.
        /// </param>
        /// <returns>
        /// Returns <see cref="object"/> that acts as the key for the specified <see cref="ConfigurationElement"/>.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TNamedConfigurationElement)element).Name;
        }

        /// <summary>
        /// Returns the configuration element with the specified name.
        /// </summary>
        /// <param name="name">The name of the element to return.</param>
        /// <returns>The <see cref="NamedConfigurationElement"/> with the specified name; otherwise, null.</returns>
        public TNamedConfigurationElement GetByName(string name)
        {
            return (TNamedConfigurationElement)this.BaseGet((object)name);
        }

        /// <summary>
        /// Adds an element to the collection.
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        public void Add(TNamedConfigurationElement element)
        {
            this.BaseAdd(element);
        }

        /// <summary>
        /// Removes a <see cref="NamedConfigurationElement"/> from the collection.
        /// </summary>
        /// <param name="name">The name of the <see cref="NamedConfigurationElement"/> to remove.</param>
        public void Remove(object name)
        {
            this.BaseRemove(name);
        }

        /// <summary>
        /// Removes the <see cref="NamedConfigurationElement"/> at the specified index location.
        /// </summary>
        /// <param name="index">The index location of the <see cref="NamedConfigurationElement"/> to remove.</param>
        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }
    }
}
