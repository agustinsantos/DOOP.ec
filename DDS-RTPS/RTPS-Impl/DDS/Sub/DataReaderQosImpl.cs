using Doopec.DDS.Core;
using org.omg.dds.core.policy;
using org.omg.dds.sub;
using org.omg.dds.sub.modifiable;
using System;

namespace Doopec.DDS.Sub
{
    public class DataReaderQosImpl : EntityQosImpl<DataReaderQos, ModifiableDataReaderQos>, DataReaderQos
    {
        public static readonly DataReaderQos DDS_READER_QOS_DEFAULT = new DataReaderQosImpl();

        private DurabilityQosPolicy qosDurability;
        private DeadlineQosPolicy qosDeadLine;
        private LatencyBudgetQosPolicy qosLatencyBudget;
        private LivelinessQosPolicy qosLiveliness;
        private DestinationOrderQosPolicy qosDestinationOrder;
        private HistoryQosPolicy qosHistory;
        private ResourceLimitsQosPolicy qosResourceLimits;
        private UserDataQosPolicy qosUserData;
        private OwnershipQosPolicy qosOwnership;
        private TimeBasedFilterQosPolicy qosTimeBasedFilter;
        private ReaderDataLifecycleQosPolicy qosReaderDataLifecycle;
        private DataRepresentationQosPolicy qosDataRepresentation;
        private TypeConsistencyEnforcementQosPolicy qosTypeConsistencyEnforcement;

        public DurabilityQosPolicy getDurability()
        {
            throw new NotImplementedException();
        }

        public DeadlineQosPolicy getDeadline()
        {
            throw new NotImplementedException();
        }

        public LatencyBudgetQosPolicy getLatencyBudget()
        {
            throw new NotImplementedException();
        }

        public LivelinessQosPolicy getLiveliness()
        {
            throw new NotImplementedException();
        }

        public DestinationOrderQosPolicy getDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public HistoryQosPolicy getHistory()
        {
            throw new NotImplementedException();
        }

        public ResourceLimitsQosPolicy getResourceLimits()
        {
            throw new NotImplementedException();
        }

        public UserDataQosPolicy getUserData()
        {
            throw new NotImplementedException();
        }

        public OwnershipQosPolicy getOwnership()
        {
            throw new NotImplementedException();
        }

        public TimeBasedFilterQosPolicy getTimeBasedFilter()
        {
            throw new NotImplementedException();
        }

        public ReaderDataLifecycleQosPolicy getReaderDataLifecycle()
        {
            throw new NotImplementedException();
        }

        public DataRepresentationQosPolicy getRepresentation()
        {
            throw new NotImplementedException();
        }

        public TypeConsistencyEnforcementQosPolicy getTypeConsistency()
        {
            throw new NotImplementedException();
        }
    }
}
