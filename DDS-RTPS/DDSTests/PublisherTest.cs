using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.type.builtin;
using Doopec.Dds.Domain;
using Doopec.Dds.Pub;
using org.omg.dds.pub;
using org.omg.dds.topic;
using System.Collections.Generic;

namespace DDSTests
{
    [TestClass]
    public class PublisherTest
    {
        [TestMethod]
        public void TestCreateDataWriter()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.IsNotNull(dw);
        }

        [TestMethod]
        public void TestCreateDataWriter02()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataWriterQos qosdw = new DataWriterQosImpl(Bootstrap.CreateInstance());
            DataWriterListener<Type> listener = null;
            ICollection<Type> statuses = null;
            DataWriter<Type> dw = publisher.CreateDataWriter(tp, qosdw, listener, statuses);
            Assert.IsNotNull(dw);
        }

        [TestMethod]
        public void TestCreateDataWriter03()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestCreateBytesDataWriter()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void TestGetDefaultDataWriterQoS()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();        
            DataWriterQos dwqos = publisher.GetDefaultDataWriterQos();
            Assert.IsNotNull(dwqos);
        }
        
    }
}
