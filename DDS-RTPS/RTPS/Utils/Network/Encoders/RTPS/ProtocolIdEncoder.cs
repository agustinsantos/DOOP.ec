using Mina.Core.Buffer;
using rtps.messages.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class ProtocolIdEncoder
    {
        public static void PutProtocolId(this IoBuffer buffer, ProtocolId obj)
        {
            buffer.Put(obj.Id);
        }

        public static ProtocolId GetProtocolId(this IoBuffer buffer)
        {
            ProtocolId obj = new ProtocolId();
            buffer.GetProtocolId(ref obj);
            return obj;
        }

        public static void GetProtocolId(this IoBuffer buffer, ref ProtocolId obj)
        {
            buffer.Get(obj.Id, 0, ProtocolId.PROTOID_SIZE);
        }
    }
}
