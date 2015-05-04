using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Doopec.Serializer.TypeSerializers
{
    public class ListSerializer : IStaticTypeSerializer
    {
        public bool Handles(Type type)
        {
            if (!type.IsGenericType)
                return false;

            var genTypeDef = type.GetGenericTypeDefinition();

            return genTypeDef == typeof(List<>);
        }

        public IEnumerable<Type> GetSubtypes(Type type)
        {
            // List<T> is stored as T[]

            var genArgs = type.GetGenericArguments();

            var serializedType = genArgs[0].MakeArrayType();

            yield return serializedType;
        }

        public void GetStaticMethods(Type type, out MethodInfo writer, out MethodInfo reader)
        {
            Debug.Assert(type.IsGenericType);

            if (!type.IsGenericType)
                throw new Exception();

            var genTypeDef = type.GetGenericTypeDefinition();

            Debug.Assert(genTypeDef == typeof(List<>));

            var containerType = this.GetType();

            writer = GetGenWriter(containerType, genTypeDef);
            reader = GetGenReader(containerType, genTypeDef);

            var genArgs = type.GetGenericArguments();

            writer = writer.MakeGenericMethod(genArgs);
            reader = reader.MakeGenericMethod(genArgs);
        }

        static MethodInfo GetGenWriter(Type containerType, Type genType)
        {
            var mis = containerType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(mi => mi.IsGenericMethod && mi.Name == "WriteListPrimitive");

            foreach (var mi in mis)
            {
                var p = mi.GetParameters();

                if (p.Length != 2)
                    continue;

                if (p[0].ParameterType != typeof(IoBuffer))
                    continue;

                var paramType = p[1].ParameterType;

                if (paramType.IsGenericType == false)
                    continue;

                var genParamType = paramType.GetGenericTypeDefinition();

                if (genType == genParamType)
                    return mi;
            }

            return null;
        }

        static MethodInfo GetGenReader(Type containerType, Type genType)
        {
            var mis = containerType.GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(mi => mi.IsGenericMethod && mi.Name == "ReadListPrimitive");

            foreach (var mi in mis)
            {
                var p = mi.GetParameters();

                if (p.Length != 2)
                    continue;

                if (p[0].ParameterType != typeof(IoBuffer))
                    continue;

                var paramType = p[1].ParameterType;

                if (paramType.IsByRef == false)
                    continue;

                paramType = paramType.GetElementType();

                if (paramType.IsGenericType == false)
                    continue;

                var genParamType = paramType.GetGenericTypeDefinition();

                if (genType == genParamType)
                    return mi;
            }

            return null;
        }

        public static void WriteListPrimitive<T>(IoBuffer stream, List<T> value)
        {
            var pArray = new T[value.Count];

            int i = 0;
            foreach (var kvp in value)
                pArray[i++] = kvp;

            Serializer.SerializeInternal(stream, pArray);
        }

        public static void ReadListPrimitive<T>(IoBuffer stream, out List<T> value)
        {
            var tmp = Serializer.DeserializeInternal(stream);

            T[] pArray = (T[])tmp;
            value = new List<T>(pArray.Length);

            foreach (var p in pArray)
                value.Add(p);
        }
    }
}
