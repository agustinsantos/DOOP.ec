using Doopec.Rtps.Utils;
using org.omg.dds.domain;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;

namespace Doopec.Rtps.Discovery
{
    /// <summary>
    /// Discovery Strategy class that implements RTPS discovery
    /// This class implements the Discovery interface for Rtps-based
    /// discovery.
    /// </summary>
    public class DiscoveryImpl
    {
        GuidGenerator generator = new GuidGenerator();

        // Participant operations:
        public virtual bool AttachParticipant(int domainId, int participantId)
        {
            throw new NotImplementedException();
        }

        internal virtual AddDomainStatus AddDomainParticipant(int domain, DomainParticipantQos qos)
        {
            lock (this)
            {
                AddDomainStatus ads = new AddDomainStatus() { id = new GUID(), federated = false };
                generator.Populate(ref ads.id);
                ads.id.EntityId = EntityId.ENTITYID_PARTICIPANT;
                try
                {
                    if (participants_.ContainsKey(domain) && participants_[domain] != null)
                    {
                        participants_[domain][ads.id] = new Spdp(domain, ads.id, qos, this);
                    }
                    else
                    {
                        participants_[domain] = new Dictionary<GUID, Spdp>();
                        participants_[domain][ads.id] = new Spdp(domain, ads.id, qos, this);
                    }
                }
                catch (Exception e)
                {
                    ads.id = GUID.GUID_UNKNOWN;
                    //  ACE_ERROR((LM_ERROR, "(%P|%t) RtpsDiscovery::add_domain_participant() - "
                    //    "failed to initialize RTPS Simple Participant Discovery Protocol: %C\n",
                    //    e.what()));
                }
                return ads;
            }
        }


        public virtual bool RemoveDomainParticipant(int domainId, int participantId)
        {
            throw new NotImplementedException();
        }


        public virtual bool IgnoreDomainParticipant(int domainId, int myParticipantId, int ignoreId)
        {
            throw new NotImplementedException();
        }


        public virtual bool UpdateDomainParticipantQos(int domain, int articipantId, DomainParticipantQos qos)
        {
            throw new NotImplementedException();
        }

        private IDictionary<int, IDictionary<GUID, Spdp>> participants_ = new Dictionary<int, IDictionary<GUID, Spdp>>();

    }

    // Information returned from call to add_domain_participant()
    internal class AddDomainStatus
    {
        // These are unique across a domain
        // They are also the InstanceHandle_t in Sample_Info for built-in Topics
        public GUID id;
        public bool federated;
    }
}
