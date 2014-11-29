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



using System;

namespace org.omg.dds.type
{


    [System.AttributeUsage(AttributeTargets.Class |
                            AttributeTargets.Enum |
                            AttributeTargets.Interface |
                            AttributeTargets.Field |
                            AttributeTargets.Property |
                            AttributeTargets.Method)
    ]
    public class SerializeAs : Attribute
    {
        public TypeKind value  { get; set; }

        /**
         * The type of the elements to be stored in a collection (string,
         * sequence, or map) or TypeKind.NO_TYPE if this annotation is not applied
         * to a collection.
         * 
         * If this annotation is applied to a map, it indicates the type of the
         * map's "value" elements. 
         */
        public TypeKind collectionElementKind  { get; set; }// default TypeKind.NO_TYPE;

        /**
         * The type of the "key" elements to be stored in a map or
         * TypeKind.NO_TYPE if this annotation is not applied to a map.
         */
        public TypeKind mapKeyElementKind  { get; set; }// default TypeKind.NO_TYPE;

        /**
         * The collection's or bit set's bound(s), if any, if this annotation is
         * applied to a collection or bit set, or an empty array if not.
         * 
         * strings, sequences, and maps have a bound with a single value; an
         * empty array indicates an unbounded collection. Bit sets have a
         * mandatory bound of a single value. Arrays may be multidimensional;
         * each element of the array corresponds to one of these dimensions.
         */
        public long[] bound { get; set; }// default { /* empty */ };
    }
}