using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;

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
    }
}
