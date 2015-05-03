using Rtps.Behavior.Types;
using Rtps.Structure.Types;
namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Specialization of RTPS Endpoint representing
    /// the objects that can be used to receive messages communicating CacheChanges.
    /// It will not communicate with unknown writers. It is the
    /// responsibility of DDS layer to provide matched readers when necessary.
    /// Likewise, DDS layer should Remove matched writer, when it detects that it is
    ///  not available anymore.<p>
    ///  
    /// When Samples arrive at RTPSReader, they are passed on to DDS layer through
    /// <i>ReaderCache</i>. ReaderCache is implemented by DDS layer and is responsible for
    /// storing samples.
    /// </summary>
    public abstract class Reader<T> : Endpoint
    {
        /// <summary>
        /// Protocol tuning parameter that allows the RTPS Reader to delay the sending of a 
        /// positive or negative acknowledgment
        /// </summary>
        public Duration HeartbeatResponseDelay { get; set; }

        /// <summary>
        /// Protocol tuning parameter that allows the RTPS Reader to ignore HEARTBEATs that 
        /// arrive ‘too soon’ after a previous HEARTBEAT was received.
        /// </summary>
        public Duration HeartbeatSuppressionDuration { get; set; }

        /// <summary>
        /// Contains the history of CacheChange changes for this RTPS Reader.
        /// </summary>
        public HistoryCache<T> ReaderCache { get; set; }

        /// <summary>
        ///  Specifies whether the RTPS Reader expects in-line QoS to be sent along with any data.
        /// </summary>
        public bool ExpectsInlineQos { get; set; }


        public Reader(GUID guid)
            : base(guid)
        {
            //The following timing-related values are used as the defaults in order to facilitate 
            // ‘out-of-the-box’ interoperability between implementations.
            this.HeartbeatResponseDelay = new Duration(500); //500 milliseconds
            this.HeartbeatSuppressionDuration = new Duration(0);

            ReaderCache = new HistoryCache<T>();
        }
    }

}