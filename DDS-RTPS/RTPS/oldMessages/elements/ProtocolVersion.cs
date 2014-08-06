


using System;
namespace rtps.messages.elements
{
    /// <summary>
    /// Protocol Version in major and minor releases
    /// </summary>
    public class ProtocolVersion : SubMessageElement, IComparable<ProtocolVersion>
    {
        public static int PROTOCOL_VERSION_SIZE = 2;

        public static readonly ProtocolVersion PROTOCOLVERSION_1_0 = new ProtocolVersion() { major = 1, minor = 0 };
        public static readonly ProtocolVersion PROTOCOLVERSION_1_1 = new ProtocolVersion() { major = 1, minor = 1 };
        public static readonly ProtocolVersion PROTOCOLVERSION_2_0 = new ProtocolVersion() { major = 2, minor = 0 };
        public static readonly ProtocolVersion PROTOCOLVERSION_2_1 = new ProtocolVersion() { major = 2, minor = 1 };
        public static readonly ProtocolVersion PROTOCOLVERSION = new ProtocolVersion() { major = 2, minor = 1 };

        protected byte major;
        protected byte minor;

        public ProtocolVersion(byte major, byte minor) :
            base(PROTOCOL_VERSION_SIZE)
        {
            this.major = major;
            this.minor = minor;
        }

        public ProtocolVersion() :
            base(PROTOCOL_VERSION_SIZE)
        {
            this.major = 2;
            this.minor = 1;
        }

        /// <summary>
        /// Returns the value.
        /// </summary>
        public byte Major
        {
            get
            {
                return this.major;
            }
            set
            {
                this.major = value;
            }
        }

        public byte Minor
        {
            get
            {
                return this.minor;
            }
            set
            {
                this.minor = value;
            }
        }

        public override string ToString()
        {
            return this.major + "." + this.minor;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ProtocolVersion other = (ProtocolVersion)obj;
            return this.CompareTo(other) == 0;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.major * 31 + this.minor;
        }

        public int CompareTo(ProtocolVersion ver)
        {
            if (this.major > ver.major)
            {
                return 1;
            }
            else if (this.major > ver.major)
            {
                return -1;
            }
            else
            {
                // major version is the same...
                if (this.minor > ver.minor)
                {
                    return 1;
                }
                else if (this.minor < ver.minor)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
