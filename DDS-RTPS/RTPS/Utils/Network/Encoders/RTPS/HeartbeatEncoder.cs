using Mina.Core.Buffer;
using rtps.messages.submessage.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders.RTPS
{
    public static class HeartbeatEncoder
    {
        public static void PutHeartbeat(this IoBuffer buffer, Heartbeat obj)
        {
            buffer.PutEntityId(obj.readerId);
            buffer.PutEntityId(obj.writerId);
            buffer.PutSequenceNumber(obj.firstSN);
            buffer.PutSequenceNumber(obj.lastSN);
            buffer.PutInt32(obj.count);
        }

        public static Heartbeat GetHeartbeat(this IoBuffer buffer)
        {
            Heartbeat obj = new Heartbeat();
            buffer.GetHeartbeat(ref obj);
            return obj;
        }

        public static void GetHeartbeat(this IoBuffer buffer, ref Heartbeat obj)
        {
            obj.readerId = buffer.GetEntityId();
            obj.writerId = buffer.GetEntityId();
            obj.firstSN = buffer.GetSequenceNumber();
            obj.lastSN = buffer.GetSequenceNumber();
            obj.count = buffer.GetInt32();
        }
    }
}
