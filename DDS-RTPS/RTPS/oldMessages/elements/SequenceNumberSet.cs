#if TODO

using rtps.messages.MalformedSubmessageElementException;
using rtps.portable.InputPacket;
using rtps.types.SequenceNumber_t;
using rtps.types.SequenceNumber_tHelper;
using RTPS;

namespace rtps.messages.elements
{
    /**
     * This class encodes a set of <code>SequenceNumber</code>s in a compact way.
     * Please refer to the OMG RTPS-Wire Protocol standard for an extensive
     * explanation of the encoding tecnique.<br/>
     * Basically a <code>SequenceNumber</code> is mantained as the 
     * @author kerush
     *
     */
    public class SequenceNumberSet : SubmessageElement
    {

        protected SequenceNumber_t base_;
        protected int numBits = 0;
        protected int[] set;

        /**
         * TODO: constructor weak: it can't set the size of the CDR encoded element...
         * @param base
         * @param set
         */
        public SequenceNumberSet(SequenceNumber_t base_, int numBits, int[] set)
            : base(0)
        {
            this.numBits = numBits;
            this.base_ = base_;
            this.set = set;
            base.size = SubmessageElement.SEQUENCE_NUMBER_SIZE + 4 + set.Length * 4;
        }


    }
}
#endif