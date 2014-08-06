
using Rtps.messages.elements;
using Rtps.messages.submessage.attribute;

namespace Rtps.messages.submessage.entity
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p43: Describes the information that is no 
    /// longer relevant to Readers. Gap messages are sent by a Writer to one 
    /// or more Readers.
    /// <p>
    /// From OMG RTPS Standard v2,1 p52: This Submessage is sent from an RTPS Writer
    /// to an RTPS Reader and indicates to the RTPS Reader that a range of sequence 
    /// numbers is no longer relevant. The set may be a contiguous range of sequence 
    /// numbers or a specific set of sequence numbers.
    /// </summary>
    public class Gap : SubMessage
    {
        public EntityId readerId;
        public EntityId writerId;
        public SequenceNumber gapStart;
        public SequenceNumberSet gapList;

        public Gap()
            : base(SubMessageKind.GAP)
        { }

        /// <summary>
        /// Get the Reader Entity that is being informed of the irrelevance of a set
        /// of sequence numbers.
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
        /// Get the Writer Entity to which the range of sequence numbers applies.
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
        /// Identifies the first sequence number in the interval of irrelevant
        /// sequence numbers.
        /// </summary>
        public SequenceNumber GapStart
        {
            get
            {
                return gapStart;
            }
            set
            {
                gapStart = value;
            }
        }

        /// <summary>
        /// SequenceNumberSet.bitmapBase is the last sequence number of irrelevant
        /// seq nums. SequenceNumberSet.bitmaps identifies additional irrelevant
        /// sequence numbers.
        /// </summary>
        public SequenceNumberSet GapList
        {
            get
            {
                return gapList;
            }
            set
            {
                gapList = value;
            }

        }

        public override string ToString()
        {
            return base.ToString() + " " + gapStart + ", " + gapList;
        }
    }
}
