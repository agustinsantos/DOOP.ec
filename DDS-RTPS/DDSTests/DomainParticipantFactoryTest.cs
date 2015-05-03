using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using Doopec.Dds.Domain;

namespace DDSTests
{
    [TestClass]
    public class DomainParticipantFactoryTest
    {
        [TestMethod]
        public void TestGetInstance()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());
        }

        [TestMethod]
        public void TestCreateParticipant()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());

            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
            Assert.AreEqual(0, dp.RtpsParticipantId);
        }

        [TestMethod]
        public void TestCreateParticipant2()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());

            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(Doopec.Dds.Domain.DomainParticipantFactoryImpl), factory.GetType());

            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp);
            Assert.AreEqual(0, dp.DomainId);
            Assert.AreEqual(0, dp.RtpsParticipantId);

            DomainParticipantImpl dp2 = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp2);
            Assert.AreEqual(0, dp2.DomainId);
            Assert.AreEqual(1, dp2.RtpsParticipantId);

            DomainParticipantImpl dp3 = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsNotNull(dp3);
            Assert.AreEqual(0, dp3.DomainId);
            Assert.AreEqual(2, dp3.RtpsParticipantId);
        }
    }
}
