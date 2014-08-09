using Mina.Core.Buffer;
using Rtps.Messages.Submessages;

namespace Doopec.Rtps.Encoders
{
    public static class InfoDestinationEncoder
    {
        public static void PutInfoDestination(this IoBuffer buffer, InfoDestination msg)
        {
            buffer.PutGuidPrefix(msg.GuidPrefix);
        }

        public static InfoDestination GetInfoDestination(this IoBuffer buffer)
        {
            InfoDestination obj = new InfoDestination();
            buffer.GetInfoDestination(ref obj);
            return obj;
        }

        public static void GetInfoDestination(this IoBuffer buffer, ref InfoDestination obj)
        {
            obj.GuidPrefix = buffer.GetGuidPrefix();
        }
    }
}
