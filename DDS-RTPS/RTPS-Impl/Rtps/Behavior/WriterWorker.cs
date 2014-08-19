using Common.Logging;
using Doopec.Rtps.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Behavior
{
    public class WriterWorker : PeriodicWorker
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public delegate void PeriodicWorkDelegate();

        private PeriodicWorkDelegate periodicWork;

        public WriterWorker()
        {
        }

        public WriterWorker(PeriodicWorkDelegate periodicWork)
        {
            this.periodicWork = periodicWork;
        }

        public override void DoPeriodicWork()
        {
            base.DoPeriodicWork();
            // the RTPS Writer to repeatedly announce the availability of data by sending a Heartbeat Message.
            Console.WriteLine("I have to send a Heartbeat Message,  at {0}", DateTime.Now);
            if (periodicWork != null)
                periodicWork();
        }
    }
}
