using Common.Logging;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.SharedMem
{
    public class SharedMemoryDiscovery
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private List<Participant> participants = new List<Participant>();
        private List<Endpoint> endpoints = new List<Endpoint>();

        public delegate void DiscoveryEventHandler(object sender, EventArgs e);

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
                NotifyParticipantChanges();
            }
        }

        public void UnregisterParticipant(Participant participant)
        {
            if (participant != null)
            {
                participants.Remove(participant);
                NotifyParticipantChanges();
            }
        }

        public void RegisterEndpoint(Endpoint endpoint)
        {
            if (endpoint != null)
            {
                endpoints.Add(endpoint);
                NotifyEndpointsChanges();
            }
        }

        public void UnregisterEndpoint(Endpoint endpoint)
        {
            if (endpoint != null)
            {
                endpoints.Remove(endpoint);
                NotifyEndpointsChanges();
            }
        }

        private void NotifyParticipantChanges()
        {
            log.Debug("The information about Participants has changed");
            if (ParticipantDiscovery != null)
            {
                ParticipantDiscovery(this, EventArgs.Empty);
            }
        }

        private void NotifyEndpointsChanges()
        {
            log.Debug("The information about Endpoints has changed");
            if (EndpointDiscovery != null)
            {
                EndpointDiscovery(this, EventArgs.Empty);
            }
        }
    }
}
