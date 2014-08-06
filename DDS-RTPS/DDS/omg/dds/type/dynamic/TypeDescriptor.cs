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

        /**
         * @return the kind
         */
        TypeKind getKind();

        /**
         * @return the name
         */
        string getName();

        /**
         * @return the baseType
         */
        DynamicType getBaseType();

        /**
         * @return the discriminatorType
         */
        DynamicType getDiscriminatorType();

        /**
         * @return the bound, an unmodifiable list
         */
        List<int> getBound();

        /**
         * @return the elementType
         */
        [Optional]
        DynamicType getElementType();

        /**
         * @return the keyElementType
         */
        [Optional]
        DynamicType getKeyElementType();
    }
}