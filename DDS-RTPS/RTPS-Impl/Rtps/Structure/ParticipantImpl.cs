using Doopec.Rtps.Discovery;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Structure
{
    public class ParticipantImpl : Participant
    {
        private SPDPbuiltinParticipantReader spdpReader;

        //The SPDPbuiltinParticipantWriter is an RTPS Best-Effort StatelessWriter.
        private SPDPbuiltinParticipantWriter spdpWriter;

        public ParticipantImpl()
            : base()
        {
            spdpReader = new SPDPbuiltinParticipantReader(this);
            spdpWriter = new SPDPbuiltinParticipantWriter(this);
        }
    }
}
