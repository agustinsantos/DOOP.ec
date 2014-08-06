using Mina.Core.Buffer;
using rtps.messages.elements;

namespace RTPS.Utils.Network.Encoders
{
    public static class EntityIdEncoder
    {
        public static void PutEntityId(this IoBuffer buffer, EntityId obj)
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
    }
}
