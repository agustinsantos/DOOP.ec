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
    class ModifiableDataReaderQosImpl : ModifiableDataReaderQos
    {
        private DataReaderQosImpl innerQos;
        public ModifiableDataReaderQosImpl(DataReaderQosImpl qos)
        {
            this.innerQos = qos;
        }

        public ModifiableDataReaderQosImpl(Bootstrap boostrap)
        {
            this.innerQos = new DataReaderQosImpl(boostrap);
        }
        public ModifiableDataReaderQos SetTimeBasedFilter(TimeBasedFilterQosPolicy timeBasedFilter)
        {
            this.innerQos.TimeBasedFilter = timeBasedFilter;
            return this;
        }
        public ModifiableDataReaderQos SetDurability(DurabilityQosPolicy durability)
        {
            this.innerQos.Durability = durability;
            return this;
        }

        public ModifiableDataReaderQos SetDurabilityService(DurabilityServiceQosPolicy durabilityService)
        {
            this.innerQos.DurabilityService = durabilityService;
            return this;
        }

        public ModifiableDataReaderQos SetDeadline(DeadlineQosPolicy deadline)
        {
            this.innerQos.Deadline = deadline;
            return this;
        }

        public ModifiableDataReaderQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget)
        {
            this.innerQos.LatencyBudget = latencyBudget;
            return this;
        }

        public ModifiableDataReaderQos SetLiveliness(LivelinessQosPolicy liveliness)
        {
            this.innerQos.Liveliness = liveliness;
            return this;
        }

        public ModifiableDataReaderQos SetReliability(ReliabilityQosPolicy reliability)
        {
            this.innerQos.Reliability = reliability;
            return this;
        }

        public ModifiableDataReaderQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder)
        {
            this.innerQos.DestinationOrder = destinationOrder;
            return this;
        }

        public ModifiableDataReaderQos SetHistory(HistoryQosPolicy history)
        {
            this.innerQos.History = history;
            return this;
        }

        public ModifiableDataReaderQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits)
        {
            this.innerQos.ResourceLimits = resourceLimits;
            return this;
        }

        public ModifiableDataReaderQos SetTransportPriority(TransportPriorityQosPolicy transportPriority)
        {
            this.innerQos.TransportPriority = transportPriority;
            return this;
        }

        public ModifiableDataReaderQos SetLifespan(LifespanQosPolicy lifespan)
        {
            this.innerQos.Lifespan = lifespan;
            return this;
        }

        public ModifiableDataReaderQos SetUserData(UserDataQosPolicy userData)
        {
            this.innerQos.UserData = userData;
            return this;
        }

        public ModifiableDataReaderQos SetOwnership(OwnershipQosPolicy ownership)
        {
            this.innerQos.Ownership = ownership;
            return this;
        }

        public ModifiableDataReaderQos SetOwnershipStrength(OwnershipStrengthQosPolicy ownershipStrength)
        {
            this.innerQos.OwnershipStrength = ownershipStrength;
            return this;
        }

        public ModifiableDataReaderQos SetReaderDataLifecycle(ReaderDataLifecycleQosPolicy readerDataLifecycle)
        {
            this.innerQos.ReaderDataLifecycle = readerDataLifecycle;
            return this;
        }

        public ModifiableDataReaderQos SetRepresentation(DataRepresentationQosPolicy representation)
        {
            this.innerQos.DataRepresentation = representation;
            return this;
        }

        public ModifiableDataReaderQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency)
        {
            this.innerQos.TypeConsistencyEnforcement = typeConsistency;
            return this;
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




        public DurabilityQosPolicy GetDurability()
        {
            return this.innerQos.GetDurability();
        }

        public DeadlineQosPolicy GetDeadline()
        {
            return this.innerQos.GetDeadline();
        }

        public LatencyBudgetQosPolicy GetLatencyBudget()
        {
            return this.innerQos.GetLatencyBudget();
        }

        public LivelinessQosPolicy GetLiveliness()
        {
            return this.innerQos.GetLiveliness();
        }

        public DestinationOrderQosPolicy GetDestinationOrder()
        {
            return this.innerQos.GetDestinationOrder();
        }

        public HistoryQosPolicy GetHistory()
        {
            return this.innerQos.GetHistory();
        }

        public ResourceLimitsQosPolicy GetResourceLimits()
        {
            return this.innerQos.GetResourceLimits();
        }

        public UserDataQosPolicy GetUserData()
        {
            return this.innerQos.GetUserData();
        }

        public OwnershipQosPolicy GetOwnership()
        {
            return this.innerQos.GetOwnership();
        }

        public TimeBasedFilterQosPolicy GetTimeBasedFilter()
        {
            return this.innerQos.GetTimeBasedFilter();
        }

        public ReliabilityQosPolicy GetReliability()
        {
            return this.innerQos.GetReliability();
        }

        public ReaderDataLifecycleQosPolicy GetReaderDataLifecycle()
        {
            return this.innerQos.GetReaderDataLifecycle();
        }

        public DataRepresentationQosPolicy GetRepresentation()
        {
            return this.innerQos.GetRepresentation();
        }

        public TypeConsistencyEnforcementQosPolicy GetTypeConsistency()
        {
            return this.innerQos.GetTypeConsistency();
        }

        public POLICY Get<POLICY>(QosPolicyId id) where POLICY : QosPolicy
        {
            throw new NotImplementedException();
        }

        public QosPolicy Put(QosPolicyId key, QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public QosPolicy Remove(object key)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public void Add(QosPolicyId key, QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(QosPolicyId key)
        {
            throw new NotImplementedException();
        }

        public ICollection<QosPolicyId> Keys
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(QosPolicyId key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(QosPolicyId key, out QosPolicy value)
        {
            throw new NotImplementedException();
        }

        public ICollection<QosPolicy> Values
        {
            get { throw new NotImplementedException(); }
        }

        public QosPolicy this[QosPolicyId key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<QosPolicyId, QosPolicy>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<QosPolicyId, QosPolicy>> IEnumerable<KeyValuePair<QosPolicyId, QosPolicy>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ModifiableDataReaderQos Modify()
        {
            return this;
        }
    }
}
