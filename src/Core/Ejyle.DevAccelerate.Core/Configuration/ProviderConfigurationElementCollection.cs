// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    public class ProviderConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ProviderConfigurationElement)element).Name;
        }

        public ProviderConfigurationElement GetByName(string name)
        {
            return (ProviderConfigurationElement)this.BaseGet((object)name);
        }

        public void Add(ProviderConfigurationElement element)
        {
            this.BaseAdd(element);
        }

        public void Remove(object name)
        {
            this.BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            this.BaseRemoveAt(index);
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ProviderConfigurationElement();
        }
    }
}
