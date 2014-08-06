
using RTPS.Utils;
using System;
using System.Text;
namespace Rtps.Messages.Types
{
    /// <summary>
    /// Enumeration used to identify the protocol.
    /// Protocol Identifier (constant at {'R','T','P','S'})
    /// </summary>
    public class ProtocolId
    {
        public const int PROTOID_SIZE = 4;
        public static readonly ProtocolId PROTOCOL_RTPS = new ProtocolId()
        {
            id = new byte[] {   Convert.ToByte('R'), 
                                Convert.ToByte('T'),
                                Convert.ToByte('P'), 
                                Convert.ToByte('S') }
        };

        protected byte[] id; //[4];

        public ProtocolId(byte[] id)
        {
            this.id = id;
        }

        public ProtocolId()
        {
            id = new byte[PROTOID_SIZE];
        }

        /// <summary>
        /// Returns the id.
        /// </summary>
        public byte[] Id
        {
            get
            {
                return id;
                //return Convert.ToInt32(this.id);
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
            ProtocolId other = (ProtocolId)obj;
            return comparer.Equals(this.id, other.id); ;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return comparer.GetHashCode(this.id);
        }

        public override string ToString()
        {
            if (this.id != null)
                return Encoding.ASCII.GetString(this.id);
            else
                return "(null)";
        }
    }
}
