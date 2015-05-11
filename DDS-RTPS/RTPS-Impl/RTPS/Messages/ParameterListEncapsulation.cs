﻿using Doopec.Rtps.Encoders;
using Mina.Core.Buffer;
using Rtps.Messages.Submessages.Elements;
using System.Reflection;
using System;
using System.Linq;
using org.omg.dds.type;
using Rtps.Messages.Types;
using System.Diagnostics;
using Doopec.XTypes;
using org.omg.dds.type.typeobject;

namespace Doopec.Rtps.Messages
{
    /// <summary>
    /// ParameterListEncapsulation is a specialization of DataEncapsulation.
    /// In addition to the encapsulation identifier, the ParameterList encapsulation specifies the length of the data followed by the
    /// data encapsulated using a ParameterList. The same CDR encoding is used for both the length and the parameter list.
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |             PL_CDR_BE         |         ushort options        |
    /// +---------------+---------------+---------------+---------------+
    /// |                                                               |
    /// ~        Serialized Data (ParameterList CDR Big Endian)         ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// 0...2...........8...............16..............24..............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |             PL_CDR_LE         |         ushort options        |
    /// +---------------+---------------+---------------+---------------+
    /// |                                                               |
    /// ~        Serialized Data (ParameterList CDR Little Endian)      ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+  
    /// 
    /// And Serialized Data is:
    /// ....2...........8...............16.............24...............32
    /// +-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
    /// |       short parameterId_1     |       short length_1          |
    /// +---------------+---------------+---------------+---------------+
    /// |                                                               |
    /// ~                     octet[length_1] value_1                   ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// |       short parameterId_2     |      short length_2           |
    /// +---------------+---------------+---------------+---------------+
    /// |                                                               |
    /// ~                     octet[length_2] value_2                   ~
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// |                                                               |
    /// ~                            ...                                ~
    /// |                                                               |
    /// |                                                               |
    /// +---------------+---------------+---------------+---------------+
    /// |          PID_SENTINEL         |           ignored             |
    /// +---------------+---------------+---------------+---------------+
    /// 
    /// This encapsulation is used by IsDiscovery.
    /// </summary>
    public class ParameterListEncapsulation : DataEncapsulation
    {
        private ParameterList parameters;
        private byte[] data;
        private ByteOrder order;

        public ParameterListEncapsulation(IoBuffer buffer, object dataObj, ByteOrder order)
        {
            int initialPos = buffer.Position;
            this.order = order;
            if (order == ByteOrder.LittleEndian)
                buffer.PutEncapsulationScheme(PL_CDR_LE_HEADER);
            else
                buffer.PutEncapsulationScheme(PL_CDR_BE_HEADER);
            buffer.Order = this.order;
            ParameterList parameters = BuildParameters(dataObj, order);
            buffer.PutParameterList(parameters);
            data = new byte[buffer.Position - initialPos];
            buffer.Position = initialPos;
            buffer.Get(data, 0, data.Length);
        }

        internal ParameterListEncapsulation(IoBuffer buffer, ByteOrder order, int length)
        {
            this.order = order;
            this.data = new byte[length];
            buffer.Get(data, 0, data.Length);
        }

        public static void Serialize(IoBuffer buffer, object dataObj, ByteOrder order)
        {
            buffer.Order = order;
            ParameterList parameters = BuildParameters(dataObj, order);
            Serialize(buffer, parameters, order);
        }
        public static void Serialize(IoBuffer buffer, ParameterList parameters, ByteOrder order)
        {
            if (order == ByteOrder.LittleEndian)
                buffer.PutEncapsulationScheme(PL_CDR_LE_HEADER);
            else
                buffer.PutEncapsulationScheme(PL_CDR_BE_HEADER);
            buffer.Order = order;
            int initialPos = buffer.Position;
            buffer.Position += 4;
            buffer.PutParameterList(parameters);
            int finalPos = buffer.Position;
            buffer.Position = initialPos;
            buffer.PutInt32(finalPos - initialPos - 4);
            buffer.Position = finalPos;
        }

        private static ParameterList BuildParameters(object obj, ByteOrder order)
        {
            var type = TypeExplorer.ExploreType(obj.GetType());
            //var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            //                   .Where(fi => (fi.Attributes & FieldAttributes.NotSerialized) == 0);
            StructureType structType = type as StructureType;
            ParameterList parameters = new ParameterList();
            foreach (var member in structType.GetMember())
            {
                Parameter parameter = new Parameter();
                //uint id = field.GetProperty().MemberId;
                parameter.ParameterId = (ParameterId)member.GetProperty().MemberId; ;
                IoBuffer buffer = ByteBufferAllocator.Instance.Allocate(64);
                buffer.Order = order;
                buffer.AutoExpand = true;
                if (member.GetProperty().IsProperty)
                {
                    var field = obj.GetType().GetProperty(member.GetProperty().Name);
                    object data = field.GetValue(obj);
                    if (data == null)
                        continue;
                    Doopec.Serializer.Serializer.Serialize(buffer, data);
                }
                else
                {
                    var field = obj.GetType().GetField(member.GetProperty().Name);
                    Doopec.Serializer.Serializer.Serialize(buffer, field.GetValue(obj));
                }

                int length = buffer.Position;
                parameter.Bytes = new byte[length];
                buffer.Rewind();
                buffer.Get(parameter.Bytes, 0, length);
                parameters.Value.Add(parameter);
            }
            return parameters;
        }
        public static T Deserialize<T>(IoBuffer buffer) where T : new()
        {
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            if (scheme.Equals(DataEncapsulation.PL_CDR_BE_HEADER))
            {
                buffer.Order = ByteOrder.BigEndian;
            }
            else if (scheme.Equals(DataEncapsulation.PL_CDR_LE_HEADER))
            {
                buffer.Order = ByteOrder.LittleEndian;
            }
            else
            {
                throw new NotImplementedException();
            }
            int initialPos = buffer.Position;
            ParameterList parameters = buffer.GetParameterList();
            return BuildObject<T>(parameters, buffer.Order);
        }

        public static ParameterListEncapsulation Deserialize(IoBuffer buffer, int length)
        {
            int initialPos = buffer.Position;
            EncapsulationScheme scheme = buffer.GetEncapsulationScheme();
            if (scheme.Equals(DataEncapsulation.PL_CDR_BE_HEADER))
            {
                buffer.Order = ByteOrder.BigEndian;
            }
            else if (scheme.Equals(DataEncapsulation.PL_CDR_LE_HEADER))
            {
                buffer.Order = ByteOrder.LittleEndian;
            }
            else
            {
                throw new NotImplementedException();
            }
            buffer.Position = initialPos;
            return new ParameterListEncapsulation(buffer, buffer.Order, length);
        }

        private static T BuildObject<T>(ParameterList parameters, ByteOrder order) where T : new()
        {
            T obj = new T();
            var fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                               .Where(fi => (fi.Attributes & FieldAttributes.NotSerialized) == 0);
            int cnt = 0;
            foreach (var field in fields)
            {
                IoBuffer buffer = IoBuffer.Wrap(parameters.Value[cnt].Bytes);
                buffer.Order = order;
                MethodInfo method = typeof(Doopec.Serializer.Serializer).GetMethods().Where(x => x.Name == "Deserialize" && x.IsGenericMethod).SingleOrDefault(); ;
                //MethodInfo method = typeof(Doopec.Serializer.Serializer).GetMethod("Deserialize", new Type[] { buffer.GetType() });
                MethodInfo generic = method.MakeGenericMethod(field.FieldType);
                object val = generic.Invoke(null, new object[] { buffer });
                field.SetValue(obj, val);
            }
            return obj;
        }

        public ParameterListEncapsulation(ParameterList parameters, ByteOrder order)
        {
            this.parameters = parameters;
            this.order = order;
        }

        public ParameterList GetParameterList()
        {
            return parameters;
        }


        public override bool ContainsData()
        {
            return (data != null); // TODO: how do we represent key in serialized payload
        }

        public override byte[] SerializedPayload
        {
            get
            {
                return data;
            }
        }
    }
}
