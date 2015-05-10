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
        public void TestDDSConfigurationAttributes()
        {
            Assert.IsNotNull(ddsConfig);
            Assert.IsNotNull(ddsConfig.Vendor);
            Assert.IsNotNull(ddsConfig.Version);
            Assert.AreEqual("Doopec", ddsConfig.Vendor);
            Assert.AreEqual("2.1", ddsConfig.Version);
            Assert.AreEqual(new Version(2, 1), Version.Parse(ddsConfig.Version));
        }

        [TestMethod]
        public void TestboostrapType()
        {
            Assert.IsNotNull(ddsConfig);
            Assert.IsNotNull(ddsConfig.BoostrapType);
            Assert.AreEqual("default", ddsConfig.BoostrapType.Name);
            Assert.AreEqual("Doopec.Dds.Core.BootstrapImpl, Doopec", ddsConfig.BoostrapType.Type);
         }

        [TestMethod]
        public void TestExistDomains()
        {
            Assert.AreEqual(1, ddsConfig.Domains.Count);
            Assert.AreEqual("Main", ddsConfig.Domains[0].Name);
            Assert.AreEqual(0, ddsConfig.Domains[0].Id);
        }

        [TestMethod]
        public void TestExistQoSProfiles()
        {
            Assert.AreEqual(1, ddsConfig.QoSProfiles.Count);
            Assert.AreEqual("defaultQoS", ddsConfig.QoSProfiles[0].Name);
            Assert.IsNotNull(ddsConfig.QoSProfiles["defaultQoS"]);
            Assert.AreEqual("defaultQoS", ddsConfig.QoSProfiles["defaultQoS"].Name);
        }


        [TestMethod]
        public void TestExistTransport()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.TransportProfile);
            Assert.AreEqual("defaultRtps", domain.TransportProfile.Name);
        }

        [TestMethod]
        public void TestExistQoSProfile()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile);
            Assert.AreEqual("defaultQoS", domain.QoSProfile.Name);
        }

        [TestMethod]
        public void TestExistGuidKind()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.Guid);
            Assert.AreEqual(Doopec.Configuration.GuiKind.Fixed, domain.Guid.Kind);
            Assert.AreEqual("7F294ABE-33F2-40B9-BFF5-7D9376EA061C", domain.Guid.Val);
        }

        [TestMethod]
        public void TestExistQoSProfilePolicy()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile);
            Assert.AreEqual("defaultQoS", qosProfile.Name);
        }

        [TestMethod]
        public void TestExistDomainParticipantFactoryQos()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantFactoryQos);
            Assert.AreEqual("defaultDomainParticipantFactoryQoS", qosProfile.DomainParticipantFactoryQos.Name);
        }

        [TestMethod]
        public void TestExistDomainParticipantQos()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.AreEqual("defaultDomainParticipantQoS", qosProfile.DomainParticipantQos.Name);
        }

        [TestMethod]
        public void TestExistTopicQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual("defaultTopicQoS", qosProfile.TopicQoS.Name);
        }

        [TestMethod]
        public void TestExistPublisherQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual("defaultPublisherQoS", qosProfile.PublisherQoS.Name);
        }

        [TestMethod]
        public void TestExistSubscriberQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual("defaultSubscriberQoS", qosProfile.SubscriberQoS.Name);
        }


        [TestMethod]
        public void TestExistDataWriterQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual("defaultDataWriterQoS", qosProfile.DataWriterQoS.Name);
        }

        [TestMethod]
        public void TestExistDataReaderQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual("defaultDataReaderQoS", qosProfile.DataReaderQoS.Name);
        }
    }
}
