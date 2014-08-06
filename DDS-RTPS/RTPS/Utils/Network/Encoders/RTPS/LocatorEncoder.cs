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
    public static class LocatorEncoder
    {
        public static void PutLocator(this IoBuffer buffer, Locator obj)
        {
            buffer.PutInt32((int)obj.Kind);
            buffer.PutInt32(obj.Port);
            buffer.Put(obj.SocketAddressBytes);
        }

        public static Locator GetLocator(this IoBuffer buffer)
        {
            Locator obj = new Locator();
            buffer.GetLocator(ref obj);
            return obj;
        }

        public static void GetLocator(this IoBuffer buffer, ref Locator obj)
        {
            obj.Kind = (LocatorKind)buffer.GetInt32();
            obj.Port = (int)buffer.GetInt32(); ;
            byte[] tmp = new byte[16];

            buffer.Get(tmp, 0, 16);
            obj.SocketAddressBytes = tmp;
        }
    }
}
