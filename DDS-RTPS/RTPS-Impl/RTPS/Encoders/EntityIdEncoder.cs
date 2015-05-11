using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class EntityIdEncoder
    {
        public static void PutEntityId(this IoBuffer buffer, EntityId obj)
        {
            buffer.Put(obj.EntityKey);
            buffer.Put((byte)obj.TypeID);
        }
        public static void WriteEntityId(IoBuffer buffer, EntityId obj)
        {
            buffer.Put(obj.EntityKey);
            buffer.Put((byte)obj.TypeID);
        }
        public static EntityId GetEntityId(this IoBuffer buffer)
        {
            EntityId obj = new EntityId();
            buffer.GetEntityId(ref obj);
            return obj;
        }

        public static void GetEntityId(this IoBuffer buffer, ref EntityId obj)
        {
            buffer.Get(obj.EntityKey, 0, 3);
            obj.TypeID = (EntityKinds)buffer.Get();
        }
        public static void ReadEntityId(IoBuffer buffer, ref EntityId obj)
        {
            if (obj == null)
                obj = new EntityId();

            buffer.Get(obj.EntityKey, 0, 3);
            obj.TypeID = (EntityKinds)buffer.Get();
        }
    }

    public class EntityIdSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, EntityId obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref EntityId obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = EntityIdEncoder.WriteEntityId;
            ReaderDelegate readerDelegate = EntityIdEncoder.ReadEntityId;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(EntityId);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
