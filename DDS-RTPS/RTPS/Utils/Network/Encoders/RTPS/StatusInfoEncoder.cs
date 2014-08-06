using Mina.Core.Buffer;
using rtps.messages.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class StatusInfoEncoder
    {
        public static void PutStatusInfo(this IoBuffer buffer, StatusInfo obj)
        {
            buffer.Put(obj.Bytes);
        }

        public static StatusInfo GetStatusInfo(this IoBuffer buffer)
        {
            StatusInfo obj = new StatusInfo();
            buffer.GetStatusInfo(ref obj);
            return obj;
        }

        public static void GetStatusInfo(this IoBuffer buffer, ref StatusInfo obj)
        {
             buffer.Get(obj.Bytes, 0, 4);
        }
    }
}
