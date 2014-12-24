using Rtps.Structure.Types;
using System.Collections.Generic;
using System.Text;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// This class encodes a Set of  SequenceNumber s in a compact way.
    /// Please refer to the OMG RTPS-Wire Protocol standard for an extensive
    /// explanation of the encoding tecnique.
    /// </summary>
    public class SequenceNumberSet
    {
        private SequenceNumber base_;
        private int numBits = 0;
        private int[] set_;

        public int[] Set
        {
            get { return set_; }
            set { set_ = value; }
        }

        public SequenceNumberSet()
        { }

        public SequenceNumberSet(int base_, int[] set)
        {
            this.numBits = set.Length * 32;
            this.base_ = new SequenceNumber(base_);
            this.set_ = set;
        }

        public SequenceNumberSet(SequenceNumber base_, int numBits, int[] set)
        {
            this.numBits = numBits;
            this.base_ = base_;
            this.set_ = set;
        }


        /// <summary>
        /// Gets the bitmap base.
        /// </summary>
        public SequenceNumber BitmapBase
        {
            get
            {
                return base_;
            }
            set
            {
                base_ = value;
            }
        }

        /// <summary>
        /// Gets the number of bits in bitmaps.
        /// </summary>
        public int NumBits
        {
            get
            {
                return numBits;
            }
            set
            {
                numBits = value;
            }
        }

        /// <summary>
        /// Gets the bitmaps as an array of ints.
        /// </summary>
        public int[] Bitmaps
        {
            get
            {
                return set_;
            }
            set
            {
                set_ = value;
            }
        }

        /// <summary>
        /// Gets the sequence numbers Set in this SequenceNumberSet.
        /// </summary>
        /// <returns></returns>
        public IList<long> GetSequenceNumbers()
        {
            IList<long> seqNums = new List<long>();

            long seqNum = base_.LongValue;
            int bitCount = 0;

            for (int i = 0; i < set_.Length; i++)
            {
                int bitmap = set_[i];

                for (int j = 0; j < 32 && bitCount < numBits; j++)
                {
                    if ((bitmap & 0x8000000) == 0x8000000)
                    { // id the MSB matches, Add a new seqnum
                        seqNums.Add(seqNum);
                    }

                    seqNum++; bitCount++;
                    bitmap = bitmap << 1;
                }
            }

            return seqNums;
        }

        /// <summary>
        /// Gets the sequence numbers missing in this SequenceNumberSet.
        /// </summary>
        /// <returns></returns>
        public IList<long> GetMissingSequenceNumbers()
        {
            IList<long> seqNums = new List<long>();

            long seqNum = base_.LongValue;

            for (int i = 0; i < set_.Length; i++)
            {
                int bitmap = set_[i];

                for (int j = 0; j < 32; j++)
                {
                    if ((bitmap & 0x8000000) == 0x0)
                    { // id the MSB does not
                        // matches, Add a new seqnum
                        seqNums.Add(seqNum);
                    }

                    seqNum++;
                    bitmap = bitmap << 1;
                }
            }

            return seqNums;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base_.ToString());
            sb.Append("/" + numBits);
            sb.Append(":[");
            for (int i = 0; i < set_.Length; i++)
            {
                sb.Append("0x");
                sb.Append(string.Format("{0:0000}", set_[i]));

                if (i < set_.Length - 1)
                    sb.Append(' ');
            }
            sb.Append(']');

            return sb.ToString();
        }
    }

    /// <summary>
    /// This class encodes a Set of  SequenceNumber s in a compact way.
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
