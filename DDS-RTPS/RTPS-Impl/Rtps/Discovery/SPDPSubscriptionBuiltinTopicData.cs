using Doopec.Dds.Topic;

namespace Doopec.Rtps.Discovery
{
    public class SPDPSubscriptionBuiltinTopicData : SubscriptionBuiltinTopicDataImpl
    {
        public const string SUBSCRIPTION_TOPIC = "DCPSSubscription";

        public SPDPSubscriptionBuiltinTopicData()
        {
            this.topicName = SUBSCRIPTION_TOPIC;
        }
    }
}
