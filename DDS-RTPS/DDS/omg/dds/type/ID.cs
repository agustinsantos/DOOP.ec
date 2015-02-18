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
    /// <summary>
    /// Each member of an aggregated type is uniquely identified within that type by an integer "member ID." 
    /// Member IDs are unsigned and have a range that can be represented in 28 bits: from zero to 268,435,455 (0x0FFFFFFF). 
    /// (The full range of a 32-bit unsigned integer is not used in order to allow binary Data Representations the 
    /// freedom to embed a small amount of meta-data into a single 32-bit field if they so desire.)
    /// The upper end of the range, from 268,419,072 (0x0FFFC000) to 268,435,455 (0x0FFFFFFF) inclusive, is reserved 
    /// for use by the OMG, either by this specification-including future versions of it-or by future related 
    /// specifications (16,384 values). The largest Value in this range-0x0FFFFFFF-shall be used as a sentinel to indicate 
    /// an invalid member ID. This sentinel is referred to by the name MEMBER_ID_INVALID.
    /// 
    /// The remaining part of the member ID range-from 0 to 268,402,687 (0x0FFFBFFF)-is available for use by 
    /// application-defined types compliant with this specification.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Field |
                           AttributeTargets.Property |
                           AttributeTargets.Method)
    ]
    public class IDAttribute : Attribute
    {
        public IDAttribute(uint val)
        {
            Value = val;
        }

        public uint Value { get; set; }
    }
}