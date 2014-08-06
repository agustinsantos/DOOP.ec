using Mina.Core.Buffer;
using Rtps.Messages.Submessages;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class PadEncoder
    {
        public static void PutPad(this IoBuffer buffer, Pad obj)
        {
            buffer.Put(obj.Bytes);
        }

        public static Pad GetPad(this IoBuffer buffer)
        {
            Pad obj = new Pad();
            buffer.GetPad(ref obj);
            return obj;
        }

        public static void GetPad(this IoBuffer buffer, ref Pad obj)
        {
            obj.Bytes = new byte[buffer.Remaining];
            buffer.Get(obj.Bytes, 0, obj.Bytes.Length);
        }
    }
}
