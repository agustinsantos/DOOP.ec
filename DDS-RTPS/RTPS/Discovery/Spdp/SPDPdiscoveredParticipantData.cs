using Rtps.Behavior.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.topic;

namespace Rtps.Discovery.Spdp
{
    public class SPDPdiscoveredParticipantData
    {
        //TODO  public ParticipantBuiltinTopicData ddsParticipantData;
        public ParticipantProxy ParticipantProxy { get; set; }
        public Duration LeaseDuration { get; set; }
    }
}
