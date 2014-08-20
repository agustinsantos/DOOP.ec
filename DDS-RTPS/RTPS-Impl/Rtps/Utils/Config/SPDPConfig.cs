using System.Configuration;

namespace Doopec.Rtps.Config
{
    public class SpdpConfig : ConfigurationElement
    {
        private SpdpConfig() { }

        [ConfigurationProperty("", IsDefaultCollection = true, IsKey = false, IsRequired = false)]
        public SpdpSettingCollection SpdpSettings
        {
            get
            {
                return  this[""] as SpdpSettingCollection;
            }
        }

        public int ResendDataPeriod
        {
            get { return int.Parse(this.SpdpSettings["resendDataPeriod"].Value); }
        }

        public string DiscoveryListenerUris
        {
            get { return this.SpdpSettings["discoveryListenerUris"].Value; }
        }

        [ConfigurationProperty("WellKnownPorts")]
        public WellKnownPortsConfig WellKnownPorts
        {
            get { return (WellKnownPortsConfig)this["WellKnownPorts"]; }
            set { this["WellKnownPorts"] = value; }
        }

    }


    [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add",
         CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class SpdpSettingCollection : KeyValueConfigurationCollection 
   {

   }
}
