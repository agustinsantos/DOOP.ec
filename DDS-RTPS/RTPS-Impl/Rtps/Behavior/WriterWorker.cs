using Common.Logging;
using Doopec.Rtps.Utils;
using Doopec.Utils.Transport;
using Mina.Core.Buffer;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Submessages.Elements;
using Rtps.Structure;
using Rtps.Structure.Types;
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
       
        public WriterWorker( )
        {

        }
        public override void End()
        {
            
        }

        public WriterWorker(PeriodicWorkDelegate periodicWork)
        {
            this.periodicWork = periodicWork;
        }

        public override void DoPeriodicWork()
        {
            base.DoPeriodicWork();
            if (periodicWork != null)
                periodicWork();
        }

        
    }
}
