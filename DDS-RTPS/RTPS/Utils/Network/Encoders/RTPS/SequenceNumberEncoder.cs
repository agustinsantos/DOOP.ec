using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.submessage.interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class SequenceNumberEncoder
    {
        public static void PutSequenceNumber(this IoBuffer buffer, SequenceNumber obj)
        {
            buffer.PutInt32(obj.High);
            buffer.PutInt32((int)obj.Low);
        }

        public static SequenceNumber GetSequenceNumber(this IoBuffer buffer)
        {
            SequenceNumber obj = new SequenceNumber();
            buffer.GetSequenceNumber(ref obj);
            return obj;
        }

        public static void GetSequenceNumber(this IoBuffer buffer, ref SequenceNumber obj)
        {
            obj.High = buffer.GetInt32();
            obj.Low = (uint)buffer.GetInt32(); ;
        }
    }
}
