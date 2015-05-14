using Doopec.Configuration;
using Doopec.Dds.Core;
using Doopec.Dds.Core.Policy;
using Doopec.DDS.Core.Policy;
using Doopec.DDS.Sub;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type.builtin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Doopec.Dds.Sub
{
    public class SubscriberImpl : Subscriber
    {
        private SubscriberQos qos;
        private DomainParticipant parent;
        private DataReaderQosImpl dataReaderqos;
        private SubscriberListener listener;
        private IList datawriters;
        private DDSConfigurationSection ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;
        public Bootstrap Bootstrap { get; internal set; }

        public SubscriberImpl(SubscriberQos qos, SubscriberListener listener, DomainParticipant dp, Bootstrap bootstrap)
        {
            this.qos = qos;
            this.listener = listener;
            this.parent = dp;
            this.Bootstrap = bootstrap;
            datawriters = new System.Collections.ArrayList();

            dataReaderqos = new DataReaderQosImpl(this.GetBootstrap());
#if TODO
            if (config.Settings["DefaultDataWriterQoS"] != null)
            {
                string dataReaderqosName = config.Settings["DefaultDataReaderQoS"].Value;
                // TODO Assign values to dataReaderqos from configuration
                foreach (KeyValueElement dwqos in config.QoSDataWriterCollection)
                {
                    if (dwqos.Key.Equals("durability", StringComparison.InvariantCultureIgnoreCase))
                    {
                        string durabilityVal = dwqos.Value;
                    }
                }
            }
#endif
            string qosConfigProfile = ddsConfig.Domains[dp.DomainId].QoSProfile.Name;
            Doopec.Configuration.Dds.QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[qosConfigProfile];

            if (qosProfile != null)
            {
                Doopec.Configuration.Dds.DataReaderQoS dataReaderProfileQos = qosProfile.DataReaderQoS;
                // TODO Assign values to dataReaderqos from configuration
                if (dataReaderProfileQos == null)
                    return;
                if (dataReaderProfileQos.Reliability != null)
                {
                    ReliabilityQosPolicyImpl dpqMod = new ReliabilityQosPolicyImpl(this.GetBootstrap());
                    if (dataReaderProfileQos.Reliability.Kind == Doopec.Configuration.Reliability.RELIABLE)
                        dpqMod = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.RELIABLE, this.GetBootstrap());
                    else if (dataReaderProfileQos.Reliability.Kind == Doopec.Configuration.Reliability.BEST_EFFORT)
                        dpqMod = new ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind.BEST_EFFORT, this.GetBootstrap());
                    dpqMod.MaxBlockingTimeQos = new DurationImpl(this.GetBootstrap(), dataReaderProfileQos.Reliability.MaxBlockingTime);
                    dataReaderqos.Reliability = dpqMod;
                }

                if (dataReaderProfileQos.Durability != null)
                {
                    DurabilityQosPolicyImpl dpqMod = new DurabilityQosPolicyImpl(this.GetBootstrap());
                    switch (dataReaderProfileQos.Durability.Kind)
                    {
                        case Durability.PERSISTENT:
                            dpqMod.KindQos = DurabilityQosPolicyKind.PERSISTENT;
                            break;
                        case Durability.TRANSIENT:
                            dpqMod.KindQos = DurabilityQosPolicyKind.TRANSIENT;
                            break;
                        case Durability.TRANSIENT_LOCAL:
                            dpqMod.KindQos = DurabilityQosPolicyKind.TRANSIENT_LOCAL;
                            break;
                        case Durability.VOLATILE:
                            dpqMod.KindQos = DurabilityQosPolicyKind.VOLATILE;
                            break;
                    }
                    dataReaderqos.Durability = dpqMod;
                }

               
                
                if (dataReaderProfileQos.Deadline != null)
                {
                    // TODO dataWriterProfileQos.Deadline
                    DeadlineQosPolicyImpl dpqMod = new DeadlineQosPolicyImpl(this.GetBootstrap());
                }
                if (dataReaderProfileQos.LatencyBudget != null)
                {
                    // TODO dataReaderProfileQos.LatencyBudget
                    LatencyBudgetQosPolicyImpl dpqMod = new LatencyBudgetQosPolicyImpl(this.GetBootstrap());
                    
                }
                if (dataReaderProfileQos.Liveliness != null)
                {
                    // TODO dataReaderProfileQos.LatencyBudget
                    LivelinessQosPolicyImpl dpqMod = new LivelinessQosPolicyImpl(this.GetBootstrap());
                     switch (dataReaderProfileQos.Liveliness.Kind)
                     {
                         case Liveliness.AUTOMATIC:
                             dpqMod.KindQos = LivelinessQosPolicyKind.AUTOMATIC;
                             break;
                         case Liveliness.MANUAL_BY_PARTICIPANT:
                             dpqMod.KindQos = LivelinessQosPolicyKind.MANUAL_BY_PARTICIPANT;
                             break;
                         case Liveliness.MANUAL_BY_TOPIC:
                             dpqMod.KindQos = LivelinessQosPolicyKind.MANUAL_BY_TOPIC;
                             break;
                        
                     }
                     dataReaderqos.Liveliness = dpqMod;
                    
                }
                if (dataReaderProfileQos.DestinationOrder != null)
                {
                    // TODO dataWriterProfileQos.DestinationOrder
                    DestinationOrderQosPolicyImpl dpqMod = new DestinationOrderQosPolicyImpl(this.GetBootstrap());
                    switch (dataReaderProfileQos.DestinationOrder.Kind)
                    {
                        case DestinationOrder.BY_RECEPTION_TIMESTAMP:
                            dpqMod.KindQos = DestinationOrderQosPolicyKind.BY_RECEPTION_TIMESTAMP;
                            break;
                        case DestinationOrder.BY_SOURCE_TIMESTAMP:
                            dpqMod.KindQos = DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP;
                            break;
                     }
                    dataReaderqos.DestinationOrder = dpqMod;
                }
                if (dataReaderProfileQos.History != null)
                {
                    // TODO dataReaderProfileQos.History
                    HistoryQosPolicyImpl dpqMod = new HistoryQosPolicyImpl(this.GetBootstrap());
                    switch (dataReaderProfileQos.History.Kind)
                    {
                        case History.KEEP_ALL:
                            dpqMod.KindQos = HistoryQosPolicyKind.KEEP_ALL;
                            break;
                        case History.KEEP_LAST:
                            dpqMod.KindQos = HistoryQosPolicyKind.KEEP_LAST;
                            break;
                     }
                    dataReaderqos.History = dpqMod;
                }
                if (dataReaderProfileQos.ResourceLimits != null)
                {
                    // TODO dataReaderProfileQos.ResourceLimits
                    ResourceLimitsQosPolicyImpl dpqMod = new ResourceLimitsQosPolicyImpl(this.GetBootstrap());
                }
                if (dataReaderProfileQos.UserData != null)
                {
                    // TODO dataReaderProfileQos.UserData
                    UserDataQosPolicyImpl dpqMod = new UserDataQosPolicyImpl(this.GetBootstrap());
                }
                if (dataReaderProfileQos.Ownership != null)
                {
                    // TODO dataReaderProfileQos.Ownership
                    OwnershipQosPolicyImpl dpqMod = new OwnershipQosPolicyImpl(this.GetBootstrap());
                    switch (dataReaderProfileQos.Ownership.Kind)
                    {
                        case Ownership.EXCLUSIVE:
                            dpqMod.KindQos = OwnershipQosPolicyKind.EXCLUSIVE;
                            break;
                        case Ownership.SHARED:
                            dpqMod.KindQos = OwnershipQosPolicyKind.SHARED;
                            break;
                        
                    }
                    dataReaderqos.Ownership = dpqMod;
                }
                if (dataReaderProfileQos.TimeBasedFilter != null)
                {
                    // TODO dataReaderProfileQos.TimeBasedFilter
                    TimeBasedFilterQosPolicyImpl dpqMod = new TimeBasedFilterQosPolicyImpl(this.GetBootstrap());
                }
                if (dataReaderProfileQos.ReaderDataLifecycle != null)
                {
                    // TODO dataReaderProfileQos.ReaderDataLifecycle
                    ReaderDataLifecycleQosPolicyImpl dpqMod = new ReaderDataLifecycleQosPolicyImpl(this.GetBootstrap());
                }
            }
        }


        public DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic)
        {
            DataReader<TYPE> dw = null;
            dw = new DataReaderImpl<TYPE>(this, topic);
            datawriters.Add(dw);
            return dw;
        }

        public DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            DataReader<TYPE> dw = null;
            dw = new DataReaderImpl<TYPE>(this, topic, qos, listener, statuses);
            datawriters.Add(dw);
            return dw;
        }

        public DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic, DataReaderQos qos, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader CreateBytesDataReader(TopicDescription<byte[]> topic, string qosLibraryName, string qosProfileName, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic, DataReaderQos qos, DataReaderListener<KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader CreateKeyedBytesDataReader(TopicDescription<KeyedBytes> topic, string qosLibraryName, string qosProfileName, DataReaderListener<KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public stringDataReader CreatestringDataReader(TopicDescription<string> topic)
        {
            throw new NotImplementedException();
        }

        public stringDataReader CreatestringDataReader(TopicDescription<string> topic, DataReaderQos qos, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public stringDataReader CreatestringDataReader(TopicDescription<string> topic, string qosLibraryName, string qosProfileName, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic, DataReaderQos qos, DataReaderListener<Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader CreateKeyedstringDataReader(TopicDescription<Keyedstring> topic, string qosLibraryName, string qosProfileName, DataReaderListener<Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> LookupDataReader<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> LookupDataReader<TYPE>(TopicDescription<TYPE> topicName)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader LookupBytesDataReader(TopicDescription<byte[]> topicName)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader LookupKeyedBytesDataReader(TopicDescription<KeyedBytes> topicName)
        {
            throw new NotImplementedException();
        }

        public stringDataReader LookupstringDataReader(TopicDescription<string> topicName)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader LookupKeyedstringDataReader(TopicDescription<Keyedstring> topicName)
        {
            throw new NotImplementedException();
        }

        public void CloseContainedEntities()
        {
            throw new NotImplementedException();
        }

        public ICollection<DataReader<TYPE>> GetDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers)
        {
            throw new NotImplementedException();
        }

        public ICollection<DataReader<TYPE>> GetDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void NotifyDataReaders()
        {
            throw new NotImplementedException();
        }

        public void BeginAccess()
        {
            throw new NotImplementedException();
        }

        public void EndAccess()
        {
            throw new NotImplementedException();
        }

        public DataReaderQos GetDefaultDataReaderQos()
        {
            return this.dataReaderqos;
        }

        public void SetDefaultDataReaderQos(DataReaderQos qos)
        {
            this.dataReaderqos = qos as DataReaderQosImpl;
        }

        public void SetDefaultDataReaderQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void CopyFromTopicQos(DataReaderQos dst, TopicQos src)
        {
            throw new NotImplementedException();
        }

        public DomainParticipant GetParent()
        {
            return this.parent;
        }

        public SubscriberListener GetListener()
        {
            return this.listener;
        }

        public void SetListener(SubscriberListener listener)
        {
            this.listener = listener;
        }

        public SubscriberQos GetQos()
        {
            return this.qos;
        }

        public void SetQos(SubscriberQos qos)
        {
            this.qos = qos;
        }

        public void SetQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<Subscriber> GetStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> GetStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle GetInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Retain()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            return Bootstrap;
        }


        public DataReader<TYPE> CreateDataReader<TYPE>(ITopicDescription topic)
        {
            throw new NotImplementedException();
        }


        public DataReader<TYPE> CreateDataReader<TYPE>(ITopicDescription topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> CreateDataReader<TYPE>(ITopicDescription topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }
    }
}
