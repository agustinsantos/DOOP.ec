using Doopec.Rtps.Messages;
using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Doopec.Encoders
{
    public static class DataEncoder
    {
        /// <summary>
        /// Creates an instance of DataEncapsulation.
        /// </summary>
        /// <param name="serializedPayload"></param>
        /// <returns></returns>
        public static DataEncapsulation EncapsuleCDRData(this byte[] serializedPayload, ByteOrder order)
        {
            return new CDREncapsulation(serializedPayload, order);
        }

        public static DataEncapsulation EncapsuleParameterListData(this ParameterList parameters, ByteOrder order)
        {
            return new ParameterListEncapsulation(parameters, order);
        }

        public static DataEncapsulation EncapsuleCDRData(this IoBuffer buffer, object dataObj, ByteOrder order)
        {
            return new CDREncapsulation(buffer, dataObj, order);
        }


        public static DataEncapsulation EncapsuleParameterListData(this IoBuffer buffer, object dataObj, ByteOrder order)
        {
            return new ParameterListEncapsulation(buffer, dataObj, order);
        }

        public static IEnumerable<FieldInfo> GetFieldInfos(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(fi => (fi.Attributes & FieldAttributes.NotSerialized) == 0)
                .OrderBy(f => f.Name, StringComparer.Ordinal);

            if (type.BaseType == null)
            {
                return fields;
            }
            else
            {
                var baseFields = GetFieldInfos(type.BaseType);
                return baseFields.Concat(fields);
            }
        }
    }
}
