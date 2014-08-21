using Rtps.Messages.Types;
using Rtps.Structure;
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
        public ParticipantProxy(Participant participant)
        {
            this.ProtocolVersion = participant.ProtocolVersion;
            this.VendorId = participant.VendorId;
            this.GuidPrefix = participant.Guid.Prefix;
            //this.ExpectsInlineQos = participant.ExpectsInlineQos;
            this.DefaultMulticastLocatorList = participant.DefaultMulticastLocatorList;
            this.DefaultUnicastLocatorList = participant.DefaultUnicastLocatorList;
        }

        public ProtocolVersion ProtocolVersion { get; set; }
        public GuidPrefix GuidPrefix { get; set; }  // optional in SPDPdiscoveredParticipantData
        public VendorId VendorId { get; set; }
        public bool ExpectsInlineQos { get; set; }
        public BuiltinEndpointSet AvailableBuiltinEndpoints { get; set; }
        public IList<Locator> MetatrafficUnicastLocatorList { get; set; }
        public IList<Locator> MetatrafficMulticastLocatorList { get; set; }
        public IList<Locator> DefaultMulticastLocatorList { get; set; }
        public IList<Locator> DefaultUnicastLocatorList { get; set; }
        public Count ManualLivelinessCount { get; set; }
    }
}
