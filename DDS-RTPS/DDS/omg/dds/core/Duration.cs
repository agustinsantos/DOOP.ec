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


using DDS.ConversionUtils;

using org.omg.dds.core.modifiable;
using org.omg.dds.type;


namespace org.omg.dds.core
{
    /// <summary>
    ///  A span of elapsed time expressed with nanosecond precision.
    /// </summary>
    [Extensibility(ExtensibilityKind.FINAL_EXTENSIBILITY)]
    [Nested]
    public abstract class Duration : Value<Duration, ModifiableDuration>
    {
        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /// 
        /// Example
        /// 

        /// <summary>
        ///  Construct a time duration of the given magnitude.
        ///  
        /// A duration of magnitude {@link Long#MAX_VALUE} indicates an infinite
        /// duration, regardless of the units specified.
        /// 
        /// @see     #IsInfinite()
        /// @see     #InfiniteDuration(Bootstrap)
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="unit"></param>
        /// <param name="bootstrap">Identifies the Service instance to which the new object will belong</param>
        /// <returns></returns>
        public static ModifiableDuration NewDuration(long duration, TimeUnit unit, Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewDuration(duration, unit);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns>An unmodifiable {@link Duration} of infinite length</returns>
        public static Duration InfiniteDuration(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().InfiniteDuration();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns>A {@link Duration} of zero length</returns>
        public static Duration ZeroDuration(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().ZeroDuration();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        // --- Data access: ------------------------------------------------------

        /// <summary>
        /// Truncate this duration to a whole-number quantity of the given time
        /// unit. For example, if this duration is equal to one second plus 100
        /// nanoseconds, calling this method with an argument of
        /// {@link TimeUnit#SECONDS} will result in the Value <code>1</code>.
        /// 
        /// If this duration is infinite, this method shall return
        /// {@link Long#MAX_VALUE}, regardless of the units given.
        /// 
        /// If this duration cannot be expressed in the given units without
        /// overflowing, this method shall return {@link Long#MAX_VALUE}. In such
        /// a case, the caller may wish to use this method in combination with
        /// {@link #GetRemainder(TimeUnit, TimeUnit)} to obtain the full duration
        /// without lack of precision.
        /// 
        /// @see     #GetRemainder(TimeUnit, TimeUnit)
        /// @see     Long#MAX_VALUE
        /// @see     TimeUnit
        /// </summary>
        /// <param name="inThisUnit">The time unit in which the return result will be measured</param>
        /// <returns></returns>
        public abstract long GetDuration(TimeUnit inThisUnit);

        /// <summary>
        /// If getting the magnitude of this duration in the given
        /// <code>primaryUnit</code> would cause truncation with respect to the
        /// given <code>remainderUnit</code>, return the magnitude of the
        /// truncation in the latter (presumably finer-grained) unit. For example,
        /// if this duration is equal to one second plus 100 nanoseconds, calling
        /// this method with arguments of {@link TimeUnit#SECONDS} and
        /// {@link TimeUnit#NANOSECONDS} respectively will result in the Value
        /// <code>100</code>.
        /// 
        /// This method is equivalent to the following pseudo-code:
        /// 
        /// <code>
        /// (this - GetDuration(primaryUnit)).GetDuration(remainderUnit)
        /// </code>
        /// 
        /// If <code>remainderUnit</code> is represents a coarser granularity than
        /// <code>primaryUnit</code> (for example, the former is
        /// {@link TimeUnit#HOURS} but the latter is {@link TimeUnit#SECONDS}),
        /// this method shall return <code>0</code>.
        /// If the resulting duration cannot be expressed in the given units
        /// without overflowing, this method shall return {@link Long#MAX_VALUE}.
        /// 
        /// @see     #GetDuration(TimeUnit)
        /// @see     Long#MAX_VALUE
        /// @see     TimeUnit
        /// </summary>
        /// <param name="primaryUnit"></param>
        /// <param name="remainderUnit">The time unit in which the return result will be measured</param>
        /// <returns></returns>
        public abstract long GetRemainder(TimeUnit primaryUnit, TimeUnit remainderUnit);


        // --- Query: ------------------------------------------------------------

        /// <summary>
        /// Report whether this duration lasts no time at all. The result of this
        /// method is equivalent to the following:
        /// <code>this.GetDuration(TimeUnit.NANOSECONDS) == 0;</code>
        /// 
        /// @see     #GetDuration(TimeUnit)
        /// </summary>
        /// <returns></returns>
        public abstract bool IsZero();

        /// <summary>
        /// Report whether this duration lasts forever.
        /// 
        /// If this duration is infinite, the following relationship shall be
        /// true:
        /// 
        /// <code>this.equals(InfiniteDuration(this.GetBootstrap()))</code>
        /// 
        /// @see     #InfiniteDuration(Bootstrap)
        /// </summary>
        /// <returns></returns>
        public abstract bool IsInfinite();


        // --- From Object: ------------------------------------------------------


        //public abstract Duration clone();


        public abstract ModifiableDuration Modify();

        public abstract Bootstrap GetBootstrap();
    }
}