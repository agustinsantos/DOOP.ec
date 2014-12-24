using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    /// <summary>
    /// Specialization of RTPS Writer used for the Stateful Reference Implementation. The RTPS StatefulWriter is 
    /// configured with the knowledge of all matched RTPS Reader endpoints and maintains state on each matched 
    /// RTPS Reader endpoint.
    /// By maintaining state on each matched RTPS Reader endpoint, the RTPS StatefulWriter can determine whether all 
    /// matched RTPS Reader endpoints have received a particular CacheChange and can be optimal in its use of network 
    /// bandwidth by avoiding to send announcements to readers that have received all the changes in the writer’s HistoryCache. 
    /// The information it maintains also simplifies QoS-based filtering on the Writer side. 
    /// </summary>
    public class StatefulWriter<T> : Writer<T>
    {
        private IList<ReaderProxy<T>> matched_readers;

        /// <summary>
        /// The StatefulWriter keeps track of all the RTPS Readers matched with it. Each 
        /// matched reader is represented by an instance of the ReaderProxy class.
        /// </summary>
        public IList<ReaderProxy<T>> MatchedReaders
        {
            get { return matched_readers; }
            set { matched_readers = value; }
        }

        public StatefulWriter(Participant participant)
            : base(participant)
        {
        }
        
        /// <summary>
        /// This operation adds the ReaderProxy a_reader_proxy to the Set StatefulWriter::matched_readers.
        /// </summary>
        /// <param name="a_reader_proxy"></param>
        public void MatchedReaderAdd(ReaderProxy<T> a_reader_proxy)
        {
            /// ADD a_writer_proxy TO {this.matched_writers};
            matched_readers.Add(a_reader_proxy);
        }

        /// <summary>
        /// This operation removes the ReaderProxy a_reader_proxy from the Set StatefulWriter::matched_readers.
        /// </summary>
        /// <param name="a_reader_proxy"></param>
        public void MatchedReaderRemove(ReaderProxy<T> a_reader_proxy)
        {
            // REMOVE a_writer_proxy FROM {this.matched_writers};
            // delete a_writer_proxy;
            matched_readers.Remove(a_reader_proxy);
        }

        /// <summary>
        /// This operation finds the ReaderProxy with GUID_t a_reader_guid from the Set StatefulWriter::matched_readers.
        /// </summary>
        /// <param name="a_reader_proxy"></param>
        /// <returns></returns>
        public ReaderProxy<T> MatchedReaderLookup(GUID a_reader_proxy)
        {
            /// FIND proxy IN this.matched_writers SUCH-THAT (proxy.remoteWriterGuid == a_writer_guid);
            /// return proxy;
            return matched_readers.FirstOrDefault((x) => { return x.remoteReaderGuid == a_reader_proxy; });
        }

        /// <summary>
        /// This operation takes a CacheChange a_change as a parameter and determines whether all the ReaderProxy have 
        /// acknowledged the CacheChange. The operation will return true if all ReaderProxy have acknowledged the  
        /// corresponding CacheChange and false otherwise.
        /// </summary>
        /// <param name="a_change"></param>
        /// <returns></returns>
        public bool IsAckedByAll<T>(CacheChange<T> a_change)
        { throw new NotImplementedException(); }
    }
}
