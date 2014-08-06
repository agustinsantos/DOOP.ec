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
    public interface MemberProperty : ModifiableValue<MemberProperty, MemberProperty>
    {
        /**
         * @param flag the flag to set
         * 
         * @return  this
         */
        MemberProperty setFlag(MemberFlag flag);

        /**
         * @return the flag
         */
        MemberFlag getFlag();

        /**
         * @param memberId the memberId to set
         * 
         * @return  this
         */
        MemberProperty setMemberId(int memberId);

        /**
         * @return the memberId
         */
        int getMemberId();

        /**
         * @param type the type to set
         * 
         * @return  this
         */
        MemberProperty setType(int type);

        /**
         * @return the type
         */
        int getType();

        /**
         * @param name the name to set
         * 
         * @return  this
         */
        MemberProperty setName(string name);

        /**
         * @return the name
         */
        string getName();
    }
}