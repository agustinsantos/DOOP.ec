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

namespace org.omg.dds.type.typeobject
{

    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface TypeProperty : ModifiableValue<TypeProperty, TypeProperty>
    {
        /// <summary>
        /// Sets the flag
        /// </summary>
        /// <param name="flag">the flag to Set</param>
        /// <returns>this</returns>
        TypeProperty SetFlag(TypeFlag flag);

        /// <summary>
        /// Gets/Sets the flag
        /// </summary>
        TypeFlag Flag { get; set; }

        /// <summary>
        /// Sets the typeId
        /// </summary>
        /// <param name="typeId">the typeId to Set</param>
        /// <returns>this</returns>
        TypeProperty SetTypeId(int typeId);

        
        /// <summary>
        /// Gets/Sets the typeId
        /// </summary>
        int TypeId { get; set; }

        
        /// <summary>
        /// Sets the name
        /// </summary>
        /// <param name="name">the name to Set</param>
        /// <returns>this</returns>
        TypeProperty SetName(string name);

        
        /// <summary>
        /// Gets/Sets the name
        /// </summary>
        string Name { get; set; }
    }

}