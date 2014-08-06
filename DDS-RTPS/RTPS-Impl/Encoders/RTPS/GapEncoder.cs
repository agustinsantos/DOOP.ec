using Mina.Core.Buffer;
using Rtps.Messages.Submessages;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class GapEncoder
    {
        public static void PutGap(this IoBuffer buffer, Gap obj)
        {
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumber(obj.GapStart);
            buffer.PutSequenceNumberSet(obj.GapList);
        }

        public static Gap GetGap(this IoBuffer buffer)
        {
            Gap obj = new Gap();
            buffer.GetGap(ref obj);
            return obj;
        }

        public static void GetGap(this IoBuffer buffer, ref Gap obj)
        {
            obj.readerId = buffer.GetEntityId();
            obj.writerId = buffer.GetEntityId();
            obj.gapStart = buffer.GetSequenceNumber();
            obj.gapList = buffer.GetSequenceNumberSet();
        }
    }
}
