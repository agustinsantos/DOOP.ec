
using System;
using System.Net;

namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Locator specialized for UDPv4 protocol
    /// </summary>
    public class LocatorUDPv4
    {
        public static readonly LocatorUDPv4 LOCATORUDPv4_INVALID = new LocatorUDPv4(0, 0);

        protected int address;
        protected int port;

        public LocatorUDPv4()
        {
            this.address = 0;
            this.port = 0;
        }

        public LocatorUDPv4(IPAddress address, int port)
        {
            if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                this.address = BitConverter.ToInt32(address.GetAddressBytes(), 0);
            else
                throw new ArgumentException("IP address is not IPv4");
            this.port = port;
        }

        public LocatorUDPv4(int address, int port)
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