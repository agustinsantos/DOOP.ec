using Mina.Core.Buffer;
using Rtps.Messages;
using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System;

namespace Doopec.Rtps.Encoders
{
    public static class EncapsulationSchemeEncoder
    {
        public static void PutEncapsulationScheme(this IoBuffer buffer, EncapsulationScheme msg)
        {
            buffer.Put(msg.B0);
            buffer.Put(msg.B1);
            buffer.Put(msg.B2);
            buffer.Put(msg.B3);
        }

        public static EncapsulationScheme GetEncapsulationScheme(this IoBuffer buffer)
        {
            EncapsulationScheme obj = new EncapsulationScheme();
            obj.B0 = buffer.Get();
            obj.B1 = buffer.Get();
            obj.B2 = buffer.Get();
            obj.B3 = buffer.Get();
            return obj;
        }

        public static void GetEncapsulationScheme(this IoBuffer buffer, ref EncapsulationScheme obj)
        {
            obj.B0 = buffer.Get();
            obj.B1 = buffer.Get();
            obj.B2 = buffer.Get();
            obj.B3 = buffer.Get();
        }
    }
}
