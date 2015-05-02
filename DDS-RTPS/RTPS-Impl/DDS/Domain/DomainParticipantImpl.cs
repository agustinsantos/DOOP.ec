using Doopec.Dds.Core;
using Doopec.Dds.Pub;
using Doopec.Dds.Sub;
using Doopec.Dds.Topic;
using Doopec.Rtps;
using Doopec.Rtps.RtpsTransport;
using Doopec.Rtps.SharedMem;
using Doopec.Rtps.Structure;
using Mina.Filter.Statistic;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using org.omg.dds.type;
using Rtps.Structure;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Domain
{
    public class DomainParticipantImpl : EntityImpl<DomainParticipant,
                                                DomainParticipantListener,
                                                DomainParticipantQos>, DomainParticipant
    {
        int domainId_ = 0;
        List<Publisher> publishers_ = new List<Publisher>();
        List<Subscriber> subscribers_ = new List<Subscriber>();
        List<ITopic> topics_ = new List<ITopic>();

        Participant rtpsParticipant;

        public DomainParticipantImpl(Bootstrap bootstrap)
            : base(bootstrap)
        {
            rtpsParticipant = new ParticipantImpl();
            RtpsEngineFactory.Instance.DiscoveryModule.RegisterParticipant(rtpsParticipant);
        }

        public DomainParticipantImpl(int domainId, DomainParticipantQos qos, DomainParticipantListener listener, Bootstrap bootstrap)
            : this(bootstrap)
        {
            this.domainId_ = domainId;
            if (qos != null)
                this.SetQos(qos);
            else
                // Check default values for qos 
                throw new NotImplementedException();
            if (listener != null)
            this.SetListener(listener);
        }

        public DomainParticipantImpl(int domainId, Bootstrap bootstrap)
            : this(domainId, null, null, bootstrap)
        {
        }

        public Publisher CreatePublisher()
        {
            Publisher pub = new PublisherImpl(null, null, this, this.Bootstrap);
            AddPublisher(pub);
            return pub;
        }

        public Publisher CreatePublisher(PublisherQos qos, PublisherListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Publisher CreatePublisher(string qosLibraryName, string qosProfileName, PublisherListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber CreateSubscriber()
        {
            Subscriber sub = new SubscriberImpl(null, null, this, this.Bootstrap);
            AddSubscriber(sub);
            return sub;
        }

        public Subscriber CreateSubscriber(SubscriberQos qos, SubscriberListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber CreateSubscriber(string qosLibraryName, string qosProfileName, SubscriberListener listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Subscriber BuiltinSubscriber
        {
            get
            {
                throw new NotImplementedException();
            }

        }

        public Topic<TYPE> CreateTopic<TYPE>(string topicName)
        {
            //DomainParticipant.TOPIC_QOS_DEFAULT, null,  StatusMask.STATUS_MASK_NONE
            // look for this topic. Check id it already exists
            // raise exception if it does exist.

            // Not exists another topic qith the same name
            Topic<TYPE> topic = new TopicImpl<TYPE>(topicName, null, null, this);
            AddTopic(topic);
            return topic;
        }


        public Topic<TYPE> CreateTopic<TYPE>(string topicName, Type type, TopicQos qos, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> CreateTopic<TYPE>(string topicName, string qosLibraryName, string qosProfileName, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }


        public Topic<TYPE> CreateTopic<TYPE>(string topicName, TypeSupport<TYPE> type)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> CreateTopic<TYPE>(string topicName, TypeSupport<TYPE> type, TopicQos qos, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> CreateTopic<TYPE>(string topicName, TypeSupport<TYPE> type, string qosLibraryName, string qosProfileName, TopicListener<TYPE> listener, ICollection<Type> statuses)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> FindTopic<TYPE>(string topicName, Duration timeout)
        {
            throw new NotImplementedException();
        }

        public Topic<TYPE> FindTopic<TYPE>(string topicName, long timeout, TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public TopicDescription<TYPE> LookupTopicDescription<TYPE>(string name)
        {
            throw new NotImplementedException();
        }

        public ContentFilteredTopic<TYPE> CreateContentFilteredTopic<TYPE>(string name, Topic<TYPE> relatedTopic, string filterExpression, IList<string> expressionParameters)
        {
            throw new NotImplementedException();
        }

        public MultiTopic<TYPE> CreateMultiTopic<TYPE>(string name, string typeName, string subscriptionExpression, List<string> expressionParameters)
        {
            throw new NotImplementedException();
        }

        public void CloseContainedEntities()
        {
            throw new NotImplementedException();
        }

        public void IgnoreParticipant(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void IgnoreTopic(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void IgnorePublication(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public void IgnoreSubscription(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public int DomainId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AssertLiveliness()
        {
            throw new NotImplementedException();
        }

        public PublisherQos DefaultPublisherQos
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetDefaultPublisherQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public SubscriberQos DefaultSubscriberQos
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetDefaultSubscriberQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public TopicQos DefaultTopicQos
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void SetDefaultTopicQos(string qosLibraryName, string qosProfileName)
        {
            throw new NotImplementedException();
        }

        public ICollection<InstanceHandle> GetDiscoveredParticipants(ICollection<InstanceHandle> participantHandles)
        {
            throw new NotImplementedException();
        }

        public ParticipantBuiltinTopicData GetDiscoveredParticipantData(ParticipantBuiltinTopicData participantData, InstanceHandle participantHandle)
        {
            throw new NotImplementedException();
        }

        public ICollection<InstanceHandle> GetDiscoveredTopics(ICollection<InstanceHandle> topicHandles)
        {
            throw new NotImplementedException();
        }

        public TopicBuiltinTopicData GetDiscoveredTopicData(TopicBuiltinTopicData topicData, InstanceHandle topicHandle)
        {
            throw new NotImplementedException();
        }

        public bool ContainsEntity(InstanceHandle handle)
        {
            throw new NotImplementedException();
        }

        public ModifiableTime CurrentTime(ModifiableTime currentTime)
        {
            throw new NotImplementedException();
        }
        public override void Close()
        {
            RtpsEngineFactory.Instance.DiscoveryModule.UnregisterParticipant(rtpsParticipant);
        }

        public override void Retain()
        {
            throw new NotImplementedException();
        }


        #region API Extensions

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

        public Topic<TYPE> FindTopic<TYPE>(string topicName, long timeout, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }
    }
}
