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
    public static class InfoTimestampEncoder
    {
        public static void PutInfoTimestamp(this IoBuffer buffer, InfoTimestamp obj)
        {
            if (!obj.HasInvalidateFlag)
            {
                buffer.PutTime(obj.TimeStamp);
            }
        }

        public static InfoTimestamp GetInfoTimestamp(this IoBuffer buffer)
        {
            InfoTimestamp obj = new InfoTimestamp();
            buffer.GetInfoTimestamp(ref obj);
            return obj;
        }

        public static void GetInfoTimestamp(this IoBuffer buffer, ref InfoTimestamp obj)
        {
            if (!obj.HasInvalidateFlag)
            {
                obj.TimeStamp = buffer.GetTime();
            }

        }
    }
}
