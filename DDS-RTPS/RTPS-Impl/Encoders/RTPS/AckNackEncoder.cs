using Mina.Core.Buffer;
using Rtps.Messages.Submessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class AckNackEncoder
    {
        public static void PutAckNack(this IoBuffer buffer, AckNack obj)
        {
            buffer.PutEntityId(obj.ReaderId);
            buffer.PutEntityId(obj.WriterId);
            buffer.PutSequenceNumberSet(obj.ReaderSNState);
            buffer.PutInt32(obj.Count);
        }

        public static AckNack GetAckNack(this IoBuffer buffer)
        {
            AckNack obj = new AckNack();
            buffer.GetAckNack(ref obj);
            return obj;
        }

        public static void GetAckNack(this IoBuffer buffer, ref AckNack obj)
        {
            obj.ReaderId = buffer.GetEntityId();
            obj.WriterId = buffer.GetEntityId();
            obj.ReaderSNState = buffer.GetSequenceNumberSet();
            obj.Count = buffer.GetInt32();
        }
    }
}
