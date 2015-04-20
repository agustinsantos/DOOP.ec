using DDS.ConversionUtils;
using Doopec.Dds.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Topic
{
    public class SubscriptionBuiltinTopicDataImpl : SubscriptionBuiltinTopicData
    {
        protected readonly ReliabilityQosPolicy reliabilityQosPolicy;


        protected BuiltinTopicKey key;
        protected BuiltinTopicKey participantKey;
        protected string topicName;
        protected string typeName;

        public SubscriptionBuiltinTopicDataImpl()
        {
            reliabilityQosPolicy = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE, Duration.NewDuration(200, TimeUnit.MILLISECONDS, null), this.GetBootstrap());
        }

        public override BuiltinTopicKey Key
        {
            get
            {
                return key;
            }
        }

        public override BuiltinTopicKey ParticipantKey
        {
            get
            {
                return participantKey;
            }
        }

        public override string TopicName
        {
            get
            {
                return topicName;
            }
        }

        public override string TypeName
        {
            get
            {
                return typeName;
            }
        }

        public override List<string> EquivalentTypeName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> BaseTypeName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.type.typeobject.TypeObject Type
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.DurabilityQosPolicy Durability
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.DeadlineQosPolicy Deadline
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.LatencyBudgetQosPolicy LatencyBudget
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.LivelinessQosPolicy Liveliness
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.ReliabilityQosPolicy Reliability
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.OwnershipQosPolicy Ownership
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.DestinationOrderQosPolicy DestinationOrder
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.UserDataQosPolicy UserData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.TimeBasedFilterQosPolicy TimeBasedFilter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.PresentationQosPolicy Presentation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.PartitionQosPolicy Partition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.TopicDataQosPolicy TopicData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.GroupDataQosPolicy GroupData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.DataRepresentationQosPolicy Representation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override org.omg.dds.core.policy.TypeConsistencyEnforcementQosPolicy TypeConsistency
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override SubscriptionBuiltinTopicData CopyFrom(SubscriptionBuiltinTopicData other)
        {
            throw new NotImplementedException();
        }

        public override SubscriptionBuiltinTopicData FinishModification()
        {
            throw new NotImplementedException();
        }

        public override SubscriptionBuiltinTopicData Modify()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
