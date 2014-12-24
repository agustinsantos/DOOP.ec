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
    public interface EnumerationType : Type
    {
        /// <summary>
        /// Gets/Sets the bit Bound
        /// </summary>
        [ID(EnumerationTypeMemberId.BIT_BOUND_ENUMERATIONTYPE_MEMBER_ID)]
        int BitBound { get; set; }

        
        /// <summary>
        /// Sets a new BitBound
        /// </summary>
        /// <param name="newBitBound">the new BitBound</param>
        /// <returns>this</returns>
        EnumerationType SetBitBound(int newBitBound);

        /// <summary>
        /// Gets/Sets the list of enumerated constants (enums values)
        /// </summary>
        [ID(EnumerationTypeMemberId.CONSTANT_ENUMERATIONTYPE_MEMBER_ID)]
        IList<EnumeratedConstant> Constants { get; set; }

        /// <summary>
        /// Set a new list of constants
        /// </summary>
        /// <param name="newConstant">the new list of constants</param>
        /// <returns>this</returns>
        EnumerationType SetConstant(IList<EnumeratedConstant> newConstant);

    }
    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class EnumerationTypeMemberId
    {
        // --- Constants: ----------------------------------------------------
        public const int BIT_BOUND_ENUMERATIONTYPE_MEMBER_ID = 100;
        public const int CONSTANT_ENUMERATIONTYPE_MEMBER_ID = 101;


        // --- Constructor: --------------------------------------------------
        private EnumerationTypeMemberId()
        {
            // empty
        }
    }
}