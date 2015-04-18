using Mina.Core.Buffer;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Submessages.Elements;
using System;
using Doopec.Utils.Network.Encoders;
using Doopec.Rtps.Messages;

namespace Doopec.Rtps.Encoders
{
    public static class DataSubMessageEncoder
    {
        public static void PutDataSubMessage(this IoBuffer buffer, Data obj)
        {
            buffer.PutInt16(obj.ExtraFlags.Value);
            short octetsToInlineQos = 0;
            if (obj.HasInlineQosFlag)
            {
                octetsToInlineQos = 4 + 4 + 8;// EntityId.LENGTH + EntityId.LENGTH + SequenceNumber.LENGTH;
            }
            buffer.PutInt16(octetsToInlineQos);
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumber(obj.WriterSN);
            if (obj.HasInlineQosFlag)
            {
                buffer.PutParameterList(obj.InlineQos);
            }

            if (obj.HasDataFlag || obj.HasKeyFlag)
            {
                buffer.Align(4);
                buffer.Put(obj.SerializedPayload.DataEncapsulation.SerializedPayload);
            }
        }

        public static Data GetDataSubMessage(this IoBuffer buffer)
        {
            Data obj = new Data();
            buffer.GetDataSubMessage(ref obj);
            return obj;
        }

        public static void GetDataSubMessage(this IoBuffer buffer, ref Data obj)
        {
            if (obj.HasDataFlag && obj.HasKeyFlag)
            {
                // Should we just ignore this message instead
                throw new ApplicationException(
                        "This version of protocol does not allow Data submessage to contain both serialized data and serialized key (9.4.5.3.1)");
            }

            int start_count = buffer.Position; // start of bytes Read so far from the
            // beginning
            Flags flgs = new Flags();
            flgs.Value = (byte)buffer.GetInt16();
            obj.ExtraFlags = flgs;
            int octetsToInlineQos = buffer.GetInt16() & 0xffff;

            int currentCount = buffer.Position; // count bytes to inline qos

            obj.ReaderId = buffer.GetEntityId();
            obj.WriterId = buffer.GetEntityId();
            obj.WriterSN = buffer.GetSequenceNumber();

            int bytesRead = buffer.Position - currentCount;
            int unknownOctets = octetsToInlineQos - bytesRead;

            for (int i = 0; i < unknownOctets; i++)
            {
                // TODO: Instead of looping, we should do just
                // newPos = bb.getBuffer.position() + unknownOctets or something
                // like that
                buffer.Get(); // Skip unknown octets, @see 9.4.5.3.3
                // octetsToInlineQos
            }

            if (obj.HasInlineQosFlag)
            {
                obj.InlineQos = buffer.GetParameterList();
            }

            if (obj.HasDataFlag || obj.HasKeyFlag)
            {
                buffer.Align(4); // Each submessage is aligned on 32-bit boundary, @see
                // 9.4.1 Overall Structure
                int end_count = buffer.Position; // end of bytes Read so far from the beginning
                int length;

                if (obj.Header.SubMessageLength != 0)
                {
                    length =  obj.Header.SubMessageLength - (end_count - start_count);
                }
                else
                { 
                    // SubMessage is the last one. Rest of the bytes are Read.
                    // @see 8.3.3.2.3
                    length =  buffer.Remaining;
                }
                obj.SerializedPayload = new SerializedPayload();
                obj.SerializedPayload.DataEncapsulation = EncapsulationManager.Deserialize(buffer, length);
            }


        }
    }
}
