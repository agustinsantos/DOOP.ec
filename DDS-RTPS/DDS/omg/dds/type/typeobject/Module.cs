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
    public interface Module : ModifiableValue<Module, Module>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">The name to set</param>
        /// <returns>this</returns>
        Module setName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The name</returns>
        string getName();

        [Shared]
        TypeLibrary getLibrary();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newLibrary"></param>
        /// <returns>this</returns>
        Module setLibrary(TypeLibrary newLibrary);
    }
}