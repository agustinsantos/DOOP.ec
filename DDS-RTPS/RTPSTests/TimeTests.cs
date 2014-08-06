using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rtps.Messages.Types;
 
namespace Rtps.Tests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void TestTimeSeconds()
        {
            long timeMillis = 1000; // 1 sec
            Time t = new Time(timeMillis);
            long timeConverted = t.TimeMillis;

            Assert.AreEqual(timeMillis, timeConverted);
        }

        [TestMethod]
        public void TestTimeFraction()
        {
            long timeMillis = 1; // 1 msec
            Time t = new Time(timeMillis);
            long timeConverted = t.TimeMillis;

            Assert.AreEqual(timeMillis, timeConverted);
        }

        [TestMethod]
        public void TestTimeSecondsFraction()
        {
            long timeMillis = 1001; // 1 sec, 1 msec
            Time t = new Time(timeMillis);
            long timeConverted = t.TimeMillis;

            Assert.AreEqual(timeMillis, timeConverted);
        }

        [TestMethod]
        public void TestTimeCurrentTimeMillis()
        {
            long currentTimeMillis = DateTime.Now.Ticks/1000000;
            Time t = new Time(currentTimeMillis);
            long timeMillis = t.TimeMillis;

            Assert.AreEqual(currentTimeMillis, timeMillis);
        }
    }
}
