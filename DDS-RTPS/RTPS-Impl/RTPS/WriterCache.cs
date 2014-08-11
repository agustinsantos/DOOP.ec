using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.RTPS
{
    /// <summary>
    /// WriterCache represents writers history cache from the RTPSWriter point of
    /// view. RTPSWriter uses WriterCache to construct Data and HeartBeat messages to
    /// be sent to RTPSReaders
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface WriterCache<T>
    {
        /// <summary>
        /// Gets the smallest sequence number available in history cache.
        /// </summary>
        /// <returns></returns>
        long getSeqNumMin();

        /// <summary>
        /// Gets the greatest sequence number available in history cache.
        /// </summary>
        /// <returns>seqNumMax</returns>
        long getSeqNumMax();

        /// <summary>
        /// Gets all the CacheChanges since given sequence number.
        /// Returned CacheChanges are ordered by sequence numbers.
        /// </summary>
        /// <param name="seqNum">sequence number to compare</param>
        /// <returns>changes since given seqNum. Returned List is newly allocated.</returns>
        LinkedList<CacheChange<T>> getSamplesSince(long seqNum);

    }
}
