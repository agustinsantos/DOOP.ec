using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{

    public static class VendorIdEncoder
    {
        public static void PutVendorId(this IoBuffer buffer, VendorId obj)
        {
            buffer.Put(obj.ToBytes());
        }
        public static void WriteVendorId(IoBuffer buffer, VendorId obj)
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

        public static void ReadVendorId(IoBuffer buffer, ref VendorId obj)
        {
            if (obj == null)
                obj = new VendorId();
            obj.Byte0 = buffer.Get();
            obj.Byte1 = buffer.Get();
        }
    }
    public class VendorIdSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, VendorId obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref VendorId obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = VendorIdEncoder.WriteVendorId;
            ReaderDelegate readerDelegate = VendorIdEncoder.ReadVendorId;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(VendorId);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
