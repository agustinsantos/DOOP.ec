using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Configuration;
using Doopec.Configuration.Dds;

namespace ConfigurationTests
{
    [TestClass]
    public class TestDDSConfig
    {
        DDSConfigurationSection ddsConfig;

        [TestInitialize]
        public void SetUp()
        {
            ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;
        }

        [TestMethod]
        public void TestExistConfiguration()
        {
            Assert.IsNotNull(ddsConfig);
        }


        [TestMethod]
        public void TestExistDomain()
        {
            Assert.AreEqual(1, ddsConfig.Domains.Count);
            Assert.AreEqual("Main", ddsConfig.Domains[0].Name);
            Assert.AreEqual("Main", ddsConfig.Domains["Main"].Name);
            Assert.AreEqual(1, ddsConfig.Domains["Main"].Id);
        }

        [TestMethod]
        public void TestExistTransport()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.Transport);
            Assert.AreEqual("defaultRtps", domain.Transport.Name);
        }

        [TestMethod]
        public void TestExistDomainParticipantFactoryQos()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.DomainParticipantFactoryQos);
            Assert.AreEqual("defaultDomainParticipantFactoryQoS", domain.QoS.DomainParticipantFactoryQos.Name);
        }

        [TestMethod]
        public void TestExistDomainParticipantQos()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.DomainParticipantQos);
            Assert.AreEqual("defaultDomainParticipantQoS", domain.QoS.DomainParticipantQos.Name);
        }

        [TestMethod]
        public void TestExistTopicQoS()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.TopicQoS);
            Assert.AreEqual("defaultTopicQoS", domain.QoS.TopicQoS.Name);
        }

        [TestMethod]
        public void TestExistPublisherQoS()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.PublisherQoS);
            Assert.AreEqual("defaultPublisherQoS", domain.QoS.PublisherQoS.Name);
        }

        [TestMethod]
        public void TestExistSubscriberQoS()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.SubscriberQoS);
            Assert.AreEqual("defaultSubscriberQoS", domain.QoS.SubscriberQoS.Name);
        }


        [TestMethod]
        public void TestExistDataWriterQoS()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.DataWriterQoS);
            Assert.AreEqual("defaultDataWriterQoS", domain.QoS.DataWriterQoS.Name);
        }

        [TestMethod]
        public void TestExistDataReaderQoS()
        {
            Domain domain = ddsConfig.Domains["Main"];
            Assert.IsNotNull(domain.QoS.DataReaderQoS);
            Assert.AreEqual("defaultDataReaderQoS", domain.QoS.DataReaderQoS.Name);
        }
    }
}
