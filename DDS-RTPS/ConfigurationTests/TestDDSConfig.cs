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

        /// <summary>
        /// Check that DDS configuration has the correct values.
        /// <DDS xmlns="urn:Configuration" vendor="Doopec" version="2.1">
        /// </summary>
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
        /// <summary>
        /// 
        /// <boostrapType name="default" type="Doopec.Dds.Core.BootstrapImpl, Doopec"/>
        /// </summary>
        [TestMethod]
        public void TestboostrapType()
        {
            Assert.IsNotNull(ddsConfig);
            Assert.IsNotNull(ddsConfig.BoostrapType);
            Assert.AreEqual("default", ddsConfig.BoostrapType.Name);
            Assert.AreEqual("Doopec.Dds.Core.BootstrapImpl, Doopec", ddsConfig.BoostrapType.Type);
         }
        /// <summary>
        /// Check that domain configuration is correct.
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistDomains()
        {
            Assert.AreEqual(1, ddsConfig.Domains.Count);
            Assert.AreEqual("Main", ddsConfig.Domains[0].Name);
            Assert.AreEqual(0, ddsConfig.Domains[0].Id);
        }
        /// <summary>
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistQoSProfiles()
        {
            Assert.AreEqual(1, ddsConfig.QoSProfiles.Count);
            Assert.AreEqual("defaultQoS", ddsConfig.QoSProfiles[0].Name);
            Assert.IsNotNull(ddsConfig.QoSProfiles["defaultQoS"]);
            Assert.AreEqual("defaultQoS", ddsConfig.QoSProfiles["defaultQoS"].Name);
        }

        /// <summary>
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistTransport()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.TransportProfile);
            Assert.AreEqual("defaultRtps", domain.TransportProfile.Name);
        }
        /// <summary>
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistQoSProfile()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile);
            Assert.AreEqual("defaultQoS", domain.QoSProfile.Name);
        }
        /// <summary>
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistGuidKind()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.Guid);
            Assert.AreEqual(Doopec.Configuration.GuiKind.Fixed, domain.Guid.Kind);
            Assert.AreEqual("7F294ABE-33F2-40B9-BFF5-7D9376EA061C", domain.Guid.Val);
        }
        /// <summary>
        /// <domain name="Main" id="0">
        /// <transportProfile name="defaultRtps"/>
        /// <qoSProfile name="defaultQoS"/>
        /// <guid kind="Fixed" val="7F294ABE-33F2-40B9-BFF5-7D9376EA061C"/>
        /// </domain>
        /// </summary>
        [TestMethod]
        public void TestExistQoSProfilePolicy()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile);
            Assert.AreEqual("defaultQoS", qosProfile.Name);
        }
        /// <summary>
        /// <qoSProfileDef name="defaultQoS">
        /// <domainParticipantFactoryQos name="defaultDomainParticipantFactoryQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// </domainParticipantFactoryQos>
        /// </summary>
        [TestMethod]
        public void TestExistDomainParticipantFactoryQos()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantFactoryQos);
            Assert.AreEqual("defaultDomainParticipantFactoryQoS", qosProfile.DomainParticipantFactoryQos.Name);
        }
        /// <summary>
        /// <domainParticipantQos name="defaultDomainParticipantQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// <userData  value=""/>
        /// </domainParticipantQos>
        /// </summary>
        [TestMethod]
        public void TestExistDomainParticipantQos()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.AreEqual("defaultDomainParticipantQoS", qosProfile.DomainParticipantQos.Name);
        }
        /// <summary>
        /// <topicQoS name="defaultTopicQoS">
        /// <topicData value=""/>
        /// <deadline  period="100"/>
        /// <durability  kind="VOLATILE"/>
        /// </topicQoS>
        /// </summary>
        [TestMethod]
        public void TestExistTopicQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual("defaultTopicQoS", qosProfile.TopicQoS.Name);
        }
        /// <summary>
        /// <publisherQoS name="defaultPublisherQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// <groupData value=""/>
        /// <partition value=""/>
        /// <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        /// </publisherQoS>
        /// </summary>
        [TestMethod]
        public void TestExistPublisherQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual("defaultPublisherQoS", qosProfile.PublisherQoS.Name);
        }
        /// <summary>
        /// <subscriberQoS name="defaultSubscriberQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// <groupData value=""/>
        /// <partition value=""/>
        /// <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        /// </subscriberQoS>
        /// </summary>
        [TestMethod]
        public void TestExistSubscriberQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual("defaultSubscriberQoS", qosProfile.SubscriberQoS.Name);
        }

        /// <summary>
        /// <dataWriterQoS name="defaultDataWriterQoS">
        /// <deadline period="1"/>
        /// <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        /// <durability  kind="VOLATILE"/>
        /// <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        /// <history kind="KEEP_LAST" depth="1"/>
        /// <latencyBudget duration="100"/>
        /// <lifespan duration="100"/>
        /// <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        /// <ownership kind="SHARED"/>
        /// <ownershipStrength value="100"/>
        /// <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        /// <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        /// <transportPriority value="1"/>
        /// <userData value=""/>
        /// <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        /// </dataWriterQoS>
        /// </summary>
        [TestMethod]
        public void TestExistDataWriterQoS()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual("defaultDataWriterQoS", qosProfile.DataWriterQoS.Name);
        }
        /// <summary>
        /// <dataReaderQoS name="defaultDataReaderQoS">
        /// <deadline period="1"/>
        /// <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        /// <durability  kind="VOLATILE"/>
        /// <history kind="KEEP_LAST" depth="1"/>
        /// <latencyBudget duration="100"/>
        /// <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        /// <ownership kind="SHARED"/>
        /// <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        /// <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        /// <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        /// <timeBasedFilter minimumSeparation="1000"/>
        /// <userData value=""/>
        /// </dataReaderQoS>
        /// </summary>
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
