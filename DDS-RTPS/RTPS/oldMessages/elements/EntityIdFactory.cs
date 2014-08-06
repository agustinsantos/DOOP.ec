

namespace rtps.messages.elements
{

    public class EntityIdFactory
    {

        public static EntityId CreateWriterId(int writer_count, byte[] topicId, bool wKey)
        {
            byte[] id = new byte[] { (byte)writer_count, topicId[0], topicId[1] };
            if (wKey)
                return new EntityId(id, EntityKinds.USER_DEFINED_WRITER_W_KEY);
            else
                return new EntityId(id, EntityKinds.USER_DEFINED_WRITER_NO_KEY);
        }

        public static EntityId CreateWriterId(int writer_count, EntityId topicId, bool wKey)
        {
            byte[] id = new byte[] { topicId.EntityKey1, topicId.EntityKey2 };
            return CreateWriterId(writer_count, id, wKey);
        }

        public static EntityId CreateReaderId(int reader_count, byte[] topicId, bool wKey)
        {
            byte[] id = new byte[] { (byte)reader_count, topicId[0], topicId[1] };
            if (wKey)
                return new EntityId(id, EntityKinds.USER_DEFINED_READER_W_KEY);
            else
                return new EntityId(id, EntityKinds.USER_DEFINED_READER_NO_KEY);
        }

        public static EntityId CreateReaderId(int reader_count, EntityId topicId, bool wKey)
        {
            byte[] id = new byte[] { topicId.EntityKey1, topicId.EntityKey2 };
            return CreateWriterId(reader_count, id, wKey);
        }

    }
}