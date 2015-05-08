using Doopec.Serializer.TypeSerializers;
using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Serializer
{
    public static partial class Serializer
    {
        static Dictionary<Type, ushort> s_typeIDMap;
        static Dictionary<Type, TypeData> typeDataMap;

        delegate void SerializerSwitch(IoBuffer buffer, object ob);
        delegate void DeserializerSwitch(IoBuffer buffer, out object ob);
        delegate void DeserializerSwitchTyped(IoBuffer buffer, out object o, ushort typeId);

        static SerializerSwitch s_serializerSwitch;
        static DeserializerSwitch s_deserializerSwitch;
        static DeserializerSwitchTyped s_deserializerSwitchTyped;

        static ITypeSerializer[] s_typeSerializers = new ITypeSerializer[] {
            new PrimitivesSerializer(),
   //         new CDRSequenceSerializer(),
            new ArraySerializer(),
            new EnumSerializer(),
            new DictionarySerializer(),
            new ListSerializer(),
            new PacketSerializer(),
            new GenericSerializer(),
		};

        static ITypeSerializer[] s_userTypeSerializers;

        public static bool IsInitialized { get; private set; }

        /// <summary>
        /// Initialize Serializer
        /// </summary>
        /// <param name="rootTypes">Types to be (de)serialized</param>
        public static void Initialize(IEnumerable<Type> rootTypes)
        {
            Initialize(rootTypes, new ITypeSerializer[0]);
        }

        public static void Initialize(Type rootType)
        {
            if (IsInitialized && typeDataMap.ContainsKey(rootType))
                return;

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];
            Doopec.Serializer.Serializer.Initialize(new Type[] { rootType }, customSerializers);
        }

        /// <summary>
        /// Initialize Serializer
        /// </summary>
        /// <param name="rootTypes">Types to be (de)serialized</param>
        /// <param name="userTypeSerializers">Array of custom serializers</param>
        public static void Initialize(IEnumerable<Type> rootTypes, ITypeSerializer[] userTypeSerializers)
        {
            if (userTypeSerializers.All(s => s is IDynamicTypeSerializer || s is IStaticTypeSerializer) == false)
                throw new ArgumentException("TypeSerializers have to implement IDynamicTypeSerializer or  IStaticTypeSerializer");

            s_userTypeSerializers = userTypeSerializers;

            typeDataMap = GenerateTypeData(rootTypes);

            GenerateDynamic(typeDataMap);

            s_typeIDMap = typeDataMap.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.TypeID);

#if GENERATE_DEBUGGING_ASSEMBLY
            // Note: GenerateDebugAssembly overwrites some fields from typeDataMap
            GenerateDebugAssembly(typeDataMap);
#endif
            IsInitialized = true;
        }

        public static void Serialize<T>(IoBuffer buffer, object data)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Serializer not initialized");

            Serialize(buffer, data);
        }

        public static void Serialize(IoBuffer buffer, object data)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Serializer not initialized");

            s_serializerSwitch(buffer, data);
        }

        public static T Deserialize<T>(IoBuffer buffer)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Serializer not initialized");

            ushort id = GetTypeID(typeof(T));
            object o;
            s_deserializerSwitchTyped(buffer, out o, id);
            return (T)o;
        }

        public static object Deserialize(IoBuffer buffer)
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Serializer not initialized");

            object o;
            s_deserializerSwitch(buffer, out o);
            return o;
        }

        internal static void SerializeInternal(IoBuffer buffer, object data)
        {
            s_serializerSwitch(buffer, data);
        }

        internal static object DeserializeInternal(IoBuffer buffer)
        {
            object o;
            s_deserializerSwitch(buffer, out o);
            return o;
        }

        static Dictionary<Type, TypeData> GenerateTypeData(IEnumerable<Type> rootTypes)
        {

            Dictionary<Type, TypeData> map;
            Stack<Type> stack;

            if (typeDataMap != null)
            {
                map = typeDataMap;
                stack = new Stack<Type>(rootTypes);
            }
            else
            {
                map = new Dictionary<Type, TypeData>();
                stack = new Stack<Type>(PrimitivesSerializer.GetSupportedTypes().Concat(rootTypes));
            }

            // TypeID 0 is reserved for null
            ushort typeID = (ushort)(map.Count + 1);

            while (stack.Count > 0)
            {
                var type = stack.Pop();

                if (map.ContainsKey(type))
                    continue;

                if (type.IsAbstract || type.IsInterface)
                    continue;

                if (type.ContainsGenericParameters)
                    throw new NotSupportedException(String.Format("Type {0} contains generic parameters", type.FullName));

                var serializer = s_userTypeSerializers.FirstOrDefault(h => h.Handles(type));

                if (serializer == null)
                    serializer = s_typeSerializers.FirstOrDefault(h => h.Handles(type));

                if (serializer == null)
                    throw new NotSupportedException(String.Format("No serializer for {0}", type.FullName));

                foreach (var t in serializer.GetSubtypes(type))
                    stack.Push(t);

                TypeData typeData;

                if (serializer is IStaticTypeSerializer)
                {
                    var sts = (IStaticTypeSerializer)serializer;

                    MethodInfo writer;
                    MethodInfo reader;

                    sts.GetStaticMethods(type, out writer, out reader);

                    Debug.Assert(writer != null && reader != null);

                    typeData = new TypeData(typeID++, writer, reader);

                }
                else if (serializer is IDynamicTypeSerializer)
                {
                    var dts = (IDynamicTypeSerializer)serializer;

                    typeData = new TypeData(typeID++, dts);
                }
                else
                {
                    throw new Exception();
                }

                map[type] = typeData;
            }

            return map;
        }

        static void GenerateDynamic(Dictionary<Type, TypeData> map)
        {
            /* generate stubs */
            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var td = kvp.Value;

                if (!td.IsGenerated)
                    continue;

                var writerDm = SerializerCodegen.GenerateDynamicSerializerStub(type);
                td.WriterMethodInfo = writerDm;
                td.WriterILGen = writerDm.GetILGenerator();

                var readerDm = DeserializerCodegen.GenerateDynamicDeserializerStub(type);
                td.ReaderMethodInfo = readerDm;
                td.ReaderILGen = readerDm.GetILGenerator();
            }

            var serializerSwitchMethod = new DynamicMethod("SerializerSwitch", null,
                new Type[] { typeof(IoBuffer), typeof(object) },
                typeof(Serializer), true);
            serializerSwitchMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            serializerSwitchMethod.DefineParameter(2, ParameterAttributes.None, "value");
            var serializerSwitchMethodInfo = serializerSwitchMethod;

            var deserializerSwitchMethod = new DynamicMethod("DeserializerSwitch", null,
                new Type[] { typeof(IoBuffer), typeof(object).MakeByRefType() },
                typeof(Serializer), true);
            deserializerSwitchMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            deserializerSwitchMethod.DefineParameter(2, ParameterAttributes.Out, "value");
            var deserializerSwitchMethodInfo = deserializerSwitchMethod;

            var deserializerSwitchTypedMethod = new DynamicMethod("DeserializerSwitchTyped", null,
                new Type[] { typeof(IoBuffer), typeof(object).MakeByRefType(), typeof(ushort) },
                typeof(Serializer), true);
            deserializerSwitchTypedMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            deserializerSwitchTypedMethod.DefineParameter(2, ParameterAttributes.Out, "value");
            deserializerSwitchTypedMethod.DefineParameter(3, ParameterAttributes.None, "typeId");
            var deserializerSwitchTypedMethodInfo = deserializerSwitchTypedMethod;


            var ctx = new CodeGenContext(map, serializerSwitchMethodInfo, deserializerSwitchMethodInfo);

            /* generate bodies */

            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var td = kvp.Value;

                if (!td.IsGenerated)
                    continue;

                td.TypeSerializer.GenerateWriterMethod(type, ctx, td.WriterILGen);
                td.TypeSerializer.GenerateReaderMethod(type, ctx, td.ReaderILGen);
            }

            var ilGen = serializerSwitchMethod.GetILGenerator();
            SerializerCodegen.GenerateSerializerSwitch(ctx, ilGen, map);
            s_serializerSwitch = (SerializerSwitch)serializerSwitchMethod.CreateDelegate(typeof(SerializerSwitch));

            ilGen = deserializerSwitchMethod.GetILGenerator();
            DeserializerCodegen.GenerateDeserializerSwitch(ctx, ilGen, map);
            s_deserializerSwitch = (DeserializerSwitch)deserializerSwitchMethod.CreateDelegate(typeof(DeserializerSwitch));

            ilGen = deserializerSwitchTypedMethod.GetILGenerator();
            DeserializerCodegen.GenerateDeserializerSwitchTyped(ctx, ilGen, map);
            s_deserializerSwitchTyped = (DeserializerSwitchTyped)deserializerSwitchTypedMethod.CreateDelegate(typeof(DeserializerSwitchTyped));
        }

#if GENERATE_DEBUGGING_ASSEMBLY
        static void GenerateDebugAssembly(Dictionary<Type, TypeData> map)
        {
            var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("SerializerDebug"), AssemblyBuilderAccess.RunAndSave);
            var modb = ab.DefineDynamicModule("SerializerDebug.dll");
            var tb = modb.DefineType("Serializer", TypeAttributes.Public);

            /* generate stubs */
            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var td = kvp.Value;

                if (!td.IsGenerated)
                    continue;

                var mb = SerializerCodegen.GenerateStaticSerializerStub(tb, type);
                td.WriterMethodInfo = mb;
                td.WriterILGen = mb.GetILGenerator();

                var dm = DeserializerCodegen.GenerateStaticDeserializerStub(tb, type);
                td.ReaderMethodInfo = dm;
                td.ReaderILGen = dm.GetILGenerator();
            }

            var serializerSwitchMethod = tb.DefineMethod("SerializerSwitch", MethodAttributes.Public | MethodAttributes.Static, null, new Type[] { typeof(IoBuffer), typeof(object) });
            serializerSwitchMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            serializerSwitchMethod.DefineParameter(2, ParameterAttributes.None, "value");
            var serializerSwitchMethodInfo = serializerSwitchMethod;

            var deserializerSwitchMethod = tb.DefineMethod("DeserializerSwitch", MethodAttributes.Public | MethodAttributes.Static, null, new Type[] { typeof(IoBuffer), typeof(object).MakeByRefType() });
            deserializerSwitchMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            deserializerSwitchMethod.DefineParameter(2, ParameterAttributes.Out, "value");
            var deserializerSwitchMethodInfo = deserializerSwitchMethod;

            var deserializerSwitchTypedMethod = tb.DefineMethod("DeserializerSwitchTyped", MethodAttributes.Public | MethodAttributes.Static, null, new Type[] { typeof(IoBuffer), typeof(object).MakeByRefType(), typeof(ushort) });
            deserializerSwitchTypedMethod.DefineParameter(1, ParameterAttributes.None, "buffer");
            deserializerSwitchTypedMethod.DefineParameter(2, ParameterAttributes.Out, "value");
            deserializerSwitchTypedMethod.DefineParameter(3, ParameterAttributes.None, "typeId");
            var deserializerSwitchTypedMethodInfo = deserializerSwitchTypedMethod;

            var ctx = new CodeGenContext(map, serializerSwitchMethodInfo, deserializerSwitchMethodInfo);

            /* generate bodies */

            foreach (var kvp in map)
            {
                var type = kvp.Key;
                var td = kvp.Value;

                if (!td.IsGenerated)
                    continue;

                td.TypeSerializer.GenerateWriterMethod(type, ctx, td.WriterILGen);
                td.TypeSerializer.GenerateReaderMethod(type, ctx, td.ReaderILGen);
            }

            var ilGen = serializerSwitchMethod.GetILGenerator();
            SerializerCodegen.GenerateSerializerSwitch(ctx, ilGen, map);

            ilGen = deserializerSwitchMethod.GetILGenerator();
            DeserializerCodegen.GenerateDeserializerSwitch(ctx, ilGen, map);

            ilGen = deserializerSwitchTypedMethod.GetILGenerator();
            DeserializerCodegen.GenerateDeserializerSwitchTyped(ctx, ilGen, map);

            tb.CreateType();
            ab.Save("SerializerDebug.dll");
        }
#endif

        /* called from the dynamically generated code */
        static ushort GetTypeID(object ob)
        {
            ushort id;

            if (ob == null)
                return 0;

            var type = ob.GetType();

            if (s_typeIDMap.TryGetValue(type, out id) == false)
                throw new InvalidOperationException(String.Format("Unknown type {0}", type.FullName));

            return id;
        }

        static ushort GetTypeID(Type type)
        {
            ushort id;

            if (type == null)
                return 0;

            if (s_typeIDMap.TryGetValue(type, out id) == false)
                throw new InvalidOperationException(String.Format("Unknown type {0}", type.FullName));

            return id;
        }

        static bool HasSwitchType(object ob)
        {
            TypeData typeData;

            if (ob == null)
                return false;

            var type = ob.GetType();

            if (typeDataMap.TryGetValue(type, out typeData) == false)
                throw new InvalidOperationException(String.Format("Unknown type {0}", type.FullName));

            return typeData.HasSwitch;
        }
    }
}
