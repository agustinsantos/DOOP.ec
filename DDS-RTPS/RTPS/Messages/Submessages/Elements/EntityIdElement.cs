using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Type used to hold the suffix part of the globally-unique RTPS-entity identifiers. The
    /// EntityId_t uniquely identifies an Entity within a Participant.
    /// Must be possible to represent using 4 octets.
    /// The following values are reserved by the protocol: ENTITYID_UNKNOWN
    /// Additional pre-defined values are defined by the Discovery module in Section 8.5.
    /// </summary>
    public class EntityIdElement : SubmessageElement<EntityId>
    {
        public const int ENTITY_ID_SIZE = 4;

        public EntityIdElement(EntityId value)
            : base(ENTITY_ID_SIZE, value)
        {
        }

        public EntityIdElement()
            : this(new EntityId())
        {
        }
    }
}