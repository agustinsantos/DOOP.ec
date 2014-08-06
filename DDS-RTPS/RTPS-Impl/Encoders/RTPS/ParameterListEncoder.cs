using log4net;
using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;
using Doopec.Encoders.RTPS;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class ParameterListEncoder
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void PutParameterList(this IoBuffer buffer, ParameterList obj)
        {
            buffer.Align(4); // @see 9.4.2.11

            obj.Value.Add(new Sentinel()); // Sentinel must be the last Parameter
            foreach (Parameter param in obj.Value)
            {
                buffer.PutInt16((short)param.ParameterId);
                buffer.PutInt16(0); // length will be calculated

                int pos = buffer.Position;
                buffer.PutParameter(param);

                buffer.Align(4); // Make sure length is multiple of 4 & align for
                // next param

                int paramLength = buffer.Position - pos;
                buffer.PutInt16(pos - 2, (short)paramLength);
            }

            // TODO: last Parameter must be PID_SENTINEL
        }

        public static ParameterList GetParameterList(this IoBuffer buffer)
        {
            ParameterList obj = new ParameterList();
            buffer.GetParameterList(ref obj);
            return obj;
        }

        public static void GetParameterList(this IoBuffer buffer, ref ParameterList obj)
        {
            log.Debug("Reading ParameterList from buffer");

            while (true)
            {
                int pos1 = buffer.Position;

                Parameter param = buffer.GetParameter();
                obj.Value.Add(param);
                int length = buffer.Position - pos1;

                log.DebugFormat("Read Parameter {0}, length {1} from position {2}", param, length, pos1);

                if (param.ParameterId == ParameterId.PID_SENTINEL)
                {
                    break;
                }
            }
        }
    }
}
