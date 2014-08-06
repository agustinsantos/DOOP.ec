using Mina.Core.Buffer;
using Rtps.Structure.Types;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class SequenceNumberEncoder
    {
        public static void PutSequenceNumber(this IoBuffer buffer, SequenceNumber obj)
        {
            buffer.PutInt32(obj.High);
            buffer.PutInt32((int)obj.Low);
        }

        public static SequenceNumber GetSequenceNumber(this IoBuffer buffer)
        {
            SequenceNumber obj = new SequenceNumber();
            buffer.GetSequenceNumber(ref obj);
            return obj;
        }

        public static void GetSequenceNumber(this IoBuffer buffer, ref SequenceNumber obj)
        {
            obj.High = buffer.GetInt32();
            obj.Low = (uint)buffer.GetInt32(); ;
        }
    }
}
