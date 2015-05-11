using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class GuidPrefixEncoder
    {
        public static void PutGuidPrefix(this IoBuffer buffer, GuidPrefix obj)
        {
            buffer.Put(obj.Prefix);
        }
        public static void WriteGuidPrefix(IoBuffer buffer, GuidPrefix obj)
        {
            buffer.Put(obj.Prefix);
        }

        public static GuidPrefix GetGuidPrefix(this IoBuffer buffer)
        {
            GuidPrefix obj = new GuidPrefix();
            buffer.GetGuidPrefix(ref obj);
            return obj;
        }

        public static void GetGuidPrefix(this IoBuffer buffer, ref GuidPrefix obj)
        {
            buffer.Get(obj.Prefix, 0, GuidPrefix.GUID_PREFIX_SIZE);
        }

        public static void ReadGuidPrefix(IoBuffer buffer, ref GuidPrefix obj)
        {
            buffer.Get(obj.Prefix, 0, GuidPrefix.GUID_PREFIX_SIZE);
        }
    }

    public class GuidPrefixSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, GuidPrefix obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref GuidPrefix obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = GuidPrefixEncoder.WriteGuidPrefix;
            ReaderDelegate readerDelegate = GuidPrefixEncoder.ReadGuidPrefix;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(GuidPrefix);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
