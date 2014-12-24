using Mina.Core.Buffer;
using Rtps.Messages.Submessages;
using System;


namespace Doopec.Rtps.Encoders
{
    public static class DataFragEncoder
    {
        public static void PutDataFrag(this IoBuffer buffer, DataFrag obj)
        {
            buffer.PutInt16(obj.ExtraFlags);

            short octets_to_inline_qos = 4 + 4 + 8 + 4 + 2 + 2 + 4;
            buffer.PutInt16(octets_to_inline_qos);

            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumber(obj.WriterSequenceNumber);

            buffer.PutInt32(obj.FragmentStartingNumber);
            buffer.PutInt16((short)obj.FragmentsInSubmessage);
            buffer.PutInt16((short)obj.FragmentSize);
            buffer.PutInt32(obj.SampleSize);

            if (obj.HasInlineQosFlag)
            {
                buffer.PutParameterList(obj.ParameterList);
            }

            buffer.Put(obj.SerializedPayload); // TODO: check this
        }

        public static DataFrag GetDataFrag(this IoBuffer buffer)
        {
            DataFrag obj = new DataFrag();
            buffer.GetDataFrag(ref obj);
            return obj;
        }

        public static void GetDataFrag(this IoBuffer buffer, ref DataFrag obj)
        {
            int start_count = buffer.Position; // start of bytes Read so far from the
            // beginning

            obj.ExtraFlags = (short)buffer.GetInt16();
            int octetsToInlineQos = buffer.GetInt16() & 0xffff;

            int currentCount = buffer.Position; // count bytes to inline qos

            obj.ReaderId = buffer.GetEntityId();
            obj.WriterId = buffer.GetEntityId();
            obj.WriterSequenceNumber = buffer.GetSequenceNumber();

            obj.FragmentStartingNumber = buffer.GetInt32(); // ulong
            obj.FragmentsInSubmessage = buffer.GetInt16(); // ushort
            obj.FragmentSize = buffer.GetInt16(); // ushort
            obj.SampleSize = buffer.GetInt32(); // ulong

            int bytesRead = buffer.Position - currentCount;
            int unknownOctets = octetsToInlineQos - bytesRead;

            for (int i = 0; i < unknownOctets; i++)
            {
                buffer.Get(); // Skip unknown octets, @see 9.4.5.3.3 octetsToInlineQos
            }

            if (obj.HasInlineQosFlag)
            {
                obj.ParameterList = buffer.GetParameterList();
            }

            int end_count = buffer.Position; // end of bytes Read so far from the beginning
            if (obj.Header.SubMessageLength != 0)
            {
                obj.SerializedPayload = new byte[obj.Header.SubMessageLength - (end_count - start_count)];
            }
            else
            { // SubMessage is the last one. Rest of the bytes are Read.
                // @see 8.3.3.2.3
                obj.SerializedPayload = new byte[buffer.Remaining];
            }

            buffer.Get(obj.SerializedPayload, 0, obj.SerializedPayload.Length);
        }
    }
}
