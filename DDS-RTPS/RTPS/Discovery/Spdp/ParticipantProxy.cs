using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Discovery.Spdp
{
    public class ParticipantProxy
    {
        public ProtocolVersion protocolVersion;
        public GuidPrefix guidPrefix;  // optional in SPDPdiscoveredParticipantData
        public VendorId vendorId;
        public bool expectsInlineQos;
        public BuiltinEndpointSet availableBuiltinEndpoints;
        public IList<Locator> metatrafficUnicastLocatorList;
        public IList<Locator> metatrafficMulticastLocatorList;
        public IList<Locator> defaultMulticastLocatorList;
        public IList<Locator> defaultUnicastLocatorList;
        public Count manualLivelinessCount;
    }
}
