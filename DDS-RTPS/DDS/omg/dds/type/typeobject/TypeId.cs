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
 * See the License for the specific Language governing permissions and
 * limitations under the License.
 */



using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{
    /// <summary>
    /// Every type has an ID. Those of the primitive types are predefined
    /// </summary>
    public sealed class TypeId
    {
        // -----------------------------------------------------------------------
        // Constants
        // -----------------------------------------------------------------------

        public const int NO_TYPE_ID =
            TypeKindValues.NO_TYPE_VALUE;
        public const int BOOLEAN_TYPE_ID =
            TypeKindValues.BOOLEAN_TYPE_VALUE;
        public const int BYTE_TYPE_ID =
            TypeKindValues.BYTE_TYPE_VALUE;
        public const int INT_16_TYPE_ID =
            TypeKindValues.INT_16_TYPE_VALUE;
        public const int UINT_16_TYPE_ID =
            TypeKindValues.UINT_16_TYPE_VALUE;
        public const int INT_32_TYPE_ID =
            TypeKindValues.INT_32_TYPE_VALUE;
        public const int UINT_32_TYPE_ID =
            TypeKindValues.UINT_32_TYPE_VALUE;
        public const int INT_64_TYPE_ID =
            TypeKindValues.INT_64_TYPE_VALUE;
        public const int UINT_64_TYPE_ID =
            TypeKindValues.UINT_64_TYPE_VALUE;
        public const int FLOAT_32_TYPE_ID =
            TypeKindValues.FLOAT_32_TYPE_VALUE;
        public const int FLOAT_64_TYPE_ID =
            TypeKindValues.FLOAT_64_TYPE_VALUE;
        public const int FLOAT_128_TYPE_ID =
            TypeKindValues.FLOAT_128_TYPE_VALUE;
        public const int CHAR_8_TYPE_ID =
            TypeKindValues.CHAR_8_TYPE_VALUE;
        public const int CHAR_32_TYPE_ID =
            TypeKindValues.CHAR_32_TYPE_VALUE;



        // -----------------------------------------------------------------------
        // Constructor
        // -----------------------------------------------------------------------

        private TypeId()
        {
            // empty
        }
    }
}