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


using org.omg.dds.core;
using org.omg.dds.type.dynamic.modifiable;
using System.Collections.Generic;

namespace org.omg.dds.type.dynamic
{

    public interface TypeDescriptor : Value<TypeDescriptor, ModifiableTypeDescriptor>
    {
        bool isConsistent();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The kind</returns>
        TypeKind getKind();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The name</returns>
        string getName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The baseType</returns>
        DynamicType getBaseType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The discriminatorType</returns>
        DynamicType getDiscriminatorType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The bound, an unmodifiable list</returns>
        List<int> getBound();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The elementType</returns>
        [Optional]
        DynamicType getElementType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The keyElementType</returns>
        [Optional]
        DynamicType getKeyElementType();
    }
}