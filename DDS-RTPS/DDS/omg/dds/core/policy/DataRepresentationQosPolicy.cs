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

using org.omg.dds.core.policy.modifiable;

namespace org.omg.dds.core.policy
{

    public interface DataRepresentationQosPolicy : QosPolicy<DataRepresentationQosPolicy, ModifiableDataRepresentationQosPolicy>
    {
        /// <summary>
        /// Properties
        /// 
        /// </summary>
        /// <returns></returns>
        List<short> getValue();
    }

    public sealed class DataRepresentationQosPolicyConst
    {
        public const short XCDR_DATA_REPRESENTATION = 0;
        public const short XML_DATA_REPRESENTATION = 1;
    }
}