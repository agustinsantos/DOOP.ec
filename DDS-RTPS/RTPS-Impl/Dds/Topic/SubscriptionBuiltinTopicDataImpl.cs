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
        protected static readonly ReliabilityQosPolicy reliabilityQosPolicy = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE, Duration.newDuration(200, TimeUnit.MILLISECONDS, null));


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

        public override org.omg.dds.type.typeobject.TypeObject getType()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.DurabilityQosPolicy getDurability()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.DeadlineQosPolicy getDeadline()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.LatencyBudgetQosPolicy getLatencyBudget()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.LivelinessQosPolicy getLiveliness()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.ReliabilityQosPolicy getReliability()
        {
            return reliabilityQosPolicy;
        }

        public override org.omg.dds.core.policy.OwnershipQosPolicy getOwnership()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.DestinationOrderQosPolicy getDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.UserDataQosPolicy getUserData()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.TimeBasedFilterQosPolicy getTimeBasedFilter()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.PresentationQosPolicy getPresentation()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.PartitionQosPolicy getPartition()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.TopicDataQosPolicy getTopicData()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.GroupDataQosPolicy getGroupData()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.DataRepresentationQosPolicy getRepresentation()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.policy.TypeConsistencyEnforcementQosPolicy getTypeConsistency()
        {
            throw new NotImplementedException();
        }

        public override SubscriptionBuiltinTopicData copyFrom(SubscriptionBuiltinTopicData other)
        {
            throw new NotImplementedException();
        }

        public override SubscriptionBuiltinTopicData finishModification()
        {
            throw new NotImplementedException();
        }

        public override SubscriptionBuiltinTopicData modify()
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
