using org.omg.dds.type;
using Rtps.Attributes;
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
            this.MetatrafficUnicastLocatorList = new List<Locator>();
            this.MetatrafficMulticastLocatorList = new List<Locator>();
        }

        [ID(0x0015)]
        public ProtocolVersion ProtocolVersion { get; set; }

        [NonField]
        public GuidPrefix GuidPrefix { get; set; }  // optional in SPDPdiscoveredParticipantData

        [ID(0x0016)]
        public VendorId VendorId { get; set; }

        [ID(0x0043)]
        public bool ExpectsInlineQos { get; set; }
        
        public BuiltinEndpointSet AvailableBuiltinEndpoints { get; set; }

        [ID(0x0048)]
        public List<Locator> DefaultMulticastLocatorList { get; set; }

        [ID(0x0031)]
        public List<Locator> DefaultUnicastLocatorList { get; set; }
        
        [ID(0x0032)]
        public List<Locator> MetatrafficUnicastLocatorList { get; set; }

        [ID(0x0033)]
        public List<Locator> MetatrafficMulticastLocatorList { get; set; }

        [ID(0x0034)]
        public Count ManualLivelinessCount { get; set; }
    }
}
