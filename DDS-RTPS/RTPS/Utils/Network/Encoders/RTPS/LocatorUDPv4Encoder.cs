using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.submessage.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class LocatorUDPv4Encoder
    {
        public static void PutLocatorUDPv4(this IoBuffer buffer, LocatorUDPv4 obj)
        {
            buffer.PutInt32(obj.Port);
            buffer.PutInt32(obj.Address);
        }

        public static LocatorUDPv4 GetLocatorUDPv4(this IoBuffer buffer)
        {
            LocatorUDPv4 obj = new LocatorUDPv4();
            buffer.GetLocatorUDPv4(ref obj);
            return obj;
        }

        public static void GetLocatorUDPv4(this IoBuffer buffer, ref LocatorUDPv4 obj)
        {
            obj.Port = buffer.GetInt32();
            obj.Address = buffer.GetInt32();
        }
    }
}
