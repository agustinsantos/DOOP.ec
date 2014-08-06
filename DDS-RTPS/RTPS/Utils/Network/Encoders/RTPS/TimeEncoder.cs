using Mina.Core.Buffer;
using Rtps.messages.elements;
using Rtps.messages.submessage.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class TimeEncoder
    {
        public static void PutTime(this IoBuffer buffer, Time obj)
        {
            buffer.PutInt32(obj.Seconds);
            buffer.PutInt32((int)obj.Fraction);
        }

        public static Time GetTime(this IoBuffer buffer)
        {
            Time obj = new Time();
            buffer.GetTime(ref obj);
            return obj;
        }

        public static void GetTime(this IoBuffer buffer, ref Time obj)
        {
            obj.Seconds = buffer.GetInt32();
            obj.Fraction = (uint)buffer.GetInt32(); ;
        }
    }
}
