using Rtps.Behavior.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    /// <summary>
    /// The RTPS ChangeFromWriter is an association class that maintains information of a CacheChange in the RTPS Reader 
    /// HistoryCache as it pertains to the RTPS Writer represented by the WriterProxy
    /// </summary>
    public class ChangeFromWriter
    {
        private ChangeFromWriterStatusKind status;
        private bool is_relevant;

        
        /// <summary>
        /// Indicates the status of a CacheChange relative to the RTPS Writer 
        /// represented by the WriterProxy.
        /// </summary>
        public ChangeFromWriterStatusKind Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Indicates whether the change is relevant to the RTPS Reader
        /// </summary>
        public bool Is_relevant
        {
            get { return is_relevant; }
            set { is_relevant = value; }
        }
    }
}
