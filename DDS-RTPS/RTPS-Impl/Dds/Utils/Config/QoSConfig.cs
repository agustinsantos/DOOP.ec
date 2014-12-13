using System;
using System.Configuration;

namespace Doopec.Dds.Config
{
     [ConfigurationCollection(typeof(KeyValueElement), AddItemName = "Add", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class QoSConfig : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new KeyValueElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            return ((KeyValueElement)element).Value;
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return (string)base["name"];
            }
        }
    }

    public class KeyValueElement : ConfigurationElement
    {
        [ConfigurationProperty("key", IsRequired = true, IsKey = true)]
        public string Key
        {
            get
            {
                return (string)base["key"];
            }
        }

        [ConfigurationProperty("value", IsRequired = true, IsKey = true)]
        public string Value
        {
            get
            {
                return (string)base["value"];
            }
        }
    }
}
