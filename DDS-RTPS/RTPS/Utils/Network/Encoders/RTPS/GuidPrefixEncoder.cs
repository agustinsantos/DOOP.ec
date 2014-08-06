using Mina.Core.Buffer;
using rtps.messages.elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.Network.Encoders
{
    public static class GuidPrefixEncoder
    {
        public static void PutGuidPrefix(this IoBuffer buffer, GuidPrefix obj)
        {
            buffer.Put(obj.Prefix);
        }

        public static GuidPrefix GetGuidPrefix(this IoBuffer buffer)
        {
            GuidPrefix obj = new GuidPrefix();
            buffer.GetGuidPrefix(ref obj);
            return obj;
        }

        public static void GetGuidPrefix(this IoBuffer buffer, ref GuidPrefix obj)
        {
            buffer.Get(obj.Prefix, 0, GuidPrefix.GUID_PREFIX_SIZE);
        }
    }
}
