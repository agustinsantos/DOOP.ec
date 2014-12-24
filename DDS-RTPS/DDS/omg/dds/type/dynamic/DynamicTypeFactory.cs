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


using org.omg.dds.core;
using org.omg.dds.type;

namespace org.omg.dds.type.dynamic
{

    public abstract class DynamicTypeFactory : DDSObject
    {
        // -----------------------------------------------------------------------
        // Singleton Access
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the
        ///                         object will belong
        /// </param>
        /// <returns></returns>
        public static DynamicTypeFactory GetInstance(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().GetTypeFactory();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        public abstract DynamicType GetPrimitiveType(TypeKind kind);

        public abstract DynamicType CreateType(TypeDescriptor descriptor);
        public abstract DynamicType CreatestringType(int bound);
        public abstract DynamicType CreateWstringType(int bound);
        public abstract DynamicType CreateSequenceType(DynamicType elementType, int bound);
        public abstract DynamicType CreateArrayType(DynamicType elementType, params int[] bound);
        public abstract DynamicType CreateMapType(DynamicType keyElementType, DynamicType elementType, int bound);
        public abstract DynamicType CreateBitSetType(int bound);

        public abstract DynamicType LoadTypeFromUrl(string documentUrl, string typeName, params string[] includePaths);
        public abstract DynamicType LoadTypeFromDocument(string document, string typeName, params string[] includePaths);

        public abstract Bootstrap GetBootstrap();
    }
}