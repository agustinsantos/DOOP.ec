using Doopec.Dds.Pub;
using Doopec.Dds.Sub;
using Doopec.Dds.Topic;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Domain
{
    public class DomainParticipantImpl : DomainParticipant
    {
        int domainId_ = 0;
        List<Publisher> publishers_ = new List<Publisher>();
        List<Subscriber> subscribers_ = new List<Subscriber>();
        DomainParticipantQos qos_;
        DomainParticipantListener listener_ = null;

        List<ITopic> topics_ = new List<ITopic>();

        public DomainParticipantImpl() { }

        public DomainParticipantImpl(int domainId, DomainParticipantQos qos, DomainParticipantListener listener)
        {
            this.domainId_ = domainId;
            this.qos_ = qos;
            this.listener_ = listener;
        }

        public DomainParticipantImpl(int domainId)
            : this(domainId, null, null)
        {
            // Check default values for qos and listener
            throw new NotImplementedException();
        }

        public Publisher createPublisher()
        {
            Publisher pub = new PublisherImpl(null, null, this);
            AddPublisher(pub);
            return pub;
        }

        public Publisher createPublisher(PublisherQos qos, PublisherListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Publisher createPublisher(string qosLibraryName, string qosProfileName, PublisherListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber createSubscriber()
        {
            Subscriber sub = new SubscriberImpl(null, null, this);
            AddSubscriber(sub);
            return sub;
        }

        public Subscriber createSubscriber(SubscriberQos qos, SubscriberListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber createSubscriber(string qosLibraryName, string qosProfileName, SubscriberListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber getBuiltinSubscriber()
        {
            throw new NotImplementedException();
        }

        public ITopic createTopic(string topicName)
        {
            throw new NotImplementedException();
        }

        public ITopic createTopic(string topicName, Type type)
        {
            throw new NotImplementedException();
        }
        public Topic<TYPE> createTopic<TYPE>(string topicName)
        {
            throw new NotImplementedException();
        }


        public Topic<TYPE> createTopic<TYPE>(string topicName, Type type, TopicQos qos, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> createTopic<TYPE>(string topicName, Type type, string qosLibraryName, string qosProfileName, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public ITopic createTopic(string topicName, Type type, TopicQos qos, ITopicListener listener, ICollection<Type> statuses)
        {
            // look for this topic. Check id it already exists
            // raise exception if it does exist.

            // Not exists another topic qith the same name
            ITopic topic = new TopicImpl(type, topicName, qos, listener, this);
            AddTopic(topic);
            return topic;
        }

        public ITopic createTopic(string topicName, Type type, string qosLibraryName, string qosProfileName, ITopicListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> createTopic<TYPE>(string topicName, TypeSupport<TYPE> type)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> createTopic<TYPE>(string topicName, TypeSupport<TYPE> type, TopicQos qos, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> createTopic<TYPE>(string topicName, TypeSupport<TYPE> type, string qosLibraryName, string qosProfileName, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> findTopic<TYPE>(string topicName, Duration timeout)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> findTopic<TYPE>(string topicName, long timeout, DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public TopicDescription<TYPE> lookupTopicDescription<TYPE>(string name)
        {
            throw new NotImplementedException();
        }

        public ContentFilteredTopic<TYPE> createContentFilteredTopic<TYPE>(string name, Topic<TYPE> relatedTopic, string filterExpression, IList<string> expressionParameters)
        {
            throw new NotImplementedException();
        }

        public MultiTopic<TYPE> createMultiTopic<TYPE>(string name, string typeName, string subscriptionExpression, List<string> expressionParameters)
        {
            throw new NotImplementedException();
        }

        public void closeContainedEntities()
        {
            throw new NotImplementedException();
        }

        public void ignoreParticipant(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void ignoreTopic(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void ignorePublication(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void ignoreSubscription(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public int getDomainId()
        {
            throw new NotImplementedException();
        }

        public void assertLiveliness()
        {
            throw new NotImplementedException();
        }

        public PublisherQos getDefaultPublisherQos()
        {
            throw new NotImplementedException();
        }

        public void setDefaultPublisherQos(PublisherQos qos)
        {
            throw new NotImplementedException();
        }

        public void setDefaultPublisherQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public SubscriberQos getDefaultSubscriberQos()
        {
            throw new NotImplementedException();
        }

        public void setDefaultSubscriberQos(SubscriberQos qos)
        {
            throw new NotImplementedException();
        }

        public void setDefaultSubscriberQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public TopicQos getDefaultTopicQos()
        {
            throw new NotImplementedException();
        }

        public void setDefaultTopicQos(TopicQos qos)
        {
            throw new NotImplementedException();
        }

        public void setDefaultTopicQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public ICollection<InstanceHandle> getDiscoveredParticipants(ICollection<InstanceHandle> participantHandles)
        {
            throw new NotImplementedException();
        }

        public ParticipantBuiltinTopicData getDiscoveredParticipantData(ParticipantBuiltinTopicData participantData, InstanceHandle participantHandle)
        {
            throw new NotImplementedException();
        }

        public ICollection<InstanceHandle> getDiscoveredTopics(ICollection<InstanceHandle> topicHandles)
        {
            throw new NotImplementedException();
        }

        public TopicBuiltinTopicData getDiscoveredTopicData(TopicBuiltinTopicData topicData, InstanceHandle topicHandle)
        {
            throw new NotImplementedException();
        }

        public bool containsEntity(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public ModifiableTime getCurrentTime(ModifiableTime currentTime)
        {
            throw new NotImplementedException();
        }

        public DomainParticipantListener getListener()
        {
            throw new NotImplementedException();
        }

        public void setListener(DomainParticipantListener listener)
        {
            throw new NotImplementedException();
        }

        public DomainParticipantQos getQos()
        {
            throw new NotImplementedException();
        }

        public void setQos(DomainParticipantQos qos)
        {
            throw new NotImplementedException();
        }

        public void setQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public void Enable()
        {
            throw new NotImplementedException();
        }

        public StatusCondition<DomainParticipant> getStatusCondition()
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

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Retain()
        {
            throw new NotImplementedException();
        }

        public Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }


        #region API Extensions

        public DomainParticipantQos Qos
        {
            get { return qos_; }
            set { qos_ = value; }
        }

        public DomainParticipantListener Listener
        {
            get { return listener_; }
            set { listener_ = value; }
        }

        internal protected void AddPublisher(Publisher pub)
        {
            this.publishers_.Add(pub);
        }

        internal protected void DeletePublisher(Publisher pub)
        {
            this.publishers_.Remove(pub);
        }

        internal protected void AddSubscriber(Subscriber sub)
        {
            this.subscribers_.Add(sub);
        }

        internal protected void DeleteSubscriber(Subscriber sub)
        {
            this.subscribers_.Remove(sub);
        }

        internal protected void AddTopic(ITopic topic)
        {
            this.topics_.Add(topic);
        }

        internal protected void DeleteTopic(ITopic topic)
        {
            this.topics_.Remove(topic);
        }
        #endregion


    }
}
