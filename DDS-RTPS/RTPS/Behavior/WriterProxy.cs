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
    /// The RTPS WriterProxy represents the information an RTPS StatefulReader maintains on each matched RTPS Writer.
    /// The association is a consequence of the matching of the corresponding DDS Entities as defined by the DDS specification, 
    /// that is the DDS DataReader matching a DDS DataWriter by Topic, having compatible QoS, belonging to a common 
    /// partition, and not being explicitly ignored by the application that uses DDS.
    /// </summary>
    public class WriterProxy
    {
        private GUID remoteWriterGuid;
        private IList<Locator> unicastLocatorList;
        private IList<Locator> multicastLocatorList;
        private ISet<CacheChange> changes_from_writer;

        /// <summary>
        /// Identifies the matched Writer.
        /// </summary>
        public GUID RemoteWriterGuid
        {
            get { return remoteWriterGuid; }
            set { remoteWriterGuid = value; }
        }

        /// <summary>
        /// List of unicast (address, port) combinations that can be used to send 
        /// messages to the matched Writer or Writers. The list may be empty.
        /// </summary>
        public IList<Locator> UnicastLocatorList
        {
            get { return unicastLocatorList; }
            set { unicastLocatorList = value; }
        }

        /// <summary>
        /// List of multicast (address, port) combinations that can be used to send 
        /// messages to the matched Writer or Writers. The list may be empty.
        /// </summary>
        public IList<Locator> MulticastLocatorList
        {
            get { return multicastLocatorList; }
            set { multicastLocatorList = value; }
        }

        /// <summary>
        /// List of CacheChange changes received or expected from the matched 
        /// RTPS Writer. 
        /// </summary>
        public ISet<CacheChange> Changes_from_writer
        {
            get { return changes_from_writer; }
            set { changes_from_writer = value; }
        }
    }
}
