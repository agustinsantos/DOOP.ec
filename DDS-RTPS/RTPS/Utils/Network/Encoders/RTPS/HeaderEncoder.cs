using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class HeaderEncoder
    {
        public static void PutHeader(this IoBuffer buffer, Header msg)
        {
            buffer.PutProtocolId(msg.Protocol);
            buffer.PutProtocolVersion(msg.Version);
            buffer.PutVendorId(msg.VendorId);
            buffer.PutGuidPrefix(msg.GuidPrefix);
        }

        public static Header GetHeader(this IoBuffer buffer)
        {
            Header obj = new Header();
            buffer.GetHeader(ref obj);
            return obj;
        }

        public static void GetHeader(this IoBuffer buffer, ref Header obj)
        {
            ProtocolId protocol = buffer.GetProtocolId();
            if (!protocol.Equals(ProtocolId.PROTOCOL_RTPS))
            {
                throw new ApplicationException("Wrong Protocol ID. Expected RTPS");
            }
            ProtocolVersion version = buffer.GetProtocolVersion();
            if (!version.Equals(ProtocolVersion.PROTOCOLVERSION))
            {
                throw new ApplicationException("Wrong Protocol version. Expected " + ProtocolVersion.PROTOCOLVERSION);
            }
            obj.VendorId = buffer.GetVendorId();
            obj.GuidPrefix = buffer.GetGuidPrefix();
        }
    }
}
