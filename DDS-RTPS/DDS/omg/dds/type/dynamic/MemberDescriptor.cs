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


using System.Collections.Generic;

using org.omg.dds.core;
using org.omg.dds.type.dynamic.modifiable;

namespace org.omg.dds.type.dynamic
{

    public interface MemberDescriptor : Value<MemberDescriptor, ModifiableMemberDescriptor>
    {
        bool isConsistent();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The name</returns>
        string getName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The id</returns>
        int getId();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The type</returns>
        DynamicType getType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The defaultValue</returns>
        string getDefaultValue();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The index</returns>
        int getIndex();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The label</returns>
        List<int> getLabel();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The defaultLabel</returns>
        bool isDefaultLabel();
    }
}