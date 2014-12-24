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


using System;
using System.Runtime.Serialization;

namespace org.omg.dds.core
{
    public interface Value : DDSObject //, ICloneable
    {
        // --- From Object: ------------------------------------------------------

        /// <summary>
        /// Implementing classes should override <code>equals()</code>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

          bool Equals(Object other);

        /// <summary>
        /// Implementing classes should override <code>hashCode()</code>
        /// </summary>
        /// <returns></returns>

          int GetHashCode();

        /// <summary>
        /// Extends the concept of "cloneable" defined in <code>java.lang</code> by
        /// providing an explicit public {@link #clone()} method.
        /// </summary>
        /// <returns>A new object that with state identical to that of this object</returns>
        //Value Clone();


        // --- Conversion: -------------------------------------------------------

        /// <summary>
        /// If this Value type is of a modifiable subtype, return this.
        /// If this Value type has a modifiable subtype, return a new object
        /// of that type that is a modifiable copy of this object.
        /// Otherwise, return null
        /// </summary>
        /// <returns><code>this</code>, a new modifiable copy of <code>this</code>,
        ///          or <code>null</code></returns>
        //Value modify();
    }

    /// <summary>
    /// Implementing classes have Value semantics: they can be deeply copied, and
    /// equality is determined based on their contents, not on their object identity.
    /// </summary>
    /// <typeparam name="UNMOD_SELF"></typeparam>
    /// <typeparam name="MOD_SELF"></typeparam>
    public interface Value<UNMOD_SELF, MOD_SELF> : Value
        where UNMOD_SELF : Value<UNMOD_SELF, MOD_SELF>
        where MOD_SELF : UNMOD_SELF
    {
        // --- From Object: ------------------------------------------------------

        /// <summary>
        /// Implementing classes should override <code>equals()</code>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        //bool Equals(Object other);

        /// <summary>
        /// Implementing classes should override <code>hashCode()</code>
        /// </summary>
        /// <returns></returns>
        //int GetHashCode();

        /// <summary>
        /// Extends the concept of "cloneable" defined in <code>java.lang</code> by
        /// providing an explicit public {@link #clone()} method
        /// </summary>
        /// <returns>A new object that with state identical to that of this object</returns>
         //UNMOD_SELF clone();


        // --- Conversion: -------------------------------------------------------

        /// <summary>
        /// If this Value type is of a modifiable subtype, return this.
        /// If this Value type has a modifiable subtype, return a new object
        /// of that type that is a modifiable copy of this object.
        /// Otherwise, return null.
        /// </summary>
        /// <returns><code>this</code>, a new modifiable copy of <code>this</code>, or <code>null</code></returns>
        MOD_SELF Modify();
    }
}