using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.submessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sxta.GenericProtocol.Encoding;

namespace RTPS.Utils.Network.Encoders
{
    public static class SubMessageHeaderEncoder
    {
        public static void PutSubMessageHeader(this IoBuffer buffer, SubMessageHeader obj)
        {
            buffer.Put((byte)obj.SubMessageKind);
            buffer.Put((byte)obj.FlagsValue);
            buffer.PutUShortLE(obj.SubMessageLength);
        }

        public static SubMessageHeader GetSubMessageHeader(this IoBuffer buffer)
        {
            SubMessageHeader obj = new SubMessageHeader((SubMessageKind)0, 0);
            buffer.GetSubMessageHeader(ref obj);
            return obj;
        }

        public static void GetSubMessageHeader(this IoBuffer buffer, ref SubMessageHeader obj)
        {
            obj.SubMessageKind = (SubMessageKind)buffer.Get();
            obj.FlagsValue = buffer.Get();
            obj.SubMessageLength = buffer.GetUShortLE();
        }
    }
}
