
using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System;

namespace Doopec.Rtps.Messages
{
    /// <summary>
    /// CDREncapsulation is a general purpose binary DataEncapsulation. It holds a IoBuffer,
    /// which can be used by marshallers.
    /// </summary>
    public class CDREncapsulation : DataEncapsulation
    {
        private ByteOrder order;
        private byte[] data;

        public CDREncapsulation(IoBuffer buffer,  object dataObj, ByteOrder order)
        {
            this.order = order;
            buffer.Order = this.order;
            if (order == ByteOrder.LittleEndian)
                buffer.Put(CDR_LE_HEADER);
            else
                buffer.Put(CDR_BE_HEADER);
            int initialPos = buffer.Position;
            Doopec.Serializer.Serializer.Serialize(buffer, dataObj);
            var serializedData = new byte[buffer.Position-initialPos];
            buffer.Get(serializedData, initialPos, serializedData.Length);
            data = serializedData;
        }

        public CDREncapsulation(byte[] serializeData, ByteOrder order)
        {
            this.order = order;
            data = serializeData;
         }

        public override byte[] SerializedPayload
        {
            get
            {
                return data;
            }
        }

        /// <summary>
        /// Gets a IoBuffer, which can be used to marshall/unmarshall data.
        /// </summary>
        public IoBuffer Buffer
        {
            get
            {
                IoBuffer buff = IoBuffer.Allocate(data.Length + 4);
                buff.Order = this.order;
                if (order == ByteOrder.LittleEndian)
                    buff.Put(CDR_LE_HEADER);
                else
                    buff.Put(CDR_BE_HEADER);
                buff.Put(data);
                return buff;
            }
        }

        public override bool ContainsData()
        {
            return (data != null);
        }
    }
}
