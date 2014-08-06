
using System;
using System.Net;
namespace rtps.messages.elements
{
    /// <summary>
    /// Locator specialized for UDPv4 protocol
    /// </summary>
    public class LocatorUDPv4 : SubMessageElement
    {
        public static readonly LocatorUDPv4 LOCATORUDPv4_INVALID = new LocatorUDPv4(0, 0);

        protected int address;
        protected int port;

        public LocatorUDPv4()
            : base(8)
        {
            this.address = 0;
            this.port = 0;
        }


        public LocatorUDPv4(IPAddress address, int port)
            : base(8)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                this.address = BitConverter.ToInt32(address.GetAddressBytes(), 0);
            else
                throw new ArgumentException("IP address is not IPv4");
            this.port = port;
        }
        public LocatorUDPv4(int address, int port)
            : base(8)
        {
            this.address = address;
            this.port = port;
        }

        public IPEndPoint IPEndPoint
        {
            get { return new IPEndPoint(address, (int)port); }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }
        public int Address
        {
            get { return address; }
            set { address = value; }
        }
        public override string ToString()
        {
            return this.IPEndPoint.ToString();
        }
    }
}