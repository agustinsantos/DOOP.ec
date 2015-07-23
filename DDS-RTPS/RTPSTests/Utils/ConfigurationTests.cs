﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Rtps.Config;
using System.Configuration;
using Rtps;
using RTPS;


namespace Rtps.Tests.Utils
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void TestRtpsExists()
        {
            Doopec.Rtps.Config.RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig);
        }

        [TestMethod]
        public void TestSPDPExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.SPDPConfig);
        }

        [TestMethod]
        public void TestSPDPContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            /// The default rate by which SPDP periodic announcements are sent equals 30 seconds.
            Assert.AreEqual(3000, rtpsConfig.SPDPConfig.ResendDataPeriod);
            Assert.AreEqual("udp://239.255.0.1", rtpsConfig.SPDPConfig.MulticastLocatorList);
            Assert.AreEqual("udp://localhost", rtpsConfig.SPDPConfig.UnicastLocatorList);
            Assert.IsNotNull(rtpsConfig.SPDPConfig.WellKnownPorts);

            /// In order to enable out-of-the-box interoperability, the following default values must be used
            /// page 179 (9.6.1.4 Default Settings for the Simple Participant Discovery Protocol)
            Assert.AreEqual(7400, rtpsConfig.SPDPConfig.WellKnownPorts.PortBase);
            Assert.AreEqual(250, rtpsConfig.SPDPConfig.WellKnownPorts.DomainIdGain);
            Assert.AreEqual(2, rtpsConfig.SPDPConfig.WellKnownPorts.ParticipantIdGain);
            Assert.AreEqual(0, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd0);
            Assert.AreEqual(10, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd1);
            Assert.AreEqual(1, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd2);
            Assert.AreEqual(11, rtpsConfig.SPDPConfig.WellKnownPorts.Offsetd3);
        }

        [TestMethod]
        public void TestWriterExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.WriterConfiguration);
        }

        [TestMethod]
        public void TestWriterContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.AreEqual(true, rtpsConfig.WriterConfiguration.PushMode);
            Assert.AreEqual(5000, rtpsConfig.WriterConfiguration.HeartbeatPeriod);
            Assert.AreEqual(200, rtpsConfig.WriterConfiguration.NackResponseDelay);
            Assert.AreEqual(0, rtpsConfig.WriterConfiguration.NackSuppressionDuration);
        }

        [TestMethod]
        public void TestReaderExists()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.IsNotNull(rtpsConfig.ReaderConfiguration);
        }

        [TestMethod]
        public void TestReaderContent()
        {
            RtpsConfigurationSectionHandler rtpsConfig = ConfigurationManager.GetSection("Doopec.Rtps") as Doopec.Rtps.Config.RtpsConfigurationSectionHandler;
            Assert.AreEqual(100, rtpsConfig.ReaderConfiguration.HeartbeatResponseDelay);
            Assert.AreEqual(0, rtpsConfig.ReaderConfiguration.HeartbeatSuppressionDuration);
        }
    }
}
