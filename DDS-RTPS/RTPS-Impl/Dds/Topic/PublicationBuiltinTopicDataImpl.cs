using DDS.ConversionUtils;
using Doopec.Dds.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.topic;
using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Topic
{
    public class PublicationBuiltinTopicDataImpl : PublicationBuiltinTopicData
    {
        protected static readonly ReliabilityQosPolicy reliabilityQosPolicy = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE,   Duration.newDuration(200, TimeUnit.MILLISECONDS, null));

        protected BuiltinTopicKey key;
        protected BuiltinTopicKey participantKey;
        protected string topicName;
        protected string typeName;

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
                throw new System.NotImplementedException();
            }
        }

        public override List<string> BaseTypeName
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override TypeObject Type
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override DurabilityQosPolicy Durability
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override DurabilityServiceQosPolicy DurabilityService
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override DeadlineQosPolicy Deadline
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override LatencyBudgetQosPolicy LatencyBudget
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override LivelinessQosPolicy Liveliness
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override ReliabilityQosPolicy Reliability
        {
            get
            {
                return reliabilityQosPolicy;
            }
        }

        public override LifespanQosPolicy Lifespan
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override UserDataQosPolicy UserData
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override OwnershipQosPolicy Ownership
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override OwnershipStrengthQosPolicy OwnershipStrength
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override DestinationOrderQosPolicy DestinationOrder
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override PresentationQosPolicy Presentation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override PartitionQosPolicy Partition
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override TopicDataQosPolicy TopicData
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override GroupDataQosPolicy GroupData
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override DataRepresentationQosPolicy Representation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override TypeConsistencyEnforcementQosPolicy TypeConsistency
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        public override PublicationBuiltinTopicData CopyFrom(PublicationBuiltinTopicData other)
        {
            throw new NotImplementedException();
        }

        public override PublicationBuiltinTopicData finishModification()
        {
            throw new NotImplementedException();
        }

        public override PublicationBuiltinTopicData Clone()
        {
            throw new NotImplementedException();
        }

        public override PublicationBuiltinTopicData Modify()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
