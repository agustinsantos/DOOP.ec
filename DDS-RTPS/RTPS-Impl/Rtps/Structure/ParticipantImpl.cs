using Doopec.Configuration;
using Doopec.Configuration.Dds;
using Doopec.Configuration.Rtps;
using Doopec.Rtps.Discovery;
using Doopec.Rtps.RtpsTransport;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Structure
{
    public class ParticipantImpl : Participant, IDisposable
    {
        private SPDPbuiltinParticipantReaderImpl spdpReader;

        //The SPDPbuiltinParticipantWriter is an RTPS Best-Effort StatelessWriter.
        private SPDPbuiltinParticipantWriterImpl spdpWriter;

        public int ParticipantId { get; set; }
        public int DomainId { get; set; }


        public ParticipantImpl(int domainId, int participantId)
            : base(new global::Rtps.Structure.Types.GUID(new GuidPrefix(domainId), EntityId.ENTITYID_PARTICIPANT))
        {
            this.DomainId = domainId;
            this.ParticipantId = participantId;
        }

        public void Enable()
        {
            DDSConfigurationSection ddsConfig = Doopec.Configuration.DDSConfigurationSection.Instance;
            RTPSConfigurationSection rtpsConfig = Doopec.Configuration.RTPSConfigurationSection.Instance;
            DomainParticipant domain = ddsConfig.Domains[this.DomainId];
            Transport transport = rtpsConfig.Transports[domain.TransportProfile.Name];

            spdpReader = new SPDPbuiltinParticipantReaderImpl(transport, this);
            spdpWriter = new SPDPbuiltinParticipantWriterImpl(transport, this);

            spdpReader.Start();
            spdpWriter.Start();
            RtpsEngineFactory.Instance.DiscoveryModule.RegisterParticipant(this);
        }

        public void Close()
        {
            //spdpReader.Close();
            //spdpWriter.Close();
            RtpsEngineFactory.Instance.DiscoveryModule.UnregisterParticipant(this);
            //throw new NotImplementedException();
        }

        public void Dispose()
        {
            Close();
        }
    }
}
