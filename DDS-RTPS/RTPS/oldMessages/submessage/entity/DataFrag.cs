using Rtps.messages.elements;
using Rtps.messages.submessage.attribute;
using System.Collections.Generic;
namespace Rtps.messages.submessage.entity
{

    /**
     * From OMG RTPS Standard v2.1 p43: Equivalent to Data, but only contains a part
     * of the new value (one or more fragments). Allows data to be transmitted as
     * multiple fragments to overcome transport message size limitations
     * <p>
     * From OMG RTPS Standard v2.1 p49: The DataFrag Submessage  : the Data 
     * Submessage by enabling the serializedData to be fragmented and sent as multiple
     * DataFrag Submessages. The fragments contained in the DataFrag Submessages are 
     * then re-assembled by the RTPS Reader. 
     *  
 
     *
     */

    public class DataFrag : SubMessage
    {
        private short extraFlags;


        private EntityId readerId;
        private EntityId writerId;
        private SequenceNumber writerSN;
        private int fragmentStartingNum;
        private int fragmentsInSubmessage;
        private int fragmentSize;
        private int sampleSize;

        private ParameterList parameterList = new ParameterList();
        private byte[] serializedPayload;

        public DataFrag()
            : base(SubMessageKind.DATA_FRAG)
        { }

        public short ExtraFlags
        {
            get { return extraFlags; }
            set { extraFlags = value; }
        }

        public bool HasInlineQosFlag
        {
            get
            {
                return Header.Flags.HasInlineQosFlag;
            }
        }

        public bool HasKeyFlag
        {
            get
            {
                return Header.Flags.HasKeyFlag;
            }
        }

        public EntityId ReaderId
        {
            get
            {
                return readerId;
            }
            set
            {
                readerId = value;
            }
        }

        public EntityId WriterId
        {
            get
            {
                return writerId;
            }
            set
            {
                writerId = value;
            }
        }

        public SequenceNumber WriterSequenceNumber
        {
            get
            {
                return writerSN;
            }
            set
            {
                writerSN = value;
            }
        }

        public int FragmentStartingNumber
        {
            get
            {
                return fragmentStartingNum;
            }
            set
            {
                fragmentStartingNum = value;
            }
        }

        public int FragmentsInSubmessage
        {
            get
            {
                return fragmentsInSubmessage;
            }
            set
            {
                fragmentsInSubmessage = value;
            }
        }

        public int FragmentSize
        {
            get
            {
                return fragmentSize;
            }
            set
            {
                fragmentSize = value;
            }
        }

        public int SampleSize
        { // getDataSize()
            get
            {
                return sampleSize;
            }
            set
            {
                sampleSize = value;
            }
        }

        public ParameterList ParameterList
        {
            get { return parameterList; }
            set { parameterList = value; }
        }

        public byte[] SerializedPayload
        {
            get { return serializedPayload; }
            set { serializedPayload = value; }
        }
    }
}
