using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Messages.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class ProtocolIdEncoder
    {
        public static void PutProtocolId(this IoBuffer buffer, ProtocolId obj)
        {
            buffer.Put(obj.Id);
        }
        public static void WriteProtocolId(IoBuffer buffer, ProtocolId obj)
        {
            buffer.Put(obj.Id);
        }
        public static ProtocolId GetProtocolId(this IoBuffer buffer)
        {
            ProtocolId obj = new ProtocolId();
            buffer.GetProtocolId(ref obj);
            return obj;
        }

        public static void GetProtocolId(this IoBuffer buffer, ref ProtocolId obj)
        {
            buffer.Get(obj.Id, 0, ProtocolId.PROTOID_SIZE);
        }
        public static void ReadProtocolId( IoBuffer buffer, ref ProtocolId obj)
        {
            if (obj == null)
                obj = new ProtocolId();
            buffer.Get(obj.Id, 0, ProtocolId.PROTOID_SIZE);
        }
    }
    public class ProtocolIdSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, ProtocolId obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref ProtocolId obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = ProtocolIdEncoder.WriteProtocolId;
            ReaderDelegate readerDelegate = ProtocolIdEncoder.ReadProtocolId;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(ProtocolId);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
