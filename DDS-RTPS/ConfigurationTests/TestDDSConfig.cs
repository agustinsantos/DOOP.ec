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
        /// <domainParticipantQos name="defaultDomainParticipantQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// <userData  value=""/>
        /// </domainParticipantQos>
        /// </summary>
        [TestMethod]
        public void TestExistDomainParticipantQos_NUEVO()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.AreEqual("defaultDomainParticipantQoS", qosProfile.DomainParticipantQos.Name);
            Assert.AreEqual("", qosProfile.DomainParticipantQos.UserData);
        }
        /// <summary>
        /// <domainParticipantQos name="defaultDomainParticipantQoS">
        /// <entityFactory autoenableCreatedEntities="true"/>
        /// <userData  value=""/>
        /// </domainParticipantQos>
        /// </summary>
        [TestMethod]
        public void TestExistDomainParticipantQos_NUEVO1()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.AreEqual("DomainParticipantQoS01", qosProfile.DomainParticipantQos.Name);
            Assert.AreEqual("user data sample", qosProfile.DomainParticipantQos.UserData);
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



        /*SERIE DE PRUEBAS 2*/


        //PRESENTATION

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="false" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation04()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="false" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation05()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation06()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="false" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation07()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="false" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation08()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="true" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation09()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation10()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation11()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="true" orderedAccess="false"/>
        ///</publisherQoS>
        ///</summary>
        [TestMethod]
        public void TestPublisherQoS_presentation12()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.PublisherQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.PublisherQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.PublisherQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>
        
        [TestMethod]
        public void TestSubscriberQoS_presentation()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="true" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="true" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="false" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation04()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="false" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation05()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation06()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.INSTANCE, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="false" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation07()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="false" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation08()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="TOPIC" coherentAccess="true" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation09()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.TOPIC, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation10()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation11()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="true" orderedAccess="false"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_presentation12()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual(AccessScope.GROUP, qosProfile.SubscriberQoS.Presentation.AccessScope);
            Assert.IsFalse(qosProfile.SubscriberQoS.Presentation.OrderedAccess);
            Assert.IsTrue(qosProfile.SubscriberQoS.Presentation.CoherentAccess);
        }

        //ENTITY_FACTORY

        ///<summary>
        ///<domainParticipantFactoryQos name="defaultDomainParticipantFactoryQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///</domainParticipantFactoryQos>
        ///</summary>

        [TestMethod]
        public void TestDomainParticipantFactoryQoS_entityFactory()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantFactoryQos);
            Assert.IsTrue(qosProfile.DomainParticipantFactoryQos.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<domainParticipantFactoryQos name="defaultDomainParticipantFactoryQoS">
        ///  <entityFactory autoenableCreatedEntities="false"/>
        ///</domainParticipantFactoryQos>
        ///</summary>

        [TestMethod]
        public void TestDomainParticipantFactoryQoS_entityFactory02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantFactoryQos);
            Assert.IsFalse(qosProfile.DomainParticipantFactoryQos.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<domainParticipantQos name="defaultDomainParticipantQoS">
        ///   <entityFactory autoenableCreatedEntities="true"/>
        ///   <userData  value=""/>
        /// </domainParticipantQos>
        ///</summary>

        [TestMethod]
        public void TestDomainParticipantQoS_entityFactory()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.IsTrue(qosProfile.DomainParticipantQos.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<domainParticipantQos name="defaultDomainParticipantQoS">
        ///   <entityFactory autoenableCreatedEntities="false"/>
        ///   <userData  value=""/>
        /// </domainParticipantQos>
        ///</summary>

        [TestMethod]
        public void TestDomainParticipantQoS_entityFactory02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.IsFalse(qosProfile.DomainParticipantQos.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>

        [TestMethod]
        public void TestPublisherQoS_entityFactory()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.IsTrue(qosProfile.PublisherQoS.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="false"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>

        [TestMethod]
        public void TestPublisherQoS_entityFactory02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.IsFalse(qosProfile.PublisherQoS.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_entityFactory()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.IsTrue(qosProfile.SubscriberQoS.EntityFactory.AutoenableCreatedEntities);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="false"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="GROUP" coherentAccess="false" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_entityFactory02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.IsFalse(qosProfile.SubscriberQoS.EntityFactory.AutoenableCreatedEntities);
        }

        //USER_DATA

        ///<summary>
        ///<domainParticipantQos name="defaultDomainParticipantQoS">
        ///   <entityFactory autoenableCreatedEntities="true"/>
        ///   <userData  value=""/>
        /// </domainParticipantQos>
        ///</summary>

        [TestMethod]
        public void TestDomainParticipantQoS_userData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DomainParticipantQos);
            Assert.AreEqual("", qosProfile.DomainParticipantQos.UserData.Value);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_userData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual("", qosProfile.DataReaderQoS.UserData.Value);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_userData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual("", qosProfile.DataWriterQoS.UserData.Value);
        }

        //TOPIC_DATA

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="VOLATILE"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_topicData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual("", qosProfile.TopicQoS.TopicData.Value);
        }

        //DEADLINE

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="VOLATILE"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_deadline()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual(100, qosProfile.TopicQoS.Deadline.Period);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_deadline()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.Deadline.Period);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_deadline()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.Deadline.Period);
        }

        //DURABILITY

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="VOLATILE"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_durability()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual(Durability.VOLATILE, qosProfile.TopicQoS.Durability.Kind);
        }

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="TRANSIENT_LOCAL"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_durability02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual(Durability.TRANSIENT_LOCAL, qosProfile.TopicQoS.Durability.Kind);
        }

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="TRANSIENT"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_durability03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual(Durability.TRANSIENT, qosProfile.TopicQoS.Durability.Kind);
        }

        ///<summary>
        ///<topicQoS name="defaultTopicQoS">
        ///  <topicData value=""/>
        ///  <deadline  period="100"/>
        ///  <durability  kind="PERSISTENT"/>
        ///</topicQoS>
        ///</summary>

        [TestMethod]
        public void TestTopicQoS_durability04()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.TopicQoS);
            Assert.AreEqual(Durability.PERSISTENT, qosProfile.TopicQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_durability()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Durability.VOLATILE, qosProfile.DataReaderQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="TRANSIENT_LOCAL"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_durability02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Durability.TRANSIENT_LOCAL, qosProfile.DataReaderQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="TRANSIENT"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_durability03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Durability.TRANSIENT, qosProfile.DataReaderQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="PERSISTENT"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_durability04()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Durability.PERSISTENT, qosProfile.DataReaderQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durability()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Durability.VOLATILE, qosProfile.DataWriterQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="TRANSIENT_LOCAL"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durability02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Durability.TRANSIENT_LOCAL, qosProfile.DataWriterQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="TRANSIENT"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durability03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Durability.TRANSIENT, qosProfile.DataWriterQoS.Durability.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="PERSISTENT"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durability04()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Durability.PERSISTENT, qosProfile.DataWriterQoS.Durability.Kind);
        }

        //GROUP_DATA

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>

        [TestMethod]
        public void TestPublisherQoS_groupData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual("", qosProfile.PublisherQoS.GroupData.Value);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_groupData()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual("", qosProfile.SubscriberQoS.GroupData.Value);
        }

        //PARTITION

        ///<summary>
        ///<publisherQoS name="defaultPublisherQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</publisherQoS>
        ///</summary>

        [TestMethod]
        public void TestPublisherQoS_partition()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.PublisherQoS);
            Assert.AreEqual("", qosProfile.PublisherQoS.Partition.Value);
        }

        ///<summary>
        ///<subscriberQoS name="defaultSubscriberQoS">
        ///  <entityFactory autoenableCreatedEntities="true"/>
        ///  <groupData value=""/>
        ///  <partition value=""/>
        ///  <presentation accessScope="INSTANCE" coherentAccess="true" orderedAccess="true"/>
        ///</subscriberQoS>
        ///</summary>

        [TestMethod]
        public void TestSubscriberQoS_partition()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.SubscriberQoS);
            Assert.AreEqual("", qosProfile.SubscriberQoS.Partition.Value);
        }

        //DESTINATION_ORDER

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_destinationOrder()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(DestinationOrder.BY_SOURCE_TIMESTAMP, qosProfile.DataReaderQoS.DestinationOrder.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_RECEPTION_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_destinationOrder02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(DestinationOrder.BY_RECEPTION_TIMESTAMP, qosProfile.DataReaderQoS.DestinationOrder.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_destinationOrder()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(DestinationOrder.BY_SOURCE_TIMESTAMP, qosProfile.DataWriterQoS.DestinationOrder.Kind );
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_RECEPTION_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_destinationOrder02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(DestinationOrder.BY_RECEPTION_TIMESTAMP, qosProfile.DataWriterQoS.DestinationOrder.Kind);
        }

        //HISTORY

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>
        ///
        [TestMethod]
        public void TestDataReaderQoS_history()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(History.KEEP_LAST, qosProfile.DataReaderQoS.History.Kind);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.History.Depth);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>
        ///
        [TestMethod]
        public void TestDataReaderQoS_history02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(History.KEEP_ALL, qosProfile.DataReaderQoS.History.Kind);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.History.Depth);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_history()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(History.KEEP_LAST, qosProfile.DataWriterQoS.History.Kind);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.History.Depth);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_ALL" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_history02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(History.KEEP_ALL, qosProfile.DataWriterQoS.History.Kind);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.History.Depth);
        }

        //LATENCY_BUDGET

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>
        
        [TestMethod]
        public void TestDataReaderQoS_latencyBudget()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(100, qosProfile.DataReaderQoS.LatencyBudget.Duration);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_latencyBudget()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.LatencyBudget.Duration);
        }

        //LIVELINESS

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_liveliness()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Liveliness.AUTOMATIC, qosProfile.DataReaderQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataReaderQoS.Liveliness.LeaseDuration);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="MANUAL_BY_PARTICIPANT" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_liveliness02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Liveliness.MANUAL_BY_PARTICIPANT, qosProfile.DataReaderQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataReaderQoS.Liveliness.LeaseDuration);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="MANUAL_BY_TOPIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_liveliness03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Liveliness.MANUAL_BY_TOPIC, qosProfile.DataReaderQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataReaderQoS.Liveliness.LeaseDuration);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_liveliness()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Liveliness.AUTOMATIC, qosProfile.DataWriterQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.Liveliness.LeaseDuration);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="MANUAL_BY_PARTICIPANT" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_liveliness02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Liveliness.MANUAL_BY_PARTICIPANT, qosProfile.DataWriterQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.Liveliness.LeaseDuration);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="MANUAL_BY_TOPIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_liveliness03()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Liveliness.MANUAL_BY_TOPIC, qosProfile.DataWriterQoS.Liveliness.Kind);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.Liveliness.LeaseDuration);
        }

        //OWNERSHIP

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_ownership()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Ownership.SHARED, qosProfile.DataReaderQoS.Ownership.Kind);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="EXCLUSIVE"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_ownership02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Ownership.EXCLUSIVE, qosProfile.DataReaderQoS.Ownership.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_ownership()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Ownership.SHARED, qosProfile.DataWriterQoS.Ownership.Kind);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="EXCLUSIVE"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_ownership02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Ownership.EXCLUSIVE, qosProfile.DataWriterQoS.Ownership.Kind);
        }

        //RELIABILITY

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_reliability()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Reliability.BEST_EFFORT, qosProfile.DataReaderQoS.Reliability.Kind);
            Assert.AreEqual(1000, qosProfile.DataReaderQoS.Reliability.MaxBlockingTime);
        }

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="RELIABLE" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_reliability02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(Reliability.RELIABLE, qosProfile.DataReaderQoS.Reliability.Kind);
            Assert.AreEqual(1000, qosProfile.DataReaderQoS.Reliability.MaxBlockingTime);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_reliability()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Reliability.BEST_EFFORT, qosProfile.DataWriterQoS.Reliability.Kind);
            Assert.AreEqual(1000, qosProfile.DataWriterQoS.Reliability.MaxBlockingTime);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="RELIABLE" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_reliability02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(Reliability.RELIABLE, qosProfile.DataWriterQoS.Reliability.Kind);
            Assert.AreEqual(1000, qosProfile.DataWriterQoS.Reliability.MaxBlockingTime);
        }

        //RESOURCE_LIMITS

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_resourceLimits()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.ResourceLimits.MaxInstances);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.ResourceLimits.MaxSamples);
            Assert.AreEqual(1, qosProfile.DataReaderQoS.ResourceLimits.MaxSamplesPerInstance);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_resourceLimits()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.ResourceLimits.MaxInstances);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.ResourceLimits.MaxSamples);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.ResourceLimits.MaxSamplesPerInstance);
        }

        //READER_DATA_LIFECYCLE

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_readerDataLifecycle()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(1000, qosProfile.DataReaderQoS.ReaderDataLifecycle.AutopurgeDisposedSamplesDelay);
            Assert.AreEqual(1000, qosProfile.DataReaderQoS.ReaderDataLifecycle.AutopurgeNowriterSamplesDelay);
        }

        //TIME_BASED_FILTER

        ///<summary>
        ///<dataReaderQoS name="defaultDataReaderQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <readerDataLifecycle autopurgeDisposedSamplesDelay="1000" autopurgeNowriterSamplesDelay="1000"/>
        ///  <timeBasedFilter minimumSeparation="1000"/>
        ///  <userData value=""/>
        ///</dataReaderQoS>
        ///</summary>

        [TestMethod]
        public void TestDataReaderQoS_timeBasedFilter()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataReaderQoS);
            Assert.AreEqual(1000, qosProfile.DataReaderQoS.TimeBasedFilter.MinimumSeparation);
        }

        //DURABILITY_SERVICE

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durabilityService()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(0, qosProfile.DataWriterQoS.DurabilityService.HistoryDepth);
            Assert.AreEqual(History.KEEP_LAST, qosProfile.DataWriterQoS.DurabilityService.HistoryKind);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxInstances);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxSamples);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxSamplesPerInstance);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.DurabilityService.ServiceCleanupDelay);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_ALL" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_durabilityService02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(0, qosProfile.DataWriterQoS.DurabilityService.HistoryDepth);
            Assert.AreEqual(History.KEEP_ALL, qosProfile.DataWriterQoS.DurabilityService.HistoryKind);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxInstances);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxSamples);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.DurabilityService.MaxSamplesPerInstance);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.DurabilityService.ServiceCleanupDelay);
        }

        //WRITER_DATA_LIFECYCLE

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_readerDataLifecycle()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.IsTrue(qosProfile.DataWriterQoS.WriterDataLifecycle.AutodisposeUnregisteredInstances);
        }

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_readerDataLifecycle02()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.IsFalse(qosProfile.DataWriterQoS.WriterDataLifecycle.AutodisposeUnregisteredInstances);
        }

        //LIFESPAN

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_lifespan()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.Lifespan.Duration);
        }

        //OWNERSHIP_STRENGTH

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_ownershipStrength()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(100, qosProfile.DataWriterQoS.OwnershipStrength.Value);
        }

        //TRANSPORT_PRIORITY

        ///<summary>
        ///<dataWriterQoS name="defaultDataWriterQoS">
        ///  <deadline period="1"/>
        ///  <destinationOrder  kind="BY_SOURCE_TIMESTAMP"/>
        ///  <durability  kind="VOLATILE"/>
        ///  <durabilityService historyDepth="0" historyKind="KEEP_LAST" maxInstances="1" maxSamples="1" maxSamplesPerInstance="1" serviceCleanupDelay="100"/>
        ///  <history kind="KEEP_LAST" depth="1"/>
        ///  <latencyBudget duration="100"/>
        ///  <lifespan duration="100"/>
        ///  <liveliness kind="AUTOMATIC" leaseDuration="100"/>
        ///  <ownership kind="SHARED"/>
        ///  <ownershipStrength value="100"/>
        ///  <reliability kind="BEST_EFFORT" maxBlockingTime="1000"/>
        ///  <resourceLimits maxInstances="1" maxSamples="1" maxSamplesPerInstance="1"/>
        ///  <transportPriority value="1"/>
        ///  <userData value=""/>
        ///  <writerDataLifecycle autodisposeUnregisteredInstances="true"/>
        ///</dataWriterQoS>
        ///</summary>

        [TestMethod]
        public void TestDataWriterQoS_transportPriority()
        {
            DomainParticipant domain = ddsConfig.Domains[0];
            Assert.IsNotNull(domain.QoSProfile.Name);
            QoSProfilePolicy qosProfile = ddsConfig.QoSProfiles[domain.QoSProfile.Name];
            Assert.IsNotNull(qosProfile.DataWriterQoS);
            Assert.AreEqual(1, qosProfile.DataWriterQoS.TransportPriority.Value);
        }

    }
}
