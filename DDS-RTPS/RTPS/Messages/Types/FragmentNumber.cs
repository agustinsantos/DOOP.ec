using System;
namespace Rtps.Messages.Types
{
    /// <summary>
    /// A fragment number is a 32-bit unsigned integer and is used by Submessages to identify a particular fragment in
    /// fragmented serialized data. Fragment numbers start at 1.
    /// </summary>
    public class FragmentNumber : IComparable<FragmentNumber>
    {
        public static int FRAGMENT_NUMBER_SIZE = 4;

        /// <summary>
        /// Provides the Value of the 32-bit fragment number.
        /// </summary>
        protected uint value;

        public FragmentNumber(uint value)
        {
            this.value = value;
        }

        public FragmentNumber()
            : this(1)
        {
        }

        public uint IntValue
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int CompareTo(FragmentNumber o)
        {
            if (o != null)
            {
                if (this.value > o.value)
                {
                    return 1;
                }
                else if (this.value < o.value)
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
            FragmentNumber other = (FragmentNumber)obj;
            return this.value == other.value;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)this.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}