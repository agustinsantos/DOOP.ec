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
        /// <param name="kind">The kind to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetKind(TypeKind kind);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseType">The baseType to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetBaseType(DynamicType baseType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="discriminatorType">The discriminatorType to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetDiscriminatorType(DynamicType discriminatorType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bound">The Bound to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetBound(params int[] bound);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementType">The ElementType to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetElementType(DynamicType elementType);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyElementType">The keyElementType to Set</param>
        /// <returns>this</returns>
        ModifiableTypeDescriptor SetKeyElementType(DynamicType keyElementType);
    }
}