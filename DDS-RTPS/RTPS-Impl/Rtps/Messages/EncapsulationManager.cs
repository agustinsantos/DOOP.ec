using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doopec.Rtps.Encoders;
using Doopec.Serializer.Attributes;

namespace Doopec.Rtps.Messages
{
    public class EncapsulationManager
    {
        public static DataEncapsulation Serialize<T>()
        {
            PacketAttribute packetAttr = PacketAttribute.GetAttribute(typeof(T));
            /*
             IoBuffer buffer, int length;
                  int pos = buffer.Position;
                  EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
                  buffer.Position = pos;
                  if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
                  {
                      return CDREncapsulation.Deserialize(buffer, length);
                  }
                  else if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
                  {
                      return ParameterListEncapsulation.Deserialize(buffer, length);
                  }
                  else
                      throw new ApplicationException("Unkonw scheme encapsulation " + scheme);
              */
            throw new NotImplementedException();
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
            else if (scheme.Equals(DataEncapsulation.CDR_BE_HEADER) || scheme.Equals(DataEncapsulation.CDR_LE_HEADER))
            {
                return ParameterListEncapsulation.Deserialize(buffer, length);
            }
            else
                throw new ApplicationException("Unkonw scheme encapsulation " + scheme);

        }
    }
}
