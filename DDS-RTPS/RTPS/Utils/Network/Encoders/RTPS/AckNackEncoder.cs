using Mina.Core.Buffer;
using rtps.messages.submessage.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders.RTPS
{
    public static class AckNackEncoder
    {
        public static void PutAckNack(this IoBuffer buffer, AckNack obj)
        {
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumberSet(obj.readerSNState);
            buffer.PutInt32(obj.count);
        }

        public static AckNack GetAckNack(this IoBuffer buffer)
        {
            AckNack obj = new AckNack();
            buffer.GetAckNack(ref obj);
            return obj;
        }

        public static void GetAckNack(this IoBuffer buffer, ref AckNack obj)
        {
            obj.readerId = buffer.GetEntityId();
            obj.writerId = buffer.GetEntityId();
            obj.readerSNState = buffer.GetSequenceNumberSet();
            obj.count = buffer.GetInt32();
        }
    }
}
