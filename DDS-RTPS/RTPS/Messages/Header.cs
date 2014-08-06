

using Rtps.Messages.Types;
using Rtps.Structure.Types;
namespace Rtps.Messages
{
    /// <summary>
    /// The Header identifies the message as belonging to the RTPS protocol. The Header identifies the version of the protocol
    /// and the vendor that sent the message. The Header contains the fields listed in Table 8.14.
    /// </summary>
    public class Header
    {
        private ProtocolId protocol = ProtocolId.PROTOCOL_RTPS;
        private ProtocolVersion version = ProtocolVersion.PROTOCOLVERSION;
        private VendorId vendorId = VendorId.Sxta;
        private GuidPrefix guidPrefix;

        public Header()
        {
            guidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        public Header(GuidPrefix prefix)
        {
            guidPrefix = prefix;
        }

        /// <summary>
        ///  Identifies the message as an RTPS message.
        /// </summary>
        public ProtocolId Protocol
        {
            get { return protocol; }
        }

        /// <summary>
        ///  Identifies the version of the RTPS protocol.
        /// </summary>
        public ProtocolVersion Version
        {
            get { return version; }
        }

        /// <summary>
        /// Indicates the vendor that provides the implementation of the RTPS protocol.
        /// </summary>
        public VendorId VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        /// <summary>
        /// Defines a default prefix to use for all GUIDs that appear in the message.
        /// </summary>
        public GuidPrefix GuidPrefix
        {
            get { return guidPrefix; }
            set { guidPrefix = value; }
        }
    }
}
