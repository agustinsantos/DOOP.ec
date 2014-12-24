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


using org.omg.dds.core;
using org.omg.dds.type.dynamic.modifiable;
using System.Collections.Generic;

namespace org.omg.dds.type.dynamic
{

    public interface TypeDescriptor : Value<TypeDescriptor, ModifiableTypeDescriptor>
    {
        bool IsConsistent();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The kind</returns>
        TypeKind GetKind();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The name</returns>
        string GetName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The baseType</returns>
        DynamicType GetBaseType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The discriminatorType</returns>
        DynamicType GetDiscriminatorType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Bound, an unmodifiable list</returns>
        List<int> GetBound();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The ElementType</returns>
        [Optional]
        DynamicType GetElementType();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The keyElementType</returns>
        [Optional]
        DynamicType GetKeyElementType();
    }
}