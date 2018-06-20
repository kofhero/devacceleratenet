// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd (www.ejyle.com)
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System.Configuration;

namespace Ejyle.DevAccelerate.Core.Configuration
{
    public class ProviderConfigurationElementCollection : ProviderConfigurationElementCollection<ProviderConfigurationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ProviderConfigurationElement();
        }
    }

    public abstract class ProviderConfigurationElementCollection<TProviderConfigurationElement> : ConfigurationElementCollection
            where TProviderConfigurationElement : ProviderConfigurationElement
    {
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TProviderConfigurationElement)element).Name;
        }

        public TProviderConfigurationElement GetByName(string name)
        {
            return (TProviderConfigurationElement)this.BaseGet((object)name);
        }

        public void Add(TProviderConfigurationElement element)
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
    }
}
