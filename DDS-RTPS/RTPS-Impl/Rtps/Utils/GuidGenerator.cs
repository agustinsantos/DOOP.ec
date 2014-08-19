using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Doopec.Rtps.Utils
{
    /// <summary>
    /// Generate GuidPrefix_t values for use with RTPS
    ///    Also see GuidConverter.h in dds/DCPS
    ///    0  GUID_t.guidPrefix[ 0] == VendorId_t == 0x01 for OCI (used for OpenDDS)
    ///    1  GUID_t.guidPrefix[ 1] == VendorId_t == 0x03 for OCI (used for OpenDDS)
    ///    2  GUID_t.guidPrefix[ 2] == MAC Address
    ///    3  GUID_t.guidPrefix[ 3] == MAC Address
    ///    4  GUID_t.guidPrefix[ 4] == MAC Address
    ///    5  GUID_t.guidPrefix[ 5] == MAC Address
    ///    6  GUID_t.guidPrefix[ 6] == MAC Address
    ///    7  GUID_t.guidPrefix[ 7] == MAC Address
    ///    8  GUID_t.guidPrefix[ 8] == Process ID (MS byte)
    ///    9  GUID_t.guidPrefix[ 9] == Process ID (LS byte)
    ///   10  GUID_t.guidPrefix[10] == Counter (MS byte)
    ///   11  GUID_t.guidPrefix[11] == Counter (LS byte)
    ///   
    /// Code borrowed from the code of OpenDDS
    /// </summary>
    public class GuidGenerator
    {
        /// <summary>
        /// Vendor Id value specified for Doop-ec.
        /// TODO. Look for the right value
        /// </summary>
        public static readonly byte[] VENDORID_DOOPEC = new byte[] { 0x01, 0xAA };

        public const int NODE_ID_SIZE = 6;

        private static Random rand = new Random();

        /// Static constructor - initializes pid and MAC address values
        static GuidGenerator()
        {
            nodeId[0] = VENDORID_DOOPEC[0];
            nodeId[1] = VENDORID_DOOPEC[1];

            byte[] partId = new byte[NODE_ID_SIZE];
            PhysicalAddress macaddress = GetMacAddress();

            if (macaddress != null)
            {
                Array.Copy(macaddress.GetAddressBytes(), partId, NODE_ID_SIZE);
            }
            else
            {
                rand.NextBytes(partId);
            }
            Array.Copy(partId, 0, nodeId, 2, NODE_ID_SIZE);

            int pid = Process.GetCurrentProcess().Id;
            nodeId[8] = (byte)(pid >> 8);
            nodeId[9] = (byte)(pid & 0xFF);
        }

        /// <summary>
        /// Finds the MAC address of the first operation NIC found.
        /// </summary>
        /// <returns>The MAC address.</returns>
        private static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }

        /// populate a GUID container with a unique ID. This will increment
        /// the counter, and use a lock while doing so.
        public void Populate(ref GUID container)
        {
            byte[] guidPrefix = container.Prefix.Prefix; // new byte[GuidPrefix.GUID_PREFIX_SIZE];
            Array.Copy(nodeId, 0, guidPrefix, 0, nodeId.Length);

            int count = GetCount();
            guidPrefix[10] = (byte)(count >> 8);
            guidPrefix[11] = (byte)(count & 0xFF);
        }

        public GUID GenerateGuid()
        {
            GUID container = new GUID();
            Populate(ref container);
            return container;
        }


        private static int GetCount()
        {
            return Interlocked.Increment(ref counter);
        }

        private static byte[] nodeId = new byte[NODE_ID_SIZE + 2 + 2];
        private static int counter;
    }
}
