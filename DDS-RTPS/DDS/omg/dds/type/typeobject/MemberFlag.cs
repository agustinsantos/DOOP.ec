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
using System;

namespace org.omg.dds.type.typeobject
{
    [Flags]
    [BitSet]
    [BitBound(16)]
    public enum MemberFlag : ushort
    {
        // -----------------------------------------------------------------------
        // Constants
        // -----------------------------------------------------------------------
        NO_FLAGS = 0,

        [Value(0)]
        IS_KEY = 1,
  
        [Value(1)]
        IS_OPTIONAL = 2,

        [Value(2)]
        IS_SHAREABLE = 4,

        [Value(3)]
        IS_UNION_DEFAULT = 8
    }

    public static class MemberFlagExtensions
    {
        public static bool IsKey(this MemberFlag flag)
        {
            return (flag & MemberFlag.IS_KEY) == MemberFlag.IS_KEY;
        }
        public static bool IsOptional(this MemberFlag flag)
        {
            return (flag & MemberFlag.IS_OPTIONAL) == MemberFlag.IS_OPTIONAL;
        }
        public static bool IsSharable(this MemberFlag flag)
        {
            return (flag & MemberFlag.IS_SHAREABLE) == MemberFlag.IS_SHAREABLE;
        }
        public static bool IsUnionDefault(this MemberFlag flag)
        {
            return (flag & MemberFlag.IS_UNION_DEFAULT) == MemberFlag.IS_UNION_DEFAULT;
        }
    }
}