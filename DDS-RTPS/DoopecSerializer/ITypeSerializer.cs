﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Doopec.Serializer
{
    public interface ITypeSerializer
    {
        /// <summary>
        /// Returns if this TypeSerializer handles the given type
        /// </summary>
        bool Handles(Type type);

        /// <summary>
        /// Return types that are needed to serialize the given type
        /// </summary>
        IEnumerable<Type> GetSubtypes(Type type);
    }

    public interface IStaticTypeSerializer : ITypeSerializer
    {
        /// <summary>
        /// Get static methods used to serialize and deserialize the given type
        /// </summary>
        void GetStaticMethods(Type type, out MethodInfo writer, out MethodInfo reader);
    }

    public interface IDynamicTypeSerializer : ITypeSerializer
    {
        /// <summary>
        /// Generate code to serialize the given type
        /// </summary>
        void GenerateWriterMethod(Type type, CodeGenContext ctx, ILGenerator il);

        /// <summary>
        /// Generate code to deserialize the given type
        /// </summary>
        void GenerateReaderMethod(Type type, CodeGenContext ctx, ILGenerator il);

        bool HasSwitch { get; }
    }
}
