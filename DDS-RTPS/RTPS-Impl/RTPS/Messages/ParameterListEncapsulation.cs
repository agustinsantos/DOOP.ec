using Doopec.Rtps.Encoders;
using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;

namespace Doopec.Rtps.Messages
{
    /// <summary>
    /// ParameterListEncapsulation is a specialization of DataEncapsulation.
    /// This encapsulation is used by discovery.
    /// </summary>
    public class ParameterListEncapsulation : DataEncapsulation
    {
        private ParameterList parameters;
        private byte[] data;
        private ByteOrder order;

        public ParameterListEncapsulation(IoBuffer buffer, object dataObj, ByteOrder order)
        {
            this.order = order;
            if (order == ByteOrder.LittleEndian)
                buffer.Put(PL_CDR_LE_HEADER);
            else
                buffer.Put(PL_CDR_BE_HEADER);
            buffer.Order = this.order;
            int initialPos = buffer.Position;
            buffer.PutParameterList(parameters);
            var serializedData = new byte[buffer.Position - initialPos];
            buffer.Get(serializedData, initialPos, serializedData.Length);
        }

        public ParameterListEncapsulation(ParameterList parameters, ByteOrder order)
        {
            this.parameters = parameters;
            this.order = order;
        }

        public ParameterList GetParameterList()
        {
            return parameters;
        }


        public override bool ContainsData()
        {
            return (data != null); // TODO: how do we represent key in serialized payload
        }

        public override byte[] SerializedPayload
        {
            get
            {
                return data;
            }
        }
    }
}
