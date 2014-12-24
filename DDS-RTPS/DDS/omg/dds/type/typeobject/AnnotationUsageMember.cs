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
    // The assignment of a Value to a member of an annotation
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface AnnotationUsageMember
     : ModifiableValue<AnnotationUsageMember, AnnotationUsageMember>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId">The memberId to Set</param>
        /// <returns>this</returns>
        AnnotationUsageMember SetMemberId(int memberId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The memberId</returns>
        int GetMemberId();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Value">The Value to Set</param>
        /// <returns>this</returns>
        AnnotationUsageMember SetValue(AnnotationMemberValue value);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The Value</returns>
        AnnotationMemberValue GetValue();
    }
}