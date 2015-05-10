using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doopec.Rtps.Encoders;
using Doopec.Serializer.Attributes;
using Doopec.Encoders;

namespace Doopec.Rtps.Messages
{
    public class EncapsulationManager
    {
        public static DataEncapsulation Serialize<T>(T obj, Encapsulation scheme = Encapsulation.CDR_BE)
        {
            DataEncapsulation rst;

            if (scheme == Encapsulation.UNKNOWN)
            {
                PacketAttribute packetAttr = PacketAttribute.GetAttribute(typeof(T));
                if (packetAttr != null)
                    scheme = packetAttr.EncapsulationScheme;
            }
           
             IoBuffer buff = IoBuffer.Allocate(1024);
             buff.AutoExpand = true;
             switch (scheme)
             {
                 default:
                 case Encapsulation.CDR_BE:
                     rst = buff.EncapsuleCDRData(obj, ByteOrder.BigEndian);
                     break;
                 case Encapsulation.CDR_LE:
                     rst = buff.EncapsuleCDRData(obj, ByteOrder.LittleEndian);
                     break;
                 case Encapsulation.PL_CDR_BE:
                     rst = buff.EncapsuleParameterListData(obj, ByteOrder.BigEndian);
                     break;
                 case Encapsulation.PL_CDR_LE:
                     rst = buff.EncapsuleParameterListData(obj, ByteOrder.LittleEndian);
                     break;
             }
             return rst;
        }

        public static DataEncapsulation Deserialize(IoBuffer buffer, int length)
        {
            int pos = buffer.Position;
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            buffer.Position = pos;
            if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
            {
                return CDREncapsulation.Deserialize(buffer, length);
            }
            else if (scheme.Equals(DataEncapsulation.PL_CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.PL_CDR_LE_HEADER))
            {
                return ParameterListEncapsulation.Deserialize(buffer, length);
            }
            else
                throw new ApplicationException("Unkonw scheme encapsulation " + scheme);

        }

        public static T Deserialize<T>(IoBuffer buffer) where T : new()
        {
            int pos = buffer.Position;
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            buffer.Position = pos;
            if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
            {
                return CDREncapsulation.Deserialize<T>(buffer);
            }
            else if (scheme.Equals(DataEncapsulation.PL_CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.PL_CDR_LE_HEADER))
            {
                return ParameterListEncapsulation.Deserialize<T>(buffer);
            }
            else
                throw new ApplicationException("Unkonw scheme encapsulation " + scheme);

        }
    }
}
