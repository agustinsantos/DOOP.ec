using Mina.Core.Buffer;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Encoders
{

    public static class VendorIdEncoder
    {
        public static void PutVendorId(this IoBuffer buffer, VendorId obj)
        {
            buffer.Put(obj.ToBytes());
        }

        public static VendorId GetVendorId(this IoBuffer buffer)
        {
            VendorId obj = new VendorId();
            buffer.GetVendorId(ref obj);
            return obj;
        }

        public static void GetVendorId(this IoBuffer buffer, ref VendorId obj)
        {
            obj.Byte0 = buffer.Get();
            obj.Byte1 = buffer.Get();
        }
    }
}
