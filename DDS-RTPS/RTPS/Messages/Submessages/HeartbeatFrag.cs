using Rtps.Messages.Types;
using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages
{

    /* 
     * From OMG RTPS Standard v2.1 p43: For fragmented data, describes what fragments
     * are available in a Writer. HeartbeatFrag messages are sent by a Writer 
     * (NO_KEY Writer or WITH_KEY Writer) to one or more Readers (NO_KEY Reader or
     * WITH_KEY Reader).
     * <p>
     * From OMG RTPS Standard v2.1 p55: When fragmenting data and until all fragments are 
     * available, the HeartbeatFrag Submessage is sent from an RTPS Writer to an RTPS Reader
     * to communicate which fragments the Writer has available. This enables reliable
     * communication at the fragment level.
     * Once all fragments are available, a regular Heartbeat message is used.
     */

    public class HeartbeatFrag : SubMessage
    {
        /// <summary>
        /// Identifies the Reader Entity that is being informed of the availability
        ///  of fragments. Can be set to ENTITYID_UNKNOWN to indicate all readers for
        /// the writer that sent the message.
        /// </summary>
        private EntityId readerId;

        /// <summary>
        /// Identifies the Writer Entity that sent the Submessage.
        /// </summary>
        private EntityId writerId;

        /// <summary>
        /// Identifies the sequence number of the data change for which fragments are
        /// available.
        /// </summary>
        private SequenceNumber writerSN;

        /// <summary>
        /// All fragments up to and including this last (highest) fragment are
        /// available on the Writer for the change identified by writerSN.
        /// </summary>
        private int lastFragmentNum;

        /// <summary>
        /// A counter that is incremented each time a new HeartbeatFrag message is
        /// sent. Provides the means for a Reader to detect duplicate HeartbeatFrag
        /// messages that can result from the presence of redundant communication
        /// paths.
        /// </summary>
        private int count;


        public HeartbeatFrag()
            : base(SubMessageKind.HEARTBEAT_FRAG)
        { }

        public EntityId ReaderId
        {
            get
            {
                return readerId;
            }
            set
            {
                readerId = value;
            }
        }

        public EntityId WriterId
        {
            get
            {
                return writerId;
            }
            set
            {
                writerId = value;
            }
        }

        public SequenceNumber WriterSequenceNumber
        {
            get
            {
                return writerSN;
            }
            set
            {
                writerSN = value;
            }
        }

        public int LastFragmentNumber
        {
            get
            {
                return lastFragmentNum;
            }
            set
            {
                lastFragmentNum = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }
    }
}
