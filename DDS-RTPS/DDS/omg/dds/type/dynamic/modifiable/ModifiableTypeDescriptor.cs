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
        /**
         * @param kind the kind to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setKind(TypeKind kind);

        /**
         * @param name the name to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setName(string name);

        /**
         * @param baseType the baseType to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setBaseType(DynamicType baseType);

        /**
         * @param discriminatorType the discriminatorType to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setDiscriminatorType(DynamicType discriminatorType);

        /**
         * @param bound the bound to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setBound(params int[] bound);

        /**
         * @param elementType the elementType to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setElementType(DynamicType elementType);

        /**
         * @param keyElementType the keyElementType to set
         * 
         * @return  this
         */
        ModifiableTypeDescriptor setKeyElementType(DynamicType keyElementType);
    }
}