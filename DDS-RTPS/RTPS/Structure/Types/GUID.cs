
namespace Rtps.Structure.Types
{

    /// <summary>
    /// GUID stands for Global Universal IDentifier. It consists of
    /// a 12 bytes <code>GuidPrefix<code> and a 4 bytes <code>EntityId</code> suffix.<br/>
    /// The prefix is used to identify a participant in the domain,
    /// the suffix to identify the entity in the participant.
    /// </summary>
    public class GUID
    {
        public static readonly GUID GUID_UNKNOWN = new GUID { guidPrefix = GuidPrefix.GUIDPREFIX_UNKNOWN, entityId = EntityId.ENTITYID_UNKNOWN };

        /// <summary>
        /// prefix (12 bytes)
        /// </summary>
        protected GuidPrefix guidPrefix;

        /// <summary>
        /// entityId (4 bytes)
        /// </summary>
        protected EntityId entityId;

        public GUID(GuidPrefix prefix, EntityId entityId)
        {
            this.guidPrefix = prefix;
            this.entityId = entityId;
        }

        public GUID()
            : this(new GuidPrefix(), new EntityId())
        {
        }

        /// <summary>
        /// Returns the entityId.
        /// Uniquely identifies the entity in the participant.
        /// </summary>
        public EntityId EntityId
        {
            get { return entityId; }
            internal set { entityId = value; }
        }

        /// <summary>
        /// Returns the prefix.
        /// Uniquely identifies the participant within the domain.
        /// </summary>
        public GuidPrefix Prefix
        {
            get { return guidPrefix; }
            internal set { guidPrefix = value; }
        }



        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            GUID other = (GUID)obj;
            return this.guidPrefix == other.guidPrefix &&
                        this.entityId == other.entityId;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.guidPrefix.GetHashCode() * 31 + this.entityId.GetHashCode();
        }

        public override string ToString()
        {
            return this.guidPrefix.ToString() + ":" + this.entityId.ToString();
        }
    }
}
