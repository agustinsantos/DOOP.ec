using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using Doopec.Dds.Domain;

namespace DDSTests
{
    [TestClass]
    public class DomainParticipantTests
    {
        [TestMethod]
        public void TestCreateDomainParticipant()
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
    }
}
