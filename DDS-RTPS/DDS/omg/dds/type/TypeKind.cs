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

namespace org.omg.dds.type
{
    public enum TypeKind
    {
        // -----------------------------------------------------------------------
        // Enumerated Constants
        // -----------------------------------------------------------------------

        /** sentinel indicating "null" value */
        NO_TYPE = TypeKindValues.NO_TYPE_VALUE,
        BOOLEAN_TYPE = TypeKindValues.BOOLEAN_TYPE_VALUE,
        BYTE_TYPE = TypeKindValues.BYTE_TYPE_VALUE,
        INT_16_TYPE = TypeKindValues.INT_16_TYPE_VALUE,
        UINT_16_TYPE = TypeKindValues.UINT_16_TYPE_VALUE,
        INT_32_TYPE = TypeKindValues.INT_32_TYPE_VALUE,
        UINT_32_TYPE = TypeKindValues.UINT_32_TYPE_VALUE,
        INT_64_TYPE = TypeKindValues.INT_64_TYPE_VALUE,
        UINT_64_TYPE = TypeKindValues.UINT_64_TYPE_VALUE,
        FLOAT_32_TYPE = TypeKindValues.FLOAT_32_TYPE_VALUE,
        FLOAT_64_TYPE = TypeKindValues.FLOAT_64_TYPE_VALUE,
        FLOAT_128_TYPE = TypeKindValues.FLOAT_128_TYPE_VALUE,
        CHAR_8_TYPE = TypeKindValues.CHAR_8_TYPE_VALUE,
        CHAR_32_TYPE = TypeKindValues.CHAR_32_TYPE_VALUE,

        ENUMERATION_TYPE = TypeKindValues.ENUMERATION_TYPE_VALUE,
        BITSET_TYPE = TypeKindValues.BITSET_TYPE_VALUE,
        ALIAS_TYPE = TypeKindValues.ALIAS_TYPE_VALUE,

        ARRAY_TYPE = TypeKindValues.ARRAY_TYPE_VALUE,
        SEQUENCE_TYPE = TypeKindValues.SEQUENCE_TYPE_VALUE,
        STRING_TYPE = TypeKindValues.STRING_TYPE_VALUE,
        MAP_TYPE = TypeKindValues.MAP_TYPE_VALUE,

        UNION_TYPE = TypeKindValues.UNION_TYPE_VALUE,
        STRUCTURE_TYPE = TypeKindValues.STRUCTURE_TYPE_VALUE,
        ANNOTATION_TYPE = TypeKindValues.ANNOTATION_TYPE_VALUE
    }

    // -----------------------------------------------------------------------
    // Compile-TIme Constants
    // -----------------------------------------------------------------------

    public sealed class TypeKindValues
    {
        /** sentinel indicating "null" value */
        public const short NO_TYPE_VALUE = 0;
        public const short BOOLEAN_TYPE_VALUE = 1;
        public const short BYTE_TYPE_VALUE = 2;
        public const short INT_16_TYPE_VALUE = 3;
        public const short UINT_16_TYPE_VALUE = 4;
        public const short INT_32_TYPE_VALUE = 5;
        public const short UINT_32_TYPE_VALUE = 6;
        public const short INT_64_TYPE_VALUE = 7;
        public const short UINT_64_TYPE_VALUE = 8;
        public const short FLOAT_32_TYPE_VALUE = 9;
        public const short FLOAT_64_TYPE_VALUE = 10;
        public const short FLOAT_128_TYPE_VALUE = 11;
        public const short CHAR_8_TYPE_VALUE = 12;
        public const short CHAR_32_TYPE_VALUE = 13;

        public const short ENUMERATION_TYPE_VALUE = 14;
        public const short BITSET_TYPE_VALUE = 15;
        public const short ALIAS_TYPE_VALUE = 16;

        public const short ARRAY_TYPE_VALUE = 17;
        public const short SEQUENCE_TYPE_VALUE = 18;
        public const short STRING_TYPE_VALUE = 19;
        public const short MAP_TYPE_VALUE = 20;

        public const short UNION_TYPE_VALUE = 21;
        public const short STRUCTURE_TYPE_VALUE = 22;
        public const short ANNOTATION_TYPE_VALUE = 23;
    }
}