using Doopec.DDS.Sub;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.sub.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Sub.modifiable
{
    class ModifiableDataReaderQosImpl : DataReaderQosImpl, ModifiableDataReaderQos
    {
       public ModifiableDataReaderQosImpl(DataReaderQosImpl qos)
            :base(qos.GetBootstrap())
        {

        }
        public ModifiableDataReaderQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {

        }
        public ModifiableDataReaderQos SetTimeBasedFilter(TimeBasedFilterQosPolicy timeBasedFilter)
        {
            throw new NotImplementedException();
        }
        public ModifiableDataReaderQos SetDurability(DurabilityQosPolicy durability)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetDurabilityService(DurabilityServiceQosPolicy durabilityService)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetDeadline(DeadlineQosPolicy deadline)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetLiveliness(LivelinessQosPolicy liveliness)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetReliability(ReliabilityQosPolicy reliability)
        {
            this.Reliability =reliability;
            return this;
        }

        public ModifiableDataReaderQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetHistory(HistoryQosPolicy history)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetTransportPriority(TransportPriorityQosPolicy transportPriority)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetLifespan(LifespanQosPolicy lifespan)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetUserData(UserDataQosPolicy userData)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetOwnership(OwnershipQosPolicy ownership)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetOwnershipStrength(OwnershipStrengthQosPolicy ownershipStrength)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetReaderDataLifecycle(ReaderDataLifecycleQosPolicy ReaderDataLifecycle)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetRepresentation(DataRepresentationQosPolicy representation)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos CopyFrom(org.omg.dds.topic.TopicQos src)
        {
            throw new NotImplementedException();
        }

        public new System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public POLICY put<POLICY>(org.omg.dds.core.policy.QosPolicyId key, POLICY value) where POLICY : org.omg.dds.core.policy.QosPolicy
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos CopyFrom(org.omg.dds.sub.DataReaderQos other)
        {
            return new ModifiableDataReaderQosImpl(other.GetBootstrap());
        }

        public org.omg.dds.sub.DataReaderQos FinishModification()
        {
            return new DataReaderQosImpl(this.GetBootstrap());
        }


      
    }
}
