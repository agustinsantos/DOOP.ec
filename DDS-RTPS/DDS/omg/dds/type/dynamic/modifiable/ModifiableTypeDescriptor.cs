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
using org.omg.dds.type.dynamic;

namespace org.omg.dds.type.dynamic.modifiable
{
    public interface ModifiableTypeDescriptor : TypeDescriptor,
            ModifiableValue<TypeDescriptor, ModifiableTypeDescriptor>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kind">The kind to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setKind(TypeKind kind);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType">The baseType to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setBaseType(DynamicType baseType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discriminatorType">The discriminatorType to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setDiscriminatorType(DynamicType discriminatorType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bound">The bound to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setBound(params int[] bound);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType">The elementType to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setElementType(DynamicType elementType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyElementType">The keyElementType to set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor setKeyElementType(DynamicType keyElementType);
    }
}