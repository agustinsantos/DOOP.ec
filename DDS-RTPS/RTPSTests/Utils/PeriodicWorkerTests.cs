using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.Rtps.Utils;
using System.Threading;

namespace Rtps.Tests.Utils
{
    [TestClass]
    public class PeriodicWorkerTests
    {
        [TestMethod]
        public void TestWorkerVerySlow()
        {
            int period = 2 * 1000;
            int sleepTime = 20 * 1000+90;
            PeriodicWorker worker = new PeriodicWorker();
            worker.Start(period);
            Thread.Sleep(sleepTime);
            worker.End();
            Assert.AreEqual(sleepTime / period, worker.Count);
        }

        [TestMethod]
        public void TestWorkerSlow()
        {
            int period =  2 * 100;
            int sleepTime = 20 * 100 + 50;
            PeriodicWorker worker = new PeriodicWorker();
            worker.Start(period);
            Thread.Sleep(sleepTime);
            worker.End();
            Assert.AreEqual(sleepTime / period, worker.Count);
        }

        [TestMethod]
        public void TestWorkerQuick()
        {
            int period = 2 * 10;
            int sleepTime = 20 * 10 + 50;
            PeriodicWorker worker = new PeriodicWorker();
            worker.Start(period);
            Thread.Sleep(sleepTime);
            worker.End();
            Assert.AreEqual(sleepTime / period, worker.Count);
        }
    }
}
