using Mina.Core.Buffer;
using Rtps.Messages.Submessages;

namespace Doopec.Utils.Network.Encoders.Rtps
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
