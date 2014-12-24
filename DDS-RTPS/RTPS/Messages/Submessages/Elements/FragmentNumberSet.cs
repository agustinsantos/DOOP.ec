using RTPS.Utils;
namespace Rtps.Messages.Submessages.Elements
{

    public class FragmentNumberSet : NumberSet<FragmentNumber>
    {
        private FragmentNumber base_;
        private int nBits;
        private int[] set_;

        public int[] Set
        {
            get { return set_; }
            set { set_ = value; }
        }

        /**
         * TODO: constructor weak: it can't Set the size of the CDR encoded element...
         * @param base
         * @param Set
         */
        public FragmentNumberSet(FragmentNumber base_, int nBits, int[] set)
            : base(base_)
        {
            this.nBits = nBits;
            this.set_ = set;
        }

        public FragmentNumberSet()
            : base(new FragmentNumber())
        { }
    }

    public class FragmentNumberSetElement : SubmessageElement<FragmentNumberSet>
    {
        public static int FRAGMENT_NUMBER_SIZE = 4;

        public FragmentNumberSetElement(FragmentNumberSet value)
            : base(FRAGMENT_NUMBER_SIZE + 4 + value.Set.Length * 4, value)
        {
        }

        public FragmentNumberSetElement()
            : this(new FragmentNumberSet())
        {
        }
    }
}
