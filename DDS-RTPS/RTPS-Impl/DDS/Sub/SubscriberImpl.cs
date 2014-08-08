using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Doopec.Dds.Sub
{
    public class SubscriberImpl : Subscriber
    {
        private SubscriberQos qos;
        private DomainParticipant parent;
        private DataReaderQos dataReaderqos;
        private SubscriberListener listener;
        private IList datawriters;

        public SubscriberImpl(SubscriberQos qos, SubscriberListener listener, DomainParticipant dp)
        {
            this.qos = qos;
            this.listener = listener;
            this.parent = dp;
            datawriters = new System.Collections.ArrayList();
        }


        public DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic)
        {
            DataReader<TYPE> dw = null;
            dw = new DataReaderImpl<TYPE>(this, topic);
            datawriters.Add(dw);
            return dw;
        }

        public DataReader<TYPE> createDataReader<TYPE>(org.omg.dds.topic.TopicDescription<TYPE> topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> createDataReader<TYPE>(org.omg.dds.topic.TopicDescription<TYPE> topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataReader createBytesDataReader(org.omg.dds.topic.TopicDescription<byte[]> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataReader createBytesDataReader(org.omg.dds.topic.TopicDescription<byte[]> topic, DataReaderQos qos, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataReader createBytesDataReader(org.omg.dds.topic.TopicDescription<byte[]> topic, string qosLibraryName, string qosProfileName, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataReader createKeyedBytesDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.KeyedBytes> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataReader createKeyedBytesDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.KeyedBytes> topic, DataReaderQos qos, DataReaderListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataReader createKeyedBytesDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.KeyedBytes> topic, string qosLibraryName, string qosProfileName, DataReaderListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataReader createstringDataReader(org.omg.dds.topic.TopicDescription<string> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataReader createstringDataReader(org.omg.dds.topic.TopicDescription<string> topic, DataReaderQos qos, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataReader createstringDataReader(org.omg.dds.topic.TopicDescription<string> topic, string qosLibraryName, string qosProfileName, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataReader createKeyedstringDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.Keyedstring> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataReader createKeyedstringDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.Keyedstring> topic, DataReaderQos qos, DataReaderListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataReader createKeyedstringDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.Keyedstring> topic, string qosLibraryName, string qosProfileName, DataReaderListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> lookupDataReader<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> lookupDataReader<TYPE>(org.omg.dds.topic.TopicDescription<TYPE> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataReader lookupBytesDataReader(org.omg.dds.topic.TopicDescription<byte[]> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataReader lookupKeyedBytesDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.KeyedBytes> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataReader lookupstringDataReader(org.omg.dds.topic.TopicDescription<string> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataReader lookupKeyedstringDataReader(org.omg.dds.topic.TopicDescription<org.omg.dds.type.builtin.Keyedstring> topicName)
        {
            throw new NotImplementedException();
        }

        public void closeContainedEntities()
        {
            throw new NotImplementedException();
        }

        public ICollection<DataReader<TYPE>> getDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers)
        {
            throw new NotImplementedException();
        }

        public ICollection<DataReader<TYPE>> getDataReaders<TYPE>(ICollection<DataReader<TYPE>> readers, ICollection<SampleState> sampleStates, ICollection<ViewState> viewStates, ICollection<InstanceState> instanceStates)
        {
            throw new NotImplementedException();
        }

        public void notifyDataReaders()
        {
            throw new NotImplementedException();
        }

        public void beginAccess()
        {
            throw new NotImplementedException();
        }

        public void endAccess()
        {
            throw new NotImplementedException();
        }

        public DataReaderQos getDefaultDataReaderQos()
        {
            throw new NotImplementedException();
        }

        public void setDefaultDataReaderQos(DataReaderQos qos)
        {
            throw new NotImplementedException();
        }

        public void setDefaultDataReaderQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void copyFromTopicQos(DataReaderQos dst, org.omg.dds.topic.TopicQos src)
        {
            throw new NotImplementedException();
        }

        public DomainParticipant getParent()
        {
            return this.parent;
        }

        public SubscriberListener getListener()
        {
            return this.listener;
        }

        public void setListener(SubscriberListener listener)
        {
            this.listener = listener;
        }

        public SubscriberQos getQos()
        {
            return this.qos;
        }

        public void setQos(SubscriberQos qos)
        {
            this.qos = qos;
        }

        public void setQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.StatusCondition<Subscriber> getStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> getStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.InstanceHandle getInstanceHandle()
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

        public org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }


        public DataReader<TYPE> createDataReader<TYPE>(org.omg.dds.topic.ITopicDescription topic)
        {
            throw new NotImplementedException();
        }


        public DataReader<TYPE> createDataReader<TYPE>(org.omg.dds.topic.ITopicDescription topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> createDataReader<TYPE>(org.omg.dds.topic.ITopicDescription topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }
    }
}
