using Rtps.messages.elements;

namespace Rtps.messages.submessage.interpreter
{

    /*
     * From OMG RTPS Standard v2.1 p44: Provides information about the source from 
     * which subsequent Entity Submessages originated. This Submessage is primarily 
     * used for relaying RTPS Submessages. This is not discussed in the current specification.
     * 
     * From OMG RTPS Standard v2.1 p58: This message modifies the logical source of the
     * Submessages that follow.
     *
     */

    public class InfoSource : SubMessage
    {
        private ProtocolVersion protocolVersion;
        private VendorId vendorId;
        private GuidPrefix guidPrefix;

        public InfoSource()
            : this(GuidPrefix.GUIDPREFIX_UNKNOWN)
        {
        }

        public InfoSource(GuidPrefix guidPrefix)
            : base(SubMessageKind.INFO_SRC)
        {
            this.protocolVersion = ProtocolVersion.PROTOCOLVERSION_2_1;
            this.vendorId = VendorId.VENDORID_UNKNOWN;
            this.guidPrefix = guidPrefix;
        }


        /// <summary>
        /// Indicates the protocol used to encapsulate subsequent Submessages.
        /// </summary>
        public ProtocolVersion ProtocolVersion
        {
            get
            {
                return protocolVersion;
            }
            set
            {
                protocolVersion = value;
            }        
        }


        /// <summary>
        /// Indicates the VendorId of the vendor that encapsulated subsequent
        /// Submessages.
        /// </summary>
        public VendorId VendorId
        {
            get
            {
                return vendorId;
            }
            set
            {
                vendorId = value;
            }
        }

        /// <summary>
        /// Identifies the Participant that is the container of the RTPS Writer
        /// entities that are the source of the Submessages that follow.
        /// </summary>
        public GuidPrefix GuidPrefix
        {
            get
            {
                return guidPrefix;
            }
            set
            {
                guidPrefix = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + guidPrefix;
        }
    }
}