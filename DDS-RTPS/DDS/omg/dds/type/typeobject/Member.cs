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

using org.omg.dds.core.modifiable;
using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{

    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    [Nested]
    public interface Member : ModifiableValue<Member, Member>
    {
        // -----------------------------------------------------------------------
        // Properties
        // -----------------------------------------------------------------------

        [ID(MemberMemberId.PROPERTY_MEMBER_MEMBER_ID)]
        MemberProperty getProperty();

        /**
         * @return  this
         */
        [ID(MemberMemberId.PROPERTY_MEMBER_MEMBER_ID)]
        Member setProperty(MemberProperty newProperty);

        [ID(MemberMemberId.ANNOTATION_MEMBER_MEMBER_ID)]
        IList<AnnotationUsage> getAnnotation();

        /**
         * @return  this
         */
        [ID(MemberMemberId.ANNOTATION_MEMBER_MEMBER_ID)]
        Member setAnnotation(IList<AnnotationUsage> newAnnotation);

    }

    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class MemberMemberId
    {
        // -----------------------------------------------------------------------
        // Constants
        // -----------------------------------------------------------------------
        public const int PROPERTY_MEMBER_MEMBER_ID = 0;
        public const int ANNOTATION_MEMBER_MEMBER_ID = 1;

        public const int MEMBER_ID_INVALID = (int)(0x0FFFFFFFL);

        // --- Constructor: --------------------------------------------------
        private MemberMemberId()
        {
            // empty
        }
    }
}
