
using Doopec.Rtps.SharedMem;
using Rtps.Structure;
using System.Collections.Generic;
namespace Doopec.Rtps
{

    public delegate void DiscoveryEventHandler(object sender, DiscoveryEventArgs e);

    public interface IRtpsDiscovery
    {
        event DiscoveryEventHandler ParticipantDiscovery;
        event DiscoveryEventHandler EndpointDiscovery;

        void RegisterParticipant(Participant participant);

        void UnregisterParticipant(Participant participant);

        void RegisterEndpoint(Endpoint endpoint);

        void UnregisterEndpoint(Endpoint endpoint);

        IList<Participant> Participants { get; }

        IList<Endpoint> Endpoints { get; }

    }
}
