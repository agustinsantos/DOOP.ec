using Rtps.Messages.Types;
using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages
{
    /// <summary>
    ///  From OMG RTPS Standard v2.1 p43: Describes the information that is available
    ///  in a Writer. Heartbeat messages are sent by a Writer (NO_KEY Writer or 
    ///  WITH_KEY Writer) to one or more Readers (NO_KEY Reader or WITH_KEY Reader)
    ///  <p>
    ///  From OMG RTPS Standard v2.1 p53: This message is sent from an RTPS Writer to
    ///  an RTPS Reader to communicate the sequence numbers of changes that the Writer 
    ///  has available.
    /// </summary>
    public class Heartbeat : SubMessage
    {
        public EntityId readerId;
        public EntityId writerId;
        public SequenceNumber firstSN;
        public SequenceNumber lastSN;
        public int count;

        public Heartbeat() : base(SubMessageKind.HEARTBEAT) { }

        /**
     * Appears in the Submessage header flags. Indicates whether the Reader is
     * required to respond to the Heartbeat or if it is just an advisory
     * heartbeat. If finalFlag is set, Reader is not required to respond with
     * AckNack.
     * 
     * @return true if final flag is set and reader is not required to respond
     */
        public bool HasFinalFlag
        {
            get
            {
                return Header.Flags.HasFinalFlag;
            }
        }

        /**
         * Sets the finalFlag to given value.
         * 
         * @param flag
         */
        public void SetFinalFlag(bool flag)
        {
            Header.Flags.SetFinalFlag(flag);
        }

        /**
         * Appears in the Submessage header flags. Indicates that the DDS DataWriter
         * associated with the RTPS Writer of the message has manually asserted its
         * LIVELINESS.
         * 
         * @return true, if liveliness flag is set
         */
        public bool HasLivelinessFlag
        {
            get
            {
                return Header.Flags.HasLivelinessFlag;
            }
        }

        /**
         * Sets the livelinessFlag to given value
         * 
         * @param livelinessFlag
         */
        public void SetLivelinessFlag(bool livelinessFlag)
        {
            Header.Flags.SetLivelinessFlag(livelinessFlag);
        }

        /**
         * Identifies the Reader Entity that is being informed of the availability
         * of a set of sequence numbers. Can be set to ENTITYID_UNKNOWN to indicate
         * all readers for the writer that sent the message.
         */
        public EntityId ReaderId
        {
            get
            {
                return readerId;
            }
        }

        /**
         * Identifies the Writer Entity to which the range of sequence numbers
         * applies.
         */
        public EntityId WriterId
        {
            get
            {
                return writerId;
            }
        }

        /**
         * Identifies the first (lowest) sequence number that is available in the
         * Writer.
         */
        public long FirstSequenceNumber
        {
            get
            {
                return firstSN.LongValue;
            }
            set
            {
                firstSN.LongValue = value;
            }
        }

        /**
         * Identifies the last (highest) sequence number that is available in the
         * Writer.
         */
        public long LastSequenceNumber
        {
            get
            {
                return lastSN.LongValue;
            }
            set
            {
                lastSN.LongValue = value;
            }
        }

        /**
         * A counter that is incremented each time a new Heartbeat message is sent.
         * Provides the means for a Reader to detect duplicate Heartbeat messages
         * that can result from the presence of redundant communication paths.
         */
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

        public override string ToString()
        {
            return base.ToString() + " #" + count + ", " + readerId + ", " + writerId + ", " + firstSN + ", " + lastSN
                    + ", F:" + this.HasFinalFlag + ", L:" + this.HasLivelinessFlag;
        }
    }
}
