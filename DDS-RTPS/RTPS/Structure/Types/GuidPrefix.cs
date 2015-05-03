using RTPS.Utils;
using System;
namespace Rtps.Structure.Types
{
    /// <summary>
    /// Type used to hold the prefix of the globally-unique RTPS-entity identifiers. The
    /// GUIDs of entities belonging to the same participant all have the same prefix (see
    /// Section 8.2.4.3).
    /// Must be possible to represent using 12 octets.
    /// The following values are reserved by the protocol: GUIDPREFIX_UNKNOWN
    /// </summary>
    public class GuidPrefix
    {
        public const int GUID_PREFIX_SIZE = 12;

        public static readonly GuidPrefix GUIDPREFIX_UNKNOWN =
            new GuidPrefix(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

        /// <summary>
        /// GuidPrefix: 12 octets that uniquely identifies the Participant within the Domain
        /// </summary>
        protected byte[] prefix; //[12];

        public GuidPrefix(byte[] value)
        {
            if (value.Length != 12)
                throw new ArgumentException("Invalid guidprefix length");
            this.prefix = value;
        }

        public GuidPrefix()
            : this(new byte[12])
        {
        }

        public GuidPrefix(long value)
        {
           this.prefix = new byte[12];
           Array.Copy(BitConverter.GetBytes(value), 0, this.prefix, 4, 8);

        }

        public  byte[] Prefix
        {
            get
            {
                return prefix;
            }
            set
            {
                prefix = value;
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
            GuidPrefix other = (GuidPrefix)obj;
            return comparer.Equals(this.prefix, other.prefix);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return comparer.GetHashCode(this.prefix);
        }

        public override string ToString()
        {
            return BitConverter.ToString(this.prefix);
        }
    }
}