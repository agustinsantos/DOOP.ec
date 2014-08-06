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
    public static class InfoReplyIp4Encoder
    {
        public static void PutInfoReplyIp4(this IoBuffer buffer, InfoReplyIp4 obj)
        {
            buffer.PutLocatorUDPv4(obj.UnicastLocator);
            buffer.PutLocatorUDPv4(obj.MulticastLocator);
        }

        public static InfoReplyIp4 GetInfoReplyIp4(this IoBuffer buffer)
        {
            InfoReplyIp4 obj = new InfoReplyIp4();
            buffer.GetInfoReplyIp4(ref obj);
            return obj;
        }

        public static void GetInfoReplyIp4(this IoBuffer buffer, ref InfoReplyIp4 obj)
        {
            obj.UnicastLocator = buffer.GetLocatorUDPv4();
            obj.MulticastLocator = buffer.GetLocatorUDPv4();
        }
    }
}
