
using rtps.messages.elements;
using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;
using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Represents the data that may be associated with
    /// a change made to a data-object.
    /// <p>
    /// From OMG RTPS Standard v2.1 p47: Contains information regarding the Value of
    /// an application Date-object. Data Submessages are sent by Writers 
    /// (NO_KEY Writer or WITH_KEY Writer) to Readers (NO_KEY Reader or WITH_KEY Reader).
    /// 
    /// From OMG RTPS Standard v2.1 p48: The Submessage notifies the RTPS Reader 
    /// of a change to a data-object belonging to the RTPS Writer. The possible 
    /// changes include both changes in Value as well as changes to the lifecycle 
    /// of the data-object.
    /// </summary>
    public class Data : SubMessage
    {
        private Flags extraFlags = new Flags();
        private EntityId readerId;
        private EntityId writerId;
        private SequenceNumber writerSN;
        private ParameterList inlineQosParams;
        private SerializedPayload serializedPayload;

        public Data()
        { }

        public Data(EntityId readerId, EntityId writerId, long seqNum, ParameterList inlineQosParams, SerializedPayload payload)
            : base(SubMessageKind.DATA)
        {
            this.readerId = readerId;
            this.writerId = writerId;
            this.writerSN = new SequenceNumber(seqNum);

            if (inlineQosParams != null && inlineQosParams.Value.Count > 0)
            {
                Header.FlagsValue |= 0x2;
                this.inlineQosParams = inlineQosParams;
            }

            if (payload.ContainsData())
            {
                Header.FlagsValue |= Flags.DataFlag; // dataFlag
            }
            else
            {
                Header.FlagsValue |= Flags.KeyFlag; // keyFlag
            }


            this.serializedPayload = payload;
        }

        /// <summary>
        /// Identifies the RTPS Reader entity that is being informed of the change to
        ///  the data-object.
        /// </summary>
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

        /// <summary>
        /// Gets the inlineQos parameters if present. Inline QoS parameters are
        ///  present, if inlineQosFlag() returns true.
        ///  return InlineQos parameters, or null if not present
        /// </summary>
        public ParameterList InlineQos
        {
            get
            {
                return inlineQosParams;
            }
            set
            {
                inlineQosParams = value;
            }
        }

        /// <summary>
        /// Identifies the RTPS Writer entity that made the change to the
        ///  data-object.
        /// </summary>
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

        /// <summary>
        /// Uniquely identifies the change and the relative order for all 
        // changes made by the RTPS Writer identified by the writerGuid. 
        // Each change gets a consecutive sequence number. Each RTPS 
        // Writer maintains is own sequence number.
        /// </summary>
        public SequenceNumber WriterSN
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

        /// <summary>
        /// Indicates to the Reader the presence of a ParameterList containing QoS
        ///  parameters that should be used to interpret the message.
        /// </summary>
        public bool HasInlineQosFlag
        {
            get
            {
                return Header.Flags.HasInlineQosFlag;
            }
        }

        /// <summary>
        /// Indicates to the Reader that the dataPayload submessage element contains
        ///  the serialized Value of the data-object.
        /// </summary>
        public bool HasDataFlag
        {
            get { return Header.Flags.HasDataFlag; }
        }

        /// <summary>
        /// Indicates to the Reader that the dataPayload submessage element contains
        /// the serialized Value of the key of the data-object.
        /// </summary>
        public bool HasKeyFlag
        {
            get { return Header.Flags.HasKeyFlag; }
        }

        /// <summary>
        // Present only if either the DataFlag or the KeyFlag are Set in the header.
        // If the DataFlag is Set, then it contains the encapsulation of the 
        // new Value of the data-object after the change.
        // If the KeyFlag is Set, then it contains the encapsulation of the key 
        //of the data-object the message refers to.         
        /// </summary>
        public SerializedPayload SerializedPayload
        {
            get
            {
                return serializedPayload;
            }
            set
            {
                serializedPayload = value;
            }
        }

#if TODO
        /// <summary>
        /// Get the StatusInfo inline QoS parameter if it is present. If inline Qos
        /// is not present, an empty(default) StatusInfo is returned
        /// </summary>
        public StatusInfo StatusInfo
        {
            get
            {
                StatusInfo sInfo = null;
                if (HasInlineQosFlag)
                {
                    sInfo = (StatusInfo)inlineQosParams[ParameterId.PID_STATUS_INFO];
                }

                if (sInfo == null)
                {
                    sInfo = new StatusInfo(); // return empty StatusInfo (WRITE)
                }

                return sInfo;
            }
        }
#endif

        public Flags ExtraFlags
        {
            get { return extraFlags; }
            set { extraFlags = value; }
        }

        public override string ToString()
        {
            return base.ToString() + ", Payload[" + serializedPayload.ToString() + "]";
        }
    }
}
