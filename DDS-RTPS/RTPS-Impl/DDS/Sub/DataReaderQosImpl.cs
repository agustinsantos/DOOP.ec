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

        public DurabilityQosPolicy GetDurability()
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

        public LivelinessQosPolicy GetLiveliness()
        {
            throw new NotImplementedException();
        }

        public DestinationOrderQosPolicy GetDestinationOrder()
        {
            throw new NotImplementedException();
        }

        public HistoryQosPolicy GetHistory()
        {
            throw new NotImplementedException();
        }

        public ResourceLimitsQosPolicy GetResourceLimits()
        {
            throw new NotImplementedException();
        }

        public UserDataQosPolicy GetUserData()
        {
            throw new NotImplementedException();
        }

        public OwnershipQosPolicy GetOwnership()
        {
            throw new NotImplementedException();
        }

        public TimeBasedFilterQosPolicy GetTimeBasedFilter()
        {
            throw new NotImplementedException();
        }

        public ReaderDataLifecycleQosPolicy GetReaderDataLifecycle()
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
    }
}
