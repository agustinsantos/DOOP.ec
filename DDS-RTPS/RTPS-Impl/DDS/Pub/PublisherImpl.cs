using DDS.ConversionUtils;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.topic;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Doopec.Dds.Pub
{
    public class PublisherImpl : Publisher
    {
        private PublisherQos qos;
        private DomainParticipant parent;
        private DataWriterQos dataWriterqos;
        private PublisherListener listener;
        private IList datawriters;

        public PublisherImpl(PublisherQos qos, PublisherListener listener, DomainParticipant dp)
        {
            this.qos = qos;
            this.listener = listener;
            this.parent = dp;
            datawriters = new System.Collections.ArrayList();
        }

        public DataWriter<TYPE> createDataWriter<TYPE>(Topic<TYPE> topic)
        {
            DataWriter<TYPE> dw = null;
            dw = new DataWriterImpl<TYPE>(this, topic);
            datawriters.Add(dw);
            return dw;
        }

        public DataWriter<TYPE> createDataWriter<TYPE>(Topic<TYPE> topic, DataWriterQos qos, DataWriterListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataWriter<TYPE> createDataWriter<TYPE>(Topic<TYPE> topic, string qosLibraryName, string qosProfileName, DataWriterListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter createBytesDataWriter(Topic<byte[]> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter createBytesDataWriter(Topic<byte[]> topic, DataWriterQos qos, DataWriterListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter createBytesDataWriter(Topic<byte[]> topic, string qosLibraryName, string qosProfileName, DataWriterListener<byte[]> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter createKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter createKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic, DataWriterQos qos, DataWriterListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter createKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topic, string qosLibraryName, string qosProfileName, DataWriterListener<org.omg.dds.type.builtin.KeyedBytes> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter createstringDataWriter(org.omg.dds.topic.Topic<string> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter createstringDataWriter(org.omg.dds.topic.Topic<string> topic, DataWriterQos qos, DataWriterListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter createstringDataWriter(org.omg.dds.topic.Topic<string> topic, string qosLibraryName, string qosProfileName, DataWriterListener<string> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter createKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter createKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic, DataWriterQos qos, DataWriterListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter createKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topic, string qosLibraryName, string qosProfileName, DataWriterListener<org.omg.dds.type.builtin.Keyedstring> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public DataWriter<TYPE> lookupDataWriter<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }

        public DataWriter<TYPE> lookupDataWriter<TYPE>(org.omg.dds.topic.Topic<TYPE> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.BytesDataWriter lookupBytesDataWriter(org.omg.dds.topic.Topic<byte[]> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedBytesDataWriter lookupKeyedBytesDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.KeyedBytes> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.stringDataWriter lookupstringDataWriter(org.omg.dds.topic.Topic<string> topicName)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.builtin.KeyedstringDataWriter lookupKeyedstringDataWriter(org.omg.dds.topic.Topic<org.omg.dds.type.builtin.Keyedstring> topicName)
        {
            throw new NotImplementedException();
        }

        public void closeContainedEntities()
        {
            throw new NotImplementedException();
        }

        public void suspendPublications()
        {
            throw new NotImplementedException();
        }

        public void resumePublications()
        {
            throw new NotImplementedException();
        }

        public void beginCoherentChanges()
        {
            throw new NotImplementedException();
        }

        public void endCoherentChanges()
        {
            throw new NotImplementedException();
        }

        public void waitForAcknowledgments(org.omg.dds.core.Duration maxWait)
        {
            throw new NotImplementedException();
        }

        public void waitForAcknowledgments(long maxWait,  TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public DataWriterQos getDefaultDataWriterQos()
        {
            throw new NotImplementedException();
        }

        public void setDefaultDataWriterQos(DataWriterQos qos)
        {
            throw new NotImplementedException();
        }

        public void setDefaultDataWriterQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void copyFromTopicQos(DataWriterQos dst, org.omg.dds.topic.TopicQos src)
        {
            throw new NotImplementedException();
        }

        public DomainParticipant getParent()
        {
            return this.parent;
        }

        public PublisherListener getListener()
        {
            return this.listener;
        }

        public void setListener(PublisherListener listener)
        {
            this.listener = listener;
        }

        public PublisherQos getQos()
        {
            return this.qos;
        }

        public void setQos(PublisherQos qos)
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

        public org.omg.dds.core.StatusCondition<Publisher> getStatusCondition()
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

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
