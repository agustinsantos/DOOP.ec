

using rtps.messages.elements;
namespace rtps.messages.message
{
    /// <summary>
    /// The Header identifies the message as belonging to the RTPS protocol. The Header identifies the version of the protocol
    /// and the vendor that sent the message. The Header contains the fields listed in Table 8.14.
    /// </summary>
    public class Header
    {
        public ProtocolId protocol = ProtocolId.PROTOCOL_RTPS;
        public ProtocolVersion version = ProtocolVersion.PROTOCOLVERSION;
        public VendorId vendorId = VendorId.Sxta;
        public GuidPrefix guidPrefix;

        public Header()
        {
            guidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN;
        }

        public Header(GuidPrefix prefix)
        {
            guidPrefix = prefix;
        }

        public ProtocolId Protocol
        {
            get { return protocol; }
        }

        public ProtocolVersion Version
        {
            get { return version; }
        }


        public VendorId VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public GuidPrefix GuidPrefix
        {
            get { return guidPrefix; }
            set { guidPrefix = value; }
        }
    }
}
