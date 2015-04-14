using Doopec.DDS.Core;
using org.omg.dds.core.policy;
using org.omg.dds.pub;
using org.omg.dds.pub.modifiable;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Pub
{
    public class DataWriterQosImpl : EntityQosImpl<DataWriterQos, ModifiableDataWriterQos>, DataWriterQos
    {
        public DurabilityQosPolicy GetDurability()
        {
            throw new NotImplementedException();
        }

        public DurabilityServiceQosPolicy GetDurabilityService()
        {
            throw new NotImplementedException();
        }

        public DeadlineQosPolicy GetDeadline()
        {
            throw new NotImplementedException();
        }

        public LatencyBudgetQosPolicy GetLatencyBudget()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.LivelinessQosPolicy GetLiveliness()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.ReliabilityQosPolicy GetReliability()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.DestinationOrderQosPolicy GetDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.HistoryQosPolicy GetHistory()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.ResourceLimitsQosPolicy GetResourceLimits()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.TransportPriorityQosPolicy GetTransportPriority()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.LifespanQosPolicy GetLifespan()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.UserDataQosPolicy GetUserData()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.OwnershipQosPolicy GetOwnership()
        {
            throw new NotImplementedException();
        }

        public OwnershipStrengthQosPolicy GetOwnershipStrength()
        {
            throw new NotImplementedException();
        }

        public WriterDataLifecycleQosPolicy GetWriterDataLifecycle()
        {
            throw new NotImplementedException();
        }

        public DataRepresentationQosPolicy GetRepresentation()
        {
            throw new NotImplementedException();
        }

        public TypeConsistencyEnforcementQosPolicy GetTypeConsistency()
        {
            throw new NotImplementedException();
        }

        public new IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
