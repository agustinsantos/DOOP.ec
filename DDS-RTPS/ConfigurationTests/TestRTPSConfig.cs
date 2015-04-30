using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Configuration;
using Doopec.Configuration.Dds;
using Doopec.Configuration.Rtps;

namespace ConfigurationTests
{
    [TestClass]
    public class TestRTPSConfig
    {
       RTPSConfigurationSection rtpsConfig;

        [TestInitialize]
        public void SetUp()
        {
            rtpsConfig = Doopec.Configuration.RTPSConfigurationSection.Instance;
        }

        [TestMethod]
        public void TestExistConfiguration()
        {
            Assert.IsNotNull(rtpsConfig);
        }


        [TestMethod]
        public void TestExistTransport()
        {
            Assert.AreEqual(1, rtpsConfig.Transports.Count);
            Assert.AreEqual("defaultRtps", rtpsConfig.Transports[0].Name);
            Assert.AreEqual("defaultRtps", rtpsConfig.Transports["defaultRtps"].Name);
            Assert.AreEqual("namespace.class, assembly", rtpsConfig.Transports["defaultRtps"].Type);
        }

        [TestMethod]
        public void TestExistTTL()
        {
            Transport transport = rtpsConfig.Transports["defaultRtps"];
            Assert.IsNotNull(transport);
            Assert.AreEqual(1, transport.TTL.Val);
        }

        [TestMethod]
        public void TestExistDiscovery()
        {
            Transport transport = rtpsConfig.Transports["defaultRtps"];
            Discovery discovery = transport.Discovery;
            Assert.IsNotNull(discovery);
            Assert.AreEqual("defaultDiscovery", discovery.Name);
        }
    }
}
