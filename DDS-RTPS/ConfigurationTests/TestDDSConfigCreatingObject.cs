using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.domain;
using Doopec.Dds.Domain;
using org.omg.dds.pub;
using org.omg.dds.core;
using org.omg.dds.core.policy;

namespace ConfigurationTests
{
     [TestClass]
    class TestDDSConfigCreatingObject
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
    }
}
