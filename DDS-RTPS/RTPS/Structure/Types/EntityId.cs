using RTPS.Utils;
namespace Rtps.Structure.Types
{
    /// <summary>
    /// 
    /// RTPS defines the following 11 kinds according to this convention:
    /// <ol>
    /// 		<li>The less significative half-byte is used to 
    /// 			distinguish between the 'type' of the entity</li>
    /// 		<li>The most significative half-byte is used to 
    /// 			distinguish between the 'nature' of the entity</li>
    /// <ol>
    /// Where type can be one of the following: {UNKNOWN, PARTICIPANT, WRITER, READER}
    /// and 'nature' one of the following: {BUILTIN, USER_DEFINED}.<br/>
    /// To distinguish between builtin and user_defined entities, the 2 most 
    /// significative bits (0xc0) are used.<br/>
    /// 
    /// According to this convention, the following pre-defined kinds are used:
    /// </summary>
    public enum EntityKinds : byte
    {
        USER_DEFINED_UNKNOWN = 0x00,
        USER_DEFINED_WRITER_W_KEY = 0x02,
        USER_DEFINED_WRITER_NO_KEY = 0x03,
        USER_DEFINED_READER_NO_KEY = 0x04,
        USER_DEFINED_READER_W_KEY = 0x07,
        BUILT_IN_UNKNOWN = 0xc0,
        BUILT_IN_PARTICIPANT = 0xc1,
        BUILT_IN_WRITER_W_KEY = 0xc2,
        BUILT_IN_WRITER_NO_KEY = 0xc3,
        BUILT_IN_READER_NO_KEY = 0xc4,
        BUILT_IN_READER_W_KEY = 0xc7
    }



    /// <summary>
    /// Type used to hold the suffix part of the globally-unique RTPS-entity identifiers. The
    /// EntityId_t uniquely identifies an Entity within a Participant.
    /// Must be possible to represent using 4 octets.
    /// The following values are reserved by the protocol: ENTITYID_UNKNOWN
    /// Additional pre-defined values are defined by the Discovery module in Section 8.5.
    /// </summary>
    public class EntityId 
    {
        /* PRE-DEFINED INSTANCE_ID */
        public readonly static EntityId ENTITYID_UNKNOWN =
             new EntityId(new byte[] { 0, 0, 0 }, EntityKinds.USER_DEFINED_UNKNOWN);

        public readonly static EntityId ENTITYID_PARTICIPANT =
            new EntityId(new byte[] { 0, 0, 1 }, EntityKinds.BUILT_IN_PARTICIPANT);

        public readonly static EntityId ENTITYID_SEDP_BUILTIN_TOPIC_WRITER =
            new EntityId(new byte[] { 0, 0, 2 }, EntityKinds.BUILT_IN_WRITER_W_KEY);
        public readonly static EntityId ENTITYID_SEDP_BUILTIN_TOPIC_READER =
            new EntityId(new byte[] { 0, 0, 2 }, EntityKinds.BUILT_IN_READER_W_KEY);
        
        public readonly static EntityId ENTITYID_SEDP_BUILTIN_PUBLICATIONS_WRITER =
            new EntityId(new byte[] { 0, 0, 3 }, EntityKinds.BUILT_IN_WRITER_W_KEY);
        public readonly static EntityId ENTITYID_SEDP_BUILTIN_PUBLICATIONS_READER =
            new EntityId(new byte[] { 0, 0, 3 }, EntityKinds.BUILT_IN_READER_W_KEY);
        
        public readonly static EntityId ENTITYID_SEDP_BUILTIN_SUBSCRIPTIONS_WRITER =
            new EntityId(new byte[] { 0, 0, 4 }, EntityKinds.BUILT_IN_WRITER_W_KEY);
        public readonly static EntityId ENTITYID_SEDP_BUILTIN_SUBSCRIPTIONS_READER =
            new EntityId(new byte[] { 0, 0, 4 }, EntityKinds.BUILT_IN_READER_W_KEY);

        public readonly static EntityId ENTITYID_SPDP_BUILTIN_PARTICIPANT_WRITER =
            new EntityId(new byte[] { 0, 1, 0 }, EntityKinds.BUILT_IN_WRITER_W_KEY);
        public readonly static EntityId ENTITYID_SPDP_BUILTIN_PARTICIPANT_READER =
            new EntityId(new byte[] { 0, 1, 0 }, EntityKinds.BUILT_IN_READER_W_KEY);
        
        public readonly static EntityId BuiltinParticipantMessageWriter =
            new EntityId(new byte[] { 0, 2, 0 }, EntityKinds.BUILT_IN_WRITER_W_KEY);
        public readonly static EntityId BuiltinParticipantMessageReader =
            new EntityId(new byte[] { 0, 2, 0 }, EntityKinds.BUILT_IN_READER_W_KEY);

        // -------------------------------------------------------------------------
        // EntityId: 4 octets that uniquely identifies the Entity within the Participant.
        //			 The first 3 bytes identifies the Entity, the last byte identifies
        //			 the kind of the Entity.
        // -------------------------------------------------------------------------
        protected byte[] entityKey; //[3];
        protected EntityKinds entityKind;	/* encodes the kind of entity, see defines */

        public EntityId(byte[] value, EntityKinds kind)
        {
            this.entityKey = value;
            this.entityKind = kind;
        }

        public EntityId()
            : this(new byte[3], EntityKinds.USER_DEFINED_UNKNOWN)
        {
        }

        public byte[] EntityKey
        {
            get
            {
                return this.entityKey;
            }
            set
            {
                this.entityKey = value;
            }
        }
        public EntityKinds TypeID
        {
            get
            {
                return this.entityKind;
            }
            set
            {
                this.entityKind = value;
            }
        }

        public byte EntityKey0
        {
            get
            {
                return this.entityKey[0];
            }
        }

        public byte EntityKey1
        {
            get
            {
                return this.entityKey[1];
            }
        }

        public byte EntityKey2
        {
            get
            {
                return this.entityKey[2];
            }
        }

        private static readonly ArrayEqualityComparer<byte> comparer = new ArrayEqualityComparer<byte>();

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            EntityId other = (EntityId)obj;
            return comparer.Equals(this.entityKey, other.entityKey) &&
                        this.entityKey == other.entityKey;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return comparer.GetHashCode(this.entityKey);
        }


        public int IntValue
        {
            get
            {
                int out_ = 0;
                out_ |= ((int)entityKind) << 24;
                out_ |= ((int)entityKey[0]) << 16;
                out_ |= ((int)entityKey[1]) << 8;
                out_ |= ((int)entityKey[2]);
                return out_;
            }
        }

        public override string ToString()
        {
            return entityKey[2] + entityKey[1] + entityKey[0] + "-" + entityKind;
        }
    }
}