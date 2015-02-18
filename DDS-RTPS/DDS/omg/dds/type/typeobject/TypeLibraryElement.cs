/* Copyright 2010, Object Management Group, Inc.
 * Copyright 2010, PrismTech, Inc.
 * Copyright 2010, Real-Time Innovations, Inc.
 * All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



using org.omg.dds.core.modifiable;
using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    [Nested]
    public interface TypeLibraryElement : ModifiableValue<TypeLibraryElement, TypeLibraryElement>
    {
        // -----------------------------------------------------------------------
        // Properties
        // -----------------------------------------------------------------------

        TypeLibraryElementKind Discriminator();


        AliasType GetAliasType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetAliasType(AliasType value);


        AnnotationType GetAnnotationType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetAnnotationType(AnnotationType value);


        ArrayType GetArrayType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetArrayType(ArrayType value);


        BitSetType GetBitsetType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetBitsetType(BitSetType value);


        EnumerationType GetEnumerationType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetEnumerationType(EnumerationType value);


        MapType GetMapType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetMapType(MapType value);


        SequenceType GetSequenceType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetSequenceType(SequenceType value);


        stringType GetstringType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetstringType(stringType value);


        StructureType GetStructureType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetStructureType(StructureType value);


        UnionType GetUnionType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetUnionType(UnionType value);


        Module GetModule();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>this</returns>
        TypeLibraryElement SetModule(Module value);
    }

    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    [BitBound(16)]
    public enum TypeLibraryElementKind : short
    {
        // --- Constants: ----------------------------------------------------
        [Value(TypeKindValues.ALIAS_TYPE_VALUE)]
        ALIAS_TYPE_ELEMENT = TypeKindValues.ALIAS_TYPE_VALUE,

        [Value(TypeKindValues.ANNOTATION_TYPE_VALUE)]
        ANNOTATION_TYPE_ELEMENT = TypeKindValues.ANNOTATION_TYPE_VALUE,

        [Value(TypeKindValues.ARRAY_TYPE_VALUE)]
        ARRAY_TYPE_ELEMENT = TypeKindValues.ARRAY_TYPE_VALUE,

        [Value(TypeKindValues.BITSET_TYPE_VALUE)]
        BITSET_TYPE_ELEMENT = TypeKindValues.BITSET_TYPE_VALUE,

        [Value(TypeKindValues.ENUMERATION_TYPE_VALUE)]
        ENUMERATION_TYPE_ELEMENT = TypeKindValues.ENUMERATION_TYPE_VALUE,

        [Value(TypeKindValues.MAP_TYPE_VALUE)]
        MAP_TYPE_ELEMENT = TypeKindValues.MAP_TYPE_VALUE,

        [Value(TypeKindValues.SEQUENCE_TYPE_VALUE)]
        SEQUENCE_TYPE_ELEMENT = TypeKindValues.SEQUENCE_TYPE_VALUE,

        [Value(TypeKindValues.STRING_TYPE_VALUE)]
        STRING_TYPE_ELEMENT = TypeKindValues.STRING_TYPE_VALUE,

        [Value(TypeKindValues.STRUCTURE_TYPE_VALUE)]
        STRUCTURE_TYPE_ELEMENT = TypeKindValues.STRUCTURE_TYPE_VALUE,

        [Value(TypeKindValues.UNION_TYPE_VALUE)]
        UNION_TYPE_ELEMENT = TypeKindValues.UNION_TYPE_VALUE,

        [Value(TypeKindValues.UNION_TYPE_VALUE + 1)]
        MODULE_ELEMENT = (short)(TypeKindValues.UNION_TYPE_VALUE + 1)

    }
}