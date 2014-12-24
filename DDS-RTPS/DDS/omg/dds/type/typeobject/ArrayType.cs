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
 * See the License for the specific Language governing permissions and
 * limitations under the License.
 */



using System.Collections.Generic;

using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{

    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    [Nested]
    public interface ArrayType : CollectionType
    {

        // -----------------------------------------------------------------------
        // Properties
        // -----------------------------------------------------------------------

        [ID(ArrayTypeMemberId.BOUND_ARRAYTYPE_MEMBER_ID)]
        List<long> GetBound();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBound"></param>
        /// <returns>this</returns>
        ArrayType SetBound(List<long> newBound);

    }

    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class ArrayTypeMemberId
    {
        // --- Constants: ----------------------------------------------------
        public const int BOUND_ARRAYTYPE_MEMBER_ID = 200;

        // --- Constructor: --------------------------------------------------
        private ArrayTypeMemberId()
        {
            // empty
        }
    }
}