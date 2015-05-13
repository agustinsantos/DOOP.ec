using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.pub;
using org.omg.dds.pub.modifiable;
using org.omg.dds.topic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Pub.modifiable
{
    class ModifiableDataWriterQosImpl : DataWriterQosImpl, ModifiableDataWriterQos
    {
        public ModifiableDataWriterQosImpl(DataWriterQosImpl qos)
            :base(qos.GetBootstrap())
        {

        }
        public ModifiableDataWriterQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {

        }
        public ModifiableDataWriterQos SetDurability(DurabilityQosPolicy durability)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetDurabilityService(DurabilityServiceQosPolicy durabilityService)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetDeadline(DeadlineQosPolicy deadline)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetLiveliness(LivelinessQosPolicy liveliness)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetReliability(ReliabilityQosPolicy reliability)
        {
            this.Reliability =reliability;
            return this;
        }

        public ModifiableDataWriterQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetHistory(HistoryQosPolicy history)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetTransportPriority(TransportPriorityQosPolicy transportPriority)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetLifespan(LifespanQosPolicy lifespan)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetUserData(UserDataQosPolicy userData)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetOwnership(OwnershipQosPolicy ownership)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetOwnershipStrength(OwnershipStrengthQosPolicy ownershipStrength)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetWriterDataLifecycle(WriterDataLifecycleQosPolicy writerDataLifecycle)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetRepresentation(DataRepresentationQosPolicy representation)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency)
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos CopyFrom(TopicQos src)
        {
            throw new NotImplementedException();
        }

        public POLICY put<POLICY>(QosPolicyId key, POLICY value) where POLICY : QosPolicy
        {
            throw new NotImplementedException();
        }

        public ModifiableDataWriterQos CopyFrom(DataWriterQos other)
        {
            return new ModifiableDataWriterQosImpl(other.GetBootstrap());
        }

        public DataWriterQos FinishModification()
        {
            return new DataWriterQosImpl (this.GetBootstrap());
        }
    }
}