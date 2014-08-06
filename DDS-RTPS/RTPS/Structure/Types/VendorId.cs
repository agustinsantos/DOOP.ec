using RTPS.Utils;
using System;
namespace Rtps.Structure.Types
{
    /// <summary>
    /// The VendorId identifies the vendor of the middleware implementing the RTPS protocol and allows this vendor to add
    /// specific extensions to the protocol. The vendor ID does not refer to the vendor of the device or product that contains DDS
    /// middleware.
    /// </summary>
    public class VendorId
    {
        public static int VENDOR_ID_SIZE = 2;

        public static readonly VendorId VENDORID_UNKNOWN = new VendorId() { vendorId = new byte[] { 0, 0 } };
        public static readonly VendorId RTI = new VendorId() { vendorId = new byte[] { 1, 1 } };
        public static readonly VendorId PrismTech = new VendorId() { vendorId = new byte[] { 1, 2 } };
        public static readonly VendorId OCI = new VendorId() { vendorId = new byte[] { 1, 3 } };
        public static readonly VendorId MilSoft = new VendorId() { vendorId = new byte[] { 1, 4 } };
        public static readonly VendorId Gallium = new VendorId() { vendorId = new byte[] { 1, 5 } };
        public static readonly VendorId TwinOaks = new VendorId() { vendorId = new byte[] { 1, 6 } };
        public static readonly VendorId Lakota = new VendorId() { vendorId = new byte[] { 1, 7 } };
        public static readonly VendorId Icoup = new VendorId() { vendorId = new byte[] { 1, 8 } };
        public static readonly VendorId ETRI = new VendorId() { vendorId = new byte[] { 1, 9 } };
        public static readonly VendorId RTIMicro = new VendorId() { vendorId = new byte[] { 1, 0xA } };
        public static readonly VendorId PrismTechMobile = new VendorId() { vendorId = new byte[] { 1, 0xB } };
        public static readonly VendorId PrismTechGateway = new VendorId() { vendorId = new byte[] { 1, 0xC } };
        public static readonly VendorId PrismTechLite = new VendorId() { vendorId = new byte[] { 1, 0xD } };
        public static readonly VendorId Technicolor = new VendorId() { vendorId = new byte[] { 1, 0xE } };
        public static readonly VendorId Sxta = new VendorId() { vendorId = new byte[] { 1, 0xF } };

        /// <summary>
        /// Identifies the vendor of the middleware that implements the protocol.
        /// </summary>
        public byte[] vendorId;//[2];

        public VendorId(byte[] value)
        {
            this.vendorId = value;
        }

        public VendorId()
        {
            this.vendorId = new byte[] { 0, 0 };
        }

        public byte[] ToBytes()
        { return vendorId; }

        public byte Byte0
        {
            get { return vendorId[0]; }
            set { vendorId[0] = value; }
        }

        public byte Byte1
        {
            get { return vendorId[1]; }
            set { vendorId[1] = value; }
        }
        private static readonly ArrayEqualityComparer<byte> comparer = new ArrayEqualityComparer<byte>();

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            VendorId other = (VendorId)obj;
            return comparer.Equals(this.vendorId, other.vendorId);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return comparer.GetHashCode(this.vendorId);
        }

        public override string ToString()
        {
            return BitConverter.ToString(this.vendorId);
        }
    }
}
