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
        /// Check that DDS configuration has the correct values
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
        /// Check that QoS Profiles configuration is correct.
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
        /// Check that Transport configuration is correct.
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
        /// Check that QoS Profile exist.
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
        /// Check that Gui Kind configuration exist and is correct.
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
        /// Check that QoS Profie Policy configuration exist.
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
        /// Check that policy of Domain Participant Factory configuration is correct.
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
        /// Check that policy of QoS of domain participant configuration is correct.
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
            Assert.AreEqual("", qosProfile.DomainParticipantQos.UserData);
        }

        /// <summary>
        /// Check that policy of QoS of topic configuration is correct.
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
        /// Check that policy of QoS of publisher configuration is correct.
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
        /// Check that policy of QoS of Subscriber configuration is correct.
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
        /// Check that policy of QoS of DataWriter configuration is correct.
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
        /// Check that policy of QoS of DataReader configuration is correct.
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


        ///2.2.3.6 PRESENTATION
        ///This QoS policy controls the extent to which changes to data-instances can be 
        ///made dependent on each other and also the kind of dependencies that can be 
        ///propagated and maintained by the Service. Pag. 103

        ///<summary>
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Publisher.
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
        ///
        /// Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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
        ///Check that the PRESENTATION QoS policies are configured correctly by Subscriber.
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

        ///2.2.3.20 ENTITY_FACTORY
        ///This policy controls the behavior of the Entity as a factory for other entities.
        ///This policy concerns only DomainParticipant (as factory for Publisher, Subscriber, and Topic), 
        ///Publisher (as factory for DataWriter), and Subscriber (as factory for DataReader).
        ///This policy is mutable. A change in the policy affects only the entities created after the change; 
        ///not the previously created entities. Pag.110

        ///<summary>
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by DomainParticipantFactory.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by DomainParticipantFactory.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by DomainParticipant.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by DomainParticipant.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by Publisher.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by Publisher.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by Subscriber.
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
        ///Check that the ENTITY_FACTORY QoS policies are configured correctly by Subscriber.
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

        ///2.2.3.1 USER_DATA
        ///The purpose of this QoS is to allow the application to attach additional information 
        ///to the created Entity objects such that when a remote application discovers their 
        ///existence it can access that information and use it for its own purposes. Pag. 101

        ///<summary>
        ///Check that the USER_DATA QoS policies are configured correctly by DomainParticipant.
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
        ///Check that the USER_DATA QoS policies are configured correctly by DataReader.
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
        ///Check that the USER_DATA QoS policies are configured correctly by DataWriter.
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

        //2.2.3.2 TOPIC_DATA
        ///The purpose of this QoS is to allow the application to attach additional information 
        ///to the created Topic such that when a remote application discovers their existence 
        ///it can examine the information and use it in an application-defined way. Pag. 102

        ///<summary>
        ///Check that the TOPIC_DATA QoS policies are configured correctly by Topic.
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

        //2.2.3.7 DEADLINE
        ///This policy is useful for cases where a Topic is expected to have each instance 
        ///updated periodically. On the publishing side this setting establishes a contract 
        ///that the application must meet. On the subscribing side the setting establishes a minimum 
        ///requirement for the remote publishers that are expected to supply the data values. Pag. 104
        
        ///<summary>
        ///Check that the DEADLINE QoS policies are configured correctly by Topic.
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
        ///Check that the DEADLINE QoS policies are configured correctly by DataReader.
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
        ///Check that the DEADLINE QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.4 DURABILITY
        ///The decoupling between DataReader and DataWriter offered by the Publish/Subscribe paradigm 
        ///allows an application to write data even if there are no current readers on the network. Pag. 102

        ///<summary>
        ///Check that the DURABILITY QoS policies are configured correctly by Topic.
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
        ///Check that the DURABILITY QoS policies are configured correctly by Topic.
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
        ///Check that the DURABILITY QoS policies are configured correctly by Topic.
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
        ///Check that the DURABILITY QoS policies are configured correctly by Topic.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataReader.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataReader.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataReader.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataWriter.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataWriter.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataWriter.
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
        ///Check that the DURABILITY QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.3 GROUP_DATA
        ///The purpose of this QoS is to allow the application to attach additional information to the 
        ///created Publisher or Subscriber. The value of the GROUP_DATA is available to the application 
        ///on the DataReader and DataWriter entities and is propagated by means of the built-in topics. Pag. 102

        ///<summary>
        ///Check that the GROUP_DATA QoS policies are configured correctly by Publisher.
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
        ///Check that the GROUP_DATA QoS policies are configured correctly by Subscriber.
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

        ///2.2.3.13 PARTITION
        ///This policy allows the introduction of a logical partition concept inside the 
        ///‘physical’ partition induced by a domain. Pag.107

        ///<summary>
        ///Check that the PARTITION QoS policies are configured correctly by Publisher.
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
        ///Check that the PARTITION QoS policies are configured correctly by Subscriber.
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

        ///2.2.3.17 DESTINATION_ORDER
        ///This policy controls how each subscriber resolves the final value of a data instance 
        ///that is written by multiple DataWriter objects (which may be associated with different 
        ///Publisher objects) running on different nodes. Pag.109

        ///<summary>
        ///Check that the DESTINATION_ORDER QoS policies are configured correctly by DataReader.
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
        ///Check that the DESTINATION_ORDER QoS policies are configured correctly by DataReader.
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
        ///Check that the DESTINATION_ORDER QoS policies are configured correctly by DataWriter.
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
        ///Check that the DESTINATION_ORDER QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.18 HISTORY
        ///This policy controls the behavior of the Service when the value of an instance changes 
        ///before it is finally communicated to some of its existing DataReader entities. Pag.109

        ///<summary>
        ///Check that the HISTORY QoS policies are configured correctly by DataReader.
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
        ///Check that the HISTORY QoS policies are configured correctly by DataReader.
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
        ///Check that the HISTORY QoS policies are configured correctly by DataWriter.
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
        ///Check that the HISTORY QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.8 LATENCY_BUDGET
        ///This policy provides a means for the application to indicate to the middleware the 
        ///“urgency” of the data-communication. By having a non-zero duration the Service can 
        ///optimize its internal operation. Pag.104

        ///<summary>
        ///Check that the LATENCY_BUDGET QoS policies are configured correctly by DataReader.
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
        ///Check that the LATENCY_BUDGET QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.11 LIVELINESS
        ///This policy controls the mechanism and parameters used by the Service to ensure that 
        ///particular entities on the network are still “alive.” The liveliness can also affect 
        ///the ownership of a particular instance, as determined by the OWNERSHIP QoS policy. Pag.106

        ///<summary>
        ///Check that the LIVELINESS QoS policies are configured correctly by DataReader.
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
        ///Check that the LIVELINESS QoS policies are configured correctly by DataReader.
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
        ///Check that the LIVELINESS QoS policies are configured correctly by DataReader.
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
        ///Check that the LIVELINESS QoS policies are configured correctly by DataWriter.
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
        ///Check that the LIVELINESS QoS policies are configured correctly by DataWriter.
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
        ///Check that the LIVELINESS QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.9 OWNERSHIP
        ///This policy controls whether the Service allows multiple DataWriter objects to update 
        ///the same instance (identified by Topic + key) of a data-object. Pag.105


        ///<summary>
        ///Check that the OWERSHIP QoS policies are configured correctly by DataReader.
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
        ///Check that the OWERSHIP QoS policies are configured correctly by DataReader.
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
        ///Check that the OWERSHIP QoS policies are configured correctly by DataWriter.
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
        ///Check that the OWERSHIP QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.14 RELIABILITY
        ///This policy indicates the level of reliability requested by a DataReader or offered 
        ///by a DataWriter. These levels are ordered, BEST_EFFORT being lower than RELIABLE. 
        ///A DataWriter offering a level is implicitly offering all levels below. Pag.108

        ///<summary>
        ///Check that the RELIABILITY QoS policies are configured correctly by DataReader.
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
        ///Check that the REABILITY QoS policies are configured correctly by DataReader.
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
        ///Check that the RELIABILITY QoS policies are configured correctly by DataWriter.
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
        ///Check that the RELIABILITY QoS policies are configured correctly by Datawriter.
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

        ///2.2.3.19 RESOURCE_LIMITS
        ///This policy controls the resources that the Service can use in order to meet the 
        ///requirements imposed by the application and other QoS settings. Pag.109

        ///<summary>
        ///Check that the RESOURCE_LIMITS QoS policies are configured correctly by DataReader.
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
        ///Check that the RESOURCE_LIMITS QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.22 READER_DATA_LIFECYCLE 
        ///This policy controls the behavior of the DataReader with regards to the lifecycle of the 
        ///data-instances it manages, that is, the data-instances that have been received and for 
        ///which the DataReader maintains some internal resources. Pag.111

        ///<summary>
        ///Check that the READER_DATA_LIFECYCLE QoS policies are configured correctly by DataReader.
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

        ///2.2.3.12 TIME_BASED_FILTER
        /// This policy allows a DataReader to indicate that it does not necessarily want to see all 
        ///values of each instance published under the Topic. Rather, it wants to see at most one 
        ///change every minimum_separation period. Pag.107

        ///<summary>
        ///Check that the TIME_BASED_FILTER QoS policies are configured correctly by DataReader.
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

        ///2.2.3.5 DURABILITY_SERVICE
        ///This policy is used to configure the HISTORY QoS and the RESOURCE_LIMITS QoS used 
        ///by the fictitious DataReader and DataWriter used by the “persistence service.” The 
        ///“persistence service” is the one responsible for implementing the DURABILITY kinds 
        ///TRANSIENT and PERSISTENCE. Pag.103

        ///<summary>
        ///Check that the DURABILITY_SERVICE QoS policies are configured correctly by DataWriter.
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
        ///Check that the DURABILITY_SERVICE QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.21 WRITER_DATA_LIFECYCLE
        ///This policy controls the behavior of the DataWriter with regards to the lifecycle of the 
        ///data-instances it manages, that is, the data-instances that have been either explicitly 
        ///registered with the DataWriter using the register operations or implicitly by directly 
        ///writing the data. Pag.110

        ///<summary>
        ///Check that the WRITER_DATA_LIFECYCLE QoS policies are configured correctly by DataWriter.
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
        ///Check that the WRITER_DATA_LIFECYCLE QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.16 LIFESPAN
        ///The purpose of this QoS is to avoid delivering “stale” data to the application. Pag.108

        ///<summary>
        ///Check that the LIFESPAN QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.10 OWNERSHIP_STRENGTH
        ///This QoS policy should be used in combination with the OWNERSHIP policy. It only applies
        ///to the situation case where OWNERSHIP kind is set to EXCLUSIVE. Pag.106

        ///<summary>
        ///Check that the OWNERSHIP_STRENGTH QoS policies are configured correctly by DataWriter.
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

        ///2.2.3.15 TRANSPORT_PRIORITY
        ///The purpose of this QoS is to allow the application to take advantage of transports 
        ///capable of sending messages with different priorities. Pag.108

        ///<summary>
        ///Check that the TRANSPORT_PRIORITY QoS policies are configured correctly by DataWriter.
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
