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
    public interface BitSetType : Type
    {

        [ID(BitSetTypeMemberId.BIT_BOUND_BITSETTYPE_MEMBER_ID)]
        int getBitBound();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBitBound"></param>
        /// <returns>this</returns>
        BitSetType setBitBound(int newBitBound);

        [ID(BitSetTypeMemberId.BIT_BITSETTYPE_MEMBER_ID)]
        List<Bit> getBit();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBit"></param>
        /// <returns>this</returns>
        BitSetType setBit(List<Bit> newBit);

    }

    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class BitSetTypeMemberId
    {
        // --- Constants: ----------------------------------------------------
        public const int BIT_BOUND_BITSETTYPE_MEMBER_ID = 100;
        public const int BIT_BITSETTYPE_MEMBER_ID = 101;

        // --- Constructor: --------------------------------------------------
        private BitSetTypeMemberId()
        {
            // empty
        }
    }
}