using Doopec.Rtps.SharedMem;
using log4net;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.RtpsTransport
{
    public class RtpsDiscovery : IRtpsDiscovery
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private List<Participant> participants = new List<Participant>();
        private List<Endpoint> endpoints = new List<Endpoint>();

        public event DiscoveryEventHandler ParticipantDiscovery;

        public event DiscoveryEventHandler EndpointDiscovery;

        

        public IList<Participant> Participants
        {
            get { return participants.AsReadOnly(); }
        }

        public IList<Endpoint> Endpoints
        {
            get { return endpoints.AsReadOnly(); }
        }

        public void RegisterParticipant(Participant participant)
        {
            if (participant != null)
            {
                participants.Add(participant);
                DiscoveryEventArgs dea = new DiscoveryEventArgs();
                dea.Reason = EventReason.NEW_PARTICIPANT;
                dea.EventData = participant;
                NotifyParticipantChanges(dea);
            }
        }

        public void UnregisterParticipant(Participant participant)
        {
            if (participant != null)
            {
                participants.Remove(participant);
                DiscoveryEventArgs dea = new DiscoveryEventArgs();
                dea.Reason = EventReason.DELETED_PARTICIPANT;
                dea.EventData = participant;
                NotifyParticipantChanges(dea);
            }
        }

        public void RegisterEndpoint(Endpoint endpoint)
        {
            if (endpoint != null)
            {
                endpoints.Add(endpoint);
                DiscoveryEventArgs dea = new DiscoveryEventArgs();
                dea.Reason = EventReason.NEW_ENDPOINT;
                dea.EventData = endpoint;
                NotifyEndpointsChanges(dea);
            }
        }

        public void UnregisterEndpoint(Endpoint endpoint)
        {
            if (endpoint != null)
            {
                endpoints.Remove(endpoint);
                DiscoveryEventArgs dea = new DiscoveryEventArgs();
                dea.Reason = EventReason.DELETED_ENDPOINT;
                dea.EventData = endpoint;
                NotifyEndpointsChanges(dea);
            }
        }

        private void NotifyParticipantChanges(DiscoveryEventArgs dea)
        {
            log.Debug("The information about Participants has changed");
            if (ParticipantDiscovery != null)
            {
                ParticipantDiscovery(this, dea);
            }
        }

        private void NotifyEndpointsChanges(DiscoveryEventArgs dea)
        {
            log.Debug("The information about Endpoints has changed");
            if (EndpointDiscovery != null)
            {
                EndpointDiscovery(this, dea);
            }
        }
    }
}
