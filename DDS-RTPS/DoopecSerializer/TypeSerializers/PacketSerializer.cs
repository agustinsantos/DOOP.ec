using Doopec.Serializer.Attributes;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Doopec.Serializer.TypeSerializers
{
    public class PacketSerializer : IDynamicTypeSerializer
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool Handles(Type type)
        {
#if TODO
            bool packetCompatible = PacketAttribute.IsCompatible(type);

            if (!packetCompatible)
                log.WarnFormat("Type {0} is not marked with Packet attribute", type.FullName);
#endif
            return true;
        }

        public IEnumerable<Type> GetSubtypes(Type type)
        {
            var fields = Helpers.GetFieldInfos(type);

            foreach (var field in fields)
                yield return field.FieldType;
        }

        public void GenerateWriterMethod(Type type, CodeGenContext ctx, ILGenerator il)
        {
            // arg0: buffer, arg1: value

            var fields = Helpers.GetFieldInfos(type);

            foreach (var field in fields)
            {
                // Note: the user defined value type is not passed as reference. could cause perf problems with big structs

                il.Emit(OpCodes.Ldarg_0);
                if (type.IsValueType)
                    il.Emit(OpCodes.Ldarga_S, 1);
                else
                    il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldfld, field);

                Helpers.GenSerializerCall(ctx, il, field.FieldType);
            }

            il.Emit(OpCodes.Ret);
        }

        public void GenerateReaderMethod(Type type, CodeGenContext ctx, ILGenerator il)
        {
            // arg0: buffer, arg1: out value

            if (type.IsClass)
            {
                // instantiate empty class
                il.Emit(OpCodes.Ldarg_1);

                var gtfh = typeof(Type).GetMethod("GetTypeFromHandle", BindingFlags.Public | BindingFlags.Static);
                var guo = typeof(System.Runtime.Serialization.FormatterServices).GetMethod("GetUninitializedObject", BindingFlags.Public | BindingFlags.Static);
                il.Emit(OpCodes.Ldtoken, type);
                il.Emit(OpCodes.Call, gtfh);
                il.Emit(OpCodes.Call, guo);
                il.Emit(OpCodes.Castclass, type);

                il.Emit(OpCodes.Stind_Ref);
            }

            var fields = Helpers.GetFieldInfos(type);

            foreach (var field in fields)
            {
                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                if (type.IsClass)
                    il.Emit(OpCodes.Ldind_Ref);
                il.Emit(OpCodes.Ldflda, field);

                Helpers.GenDeserializerCall(ctx, il, field.FieldType);
            }

            if (typeof(System.Runtime.Serialization.IDeserializationCallback).IsAssignableFrom(type))
            {
                var miOnDeserialization = typeof(System.Runtime.Serialization.IDeserializationCallback).GetMethod("OnDeserialization",
                                        BindingFlags.Instance | BindingFlags.Public,
                                        null, new[] { typeof(Object) }, null);

                il.Emit(OpCodes.Ldarg_1);
                il.Emit(OpCodes.Ldnull);
                il.Emit(OpCodes.Constrained, type);
                il.Emit(OpCodes.Callvirt, miOnDeserialization);
            }

            il.Emit(OpCodes.Ret);
        }


        public bool HasSwitch
        {
            get { return false; }
        }
    }
}
