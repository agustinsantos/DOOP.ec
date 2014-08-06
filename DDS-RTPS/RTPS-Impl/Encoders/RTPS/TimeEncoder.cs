using Mina.Core.Buffer;
using Rtps.Messages.Types;

namespace Doopec.Utils.Network.Encoders.Rtps
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
