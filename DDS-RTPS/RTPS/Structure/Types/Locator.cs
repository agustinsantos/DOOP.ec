

using RTPS.Utils;
using System;
using System.Net;
namespace Rtps.Structure.Types
{
    // -------------------------------------------------------------------------
    // Locator of an Entity 
    // -------------------------------------------------------------------------
    public enum LocatorKind : int
    {
        LOCATOR_KIND_INVALID = -1,
        LOCATOR_PORT_INVALID = 0,
        LOCATOR_KIND_RESERVED = 0,
        LOCATOR_KIND_UDPv4 = 1,
        LOCATOR_KIND_UDPv6 = 2
    }

    /// <summary>
    /// Type used to represent the addressing information needed to send a message to an
    /// RTPS Endpoint using one of the supported transports.
    /// Should be able to hold a Discriminator identifying the kind of transport, an address,
    /// and a port number. It must be possible to represent the Discriminator and port
    /// number using 4 octets, the address using 16 octets.
    /// </summary>
    public class Locator
    {
        public static int LOCATOR_SIZE = 24;

        /// <summary>
        /// If the kind is LOCATOR_KIND_UDPv4, the address contains an IPv4 address. In this
        /// case the leading 12 octets of the address must be zero. The last 4 octets are used to store the
        /// IPv4 address. The mapping between the dot-notation “a.b.c.d” of an IPv4 address and its
        /// representation in the address field of a Locator_t is:
        ///               address = (0,0,0,0,0,0,0,0,0,0,0,0,a,b,c,d}
        /// If the kind is LOCATOR_KIND_UDPv6, the address contains an IPv6 address. IPv6
        /// addresses typically use a shorthand hexadecimal notation that maps one-to-one to the 16
        /// octets in the address field. For example the representation of the IPv6 address
        /// “FF00:4501:0:0:0:0:0:32” is:
        ///               address = (0xff,0,0x45,0x01,0,0,0,0,0,0,0,0,0,0,0,0x32}
        /// </summary>
        protected LocatorKind kind;
        protected uint port;
        protected byte[] address; //[16];

        public Locator()
        {
            this.kind = LocatorKind.LOCATOR_KIND_INVALID;
            this.address = new byte[16];
        }

        public Locator(IPEndPoint ipendpoint)
            : this(ipendpoint.Address, ipendpoint.Port)
        {
        }

        public Locator(IPAddress addr, int port)
        {
            this.port = (uint)port;
            byte[] bytes = addr.GetAddressBytes();
            if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                this.kind = LocatorKind.LOCATOR_KIND_UDPv4;
                this.address = new byte[16];
                Array.Copy(bytes, 0, this.address, 12, 4);
            }
            else if (addr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                this.kind = LocatorKind.LOCATOR_KIND_UDPv6;
                this.address = bytes;
            }
            else
            {
                this.kind = LocatorKind.LOCATOR_KIND_INVALID;
                this.address = new byte[16];
            }
        }

        public Locator(LocatorKind kind, uint port, byte[] address)
        {
            this.kind = kind;
            this.port = port;
            this.address = address;
        }

        public int Port
        {
            get { return (int)port; }
            set { port = (uint)value; }
        }

        public IPAddress SocketAddress
        {
            get
            {
                if (this.kind == LocatorKind.LOCATOR_KIND_UDPv4)
                {
                    byte[] bytes = new byte[4];
                    Array.Copy(this.address, 12, bytes, 0, 4);

                    return new IPAddress(bytes);
                }
                else
                {
                    return new IPAddress(address);
                }
            }
            set { address = value.GetAddressBytes(); }
        }

        public byte[] SocketAddressBytes
        {
            get { return address; }
            set { address = value; }
        }

        public LocatorKind Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        private static readonly ArrayEqualityComparer<byte> comparer = new ArrayEqualityComparer<byte>();

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Locator other = (Locator)obj;
            return this.kind == other.kind && this.port == other.port && comparer.Equals(this.address, other.address);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return (int)this.port * 31 + comparer.GetHashCode(this.address) + (int)this.kind;
        }

        public override string ToString()
        {
            return this.SocketAddress + ":" + this.Port;
        }
    }
}
