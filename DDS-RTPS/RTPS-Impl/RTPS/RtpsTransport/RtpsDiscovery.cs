using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.RtpsTransport
{
    public class RtpsDiscovery : IRtpsDiscovery
    {
        public event DiscoveryEventHandler ParticipantDiscovery;

        public event DiscoveryEventHandler EndpointDiscovery;

        public void RegisterParticipant(global::Rtps.Structure.Participant participant)
        {
            throw new NotImplementedException();
        }

        public void UnregisterParticipant(global::Rtps.Structure.Participant participant)
        {
            throw new NotImplementedException();
        }

        public void RegisterEndpoint(global::Rtps.Structure.Endpoint endpoint)
        {
            throw new NotImplementedException();
        }

        public void UnregisterEndpoint(global::Rtps.Structure.Endpoint endpoint)
        {
            throw new NotImplementedException();
        }
    }
}
