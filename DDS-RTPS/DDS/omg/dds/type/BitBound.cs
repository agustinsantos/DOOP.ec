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
using System.Diagnostics;

namespace org.omg.dds.type
{

    [System.AttributeUsage(AttributeTargets.Class |
                            AttributeTargets.Enum)
    ]
    public class BitBoundAttribute : Attribute
    {
        public BitBoundAttribute(int val)
        {
            Value = val;
        }

        public BitBoundAttribute()
        { Value = 32; }
        
        /// <summary>
        /// default 32;
        /// </summary>
        public int Value { get; set;} 
    }
}