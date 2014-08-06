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



using System.Collections.Generic;

using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{

    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    [Nested]
    public interface UnionType : Type
    {
        // -----------------------------------------------------------------------
        // Properties
        // -----------------------------------------------------------------------

        [ID(UnionTypeMemberId.MEMBER_UNIONTYPE_MEMBER_ID)]
        List<UnionMember> getMember();

        /**
         * @return  this
         */
        UnionType setMember(List<UnionMember> newMember);

    }
    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class UnionTypeMemberId
    {
        // --- Constants: ----------------------------------------------------
        public const int MEMBER_UNIONTYPE_MEMBER_ID = 100;

        // --- Constructor: --------------------------------------------------
        private UnionTypeMemberId()
        {
            // empty
        }
    }
}