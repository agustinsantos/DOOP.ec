
using Rtps.Messages.Types;
using RTPS.Utils;
using System;
using System.Text;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Protocol Identifier (constant at {'R','T','P','S'})
    /// </summary>
    public class ProtocolIdElement : SubmessageElement<ProtocolId>
    {

        public const int PROTOID_SIZE = 4;
        public ProtocolIdElement(ProtocolId id)
            : base(PROTOID_SIZE, id)
        {
        }

        public ProtocolIdElement()
            : base(PROTOID_SIZE, ProtocolId.PROTOCOL_RTPS)
        {
        }
    }
}
