using Mina.Core.Buffer;
using Rtps.Messages.Submessages;

namespace Doopec.Rtps.Encoders
{
    public static class InfoSourceEncoder
    {
        public static void PutInfoSource(this IoBuffer buffer, InfoSource obj)
        {
            buffer.PutInt64(0);
            buffer.PutProtocolVersion(obj.ProtocolVersion);
            buffer.PutVendorId(obj.VendorId);
            buffer.PutGuidPrefix(obj.GuidPrefix);
        }

        public static InfoSource GetInfoSource(this IoBuffer buffer)
        {
            InfoSource obj = new InfoSource();
            buffer.GetInfoSource(ref obj);
            return obj;
        }

        public static void GetInfoSource(this IoBuffer buffer, ref InfoSource obj)
        {
            buffer.GetInt64(); // unused

            obj.ProtocolVersion = buffer.GetProtocolVersion();
            obj.VendorId = buffer.GetVendorId();
            obj.GuidPrefix = buffer.GetGuidPrefix();
        }
    }
}
