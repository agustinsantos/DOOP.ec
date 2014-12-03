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
        /// <summary>
        /// Set the flag and return the instance.
        /// </summary>
        /// <param name="flag">the flag to set</param>
        /// <returns>return this</returns>
        MemberProperty SetFlag(MemberFlag flag);

        /// <summary>
        /// Gets/Sets Flags
        /// </summary>
        MemberFlag Flag { get; set; }

        /// <summary>
        /// Set the member Id
        /// </summary>
        /// <param name="memberId">the memberId to set</param>
        /// <returns>this</returns>
        MemberProperty SetMemberId(uint memberId);

        
        /// <summary>
        /// Gets/Sets the Member ID
        /// </summary>
        uint MemberId { get; set; }

        /// <summary>
        /// Return the information about DDS type
        /// </summary>
        /// <param name="type">the type to set</param>
        /// <returns>this</returns>
        MemberProperty SetType(int type);

        /// <summary>
        /// Gets/sets the DDS Type
        /// </summary>
        int Type { get; set; }

        /// <summary>
        /// Set the full name
        /// </summary>
        /// <param name="name">the name to set</param>
        /// <returns>this</returns>
        MemberProperty SetName(string name);

        /// <summary>
        /// Gets/Sets the name
        /// </summary>
        /// <returns></returns>
        string Name { get; set; }

        /// <summary>
        /// Check if the member is defined as a C# Property
        /// </summary>
        bool IsProperty { get; set; }

    }
}