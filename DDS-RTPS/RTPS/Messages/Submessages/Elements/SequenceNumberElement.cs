
using Rtps.Messages;
using Rtps.Structure.Types;
using System;


namespace Rtps.Messages.Submessages.Elements
{

    /// <summary>
    /// A sequence number is a 64-bit signed integer, that can take values in the range: -2^63 <= N <= 2^63-1.
    /// The selection of 64 bits as the representation of a sequence number ensures the sequence numbers
    /// never wrap. Sequence numbers begin at 1.
    /// Using this structure, the 64-bit sequence number is:
    ///     seq_num = high * 2^32 + low
    /// </summary>
    public class SequenceNumberElement : SubmessageElement<SequenceNumber>
    {

        public static int SEQUENCE_NUMBER_SIZE = 8;
        public SequenceNumberElement(SequenceNumber value)
            : base(SEQUENCE_NUMBER_SIZE, value)
        {
            this.value = value;
        }

        public SequenceNumberElement()
            : this(new SequenceNumber(1))
        {
        }
    }
}
