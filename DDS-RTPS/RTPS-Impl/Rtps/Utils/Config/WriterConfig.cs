using System.Configuration;

namespace Doopec.Rtps.Utils.Config
{
    [ConfigurationCollection(typeof(KeyValueConfigurationElement), AddItemName = "add",
     CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class WriterConfig : KeyValueConfigurationCollection
    {
        public bool PushMode
        {
            get { return bool.Parse(this["pushMode"].Value); }
        }

        public int HeartbeatPeriod
        {
            get { return int.Parse(this["heartbeatPeriod"].Value); }
        }


        public int NackResponseDelay
        {
            get { return int.Parse(this["nackResponseDelay"].Value); }
        }


        public int NackSuppressionDuration
        {
            get { return int.Parse(this["nackSuppressionDuration"].Value); }
        }
    }
}
