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



using org.omg.dds.core;

namespace org.omg.dds.core.modifiable
{
    public abstract class ModifiableInstanceHandle : InstanceHandle, ModifiableValue<InstanceHandle, ModifiableInstanceHandle>
    {
        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        // --- From Object: ------------------------------------------------------

        public abstract ModifiableInstanceHandle CopyFrom(InstanceHandle other);

        public abstract InstanceHandle FinishModification();

        //        public abstract Value modify();

        //        public abstract Value Clone();

        //        protected abstract ModifiableInstanceHandle ModifiableValue<InstanceHandle, ModifiableInstanceHandle>.clone();

        //       protected abstract Bootstrap GetBootstrap();
    }
}