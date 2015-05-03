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
    /// Specialization of RTPS Reader. The RTPS StatefulReader keeps state on each matched RTPS Writer. The state kept on 
    /// each writer is encapsulated in the RTPS WriterProxy class.
    /// </summary>
    public class StatefulReader<T> : Reader<T>
    {
        private IList<WriterProxy<T>> matched_writers;

        /// <summary>
        /// Used to maintain state on the remote Writers matched up with the Reader.
        /// </summary>
        public IList<WriterProxy<T>> MatchedWriters
        {
            get { return matched_writers; }
            set { matched_writers = value; }
        }

        public StatefulReader(GUID guid)
            : base(guid)
        {
            // This operation creates a new RTPS StatefulReader. The newly-created stateful reader ‘this’ is initialized as follows:
            // this.attributes := <as specified in the constructor>;
            // this.matched_writers := <empty>;

            matched_writers = new List<WriterProxy<T>>();
        }

        /// <summary>
        /// This operation adds the WriterProxy a_writer_proxy to the StatefulReader.matched_writers.
        /// </summary>
        /// <param name="a_writer_proxy"></param>
        public void MatchedWriterAdd(WriterProxy<T> a_writer_proxy)
        {
            /// ADD a_writer_proxy TO {this.matched_writers};
            matched_writers.Add(a_writer_proxy);
        }

        /// <summary>
        /// This operation adds the WriterProxy a_writer_proxy to the StatefulReader::matched_writers.
        /// </summary>
        /// <param name="a_writer_proxy"></param>
        public void MatchedWriterRemove(WriterProxy<T> a_writer_proxy)
        {
            /// REMOVE a_writer_proxy FROM {this.matched_writers};
            /// delete a_writer_proxy;
            matched_writers.Remove(a_writer_proxy);
        }

        /// <summary>
        /// This operation finds the WriterProxy with GUID_t a_writer_guid from the Set StatefulReader::matched_writers.
        /// </summary>
        /// <param name="a_writer_proxy"></param>
        public WriterProxy<T> MatchedWriterLookup(GUID a_writer_guid)
        {
            /// FIND proxy IN this.matched_writers SUCH-THAT (proxy.remoteWriterGuid == a_writer_guid);
            /// return proxy;
            return matched_writers.FirstOrDefault((x) => { return x.RemoteWriterGuid == a_writer_guid; });
        }

    }
}
