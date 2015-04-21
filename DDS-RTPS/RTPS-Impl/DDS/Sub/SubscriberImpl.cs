using Doopec.Dds.Config;
using Doopec.Dds.Core.Policy;
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
        private DataReaderQos dataReaderqos;
        private SubscriberListener listener;
        private IList datawriters;
        private DdsConfigurationSectionHandler config = ConfigurationManager.GetSection("Doopec.Dds") as DdsConfigurationSectionHandler;
        public Bootstrap Bootstrap { get; internal set; }

        public SubscriberImpl(SubscriberQos qos, SubscriberListener listener, DomainParticipant dp, Bootstrap bootstrap)
        {
            this.qos = qos;
            this.listener = listener;
            this.parent = dp;
            this.Bootstrap = bootstrap;
            datawriters = new System.Collections.ArrayList();

            dataReaderqos = new DataReaderQosImpl(this.GetBootstrap());
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
            this.dataReaderqos = qos;
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
