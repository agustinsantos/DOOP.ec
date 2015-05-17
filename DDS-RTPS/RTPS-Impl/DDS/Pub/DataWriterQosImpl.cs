using Doopec.Dds.Pub.modifiable;
using Doopec.DDS.Core;
using org.omg.dds.core;
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
        public DataWriterQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public DataWriterQosImpl(DurabilityQosPolicy durability, Bootstrap boostrap)
            : base(boostrap)
        {
            this.Durability = durability;
        }
        public DataWriterQosImpl(DurabilityServiceQosPolicy durabilityService, Bootstrap boostrap)
            : base(boostrap)
        {
            this.DurabilityService = durabilityService;
        }
        public DataWriterQosImpl(ReliabilityQosPolicy reliability, Bootstrap boostrap)
            : base(boostrap)
        {
            this.Reliability = reliability;
        }
        public DataWriterQosImpl(DestinationOrderQosPolicy destinationOrder, Bootstrap boostrap)
            : base(boostrap)
        {
            this.DestinationOrder = destinationOrder;
        }
        
       

        public DurabilityQosPolicy GetDurability()
        {
            return Durability ;
        }

        public DurabilityServiceQosPolicy GetDurabilityService()
        {
            return DurabilityService ;
        }

        public DeadlineQosPolicy GetDeadline()
        {
            return Deadline ;
        }

        public LatencyBudgetQosPolicy GetLatencyBudget()
        {
            return LatencyBudget ;
        }

        public LivelinessQosPolicy GetLiveliness()
        {
            return Liveliness;
        }

        public ReliabilityQosPolicy GetReliability()
        {
            return Reliability;
        }

        public DestinationOrderQosPolicy GetDestinationOrder()
        {
            return DestinationOrder ;
        }

        public HistoryQosPolicy GetHistory()
        {
            return History;
        }

        public ResourceLimitsQosPolicy GetResourceLimits()
        {
            return ResourceLimits ;
        }

        public TransportPriorityQosPolicy GetTransportPriority()
        {
            return TransportPriority ;
        }

        public LifespanQosPolicy GetLifespan()
        {
            return Lifespan ;
        }

        public UserDataQosPolicy GetUserData()
        {
            return UserData ;
        }

        public OwnershipQosPolicy GetOwnership()
        {
            return Ownership ;
        }

        public OwnershipStrengthQosPolicy GetOwnershipStrength()
        {
            return OwnershipStrength ;
        }

        public WriterDataLifecycleQosPolicy GetWriterDataLifecycle()
        {
            return WriterDataLifecycle;
        }

        public DataRepresentationQosPolicy GetRepresentation()
        {
            return Representation;
        }

        public TypeConsistencyEnforcementQosPolicy GetTypeConsistency()
        {
            return TypeConsistency;
        }

        public new IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override ModifiableDataWriterQos Modify()
        {
          // throw new NotImplementedException();
            return new  ModifiableDataWriterQosImpl(this);
        }

        internal DurabilityQosPolicy Durability { get; set; }
        internal DurabilityServiceQosPolicy DurabilityService { get; set; }
        internal DeadlineQosPolicy Deadline { get; set; }
        internal LatencyBudgetQosPolicy LatencyBudget { get; set; }
        internal DestinationOrderQosPolicy DestinationOrder { get; set; }
        internal HistoryQosPolicy History { get; set; }
        internal ResourceLimitsQosPolicy ResourceLimits { get; set; }
        internal TransportPriorityQosPolicy TransportPriority { get; set; }
        internal LifespanQosPolicy Lifespan { get; set; }
        internal UserDataQosPolicy UserData { get; set; }
        internal OwnershipQosPolicy Ownership { get; set; }
        internal OwnershipStrengthQosPolicy OwnershipStrength { get; set; }
        internal WriterDataLifecycleQosPolicy WriterDataLifecycle { get; set; }
        internal DataRepresentationQosPolicy Representation { get; set; }
        internal TypeConsistencyEnforcementQosPolicy TypeConsistency { get; set; }
        internal ReliabilityQosPolicy Reliability { get; set; }
        internal LivelinessQosPolicy Liveliness { get; set; }


    }
}
