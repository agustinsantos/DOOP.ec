
using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Protocol Version in major and minor releases
    /// </summary>
    public class ProtocolVersionElement : SubmessageElement<ProtocolVersion>
    {
        public static int PROTOCOL_VERSION_SIZE = 2;

        public ProtocolVersionElement(ProtocolVersion value) :
            base(PROTOCOL_VERSION_SIZE, value)
        {
        }

        public ProtocolVersionElement() :
            this(ProtocolVersion.PROTOCOLVERSION_2_1)
        {
        }
    }
}
