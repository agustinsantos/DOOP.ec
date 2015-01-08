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

        public override BuiltinTopicKey getKey()
        {
            return key;
        }

        public override BuiltinTopicKey getParticipantKey()
        {
            return participantKey;
        }

        public override string getTopicName()
        {
            return topicName;
        }

        public override string getTypeName()
        {
            return typeName;
        }

        public override List<string> getEquivalentTypeName()
        {
            throw new NotImplementedException();
        }

        public override List<string> getBaseTypeName()
        {
            throw new NotImplementedException();
        }

        public override TypeObject getType()
        {
            throw new NotImplementedException();
        }

        public override DurabilityQosPolicy getDurability()
        {
            throw new NotImplementedException();
        }

        public override DurabilityServiceQosPolicy getDurabilityService()
        {
            throw new NotImplementedException();
        }

        public override DeadlineQosPolicy getDeadline()
        {
            throw new NotImplementedException();
        }

        public override LatencyBudgetQosPolicy getLatencyBudget()
        {
            throw new NotImplementedException();
        }

        public override LivelinessQosPolicy getLiveliness()
        {
            throw new NotImplementedException();
        }

        public override ReliabilityQosPolicy getReliability()
        {
            return reliabilityQosPolicy;
        }

        public override LifespanQosPolicy getLifespan()
        {
            throw new NotImplementedException();
        }

        public override UserDataQosPolicy getUserData()
        {
            throw new NotImplementedException();
        }

        public override OwnershipQosPolicy getOwnership()
        {
            throw new NotImplementedException();
        }

        public override OwnershipStrengthQosPolicy getOwnershipStrength()
        {
            throw new NotImplementedException();
        }

        public override DestinationOrderQosPolicy getDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public override PresentationQosPolicy getPresentation()
        {
            throw new NotImplementedException();
        }

        public override PartitionQosPolicy getPartition()
        {
            throw new NotImplementedException();
        }

        public override TopicDataQosPolicy getTopicData()
        {
            throw new NotImplementedException();
        }

        public override GroupDataQosPolicy getGroupData()
        {
            throw new NotImplementedException();
        }

        public override DataRepresentationQosPolicy getRepresentation()
        {
            throw new NotImplementedException();
        }

        public override TypeConsistencyEnforcementQosPolicy getTypeConsistency()
        {
            throw new NotImplementedException();
        }

        public override PublicationBuiltinTopicData copyFrom(PublicationBuiltinTopicData other)
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

        public override PublicationBuiltinTopicData modify()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap GetBootstrap
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
