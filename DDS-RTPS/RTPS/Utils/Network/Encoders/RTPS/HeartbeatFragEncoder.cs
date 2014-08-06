using Mina.Core.Buffer;
using Rtps.messages.submessage.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders.RTPS
{
    public static class HeartbeatFragEncoder
    {
        public static void PutHeartbeatFrag(this IoBuffer buffer, HeartbeatFrag obj)
        {
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumber(obj.WriterSequenceNumber);
            buffer.PutInt32(obj.LastFragmentNumber);
            buffer.PutInt32(obj.Count);
        }

        public static HeartbeatFrag GetHeartbeatFrag(this IoBuffer buffer)
        {
            HeartbeatFrag obj = new HeartbeatFrag();
            buffer.GetHeartbeatFrag(ref obj);
            return obj;
        }

        public static void GetHeartbeatFrag(this IoBuffer buffer, ref HeartbeatFrag obj)
        {
            obj.ReaderId = buffer.GetEntityId();
            obj.WriterId = buffer.GetEntityId();
            obj.WriterSequenceNumber = buffer.GetSequenceNumber();
            obj.LastFragmentNumber = buffer.GetInt32();
            obj.Count = buffer.GetInt32();
        }
    }
}
