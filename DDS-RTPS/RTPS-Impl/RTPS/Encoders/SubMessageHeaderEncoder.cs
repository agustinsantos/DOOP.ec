using Mina.Core.Buffer;
using Rtps.Messages;
using Rtps.Messages.Types;

namespace Doopec.Rtps.Encoders
{
    public static class SubMessageHeaderEncoder
    {
        public static void PutSubMessageHeader(this IoBuffer buffer, SubMessageHeader obj)
        {
            buffer.Put((byte)obj.SubMessageKind);
            buffer.Put((byte)obj.FlagsValue);
            buffer.PutInt16((short)obj.SubMessageLength);
        }

        public static SubMessageHeader GetSubMessageHeader(this IoBuffer buffer)
        {
            SubMessageHeader obj = new SubMessageHeader((SubMessageKind)0, 0);
            buffer.GetSubMessageHeader(ref obj);
            return obj;
        }

        public static void GetSubMessageHeader(this IoBuffer buffer, ref SubMessageHeader obj)
        {
            obj.SubMessageKind = (SubMessageKind)buffer.Get();
            obj.FlagsValue = buffer.Get();
            buffer.Order = (obj.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian); // Set the endianess
            obj.SubMessageLength = (ushort)buffer.GetInt16();
        }
    }
}
