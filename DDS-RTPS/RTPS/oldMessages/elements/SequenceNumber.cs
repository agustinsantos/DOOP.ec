
using System;


namespace rtps.messages.elements
{

    /// <summary>
    /// A sequence number is a 64-bit signed integer, that can take values in the range: -2^63 <= N <= 2^63-1.
    /// The selection of 64 bits as the representation of a sequence number ensures the sequence numbers
    /// never wrap. Sequence numbers begin at 1.
    /// Using this structure, the 64-bit sequence number is:
    ///     seq_num = high * 2^32 + low
    /// </summary>
    public class SequenceNumber : SubMessageElement, IComparable<SequenceNumber>
    {

        public static int SEQUENCE_NUMBER_SIZE = 8;

        public static readonly SequenceNumber SEQUENCENUMBER_UNKNOWN = new SequenceNumber(-1, 0);

        /// <summary>
        /// Sequence number for messages (64 bits)
        /// </summary>
        private int high;

        private uint low;


        public SequenceNumber(int h, uint l)
            : base(SEQUENCE_NUMBER_SIZE)
        {
            this.high = h;
            this.low = l;
        }

        public SequenceNumber(long value)
            : base(SEQUENCE_NUMBER_SIZE)
        {
            this.LongValue = value;
        }
        
        public SequenceNumber(SequenceNumber value)
            : base(SEQUENCE_NUMBER_SIZE)
        {
            this.LongValue = value.LongValue;
        }

        public SequenceNumber()
            : this(1)
        {
        }

        public int High
        {
            get { return high; }
            set { high = value; }
        }

        public uint Low
        {
            get { return low; }
            set { low = value; }
        }

        public long LongValue
        {
            get
            {
                return ((long)this.high << 32) | ((long)this.low & 0xFFFFFFFF);
            }
            set
            {
                this.low = (uint)(value & 0xffffffff);
                this.high = (int)((value >> 32) & 0xffffffff);
            }
        }

        public int CompareTo(SequenceNumber o)
        {
            if (o != null)
            {
                if (this.LongValue > o.LongValue)
                {
                    return 1;
                }
                else if (this.LongValue < o.LongValue)
                {
                    return -1;
                }
                // they are the same
                return 0;
            }
            return 1;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            SequenceNumber other = (SequenceNumber)obj;
            return this.high == other.high && this.low == other.low;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)this.low;
        }

        public override string ToString()
        {
            return this.LongValue.ToString();
        }
    }
}
