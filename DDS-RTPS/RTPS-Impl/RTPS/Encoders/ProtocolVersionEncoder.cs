using Mina.Core.Buffer;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Encoders
{
    public static class ProtocolVersionEncoder
    {
        public static void PutProtocolVersion(this IoBuffer buffer, ProtocolVersion obj)
        {
            buffer.Put(obj.Major);
            buffer.Put(obj.Minor);
        }

        public static ProtocolVersion GetProtocolVersion(this IoBuffer buffer)
        {
            ProtocolVersion obj = new ProtocolVersion();
            buffer.GetProtocolVersion(ref obj);
            return obj;
        }

        public static void GetProtocolVersion(this IoBuffer buffer, ref ProtocolVersion obj)
        {
            obj.Major = buffer.Get();
            obj.Minor = buffer.Get();
        }
    }
}
