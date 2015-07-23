﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.core;
using org.omg.dds.domain;
using org.omg.dds.sub;
using org.omg.dds.topic;
using Doopec.Dds.Domain;

namespace DDSTests
{
    [TestClass]
    public class DataReaderTest
    {
        [TestMethod]
        public void TestTake()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings");
            DataReader<Type> dr = subscriber.CreateDataReader(tp);   
            Assert.IsNotNull(dr.Take());
        }
    }
}
