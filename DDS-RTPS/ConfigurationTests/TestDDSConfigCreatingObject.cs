using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using Doopec.Dds.Domain;
using org.omg.dds.pub;
using org.omg.dds.topic;
using org.omg.dds.core.policy;
using Doopec.Configuration;
using org.omg.dds.sub;

namespace ConfigurationTests
{
    [TestClass]
    public class TestDDSConfigCreatingObject
    {

        [TestMethod]
        public void QoSPublisherTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher pub = dp.CreatePublisher();
            PublisherQos qos = pub.GetQos();
            Assert.IsNotNull(qos);
            Assert.IsNotNull(qos.GetEntityFactory());
            Assert.IsTrue(qos.GetEntityFactory().IsAutoEnableCreatedEntities());
        }

        [TestMethod]
        public void QoSPublisherTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher pub = dp.CreatePublisher();
            PublisherQos qos = pub.GetQos();
            Assert.IsNotNull(qos);

            byte[] data = new byte[20];
            int len = qos.GetGroupData().GetValue(data, 0);
            Assert.AreEqual(0, len);
        }

        [TestMethod]
        public void QoSPublisherTest03()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher pub = dp.CreatePublisher();
            PublisherQos qos = pub.GetQos();
            Assert.IsNotNull(qos);

            byte[] data = new byte[20];
            var partitions = qos.GetPartition().GetName();
            Assert.IsNotNull(partitions);
        }

        [TestMethod]
        public void QoSPublisherTest04()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher pub = dp.CreatePublisher();
            PublisherQos qos = pub.GetQos();
            Assert.IsNotNull(qos);

            byte[] data = new byte[20];
            AccessScopeKind accessScope = qos.GetPresentation().GetAccessScope();
            Assert.AreEqual(AccessScopeKind.INSTANCE, accessScope);

            bool isCoherentAccess = qos.GetPresentation().IsCoherentAccess();
            Assert.IsTrue(isCoherentAccess);

            bool isOrderedAccess = qos.GetPresentation().IsOrderedAccess();
            Assert.IsTrue(isOrderedAccess);
        }

        [TestMethod]
        public void QoSDomainParticipantTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            DomainParticipantQos qos = dp.GetQos();
            Assert.IsNotNull(qos);
            byte[] data = new byte[20];
            string value = qos.GetUserData().GetValue(data,0).ToString();
            Assert.AreEqual("", value);
        }

        [TestMethod]
        public void QoSDomainParticipantTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            DomainParticipantQos qos = dp.GetQos();
            Assert.IsNotNull(qos);
            byte[] data = new byte[20];
            bool entityFactory = qos.GetEntityFactory().IsAutoEnableCreatedEntities();
            Assert.IsTrue(entityFactory);
        }
        [TestMethod]
        public void QoSTopicTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            TopicQos qos = tp.GetQos();
            Assert.IsNotNull(qos);
            var partitions = qos.GetTopicData().GetLength();
            Assert.AreEqual(0,partitions);
        }
     [TestMethod]
        public void QoSTopicTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            TopicQos qos = tp.GetQos();
            Assert.IsNotNull(qos);
            var period = qos.GetDeadline().GetPeriod();
            Assert.IsNotNull(period);
            Assert.AreEqual(100,period);
        }
 [TestMethod]
        public void QoSTopicTest03()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            TopicQos qos = tp.GetQos();
            Assert.IsNotNull(qos);
            DurabilityQosPolicyKind durability = qos.GetDurability().GetKind();
            Assert.IsNotNull(durability);
            Assert.AreEqual(DurabilityQosPolicyKind.VOLATILE,durability);
        }

         [TestMethod]
         public void QoSSubscriberTest01()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Subscriber sub = dp.CreateSubscriber();
             SubscriberQos qos = sub.GetQos();
             Assert.IsNotNull(qos);
             Assert.IsNotNull(qos.GetEntityFactory());
             Assert.IsTrue(qos.GetEntityFactory().IsAutoEnableCreatedEntities());
         }

         [TestMethod]
         public void QoSSubscriberTest02()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Subscriber sub = dp.CreateSubscriber();
             SubscriberQos qos = sub.GetQos();
             Assert.IsNotNull(qos);

             byte[] data = new byte[20];
             int len = qos.GetGroupData().GetValue(data, 0);
             Assert.AreEqual(0, len);
         }

         [TestMethod]
         public void QoSSubscriberTest03()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Subscriber sub = dp.CreateSubscriber();
             SubscriberQos qos = sub.GetQos();
             Assert.IsNotNull(qos);

             byte[] data = new byte[20];
             var partitions = qos.GetPartition().GetName();
             Assert.IsNotNull(partitions);
         }

         [TestMethod]
         public void QoSSubscriberTest04()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Subscriber sub = dp.CreateSubscriber();
             SubscriberQos qos = sub.GetQos();
             Assert.IsNotNull(qos);

             byte[] data = new byte[20];
             AccessScopeKind accessScope = qos.GetPresentation().GetAccessScope();
             Assert.AreEqual(AccessScopeKind.GROUP, accessScope);

             bool isCoherentAccess = qos.GetPresentation().IsCoherentAccess();
             Assert.IsFalse(isCoherentAccess);

             bool isOrderedAccess = qos.GetPresentation().IsOrderedAccess();
             Assert.IsTrue(isOrderedAccess);
         }

         [TestMethod]
         public void QoSDataWriterTest01()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var period = qos.GetDeadline().GetPeriod();
             Assert.IsNotNull(period);
             Assert.AreEqual(1, period);
         }

         [TestMethod]
         public void QoSDataWriterTest02()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             DestinationOrderQosPolicyKind destinationOrder = qos.GetDestinationOrder().GetKind();
             Assert.AreEqual(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP, destinationOrder);

         }

         [TestMethod]
         public void QoSDataWriterTest03()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             DurabilityQosPolicyKind durability = qos.GetDurability().GetKind();
             Assert.AreEqual(DurabilityQosPolicyKind.VOLATILE, durability);

         }

         [TestMethod]
         public void QoSDataWriterTest04()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var historyDepth = qos.GetDurabilityService().GetHistoryDepth();
             Assert.AreEqual(0, historyDepth);

             HistoryQosPolicyKind historyKind = qos.GetDurabilityService().GetHistoryKind();
             Assert.AreEqual(HistoryQosPolicyKind.KEEP_LAST, historyKind);

             var maxInstances = qos.GetDurabilityService().GetMaxInstances();
             Assert.AreEqual(1, maxInstances);

             var maxSamples = qos.GetDurabilityService().GetMaxSamples();
             Assert.AreEqual(1, maxSamples);

             var maxSamplesPerInstance = qos.GetDurabilityService().GetMaxSamplesPerInstance();
             Assert.AreEqual(1, maxSamplesPerInstance);

             var serviceCleanupDelay = qos.GetDurabilityService().GetServiceCleanupDelay();
             Assert.AreEqual(100, serviceCleanupDelay);
         }

         [TestMethod]
         public void QoSDataWriterTest05()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             byte[] data = new byte[20];
             HistoryQosPolicyKind kind = qos.GetHistory().GetKind();
             Assert.AreEqual(HistoryQosPolicyKind.KEEP_ALL, kind);

             var depth = qos.GetHistory().GetDepth();
             Assert.AreEqual(1, depth);

         }
         [TestMethod]
         public void QoSDataWriterTest06()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var duration = qos.GetLatencyBudget().GetDuration();
             Assert.AreEqual(100, duration);

         }
         [TestMethod]
         public void QoSDataWriterTest07()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var duration = qos.GetLifespan().GetDuration();
             Assert.AreEqual(100, duration);
         }
         [TestMethod]
         public void QoSDataWriterTest08()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             LivelinessQosPolicyKind kind = qos.GetLiveliness().GetKind();
             Assert.AreEqual(LivelinessQosPolicyKind.AUTOMATIC, kind);

             var duration = qos.GetLiveliness().GetLeaseDuration();
             Assert.AreEqual(100, duration);
         }
         [TestMethod]
         public void QoSDataWriterTest09()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             OwnershipQosPolicyKind kind = qos.GetOwnership().GetKind();
             Assert.AreEqual(OwnershipQosPolicyKind.SHARED, kind);

         }

         [TestMethod]
         public void QoSDataWriterTest10()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var value = qos.GetOwnershipStrength().GetValue();
             Assert.AreEqual(100, value);

         }

         [TestMethod]
         public void QoSDataWriterTest11()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             ReliabilityQosPolicyKind kind = qos.GetReliability().GetKind();
             Assert.AreEqual(ReliabilityQosPolicyKind.BEST_EFFORT, kind);

             var maxBlokingTime = qos.GetReliability().GetMaxBlockingTime();
             Assert.AreEqual(1000, maxBlokingTime);

         }

         [TestMethod]
         public void QoSDataWriterTest12()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var maxInstance = qos.GetResourceLimits().GetMaxInstances();
             Assert.AreEqual(1, maxInstance);

             var maxSamples = qos.GetResourceLimits().GetMaxSamples();
             Assert.AreEqual(1, maxSamples);

             var maxSamplesPerInstance = qos.GetResourceLimits().GetMaxSamplesPerInstance();
             Assert.AreEqual(1, maxSamplesPerInstance);

         }

         [TestMethod]
         public void QoSDataWriterTest13()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             var value = qos.GetTransportPriority().GetValue();
             Assert.AreEqual(1, value);

         }

         [TestMethod]
         public void QoSDataWriterTest14()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);
             byte[] data = new byte[20];
             var value = qos.GetUserData().GetValue(data,0);
             Assert.AreEqual("", value);

         }

         [TestMethod]
         public void QoSDataWriterTest15()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Publisher pub = dp.CreatePublisher();
             DataWriter<Type> dw = pub.CreateDataWriter(tp);
             DataWriterQos qos = dw.GetQos();
             Assert.IsNotNull(qos);

             bool autodisposeUnregisteredInstances = qos.GetWriterDataLifecycle().IsAutDisposeUnregisteredInstances();
             Assert.IsTrue(autodisposeUnregisteredInstances);

         }

         [TestMethod]
         public void QoSDataReaderTest01()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             var period = qos.GetDeadline().GetPeriod();
             Assert.IsNotNull(period);
             Assert.AreEqual(1, period);
         }

         [TestMethod]
         public void QoSDataReaderTest02()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             DestinationOrderQosPolicyKind destinationOrder = qos.GetDestinationOrder().GetKind();
             Assert.AreEqual(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP, destinationOrder);

         }

         [TestMethod]
         public void QoSDataReaderTest03()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             DurabilityQosPolicyKind durability = qos.GetDurability().GetKind();
             Assert.AreEqual(DurabilityQosPolicyKind.VOLATILE, durability);

         }

         [TestMethod]
         public void QoSDataReaderTest04()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             HistoryQosPolicyKind kind = qos.GetHistory().GetKind();
             Assert.AreEqual(HistoryQosPolicyKind.KEEP_LAST, kind);

             var depth = qos.GetHistory().GetDepth();
             Assert.AreEqual(1, depth);

         }
         [TestMethod]
         public void QoSDataReaderTest05()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();
             var duration = qos.GetLatencyBudget().GetDuration();
             Assert.AreEqual(100, duration);

         }
         
         [TestMethod]
         public void QoSDataReaderTest06()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             LivelinessQosPolicyKind kind = qos.GetLiveliness().GetKind();
             Assert.AreEqual(LivelinessQosPolicyKind.AUTOMATIC, kind);

             var duration = qos.GetLiveliness().GetLeaseDuration();
             Assert.AreEqual(100, duration);
         }
         [TestMethod]
         public void QoSDataReaderTest07()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             OwnershipQosPolicyKind kind = qos.GetOwnership().GetKind();
             Assert.AreEqual(OwnershipQosPolicyKind.SHARED, kind);

         }


         [TestMethod]
         public void QoSDataReaderTest08()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             ReliabilityQosPolicyKind kind = qos.GetReliability().GetKind();
             Assert.AreEqual(ReliabilityQosPolicyKind.BEST_EFFORT, kind);

             var maxBlokingTime = qos.GetReliability().GetMaxBlockingTime();
             Assert.AreEqual(1000, maxBlokingTime);

         }

         [TestMethod]
         public void QoSDataReaderTest09()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             var maxInstance = qos.GetResourceLimits().GetMaxInstances();
             Assert.AreEqual(1, maxInstance);

             var maxSamples = qos.GetResourceLimits().GetMaxSamples();
             Assert.AreEqual(1, maxSamples);

             var maxSamplesPerInstance = qos.GetResourceLimits().GetMaxSamplesPerInstance();
             Assert.AreEqual(1, maxSamplesPerInstance);

         }

         [TestMethod]
         public void QoSDataReaderTest10()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             Assert.IsNotNull(dr);
             DataReaderQos qos = dr.GetQos();

             var value = qos.GetReaderDataLifecycle().GetAutoPurgeDisposedSamplesDelay();
             Assert.AreEqual(1000, value);

             var value1 = qos.GetReaderDataLifecycle().GetAutoPurgeNoWriterSamplesDelay();
             Assert.AreEqual(1000, value1);

         }

         [TestMethod]
         public void QoSDataReaderTest11()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             DataReaderQos qos = dr.GetQos();
             Assert.IsNotNull(qos);
             var minimumSeparation = qos.GetTimeBasedFilter().GetMinimumSeparation();
             Assert.AreEqual(1000, minimumSeparation);

         }

         [TestMethod]
         public void QoSDataReaderTest12()
         {
             //PRECONDITIONS
             DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
             DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
             Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
             Subscriber sub = dp.CreateSubscriber();
             DataReader<Type> dr = sub.CreateDataReader(tp);
             DataReaderQos qos = dr.GetQos();
             Assert.IsNotNull(qos);
             byte[] data = new byte[20];
             var value = qos.GetUserData().GetValue(data, 0);
             Assert.AreEqual("", value);

         }
    }
}
