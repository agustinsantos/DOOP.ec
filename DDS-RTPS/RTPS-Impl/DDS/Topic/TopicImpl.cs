using Doopec.Dds.Domain;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.topic;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Topic
{
    internal class TopicImpl<TYPE> : Topic<TYPE>
    {
        private string topicName;
        private Type type;
        private TopicQos qos;
        private ITopicListener listener;
        private DomainParticipant parent;

        public TopicImpl( string topicName, TopicQos qos, ITopicListener listener, DomainParticipantImpl participant)
        {
            this.type = typeof(TYPE);
            this.topicName = topicName;
            this.qos = qos;
            this.listener = listener;
            this.parent = participant;
        }

        public IInconsistentTopicStatus getInconsistentTopicStatus(IInconsistentTopicStatus status)
        {
            throw new NotImplementedException();
        }

        public Type getType()
        {
            return type;
        }

        public TopicDescription<OTHER> cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public string getTypeName()
        {
            return type.FullName;
        }

        public string getName()
        {
            return topicName;
        }

        public DomainParticipant getParent()
        {
            return parent;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ITopicListener getListener()
        {
            return listener;
        }

        public void setListener(ITopicListener listener)
        {
            this.listener = listener;
        }

        public TopicQos getQos()
        {
            return qos;
        }

        public void setQos(TopicQos qos)
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

        public StatusCondition<ITopic> getStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> getStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public InstanceHandle getInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public void Retain()
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { return topicName; }
            set { topicName = value; }
        }

        public Type Type
        {
            get { return type; }
        }

        public InconsistentTopicStatus<TYPE> getInconsistentTopicStatus(InconsistentTopicStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        TopicListener<TYPE> Entity<Topic<TYPE>, TopicListener<TYPE>, TopicQos>.getListener()
        {
            throw new NotImplementedException();
        }

        public void setListener(TopicListener<TYPE> listener)
        {
            throw new NotImplementedException();
        }

        StatusCondition<Topic<TYPE>> Entity<Topic<TYPE>, TopicListener<TYPE>, TopicQos>.getStatusCondition()
        {
            throw new NotImplementedException();
        }
    }
}
