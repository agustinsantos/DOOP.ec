using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Rtps.Config;
using System.Configuration;

namespace Rtps.Tests.Utils
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TestRtpsExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig);
        }

        [TestMethod]
        public void TestSPDPExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.SPDPConfig);
        }

        [TestMethod]
        public void TestSPDPContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.AreEqual(5000, rtpsConfig.SPDPConfig.ResendDataPeriod);
            Assert.AreEqual("udp://239.255.0.1, udp://localhost", rtpsConfig.SPDPConfig.DiscoveryListenerUris);
            Assert.IsNotNull(rtpsConfig.SPDPConfig.WellKnownPorts);
            Assert.AreEqual(7400, rtpsConfig.SPDPConfig.WellKnownPorts.PortBase);
            Assert.AreEqual(250, rtpsConfig.SPDPConfig.WellKnownPorts.DomainIdGain);
            Assert.AreEqual(2, rtpsConfig.SPDPConfig.WellKnownPorts.ParticipantIdGain);
            Assert.AreEqual(0, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd0);
            Assert.AreEqual(10, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd1);
            Assert.AreEqual(1, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd2);
            Assert.AreEqual(1, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd3);
        }

        [TestMethod]
        public void TestWriterExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.WriterConfiguration);
        }

        [TestMethod]
        public void TestWriterContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.AreEqual(true, rtpsConfig.WriterConfiguration.PushMode);
            Assert.AreEqual(5000, rtpsConfig.WriterConfiguration.HeartbeatPeriod);
            Assert.AreEqual(200, rtpsConfig.WriterConfiguration.NackResponseDelay);
            Assert.AreEqual(0, rtpsConfig.WriterConfiguration.NackSuppressionDuration);
        }

        [TestMethod]
        public void TestReaderExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.ReaderConfiguration);
        }

        [TestMethod]
        public void TestReaderContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as RtpsConfigurationSectionHandler;
            Assert.AreEqual(100, rtpsConfig.ReaderConfiguration.HeartbeatResponseDelay);
            Assert.AreEqual(0, rtpsConfig.ReaderConfiguration.HeartbeatSuppressionDuration);
        }
    }
}
