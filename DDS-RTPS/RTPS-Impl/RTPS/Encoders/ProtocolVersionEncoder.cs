using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class ProtocolVersionEncoder
    {
        public static void PutProtocolVersion(this IoBuffer buffer, ProtocolVersion obj)
        {
            buffer.Put(obj.Major);
            buffer.Put(obj.Minor);
        }
        public static void WriteProtocolVersion(IoBuffer buffer, ProtocolVersion obj)
        {
            buffer.Put(obj.Major);
            buffer.Put(obj.Minor);
        }

        public static ProtocolVersion GetProtocolVersion(this IoBuffer buffer)
        {
            ProtocolVersion obj = new ProtocolVersion();
            buffer.GetProtocolVersion(ref obj);
            return obj;
        }

        public static void GetProtocolVersion(this IoBuffer buffer, ref ProtocolVersion obj)
        {
            obj.Major = buffer.Get();
            obj.Minor = buffer.Get();
        }
        public static void ReadProtocolVersion( IoBuffer buffer, ref ProtocolVersion obj)
        {
            if (obj == null)
                obj = new ProtocolVersion();
            obj.Major = buffer.Get();
            obj.Minor = buffer.Get();
        }
    }
    public class ProtocolVersionSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, ProtocolVersion obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref ProtocolVersion obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = ProtocolVersionEncoder.WriteProtocolVersion;
            ReaderDelegate readerDelegate = ProtocolVersionEncoder.ReadProtocolVersion;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(ProtocolVersion);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
