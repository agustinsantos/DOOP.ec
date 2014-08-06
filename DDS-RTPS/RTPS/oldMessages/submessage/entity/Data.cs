
using rtps.messages.elements;
using rtps.messages.submessage.attribute;
using RTPS.Messages.submessage.attribute;
namespace rtps.messages.submessage.entity
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Represents the data that may be associated with
    /// a change made to a data-object.
    /// <p>
    /// From OMG RTPS Standard v2.1 p47: Contains information regarding the value of
    /// an application Date-object. Data Submessages are sent by Writers 
    /// (NO_KEY Writer or WITH_KEY Writer) to Readers (NO_KEY Reader or WITH_KEY Reader).
    /// 
    /// From OMG RTPS Standard v2.1 p48: The Submessage notifies the RTPS Reader 
    /// of a change to a data-object belonging to the RTPS Writer. The possible 
    /// changes include both changes in value as well as changes to the lifecycle 
    /// of the data-object.
    /// </summary>
    public class Data : SubMessage
    {
        public Flags extraFlags = new Flags();
        private EntityId readerId;
        private EntityId writerId;
        private SequenceNumber writerSN;
        private ParameterList inlineQosParams;
        private DataEncapsulation dataEncapsulation;

        public Data()
        { }

        public Data(EntityId readerId, EntityId writerId, long seqNum, ParameterList inlineQosParams, DataEncapsulation dEnc)
            : base(SubMessageKind.DATA)
        {
            this.readerId = readerId;
            this.writerId = writerId;
            this.writerSN = new SequenceNumber(seqNum);

            if (inlineQosParams != null && inlineQosParams.Count > 0)
            {
                Header.FlagsValue |= 0x2;
                this.inlineQosParams = inlineQosParams;
            }

            if (dEnc.ContainsData())
            {
                Header.FlagsValue |= Flags.DataFlag; // dataFlag
            }
            else
            {
                Header.FlagsValue |= Flags.KeyFlag; // keyFlag
            }



            this.dataEncapsulation = dEnc;
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
        ///  the serialized value of the data-object.
        /// </summary>
        public bool HasDataFlag
        {
            get { return Header.Flags.HasDataFlag; }
        }

        /// <summary>
        /// Indicates to the Reader that the dataPayload submessage element contains
        /// the serialized value of the key of the data-object.
        /// </summary>
        public bool HasKeyFlag
        {
            get { return Header.Flags.HasKeyFlag; }
        }

        /// <summary>
        /// Gets the DataEncapsulation.
        /// </summary>
        public DataEncapsulation DataEncapsulation
        {
            get
            {
                return dataEncapsulation;
            }
            set
            {
                dataEncapsulation = value;
            }
        }

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

        public override string ToString()
        {
             return base.ToString() + ", Payload["+ dataEncapsulation.ToString() + "]";
        }
    }
}
