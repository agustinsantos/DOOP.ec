using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// This class encodes a set of  SequenceNumber s in a compact way.
    /// Please refer to the OMG RTPS-Wire Protocol standard for an extensive
    /// explanation of the encoding tecnique.
    /// </summary>
    public class SequenceNumberSet
    {
        private SequenceNumber base_;
        private int numBits = 0;
        private int[] set;

        public int[] Set
        {
            get { return set; }
            set { set = value; }
        }

        public SequenceNumberSet()
        { }

        public SequenceNumberSet(SequenceNumber base_, int numBits, int[] set)
        {
            this.numBits = numBits;
            this.base_ = base_;
            this.set = set;
        }
    }

    /// <summary>
    /// This class encodes a set of  SequenceNumber s in a compact way.
    /// Please refer to the OMG RTPS-Wire Protocol standard for an extensive
    /// explanation of the encoding tecnique.
    /// </summary>
    public class SequenceNumberSetElement : SubmessageElement<SequenceNumberSet>
    {
        public static int SEQUENCE_NUMBER_SIZE = 8;
        public SequenceNumberSetElement(SequenceNumberSet value)
            : base(SEQUENCE_NUMBER_SIZE + 4 + value.Set.Length * 4, value)
        {
        }

        public SequenceNumberSetElement()
            : this(new SequenceNumberSet())
        {
        }
    }
}
