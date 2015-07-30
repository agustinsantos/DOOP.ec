using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.topic;
using Doopec.Dds.Domain;
using Doopec.Dds.Pub;
using Doopec.Dds.Core.Policy;
using System.Collections.Generic;

namespace DDSTests
{
    [TestClass]
    public class DataWriterTest
    {

        /// <summary> 
        /// Method: System.Type GetType();
        /// </summary>

        [TestMethod]
        public void TestGetType()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.IsNotNull(tp);
            Assert.IsNotNull(dw.GetType()); 
        }

        /// <summary>
        /// 2.2.2.4.2.20 get_topic
        /// This operation returns the Topic associated with the DataWriter. 
        /// This is the same Topic that was used to create the DataWriter. Pag. 55
        /// Method: Topic<TYPE> GetTopic();
        /// </summary>
        [TestMethod]
        public void TestGetTopic()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.IsNotNull(tp);
            Assert.AreEqual("Greetings", dw.GetTopic().Name);
        }

        /// <summary>
        /// PARENT GetParent();
        /// </summary>
        [TestMethod]
        public void TestGetParent()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.AreEqual(publisher, dw.GetParent());
        }

        [TestMethod]
        public void TestGetListener()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.IsNotNull( dw.GetListener());
        }

        [TestMethod]
        public void TestGetQoS()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            DataWriterQosImpl dwqos = new DataWriterQosImpl(new DurabilityQosPolicyImpl(Bootstrap.CreateInstance()), Bootstrap.CreateInstance());
            dw.SetQos(dwqos);
            Assert.AreEqual(dwqos.GetDurability(), dw.GetQos().GetDurability());
            Assert.IsNotNull(dw.GetQos());
        }

    }
}
