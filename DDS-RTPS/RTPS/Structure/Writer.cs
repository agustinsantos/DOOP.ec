
using Rtps.Behavior.Types;
using Rtps.Structure.Types;
namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Specialization of RTPS Endpoint representing
    ///  the objects that can be the sources of messages communicating CacheChanges.
    /// </summary>
    public abstract class Writer<T> : Endpoint
    {
        /// <summary>
        /// Configures the mode in which the Writer operates. If pushMode==true, then the 
        /// Writer will push changes to the reader. If pushMode==false, changes will only be announced 
        /// via heartbeats and only be sent as response to the request of a reader.
        /// </summary>
        public bool pushMode;

        /// <summary>
        /// Protocol tuning parameter that allows the RTPS Writer to repeatedly announce the 
        /// availability of data by sending a Heartbeat Message.
        /// </summary>
        public Duration heartbeatPeriod;

        /// <summary>
        /// Protocol tuning parameter that allows the RTPS Writer to delay the response to a request for 
        /// data from a negative acknowledgment.
        /// </summary>
        public Duration nackResponseDelay;

        /// <summary>
        /// Protocol tuning parameter that allows the RTPS Writer to ignore requests for data from 
        /// negative acknowledgments that arrive ‘too soon’ after the corresponding change is sent
        /// </summary>
        public Duration nackSuppressionDuration;

        /// <summary>
        /// Internal counter used to assign increasing sequence number to each change made by the 
        /// Writer.
        /// </summary>
        public SequenceNumber lastChangeSequenceNumber;

        /// <summary>
        ///  Contains the history of CacheChange changes for this Writer.
        /// </summary>
        private HistoryCache<T> writer_cache = new HistoryCache<T>();

        public HistoryCache<T> HistoryCache
        {
            get { return writer_cache; }
        }

        public Writer(Participant participant)
            : base(participant)
        {
            //The following timing-related values are used as the defaults in order to facilitate 
            // ‘out-of-the-box’ interoperability between implementations.
            this.nackResponseDelay = new Duration(200); //200 milliseconds
            this.nackSuppressionDuration = new Duration(0);

            this.lastChangeSequenceNumber = new SequenceNumber();
        }

        /// <summary>
        /// This operation creates a new CacheChange to be appended to the RTPS Writer’s HistoryCache. The 
        /// sequence number of the CacheChange is automatically set to be the sequenceNumber of the previous 
        /// change plus one. 
        /// </summary>
        /// <returns>This operation returns the new change</returns>
        public CacheChange<T> NewChange(ChangeKind kind, Data data, InstanceHandle handle)
        {
            this.lastChangeSequenceNumber.LongValue++;
            CacheChange<T> a_change = new CacheChange<T>(kind, this.guid, this.lastChangeSequenceNumber, data, handle);
            return a_change;
        }
    }
}