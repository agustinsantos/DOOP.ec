using System.Configuration;

namespace Doopec.Rtps.Utils.Config
{
    [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "Add",
     CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class ReaderConfig : KeyValueConfigurationCollection
    {
        public int HeartbeatResponseDelay
        {
            get { return int.Parse(this["heartbeatResponseDelay"].Value); }
        }


        public int HeartbeatSuppressionDuration
        {
            get { return int.Parse(this["heartbeatSuppressionDuration"].Value); }
        }
    }
}
