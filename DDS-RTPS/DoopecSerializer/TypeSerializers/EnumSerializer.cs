﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Doopec.Serializer.TypeSerializers
{
    public class EnumSerializer : IStaticTypeSerializer
    {
        public bool Handles(Type type)
        {
            return type.IsEnum;
        }

        public IEnumerable<Type> GetSubtypes(Type type)
        {
            var underlyingType = Enum.GetUnderlyingType(type);

            yield return underlyingType;
        }

        public void GetStaticMethods(Type type, out MethodInfo writer, out MethodInfo reader)
        {
            Debug.Assert(type.IsEnum);

            var underlyingType = Enum.GetUnderlyingType(type);

            writer = Primitives.GetWritePrimitive(underlyingType);
            reader = Primitives.GetReaderPrimitive(underlyingType);
        }
    }
}