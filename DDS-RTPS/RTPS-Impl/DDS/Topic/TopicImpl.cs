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

        public IInconsistentTopicStatus GetInconsistentTopicStatus(IInconsistentTopicStatus status)
        {
            throw new NotImplementedException();
        }

        public Type GetType()
        {
            return type;
        }

        public TopicDescription<OTHER> Cast<OTHER>()
        {
            throw new NotImplementedException();
        }

        public string GetTypeName()
        {
            return type.FullName;
        }

        public string GetName()
        {
            return topicName;
        }

        public DomainParticipant GetParent()
        {
            return parent;
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ITopicListener getListener()
        {
            return listener;
        }

        public void SetListener(ITopicListener listener)
        {
            this.listener = listener;
        }

        public TopicQos GetQos()
        {
            return qos;
        }

        public void SetQos(TopicQos qos)
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

        public StatusCondition<ITopic> getStatusCondition()
        {
            throw new NotImplementedException();
        }

        public ICollection<TYPE> GetStatusChanges<TYPE>(ICollection<TYPE> statuses)
        {
            throw new NotImplementedException();
        }

        public InstanceHandle GetInstanceHandle()
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

        public InconsistentTopicStatus<TYPE> GetInconsistentTopicStatus(InconsistentTopicStatus<TYPE> status)
        {
            throw new NotImplementedException();
        }

        TopicListener<TYPE> Entity<Topic<TYPE>, TopicListener<TYPE>, TopicQos>.GetListener()
        {
            throw new NotImplementedException();
        }

        public void SetListener(TopicListener<TYPE> listener)
        {
            throw new NotImplementedException();
        }

        StatusCondition<Topic<TYPE>> Entity<Topic<TYPE>, TopicListener<TYPE>, TopicQos>.GetStatusCondition()
        {
            throw new NotImplementedException();
        }
    }
}
