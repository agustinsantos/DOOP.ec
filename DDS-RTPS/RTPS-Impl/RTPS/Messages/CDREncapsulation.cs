
using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System;
using Doopec.Rtps.Encoders;
using System.Diagnostics;

namespace Doopec.Rtps.Messages
{
    /// <summary>
    /// CDREncapsulation is a general purpose binary DataEncapsulation. It holds a IoBuffer,
    /// which can be used by marshallers.
    /// In addition to the encapsulation identifier, the OMG CDR encapsulation specifies the length of the data followed by the
    /// data encapsulated using CDR. The same encapsulation scheme is used for both the length and serialized data.
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |               CDR_BE          |         ushort options        |
    /// +---------------+---------------+---------------+---------------+
    /// |                   Data Length                                 |
    /// +---------------+---------------+---------------+---------------+
    /// ~               Serialized Data (CDR Big Endian)                ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// 
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |               CDR_LE          |           ushort options      |
    /// +---------------+---------------+---------------+---------------+
    /// |                   Data Length                                 |
    /// +---------------+---------------+---------------+---------------+
    /// ~               Serialized Data (CDR Little Endian)             ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// </summary>
    public class CDREncapsulation : DataEncapsulation
    {
        private ByteOrder order;
        private byte[] data;

        public CDREncapsulation()
        { }

        public CDREncapsulation(IoBuffer buffer, object dataObj, ByteOrder order)
        {
            int initialPos = buffer.Position;
            this.order = order;
            buffer.Order = this.order;
            if (order == ByteOrder.LittleEndian)
                buffer.PutEncapsulationScheme(CDR_LE_HEADER);
            else
                buffer.PutEncapsulationScheme(CDR_BE_HEADER);
            
            Doopec.Serializer.Serializer.Serialize(buffer, dataObj);
            var serializedData = new byte[buffer.Position - initialPos];
            buffer.Position = initialPos;
            buffer.Get(serializedData, 0, serializedData.Length);
            data = serializedData;
        }

        public static void Serialize(IoBuffer buffer, object dataObj, ByteOrder order)
        {
            buffer.Order = order;
            if (order == ByteOrder.LittleEndian)
                buffer.PutEncapsulationScheme(CDR_LE_HEADER);
            else
                buffer.PutEncapsulationScheme(CDR_BE_HEADER);
            int initialPos = buffer.Position;
            buffer.Position += 4;
            Doopec.Serializer.Serializer.Serialize(buffer, dataObj);
            int finalPos = buffer.Position;
            buffer.Position = initialPos;
            buffer.PutInt32(finalPos - initialPos - 4);
            buffer.Position = finalPos;
        }
        public static T Deserialize<T>(IoBuffer buffer)
        {
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER))
            {
                buffer.Order = ByteOrder.BigEndian;
            }
            else if (scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
            {
                buffer.Order = ByteOrder.LittleEndian;
            }
            else
            {
                throw new NotImplementedException();
            }
            int length = buffer.GetInt32();
            int initialPos = buffer.Position;
            T rst = Doopec.Serializer.Serializer.Deserialize<T>(buffer);
            Debug.Assert(buffer.Position == initialPos + length);
            return rst;
        }

        public static CDREncapsulation Deserialize(IoBuffer buffer, int length)
        {
            int initialPos = buffer.Position;
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            ByteOrder order;
            if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER))
            {
                order = buffer.Order = ByteOrder.BigEndian;

            }
            else if (scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
            {
                order = buffer.Order = ByteOrder.LittleEndian;
            }
            else
            {
                throw new NotImplementedException();
            }
            byte[] data = new byte[length-4];
            buffer.Get(data, 0, length-4);
            Debug.Assert(buffer.Position == initialPos + length);
            CDREncapsulation rst = new CDREncapsulation(data, order);
            return rst;
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
                    buff.PutEncapsulationScheme(CDR_LE_HEADER);
                else
                    buff.PutEncapsulationScheme(CDR_BE_HEADER);
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
