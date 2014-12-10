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
    // The assignment of a value to a member of an annotation
    [Extensibility(ExtensibilityKind.EXTENSIBLE_EXTENSIBILITY)]
    [Nested]
    public interface AnnotationUsageMember
     : ModifiableValue<AnnotationUsageMember, AnnotationUsageMember>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberId">The memberId to set</param>
        /// <returns>this</returns>
        AnnotationUsageMember setMemberId(int memberId);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The memberId</returns>
        int getMemberId();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">The value to set</param>
        /// <returns>this</returns>
        AnnotationUsageMember setValue(AnnotationMemberValue value);

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The value</returns>
        AnnotationMemberValue getValue();
    }
}