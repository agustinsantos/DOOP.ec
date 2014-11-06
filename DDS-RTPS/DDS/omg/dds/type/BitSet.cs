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
                            AttributeTargets.Method)
    ]
    public class BitSetAttribute : Attribute
    {
        public BitSetAttribute()
        { 
        }

        /**
         * When this annotation annotates an enum class, don't set this member.
         * But if you do, set it to the type of the enumeration itself.
         * 
         * When it annotates an object of type java.util.EnumSet of
         * java.util.BitSet, it indicates the BitSet-annotated enum class that
         * defines the members of the bit set.
         */
        public Enum elementType { get; set; }// default Enum.class;
    }
}