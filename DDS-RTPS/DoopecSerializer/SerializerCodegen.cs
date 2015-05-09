using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Doopec.Serializer
{
    static class SerializerCodegen
    {
        public static DynamicMethod GenerateDynamicSerializerStub(Type type)
        {
            var dm = new DynamicMethod("Serialize", null,
                new Type[] { typeof(IoBuffer), type },
                typeof(Serializer), true);

            dm.DefineParameter(1, ParameterAttributes.None, "stream");
            dm.DefineParameter(2, ParameterAttributes.None, "value");

            return dm;
        }

#if GENERATE_DEBUGGING_ASSEMBLY
		public static MethodBuilder GenerateStaticSerializerStub(TypeBuilder tb, Type type)
		{
			var mb = tb.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Static, null, new Type[] { typeof(IoBuffer), type });
			mb.DefineParameter(1, ParameterAttributes.None, "stream");
			mb.DefineParameter(2, ParameterAttributes.None, "value");
			return mb;
		}
#endif

        public static void GenerateSerializerSwitch(CodeGenContext ctx, ILGenerator il, IDictionary<Type, TypeData> map)
        {
            // arg0: Stream, arg1: object

            var idLocal = il.DeclareLocal(typeof(ushort));

            // bool ilLocal2 = Helpers.HasSwitchTypeMethodInfo(obj);
            var idLocal2 = il.DeclareLocal(typeof(bool));
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Call, Helpers.HasSwitchTypeMethodInfo, null);
            il.Emit(OpCodes.Stloc_S, idLocal2);

            // get TypeID from object's Type
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Call, Helpers.GetTypeIDMethodInfo, null);
            il.Emit(OpCodes.Stloc_S, idLocal);

            var hasSwitchLabel = il.DefineLabel();

            // if (idLocal2.HasSwitch)
            il.Emit(OpCodes.Ldloc_S, idLocal2);
            il.Emit(OpCodes.Brfalse_S, hasSwitchLabel);

            // write typeID
            //il.Emit(OpCodes.)
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldloc_S, idLocal);
            il.EmitCall(OpCodes.Call, ctx.GetWriterMethodInfo(typeof(ushort)), null);

            il.MarkLabel(hasSwitchLabel);

            // +1 for 0 (null)
            var jumpTable = new Label[map.Count + 1];
            jumpTable[0] = il.DefineLabel();
            foreach (var kvp in map)
                jumpTable[kvp.Value.TypeID] = il.DefineLabel();

            il.Emit(OpCodes.Ldloc_S, idLocal);
            il.Emit(OpCodes.Switch, jumpTable);

            il.Emit(OpCodes.Newobj, Helpers.ExceptionCtorInfo);
            il.Emit(OpCodes.Throw);

            /* null case */
            il.MarkLabel(jumpTable[0]);
            il.Emit(OpCodes.Ret);

            /* cases for types */
            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var data = kvp.Value;

                il.MarkLabel(jumpTable[data.TypeID]);

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);

                il.EmitCall(OpCodes.Call, data.WriterMethodInfo, null);

                il.Emit(OpCodes.Ret);
            }
        }

        public static void GenerateSerializerSwitchTyped(CodeGenContext ctx, ILGenerator il, IDictionary<Type, TypeData> map)
        {
            // arg0: Stream, arg1: object, arg2: ushort

            var idLocal = il.DeclareLocal(typeof(ushort));

            // +1 for 0 (null)
            var jumpTable = new Label[map.Count + 1];
            jumpTable[0] = il.DefineLabel();
            foreach (var kvp in map)
                jumpTable[kvp.Value.TypeID] = il.DefineLabel();

            // get TypeID from object's Type
            il.Emit(OpCodes.Ldarg_2);
            il.Emit(OpCodes.Switch, jumpTable);

            il.Emit(OpCodes.Newobj, Helpers.ExceptionCtorInfo);
            il.Emit(OpCodes.Throw);

            /* null case */
            il.MarkLabel(jumpTable[0]);
            il.Emit(OpCodes.Ret);

            /* cases for types */
            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var data = kvp.Value;

                il.MarkLabel(jumpTable[data.TypeID]);

                il.Emit(OpCodes.Ldarg_0);
                il.Emit(OpCodes.Ldarg_1);
                il.Emit(type.IsValueType ? OpCodes.Unbox_Any : OpCodes.Castclass, type);

                il.EmitCall(OpCodes.Call, data.WriterTypedMethodInfo, null);

                il.Emit(OpCodes.Ret);
            }
        }
    }
}
