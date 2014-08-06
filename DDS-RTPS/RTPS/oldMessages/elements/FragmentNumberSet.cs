using RTPS.Utils;
namespace rtps.messages.elements
{
#if TODO

    public class FragmentNumberSet :   NumberSet<FragmentNumber>
    {

        protected FragmentNumber_t base_;
        protected int nBits;
        protected int[] set;

        /**
         * TODO: constructor weak: it can't set the size of the CDR encoded element...
         * @param base
         * @param set
         */
        public FragmentNumberSet(FragmentNumber_t base_, int nBits, int[] set)
            : base(0)
        {
            this.base_ = base_;
            this.nBits = nBits;
            this.set = set;
            base.size = SubmessageElement.FRAGMENT_NUMBER_SIZE + 4 + set.Length * 4;
        }

    }
#endif
}
