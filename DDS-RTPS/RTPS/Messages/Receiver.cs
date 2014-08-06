using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System.Collections.Generic;
namespace Rtps.Messages
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p35: The interpretation and meaning of a Submessage
    /// within a Message may depend on the previous Submessages contained within that 
    /// same Message. Therefore, the receiver of a Message must maintain state from 
    /// previously deserialized Submessages in the same Message. This state is modeled
    /// as the state of an RTPS Receiver that is reset each time a new message is
    /// processed and provides context for the interpretation of each Submessage.
    /// </summary>
    public class Receiver
    {
        public ProtocolVersion sourceVersion = ProtocolVersion.PROTOCOLVERSION;
        public VendorId vendorId = VendorId.VENDORID_UNKNOWN;
        public GuidPrefix sourceGuidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN;
        public GuidPrefix destGuidPrefix;
        public IList<Locator> unicastReplyLocatorList = new List<Locator>();
        public IList<Locator> multicastReplyLocatorList = new List<Locator>();
        public bool haveTimestamp;
        public Time timestamp = Time.TIME_INVALID;

        public Receiver()
        {
            sourceVersion = ProtocolVersion.PROTOCOLVERSION;
            vendorId = VendorId.VENDORID_UNKNOWN;
            sourceGuidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN;
            haveTimestamp = false;
            timestamp = Time.TIME_INVALID;
        }

        public Receiver(GuidPrefix destination)
            : this()
        {
            destGuidPrefix = destination;
            throw new KeyNotFoundException("See page 35, unicast and multicast initialization");
        }

        public Receiver(Header header)
            : this()
        {
            sourceGuidPrefix = header.GuidPrefix;
            sourceVersion = header.Version;
            throw new KeyNotFoundException("See page 35, unicast and multicast initialization");
        }
    }
}
