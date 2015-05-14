using Doopec.Dds.Sub.modifiable;
using Doopec.DDS.Core;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.sub;
using org.omg.dds.sub.modifiable;
using System;

namespace Doopec.DDS.Sub
{
    public class DataReaderQosImpl : EntityQosImpl<DataReaderQos, ModifiableDataReaderQos>, DataReaderQos
    {
        internal DurabilityQosPolicy Durability { get; set; }
        internal DurabilityServiceQosPolicy DurabilityService { get; set; }
        internal DeadlineQosPolicy Deadline { get; set; }
        internal LatencyBudgetQosPolicy LatencyBudget { get; set; }
        internal LivelinessQosPolicy Liveliness { get; set; }
        internal DestinationOrderQosPolicy DestinationOrder { get; set; }
        internal HistoryQosPolicy History { get; set; }
        internal ResourceLimitsQosPolicy ResourceLimits { get; set; }
        internal UserDataQosPolicy UserData { get; set; }
        internal OwnershipQosPolicy Ownership { get; set; }
        internal OwnershipStrengthQosPolicy OwnershipStrength { get; set; }
        internal TimeBasedFilterQosPolicy TimeBasedFilter { get; set; }
        internal ReaderDataLifecycleQosPolicy ReaderDataLifecycle { get; set; }
        internal DataRepresentationQosPolicy DataRepresentation { get; set; }
        internal TypeConsistencyEnforcementQosPolicy TypeConsistencyEnforcement { get; set; }
        internal ReliabilityQosPolicy Reliability { get; set; }
        internal TransportPriorityQosPolicy TransportPriority { get; set; }
        internal LifespanQosPolicy Lifespan { get; set; }

        public DataReaderQosImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public DurabilityQosPolicy GetDurability()
        {
            return Durability;
        }

        public DeadlineQosPolicy GetDeadline()
        {
            return Deadline;
        }

        public LatencyBudgetQosPolicy GetLatencyBudget()
        {
            return LatencyBudget;
        }

        public LivelinessQosPolicy GetLiveliness()
        {
            return Liveliness;
        }

        public DestinationOrderQosPolicy GetDestinationOrder()
        {
            return DestinationOrder;
        }

        public HistoryQosPolicy GetHistory()
        {
            return History;
        }

        public ResourceLimitsQosPolicy GetResourceLimits()
        {
            return ResourceLimits;
        }

        public UserDataQosPolicy GetUserData()
        {
            return UserData;
        }

        public OwnershipQosPolicy GetOwnership()
        {
            return Ownership;
        }

        public TimeBasedFilterQosPolicy GetTimeBasedFilter()
        {
            return TimeBasedFilter;
        }

        public ReaderDataLifecycleQosPolicy GetReaderDataLifecycle()
        {
            return ReaderDataLifecycle;
        }

        public DataRepresentationQosPolicy GetRepresentation()
        {
            return DataRepresentation;
        }

        public ReliabilityQosPolicy GetReliability()
        {
            return Reliability;
        }

        public TypeConsistencyEnforcementQosPolicy GetTypeConsistency()
        {
            return TypeConsistencyEnforcement;
        }

        public override ModifiableDataReaderQos Modify()
        {
            return new ModifiableDataReaderQosImpl(this);
        }
    }
}
