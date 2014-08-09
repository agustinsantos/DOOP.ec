using Mina.Core.Buffer;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Encoders
{
    public static class LocatorEncoder
    {
        public static void PutLocator(this IoBuffer buffer, Locator obj)
        {
            buffer.PutInt32((int)obj.Kind);
            buffer.PutInt32(obj.Port);
            buffer.Put(obj.SocketAddressBytes);
        }

        public static Locator GetLocator(this IoBuffer buffer)
        {
            Locator obj = new Locator();
            buffer.GetLocator(ref obj);
            return obj;
        }

        public static void GetLocator(this IoBuffer buffer, ref Locator obj)
        {
            obj.Kind = (LocatorKind)buffer.GetInt32();
            obj.Port = (int)buffer.GetInt32(); ;
            byte[] tmp = new byte[16];

            buffer.Get(tmp, 0, 16);
            obj.SocketAddressBytes = tmp;
        }
    }
}
