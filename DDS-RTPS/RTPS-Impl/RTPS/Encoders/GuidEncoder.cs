using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class GUIDEncoder
    {
        public static void PutGUID(this IoBuffer buffer, GUID obj)
        {
            buffer.PutGuidPrefix(obj.Prefix);
            buffer.PutEntityId(obj.EntityId);
        }
        public static void WriteGUID(IoBuffer buffer, GUID obj)
        {
            buffer.PutGuidPrefix(obj.Prefix);
            buffer.PutEntityId(obj.EntityId);
        }

        public static GUID GetGUID(this IoBuffer buffer)
        {
            GUID obj = new GUID();
            obj.Prefix = buffer.GetGuidPrefix();
            obj.EntityId = buffer.GetEntityId();
            return obj;
        }

        public static void GetGUID(this IoBuffer buffer, ref GUID obj)
        {
            obj.Prefix = buffer.GetGuidPrefix();
            obj.EntityId = buffer.GetEntityId();
        }

        public static void ReadGUID(IoBuffer buffer, ref GUID obj)
        {
            if (obj == null)
                obj = new GUID();
            obj.Prefix = buffer.GetGuidPrefix();
            obj.EntityId = buffer.GetEntityId();
        }
    }

    public class GUIDSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, GUID obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref GUID obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = GUIDEncoder.WriteGUID;
            ReaderDelegate readerDelegate = GUIDEncoder.ReadGUID;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(GUID);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
