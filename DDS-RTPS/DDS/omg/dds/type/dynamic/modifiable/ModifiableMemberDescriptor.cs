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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">The id to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetId(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">The type to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetType(DynamicType type);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultValue">The defaultValue to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetDefaultValue(string defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">The index to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetIndex(int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label">The label to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetLabel(params int[] label);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultLabel">The defaultLabel to Set</param>
        /// <returns>this</returns>
        ModifiableMemberDescriptor SetDefaultLabel(bool defaultLabel);
    }
}