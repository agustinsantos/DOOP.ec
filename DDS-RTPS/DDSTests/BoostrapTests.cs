using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.core;

namespace DDSTests
{
    [TestClass]
    public class BoostrapTests
    {
        [TestMethod]
        public void TestClassNameProperty()
        {
            Assert.AreEqual("org.omg.dds.serviceClassName", Bootstrap.IMPLEMENTATION_CLASS_NAME_PROPERTY);
        }

        [TestMethod]
        public void TestCreateInstance()
        {
            // Create and return a new instance of a concrete implementation of Doopec.Dds.Core.BootstrapImpl
            Bootstrap boostrap = Bootstrap.CreateInstance();

            Assert.IsNotNull(boostrap);
            Assert.AreEqual(typeof(Doopec.Dds.Core.BootstrapImpl), boostrap.GetType());
        }

        [TestMethod]
        public void TestCreateInstance2()
        {
            // Create and return a new instance of a concrete implementation of Doopec.Dds.Core.BootstrapImpl
            Bootstrap boostrap = Bootstrap.CreateInstance(null);

            Assert.IsNotNull(boostrap);
            Assert.AreEqual(typeof(Doopec.Dds.Core.BootstrapImpl), boostrap.GetType());
        }

        [TestMethod]
        public void TestCreateInstance3()
        {
            // Create and return a new instance of a concrete implementation of Doopec.Dds.Core.BootstrapImpl
            Bootstrap boostrap = Bootstrap.CreateInstance("org.omg.dds.serviceClassName", null);

            Assert.IsNotNull(boostrap);
            Assert.AreEqual(typeof(Doopec.Dds.Core.BootstrapImpl), boostrap.GetType());
        }

        [TestMethod]
        public void TestCreateInstance4()
        {
            // Create and return a new instance of a concrete implementation of Doopec.Dds.Core.BootstrapImpl
            Bootstrap boostrap = Bootstrap.CreateInstance("Doopec-Boostrap", null);

            Assert.IsNotNull(boostrap);
            Assert.AreEqual(typeof(Doopec.Dds.Core.BootstrapImpl), boostrap.GetType());
        }

        [TestMethod]
        public void TestGetServiceProvider()
        {
            // Create and return a new instance of a concrete implementation of Doopec.Dds.Core.BootstrapImpl
            Bootstrap boostrap = Bootstrap.CreateInstance();
            Assert.IsNotNull(boostrap);
            Bootstrap.ServiceProviderInterface spi = boostrap.GetSPI();
            Assert.IsNotNull(spi);
            Assert.AreEqual(typeof(Doopec.Dds.Core.SPI), spi.GetType());
        }


    }
}
