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
    // The application of an annotation to some type or type member
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface AnnotationUsage
     : ModifiableValue<AnnotationUsage, AnnotationUsage>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeId">The typeId to Set</param>
        /// <returns>this</returns>
        AnnotationUsage SetTypeId(int typeId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The typeId</returns>
        int GetTypeId();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member">The member to Set</param>
        /// <returns>this</returns>
        AnnotationUsage SetMember(List<AnnotationUsageMember> member);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The member</returns>
        List<AnnotationUsageMember> GetMember();
    }
}