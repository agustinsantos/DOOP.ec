using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.type.builtin;
using Doopec.Dds.Domain;
using Doopec.Dds.Sub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System.Collections.Generic;
using Doopec.DDS.Sub;

namespace DDSTests
{
    [TestClass]
    public class SubscriberTest
    {
        [TestMethod]
        public void TestCreateDataReader()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataReader<Type> dr = subscriber.CreateDataReader(tp);
            Assert.IsNotNull(dr);
        }

        [TestMethod]
        public void TestCreateDataReader02()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataReaderQos qosdr = new DataReaderQosImpl(Bootstrap.CreateInstance());
            DataReaderListener<Type> listener = null;
            ICollection<Type> statuses = null;
            DataReader<Type> dr = subscriber.CreateDataReader(tp, qosdr, listener, statuses);
            Assert.IsNotNull(dr);
        }

        [TestMethod]
        public void TestGetDefaultDataReaderQoS()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            DataReaderQos drqos = subscriber.GetDefaultDataReaderQos();
            Assert.IsNotNull(drqos);
        }


    }
}
