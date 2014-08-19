using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Rtps.Utils;
using Rtps.Structure.Types;

namespace Rtps.Tests.Utils
{
    [TestClass]
    public class GuidGeneratorTests
    {
        [TestMethod]
        public void TestGeneration1()
        {
            GuidGenerator generator = new GuidGenerator();
            GUID guid = generator.GenerateGuid();

            Assert.AreEqual(GuidGenerator.VENDORID_DOOPEC[0], guid.Prefix.Prefix[0]);
            Assert.AreEqual(GuidGenerator.VENDORID_DOOPEC[1], guid.Prefix.Prefix[1]);
        }

        [TestMethod]
        public void TestGeneration2()
        {
            GuidGenerator generator = new GuidGenerator();
            GUID guid1 = generator.GenerateGuid();
            GUID guid2 = generator.GenerateGuid();

            Assert.AreNotEqual(guid2.Prefix.ToString(), guid1.Prefix.ToString());
         }
    }
}
