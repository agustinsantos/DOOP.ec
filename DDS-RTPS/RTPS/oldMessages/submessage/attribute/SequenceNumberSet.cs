using rtps.messages.elements;
using System.Collections.Generic;
using System.Text;
namespace rtps.messages.submessage.attribute
{

    public class SequenceNumberSet
    {
        private SequenceNumber bitmapBase;
        private int[] bitmaps;
        private int numBits;

        public SequenceNumberSet()
        { }

        public SequenceNumberSet(long base_, int[] bitmaps)
        {
            this.bitmapBase = new SequenceNumber(base_);
            this.bitmaps = bitmaps;
            this.numBits = bitmaps.Length * 32;
        }

        /// <summary>
        /// Gets the bitmap base.
        /// </summary>
        public SequenceNumber BitmapBase
        {
            get
            {
                return bitmapBase;
            }
            set
            {
                bitmapBase = value;
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
                return bitmaps;
            }
            set
            {
                bitmaps = value;
            }
        }

        /// <summary>
        /// Gets the sequence numbers set in this SequenceNumberSet.
        /// </summary>
        /// <returns></returns>
        public IList<long> GetSequenceNumbers()
        {
            IList<long> seqNums = new List<long>();

            long seqNum = bitmapBase.LongValue;
            int bitCount = 0;

            for (int i = 0; i < bitmaps.Length; i++)
            {
                int bitmap = bitmaps[i];

                for (int j = 0; j < 32 && bitCount < numBits; j++)
                {
                    if ((bitmap & 0x8000000) == 0x8000000)
                    { // id the MSB matches, add a new seqnum
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

            long seqNum = bitmapBase.LongValue;

            for (int i = 0; i < bitmaps.Length; i++)
            {
                int bitmap = bitmaps[i];

                for (int j = 0; j < 32; j++)
                {
                    if ((bitmap & 0x8000000) == 0x0)
                    { // id the MSB does not
                        // matches, add a new seqnum
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
            StringBuilder sb = new StringBuilder(bitmapBase.ToString());
            sb.Append("/" + numBits);
            sb.Append(":[");
            for (int i = 0; i < bitmaps.Length; i++)
            {
                sb.Append("0x");
                sb.Append(string.Format("{0:0000}", bitmaps[i]));

                if (i < bitmaps.Length - 1)
                    sb.Append(' ');
            }
            sb.Append(']');

            return sb.ToString();
        }

    }
}
