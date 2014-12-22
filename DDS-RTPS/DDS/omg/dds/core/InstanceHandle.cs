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

namespace org.omg.dds.core
{


    public abstract class InstanceHandle : Value<InstanceHandle, ModifiableInstanceHandle>
    {
        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the new object will belong</param>
        /// <returns></returns>
        public static ModifiableInstanceHandle NewInstanceHandle(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewInstanceHandle();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns>An unmodifiable nil instance handle</returns>
        public static InstanceHandle NilHandle(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().nilHandle();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        public abstract bool IsNil();


        // --- From Object: ------------------------------------------------------


        //public abstract InstanceHandle clone();

        //public abstract InstanceHandle Clone();

        public abstract ModifiableInstanceHandle Modify();

        public abstract Bootstrap GetBootstrap();
    }
}