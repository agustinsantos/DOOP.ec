using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;
using Doopec.Utils.Network.Encoders;

namespace Doopec.Rtps.Encoders
{
    public static class ParameterEncoder
    {
        public static void PutParameter(this IoBuffer buffer, Parameter obj)
        {
            buffer.PutInt16((short)obj.ParameterId);
            buffer.PutInt16(0); // length will be calculated

            int pos = buffer.Position;
            buffer.Put(obj.Bytes);

            buffer.Align(4); // Make sure length is multiple of 4 & align for
            // next param

            int paramLength = buffer.Position - pos;
            buffer.PutInt16(pos - 2, (short)paramLength);
        }

        public static Parameter GetParameter(this IoBuffer buffer)
        {
            Parameter obj = new Parameter();
            buffer.GetParameter(ref obj);
            return obj;
        }

        public static void GetParameter(this IoBuffer buffer, ref Parameter obj)
        {
            obj.ParameterId = (ParameterId)buffer.GetInt16();
            int length = buffer.GetInt16();
            obj.Bytes = new byte[length];
            buffer.Get(obj.Bytes, 0, length);
        }
    }
}
