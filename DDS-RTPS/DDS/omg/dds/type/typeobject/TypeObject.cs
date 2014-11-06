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
    /// <summary>
    /// The TypeObject type is designed to describe other types in that type system;
    /// in that sense, it is a meta-type.
    /// This identifies a single type within a library.
    /// </summary>
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    public interface TypeObject : ModifiableValue<TypeObject, TypeObject>
    {
        /**
         * @param library the library to set
         * 
         * @return  this
         */
        TypeObject setLibrary(TypeLibrary library);

        /**
         * @return the library
         */
        [Shared]
        TypeLibrary getLibrary();

        /**
         * @param the_type the the_type to set
         * 
         * @return  this
         */
        TypeObject setTheType(int the_type);

        /**
         * @return the the_type
         */
        [Optional]
        int getTheType();
    }
}