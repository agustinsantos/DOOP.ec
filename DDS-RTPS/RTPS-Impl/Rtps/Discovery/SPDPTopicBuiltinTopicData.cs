using Doopec.Dds.Topic;

namespace Doopec.Rtps.Discovery
{
    public class SPDPTopicBuiltinTopicData : TopicBuiltinTopicDataImpl
    {
        public const string TOPIC_TOPIC = "DCPSTopic,";

        public SPDPTopicBuiltinTopicData()
        {
            this.topicName = TOPIC_TOPIC;
        }
    }
}
