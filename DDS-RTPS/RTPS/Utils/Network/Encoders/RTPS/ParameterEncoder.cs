using Mina.Core.Buffer;
using rtps.messages.elements;
using rtps.messages.submessage.attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class ParameterEncoder
    {
        public static void PutParameter(this IoBuffer buffer, Parameter obj)
        {
            buffer.PutInt16((short)obj.ParameterId);
            buffer.Put(obj.Bytes);
        }

        public static Parameter GetParameter(this IoBuffer buffer)
        {
            Parameter obj = new Parameter();
            buffer.GetParameter(ref obj);
            return obj;
        }

        public static void GetParameter(this IoBuffer buffer, ref Parameter obj)
        {
            obj.ParameterId = (ParameterId )buffer.GetInt16();
            //obj.Bytes = (EntityKinds)buffer.Get();
        }
    }
}
