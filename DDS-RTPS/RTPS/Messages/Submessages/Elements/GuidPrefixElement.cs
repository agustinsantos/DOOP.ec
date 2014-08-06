using Rtps.Structure.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Type used to hold the prefix of the globally-unique RTPS-entity identifiers. The
    /// GUIDs of entities belonging to the same participant all have the same prefix (see
    /// Section 8.2.4.3).
    /// Must be possible to represent using 12 octets.
    /// The following values are reserved by the protocol: GUIDPREFIX_UNKNOWN
    /// </summary>
    public class GuidPrefixElement : SubmessageElement<GuidPrefix>
    {
        public const int GUID_PREFIX_SIZE = 12;
 
        public GuidPrefixElement(GuidPrefix val)
            : base(GUID_PREFIX_SIZE, val)
        {
        }

        public GuidPrefixElement()
            : this(new GuidPrefix())
        {
        }
    }
}