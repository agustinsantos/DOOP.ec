using DDS.ConversionUtils;
using Doopec.Dds.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Topic
{
    public class TopicBuiltinTopicDataImpl : TopicBuiltinTopicData
    {
        protected readonly ReliabilityQosPolicy reliabilityQosPolicy;

        protected BuiltinTopicKey key;
        protected string topicName;
        protected string typeName;

        public TopicBuiltinTopicDataImpl()
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

        public override string Name
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

        public override DurabilityQosPolicy Durability
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override DurabilityServiceQosPolicy DurabilityService
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override DeadlineQosPolicy Deadline
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override LatencyBudgetQosPolicy LatencyBudget
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override LivelinessQosPolicy Liveliness
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ReliabilityQosPolicy Reliability
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override TransportPriorityQosPolicy TransportPriority
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override LifespanQosPolicy Lifespan
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override DestinationOrderQosPolicy DestinationOrder
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override HistoryQosPolicy History
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override ResourceLimitsQosPolicy ResourceLimits
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override OwnershipQosPolicy Ownership
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override TopicDataQosPolicy TopicData
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override DataRepresentationQosPolicy Representation
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override TypeConsistencyEnforcementQosPolicy TypeConsistency
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override TopicBuiltinTopicData CopyFrom(TopicBuiltinTopicData other)
        {
            throw new NotImplementedException();
        }

        public override TopicBuiltinTopicData FinishModification()
        {
            throw new NotImplementedException();
        }

        public override TopicBuiltinTopicData Modify()
        {
            throw new NotImplementedException();
        }

        public override Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
