using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type.builtin;
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

        public DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            DataReader<TYPE> dw = null;
            dw = new DataReaderImpl<TYPE>(this, topic, qos, listener, statuses);
            datawriters.Add(dw);
            return dw;
        }

        public DataReader<TYPE> createDataReader<TYPE>(TopicDescription<TYPE> topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic, DataReaderQos qos, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader createBytesDataReader(TopicDescription<byte[]> topic, string qosLibraryName, string qosProfileName, DataReaderListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic, DataReaderQos qos, DataReaderListener<KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader createKeyedBytesDataReader(TopicDescription<KeyedBytes> topic, string qosLibraryName, string qosProfileName, DataReaderListener<KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public stringDataReader createstringDataReader(TopicDescription<string> topic)
        {
            throw new NotImplementedException();
        }

        public stringDataReader createstringDataReader(TopicDescription<string> topic, DataReaderQos qos, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public stringDataReader createstringDataReader(TopicDescription<string> topic, string qosLibraryName, string qosProfileName, DataReaderListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic, DataReaderQos qos, DataReaderListener<Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader createKeyedstringDataReader(TopicDescription<Keyedstring> topic, string qosLibraryName, string qosProfileName, DataReaderListener<Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> lookupDataReader<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> lookupDataReader<TYPE>(TopicDescription<TYPE> topicName)
        {
            throw new NotImplementedException();
        }

        public BytesDataReader lookupBytesDataReader(TopicDescription<byte[]> topicName)
        {
            throw new NotImplementedException();
        }

        public KeyedBytesDataReader lookupKeyedBytesDataReader(TopicDescription<KeyedBytes> topicName)
        {
            throw new NotImplementedException();
        }

        public stringDataReader lookupstringDataReader(TopicDescription<string> topicName)
        {
            throw new NotImplementedException();
        }

        public KeyedstringDataReader lookupKeyedstringDataReader(TopicDescription<Keyedstring> topicName)
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
            return this.dataReaderqos;
        }

        public void setDefaultDataReaderQos(DataReaderQos qos)
        {
            this.dataReaderqos = qos;
        }

        public void setDefaultDataReaderQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void copyFromTopicQos(DataReaderQos dst, TopicQos src)
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

        public org.omg.dds.core.Bootstrap GetBootstrap
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        public DataReader<TYPE> createDataReader<TYPE>(ITopicDescription topic)
        {
            throw new NotImplementedException();
        }


        public DataReader<TYPE> createDataReader<TYPE>(ITopicDescription topic, DataReaderQos qos, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataReader<TYPE> createDataReader<TYPE>(ITopicDescription topic, string qosLibraryName, string qosProfileName, DataReaderListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }
    }
}
