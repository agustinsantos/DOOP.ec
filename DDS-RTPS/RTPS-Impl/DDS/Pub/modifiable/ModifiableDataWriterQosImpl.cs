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
    class ModifiableDataWriterQosImpl : ModifiableDataWriterQos
    {
        private DataWriterQosImpl innerQos;

        public ModifiableDataWriterQosImpl(DataWriterQosImpl qos)
         {
            this.innerQos = qos;
         }

        public ModifiableDataWriterQosImpl(Bootstrap boostrap)
 
        {
            this.innerQos = new DataWriterQosImpl(boostrap);
        }

        public ModifiableDataWriterQos SetDurability(DurabilityQosPolicy durability)
        {
            this.innerQos.Durability = durability;
            return this;
        }

        public ModifiableDataWriterQos SetDurabilityService(DurabilityServiceQosPolicy durabilityService)
        {
            this.innerQos.DurabilityService = durabilityService;
            return this;
        }

        public ModifiableDataWriterQos SetDeadline(DeadlineQosPolicy deadline)
        {
            this.innerQos.Deadline = deadline;
            return this;
        }

        public ModifiableDataWriterQos SetLatencyBudget(LatencyBudgetQosPolicy latencyBudget)
        {
            this.innerQos.LatencyBudget = latencyBudget;
            return this;
        }

        public ModifiableDataWriterQos SetLiveliness(LivelinessQosPolicy liveliness)
        {
            this.innerQos.Liveliness = liveliness;
            return this;
        }

        public ModifiableDataWriterQos SetReliability(ReliabilityQosPolicy reliability)
        {
            this.innerQos.Reliability = reliability;
            return this;
        }

        public ModifiableDataWriterQos SetDestinationOrder(DestinationOrderQosPolicy destinationOrder)
        {
            this.innerQos.DestinationOrder = destinationOrder;
            return this;
        }

        public ModifiableDataWriterQos SetHistory(HistoryQosPolicy history)
        {
            this.innerQos.History = history;
            return this;
        }

        public ModifiableDataWriterQos SetResourceLimits(ResourceLimitsQosPolicy resourceLimits)
        {
            this.innerQos.ResourceLimits = resourceLimits;
            return this;
        }

        public ModifiableDataWriterQos SetTransportPriority(TransportPriorityQosPolicy transportPriority)
        {
            this.innerQos.TransportPriority = transportPriority;
            return this;
        }

        public ModifiableDataWriterQos SetLifespan(LifespanQosPolicy lifespan)
        {
            this.innerQos.Lifespan = lifespan;
            return this;
        }

        public ModifiableDataWriterQos SetUserData(UserDataQosPolicy userData)
        {
            this.innerQos.UserData = userData;
            return this;
        }

        public ModifiableDataWriterQos SetOwnership(OwnershipQosPolicy ownership)
        {
            this.innerQos.Ownership = ownership;
            return this;
        }

        public ModifiableDataWriterQos SetOwnershipStrength(OwnershipStrengthQosPolicy ownershipStrength)
        {
            this.innerQos.OwnershipStrength = ownershipStrength;
            return this;
        }

        public ModifiableDataWriterQos SetWriterDataLifecycle(WriterDataLifecycleQosPolicy writerDataLifecycle)
        {
            this.innerQos.WriterDataLifecycle = writerDataLifecycle;
            return this;
        }

        public ModifiableDataWriterQos SetRepresentation(DataRepresentationQosPolicy representation)
        {
            this.innerQos.Representation = representation;
            return this;
        }

        public ModifiableDataWriterQos SetTypeConsistency(TypeConsistencyEnforcementQosPolicy typeConsistency)
        {
            this.innerQos.TypeConsistency = typeConsistency;
            return this;
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
            throw new NotImplementedException();
        }

        public DataWriterQos FinishModification()
        {
            return this.innerQos;
        }

        public DurabilityQosPolicy GetDurability()
        {
            return this.innerQos.GetDurability();
        }

        public DurabilityServiceQosPolicy GetDurabilityService()
        {
            return this.innerQos.GetDurabilityService();
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

        public ReliabilityQosPolicy GetReliability()
        {
            return this.innerQos.GetReliability();
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

        public TransportPriorityQosPolicy GetTransportPriority()
        {
            return this.innerQos.GetTransportPriority();
        }

        public LifespanQosPolicy GetLifespan()
        {
            return this.innerQos.GetLifespan();
        }

        public UserDataQosPolicy GetUserData()
        {
            return this.innerQos.GetUserData();
        }

        public OwnershipQosPolicy GetOwnership()
        {
            return this.innerQos.GetOwnership();
        }

        public OwnershipStrengthQosPolicy GetOwnershipStrength()
        {
            return this.innerQos.GetOwnershipStrength();
        }

        public WriterDataLifecycleQosPolicy GetWriterDataLifecycle()
        {
            return this.innerQos.GetWriterDataLifecycle();
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
            this.innerQos.Clear();
        }

        public Bootstrap GetBootstrap()
        {
            return this.innerQos.GetBootstrap();
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
                return this.innerQos[key];
            }
            set
            {
                this.innerQos[key] = value;
            }
        }

        public void Add(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            this.innerQos.Add(item);
        }

        public bool Contains(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            return this.innerQos.Contains(item);
        }

        public void CopyTo(KeyValuePair<QosPolicyId, QosPolicy>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return this.innerQos.Count; }
        }

        public bool IsReadOnly
        {
            get { return this.innerQos.IsReadOnly; }
        }

        public bool Remove(KeyValuePair<QosPolicyId, QosPolicy> item)
        {
            return this.innerQos.Remove(item);
        }

        public IEnumerator<KeyValuePair<QosPolicyId, QosPolicy>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.innerQos.GetEnumerator();
        }

        public ModifiableDataWriterQos Modify()
        {
            return this;
        }
    }
}