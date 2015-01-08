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
        protected static readonly ReliabilityQosPolicy reliabilityQosPolicy = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE, Duration.newDuration(200, TimeUnit.MILLISECONDS, null));

        protected BuiltinTopicKey key;
        protected string topicName;
        protected string typeName;

        public override BuiltinTopicKey getKey()
        {
            return key;
        }

        public override string getName()
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

        public override org.omg.dds.type.typeobject.TypeObject getType()
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
            throw new NotImplementedException();
        }

        public override TransportPriorityQosPolicy getTransportPriority()
        {
            throw new NotImplementedException();
        }

        public override LifespanQosPolicy getLifespan()
        {
            throw new NotImplementedException();
        }

        public override DestinationOrderQosPolicy getDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public override HistoryQosPolicy getHistory()
        {
            throw new NotImplementedException();
        }

        public override ResourceLimitsQosPolicy getResourceLimits()
        {
            throw new NotImplementedException();
        }

        public override OwnershipQosPolicy getOwnership()
        {
            throw new NotImplementedException();
        }

        public override TopicDataQosPolicy getTopicData()
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

        public override TopicBuiltinTopicData copyFrom(TopicBuiltinTopicData other)
        {
            throw new NotImplementedException();
        }

        public override TopicBuiltinTopicData finishModification()
        {
            throw new NotImplementedException();
        }

        public override TopicBuiltinTopicData modify()
        {
            throw new NotImplementedException();
        }

        public override Bootstrap GetBootstrap
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
