using Doopec.Dds.Domain;
using Doopec.Rtps.Discovery;
using log4net;
using org.omg.dds.domain;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Utils
{
    public enum DiscoveryDomainParticipantEventReason
    {
        NEW_PARTICIPANT,
        DELETED_PARTICIPANT,
    }

    public class DiscoveryDomainParticipantEventArgs : EventArgs
    {
        public DiscoveryDomainParticipantEventReason Reason { get; set; }
        public DomainParticipant Participant { get; set; }
    }

    public delegate void DiscoveryDomainParticipantEventHandler(object sender, DiscoveryDomainParticipantEventArgs e);

    public class DiscoveryService : IDisposable
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// The collection of domain participants.
        private IDictionary<GUID, DomainParticipant> participants = new Dictionary<GUID, DomainParticipant>();
        private static Dictionary<int, SortedSet<DomainParticipantImpl>> participantsInDomains = new Dictionary<int, SortedSet<DomainParticipantImpl>>();

        private static DiscoveryService theInstance;

        public event DiscoveryDomainParticipantEventHandler ParticipantDiscovery;

        static DiscoveryService()
        {
            if (theInstance == null)
                theInstance = new DiscoveryService();
        }

        private DiscoveryService()
        {
        }

        public static DiscoveryService Instance
        {
            get
            {
                return theInstance;
            }
        }

        public void RegisterParticipant(DomainParticipant participant)
        {
            lock (this)
            {
                DomainParticipantImpl part = participant as DomainParticipantImpl;
                if (part != null)
                {
                    participants.Add(part.ParticipantGuid, part);
                    if (!participantsInDomains.ContainsKey(part.DomainId))
                        participantsInDomains.Add(part.DomainId, new SortedSet<DomainParticipantImpl>());
                    participantsInDomains[part.DomainId].Add(part);
                    NotifyParticipantChanges(DiscoveryDomainParticipantEventReason.NEW_PARTICIPANT, participant);
                }
            }
        }

        public void UnregisterParticipant(DomainParticipant participant)
        {
            lock (this)
            {
                DomainParticipantImpl part = participant as DomainParticipantImpl;
                if (part != null)
                {
                    participants.Remove(part.ParticipantGuid);
                    participantsInDomains[part.DomainId].Remove(part);
                    if (participantsInDomains[part.DomainId].Count == 0)
                        participantsInDomains.Remove(part.DomainId);
                    NotifyParticipantChanges(DiscoveryDomainParticipantEventReason.DELETED_PARTICIPANT, participant);
                }
            }
        }

        public DomainParticipant LookupParticipant(int domainId)
        {
            lock (this)
            {
                if (participantsInDomains.ContainsKey(domainId))
                {
                    return participantsInDomains[domainId].LastOrDefault();
                }
                else
                    return null;
            }
        }

        public IEnumerable<DomainParticipantImpl> ParticipantsInDomain(int domainId)
        {
            lock (this)
            {
                return participantsInDomains[domainId];
            }
        }

        public IEnumerable<DomainParticipant> Participants
        {
            get
            {
                lock (this)
                {
                    return participants.Values;
                }
            }
        }

        private void NotifyParticipantChanges(DiscoveryDomainParticipantEventReason reason, DomainParticipant participant)
        {
            log.DebugFormat("The information about DomainParticipants has changed. Reason {0}, Participant {1}", reason, participant);
            if (ParticipantDiscovery != null)
            {
                DiscoveryDomainParticipantEventArgs dpea = new DiscoveryDomainParticipantEventArgs()
                {
                    Reason = reason,
                    Participant = participant

                };
                ParticipantDiscovery(this, dpea);
            }
        }

        public void Dispose()
        {
        }
    }
}
