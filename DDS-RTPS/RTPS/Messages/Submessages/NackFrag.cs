using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;
using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p44: Provides information on the state 
    ///  of a Reader to a Writer, more specifically what fragments the Reader 
    ///  is still missing. NackFrag messages are sent by a Reader to one or 
    ///  more Writers.
    ///  <p>
    ///  From OMG RTPS Standard v2.1 p60: The NackFrag Submessage is used to communicate 
    ///  the state of a Reader to a Writer. When a data change is sent as a series of fragments,
    ///  the NackFrag Submessage allows the Reader to inform the Writer about specific fragment
    ///  numbers it is still missing. This Submessage can only contain negative acknowledgements.
    ///  Note this differs from an AckNack Submessage, which includes both positive and negative 
    ///  acknowledgements.
    /// </summary>
    public class NackFrag : SubMessage
    {
        private EntityId readerId;
        private EntityId writerId;
        private SequenceNumber writerSN;
        private SequenceNumberSet fragmentNumberState;
        private int count;

        public NackFrag()
            : base(SubMessageKind.NACK_FRAG)
        { }

        /// <summary>
        /// Identifies the Reader entity that requests to receive certain fragments.
        /// </summary>
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

        /// <summary>
        /// Identifies the Writer entity that is the target of the NackFrag message.
        ///  This is the Writer Entity that is being asked to re-send some fragments.
        /// </summary>
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

        /// <summary>
        /// The sequence number for which some fragments are missing.
        /// </summary>
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

        /// <summary>
        /// Communicates the state of the reader to the writer. The fragment numbers
        ///  that appear in the Set indicate missing fragments on the reader side. The
        ///  ones that do not appear in the Set are undetermined (could have been
        ///  received or not).
        /// </summary>
        public SequenceNumberSet FragmentNumberState
        {
            get
            {
                return fragmentNumberState;
            }
            set
            {
                fragmentNumberState = value;
            }
        }


        /// <summary>
        /// A counter that is incremented each time a new NackFrag message is sent.
        /// Provides the means for a Writer to detect duplicate NackFrag messages
        /// that can result from the presence of redundant communication paths.
        /// </summary>
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
