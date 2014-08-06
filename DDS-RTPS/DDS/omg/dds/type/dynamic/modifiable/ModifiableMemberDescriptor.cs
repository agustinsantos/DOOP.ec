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
using org.omg.dds.type.dynamic;

namespace org.omg.dds.type.dynamic.modifiable
{
    public interface ModifiableMemberDescriptor : MemberDescriptor,
            ModifiableValue<MemberDescriptor, ModifiableMemberDescriptor>
    {
        /**
         * @param name the name to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setName(string name);

        /**
         * @param id the id to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setId(int id);

        /**
         * @param type the type to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setType(DynamicType type);

        /**
         * @param defaultValue the defaultValue to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setDefaultValue(string defaultValue);

        /**
         * @param index the index to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setIndex(int index);

        /**
         * @param label the label to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setLabel(params int[] label);

        /**
         * @param defaultLabel the defaultLabel to set
         * 
         * @return  this
         */
        ModifiableMemberDescriptor setDefaultLabel(bool defaultLabel);
    }
}