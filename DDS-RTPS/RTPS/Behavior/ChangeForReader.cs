using Rtps.Behavior.Types;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    public interface IChangeForReader
    { }

    /// <summary>
    /// The RTPS ChangeForReader is an association class that maintains information of a CacheChange in the RTPS Writer
    /// HistoryCache as it pertains to the RTPS Reader represented by the ReaderProxy.
    /// </summary>
    public class ChangeForReader<T> : IChangeForReader
    {
        private ChangeForReaderStatusKind status;
        private bool isRelevant;
        private CacheChange<T> change;


        /// <summary>
        /// Indicates the status of a CacheChange relative to the 
        /// RTPS Reader represented by the ReaderProxy.
        /// </summary>
        public ChangeForReaderStatusKind Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// Indicates whether the change is relevant to the RTPS Reader 
        /// represented by the ReaderProxy
        /// </summary>
        public bool IsRelevant
        {
            get { return isRelevant; }
            set { isRelevant = value; }
        }

        public CacheChange<T> Change
        {
            get { return change; }
            set { change = value; }
        }
    }
}
