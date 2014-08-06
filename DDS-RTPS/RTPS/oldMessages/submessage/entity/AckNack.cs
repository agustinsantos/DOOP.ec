
using Rtps.messages.elements;
using Rtps.messages.submessage.attribute;
namespace Rtps.messages.submessage.entity
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p44: Provides information on the state of a 
    ///  Reader to a Writer. AckNack messages are sent by a Reader to one or more Writers.
    ///  <p>
    ///  From OMG RTPS Standard v2.1 p46: This Submessage is used to communicate the state of a Reader to a Writer. 
    ///  The Submessage allows the Reader to inform the Writer about the sequence 
    ///  numbers it has received and which ones it is still missing. This Submessage
    ///  can be used to do both positive and negative acknowledgments.
    /// </summary>
    public class AckNack : SubMessage
    {

        /// <summary>
        /// Identifies the Reader entity that acknowledges receipt 
        ///  of certain sequence numbers and/or requests to receive 
        ///  certain sequence numbers.
        /// </summary>
        public EntityId readerId;

        /// <summary>
        /// Identifies the Writer entity that is the target of the AckNack message.
        ///   This is the Writer Entity that is being asked to re-send some sequence 
        ///   numbers or is being informed of the reception of certain sequence numbers.
        /// </summary>
        public EntityId writerId;

        /// <summary>
        /// Communicates the state of the reader to the writer. All sequence numbers
        /// up to the one prior to readerSNState.base are confirmed as received by
        /// the reader. The sequence numbers that appear in the set indicate missing
        /// sequence numbers on the reader side. The ones that do not appear in the
        /// set are undetermined (could be received or not).
        /// </summary>
        public SequenceNumberSet readerSNState;

        /// <summary>
        /// A counter that is incremented each time a new AckNack message is sent. 
        ///  Provides the means for a Writer to detect duplicate AckNack messages that 
        ///  can result from the presence of redundant communication paths.
        /// </summary>
        public int count;

        public AckNack()
            : base(SubMessageKind.ACKNACK)
        { }

        public AckNack(EntityId readerId, EntityId writerId, SequenceNumberSet readerSnSet, int count)
            : base(SubMessageKind.ACKNACK)
        {
            this.readerId = readerId;
            this.writerId = writerId;
            this.readerSNState = readerSnSet;
            this.count = count;
        }

        /// <summary>
        /// Final flag indicates to the Writer whether a response is mandatory.
        /// true, if response is NOT mandatory
        /// </summary>
        public bool HasFinalFlag
        {
            get
            {
                return Header.Flags.HasFinalFlag;
            }
        }

        /// <summary>
        /// Sets the finalFlag.
        /// </summary>
        /// <param name="value"></param>
        public void SetFinalFlag(bool val)
        {
            Header.Flags.SetFinalFlag(val);
        }

        /// <summary>
        /// Identifies the Reader entity that acknowledges receipt of certain
        /// sequence numbers and/or requests to receive certain sequence numbers.
        /// </summary>
        public EntityId ReaderId
        {
            get
            {
                return readerId;
            }
        }

        /// <summary>
        /// Identifies the Writer entity that is the target of the AckNack message.
        ///  This is the Writer Entity that is being asked to re-send some sequence
        ///  numbers or is being informed of the reception of certain sequence
        ///  numbers.
        /// </summary>
        public EntityId WriterId
        {
            get
            {
                return writerId;
            }
        }

        /// <summary>
        /// Communicates the state of the reader to the writer. All sequence numbers
        ///  up to the one prior to readerSNState.base are confirmed as received by
        ///  the reader. The sequence numbers that appear in the set indicate missing
        ///  sequence numbers on the reader side. The ones that do not appear in the
        ///  set are undetermined (could be received or not).
        /// </summary>
        public SequenceNumberSet ReaderSNState
        {
            get
            {
                return readerSNState;
            }
        }

        /// <summary>
        /// A counter that is incremented each time a new AckNack message is sent.
        ///  Provides the means for a Writer to detect duplicate AckNack messages that
        ///  can result from the presence of redundant communication paths.
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }


        public override string ToString()
        {
            return base.ToString() + " #" + count + ", " + readerId + ", " + writerId + ", " + readerSNState + ", F:"
                    + this.HasFinalFlag;
        }
    }
}
