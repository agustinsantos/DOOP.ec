using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using Doopec.Dds.Domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System.Collections.Generic;
using Doopec.Dds.Pub;
using Doopec.Dds.Sub;


namespace DDSTests
{
    [TestClass]
    public class DomainParticipantTests
    {
        [TestMethod]
        public void TestGetfactory()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());
        }

        [TestMethod]
        public void TestCreateDomainParticipant()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
            Assert.AreEqual(0, dp.RtpsParticipantId);

        }

        [TestMethod]
        public void TestClose()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());

            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
            Assert.AreEqual(0, dp.RtpsParticipantId);

            dp.Close();
            Assert.IsFalse(dp.IsEnabled);
            Assert.IsTrue(dp.IsClosed);
        }

        [TestMethod]
        public void TestCloseAndCreateNew()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());

            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
            Assert.AreEqual(0, dp.RtpsParticipantId);

            dp.Close();
            Assert.IsFalse(dp.IsEnabled);
            Assert.IsTrue(dp.IsClosed);

            DomainParticipantImpl dp2 = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp2);
            Assert.AreEqual(0, dp2.DomainId);
            Assert.AreEqual(0, dp2.RtpsParticipantId);
        }
        /// <summary>
        /// 2.2.2.2.1.1 create_publisher
        /// This operation creates a Publisher with the desired QoS policies and attaches to it the specified PublisherListener.
        /// </summary>
        [TestMethod]
        public void TestCreatePublisher01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher= dp.CreatePublisher();
            //POSTCONDITIONS
            Assert.IsNotNull(publisher);
        }

        /// <summary>
        /// 2.2.2.2.1.1 create_publisher
        /// This operation creates a Publisher with the desired QoS policies and attaches to it the specified PublisherListener.
        /// </summary>
        [TestMethod]
        public void TestCreatePublisher02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            PublisherQos qos=null;
            PublisherListener listener=null;
            ICollection<Type> statuses=null;
            Publisher publisher=dp.CreatePublisher(qos,listener,statuses);
            //POSTCONDITIONS
            Assert.IsNotNull(publisher);
        }
        [TestMethod]
        public void TestCreatePublisher03()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            PublisherQos qos = new PublisherQosImpl(factory.GetBootstrap());
            PublisherListener listener = null;
            ICollection<Type> statuses = new List<Type>();
            Publisher publisher = dp.CreatePublisher(qos, listener, statuses);
            //POSTCONDITIONS
            Assert.IsNotNull(publisher);
        }
        [TestMethod]
        public void TestCreatePublisher04()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 2.2.2.2.1.2 delete_publisher
        /// This operation deletes an existing Publisher.
        /// </summary>
        [TestMethod]
        public void TestDeletePublisher()
        {

        }


        //UTPL

        /// <summary>
        /// 2.2.2.2.1.3 create_subscriber
        /// This operation creates a Subscriber with the desired QoS policies and 
        /// attaches to it the specified PublisherListener. Pag. 24
        /// Method: Subscriber CreateSubscriber();
        /// </summary>
        [TestMethod]
        public void TestCreateSubscriber()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Assert.IsNotNull(subscriber);
        }

        /// <summary>
        /// 2.2.2.2.1.3 create_subscriber
        /// This operation creates a Subscriber with the desired QoS policies and 
        /// attaches to it the specified PublisherListener. Pag. 24
        /// Method: Subscriber CreateSubscriber();
        /// </summary>
        [TestMethod]
        public void TestCreateSubscriber02()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestCreateSubscriber03()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 2.2.2.2.1.5 create_topic
        /// This operation creates a Topic with the desired QoS policies 
        /// and attaches to it the specified TopicListener. Pag. 24
        /// Method: Subscriber CreateSubscriber();
        /// </summary>
        [TestMethod]
        public void TestCreateTopic()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            Assert.IsNotNull(tp);
            Assert.AreEqual("Greetings", tp.Name);
        }

        /// <summary>
        /// 2.2.2.2.1.26 get_domain_id
        /// This operation retrieves the domain_id used to create the DomainParticipant. 
        /// The domain_id identifies the DDS domain to which the DomainParticipant belongs. Pag. 30
        /// Method: int DomainId { get; }
        /// </summary>
        [TestMethod]
        public void TestDomainId()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant(0) as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
        }
        
    }
}
