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
 * limitations under the License.C:\Users\Agustin\Documents\Visual Studio 2012\Projects\RTPS\DDS\omg\dds\core\policy\modifiable\ModifiableLivelinessQosPolicy.java
 */

using org.omg.dds.core;

namespace org.omg.dds.core.modifiable
{
    /// <summary>
    /// A value type that supports modification.
    /// <param><UNMOD_SELF></param>   The unmodifiable supertype of this interface.
    /// <param><MOD_SELF></param>     This interface.
    /// </summary>
    /// <typeparam name="UNMOD_SELF"></typeparam>
    /// <typeparam name="MOD_SELF"></typeparam>
    public interface ModifiableValue<UNMOD_SELF, MOD_SELF> : Value<UNMOD_SELF, MOD_SELF>
        where UNMOD_SELF : Value<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        /// <summary>
        /// Overwrite this object's state with the contents of the given object.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>this</returns>
        MOD_SELF copyFrom(UNMOD_SELF other);

        /// <summary>
        /// If this value type has an unmodifiable counterpart class, return a new
        /// object of that class containing a copy of the state of this object. If
        /// not return null.
        /// Calling this method is optional in general; because modifiable
        /// interfaces extend "unmodifiable" ones, the former can typically be
        /// used wherever the latter is required.
        /// </summary>
        /// <returns>a new unmodifiable copy of this object or null.</returns>
        UNMOD_SELF finishModification();


        // --- From Value: ---------------------------------------------------

       // MOD_SELF clone();
    }
}