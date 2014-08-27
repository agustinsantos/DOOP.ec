using Doopec.Dds.Topic;

namespace Doopec.Rtps.Discovery
{
    public class SPDPPublicationBuiltinTopicData : PublicationBuiltinTopicDataImpl
    {
        public const string PUBLICATION_TOPIC = "DCPSPublication,";

        public SPDPPublicationBuiltinTopicData()
        {
            this.topicName = PUBLICATION_TOPIC;
        }
    }
}
