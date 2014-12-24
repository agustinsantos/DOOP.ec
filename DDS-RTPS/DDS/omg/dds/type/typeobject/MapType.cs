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



using org.omg.dds.type;

namespace org.omg.dds.type.typeobject
{
    [Extensibility(ExtensibilityKind.MUTABLE_EXTENSIBILITY)]
    [Nested]
    public interface MapType : CollectionType
    {

        // -----------------------------------------------------------------------
        // Properties
        // -----------------------------------------------------------------------

        [ID(MapTypeMemberId.KEY_ELEMENT_TYPE_MAPTYPE_MEMBER_ID)]
        int GetKeyElementType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newKeyElementType"></param>
        /// <returns>this</returns>
        MapType SetKeyElementType(int newKeyElementType);

        [ID(MapTypeMemberId.BOUND_MAPTYPE_MEMBER_ID)]
        long GetBound();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newBound"></param>
        /// <returns>this</returns>
        MapType SetBound(long newBound);

    }
    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public sealed class MapTypeMemberId
    {
        // --- Constants: ----------------------------------------------------
        public const int KEY_ELEMENT_TYPE_MAPTYPE_MEMBER_ID = 200;
        public const int BOUND_MAPTYPE_MEMBER_ID = 201;

        // --- Constructor: --------------------------------------------------
        private MapTypeMemberId()
        {
            // empty
        }
    }
}