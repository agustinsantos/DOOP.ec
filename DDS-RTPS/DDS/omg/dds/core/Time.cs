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
    /// A moment in time expressed with nanosecond precision (though not
    /// necessarily nanosecond accuracy).
    /// </summary>
    [Extensibility(ExtensibilityKind.FINAL_EXTENSIBILITY)]
    [Nested]
    public abstract class Time : Value<Time, ModifiableTime>
    {


        // -----------------------------------------------------------------------
        // Factory Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// Construct a specific instant in time.
        /// 
        /// Negative values are considered invalid and will result in the
        /// construction of a time <code>t</code> such that:
        /// 
        /// <code>t.IsValid() == false</code>
        /// 
        /// @see     #IsValid()
        /// </summary>
        /// <param name="time"></param>
        /// <param name="units"></param>
        /// <param name="bootstrap">Identifies the Service instance to which the new object will belong</param>
        /// <returns></returns>
        public static ModifiableTime NewTime(long time, TimeUnit units, Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().NewTime(time, units);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the object will belong</param>
        /// <returns>An unmodifiable {@link Time} that is not valid</returns>
        public static Time InvalidTime(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().InvalidTime();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        // --- Data access: ------------------------------------------------------

        /// <summary>
        /// Truncate this time to a whole-number quantity of the given time
        /// unit. For example, if this time is equal to one second plus 100
        /// nanoseconds since the start of the epoch, calling this method with an
        /// argument of {@link TimeUnit#SECONDS} will result in the value
        /// <code>1</code>.
        /// 
        /// If this time is invalid, this method shall return
        /// a negative value, regardless of the units given.
        /// 
        /// If this time cannot be expressed in the given units without
        /// overflowing, this method shall return {@link Long#MAX_VALUE}. In such
        /// a case, the caller may wish to use this method in combination with
        /// {@link #GetRemainder(TimeUnit, TimeUnit)} to obtain the full time
        /// without lack of precision.
        /// 
        /// @see     #GetRemainder(TimeUnit, TimeUnit)
        /// @see     Long#MAX_VALUE
        /// @see     TimeUnit
        /// </summary>
        /// <param name="inThisUnit">The time unit in which the return result will
        ///                          be measured</param>
        /// <returns></returns>
        public abstract long GetTime(TimeUnit inThisUnit);

        /// <summary>
        /// If getting the magnitude of this time in the given
        /// <code>primaryUnit</code> would cause truncation with respect to the
        /// given <code>remainderUnit</code>, return the magnitude of the
        /// truncation in the latter (presumably finer-grained) unit. For example,
        /// if this time is equal to one second plus 100 nanoseconds since the
        /// start of the epoch, calling this method with arguments of
        /// {@link TimeUnit#SECONDS} and {@link TimeUnit#NANOSECONDS} respectively
        /// will result in the value <code>100</code>.
        /// 
        /// This method is equivalent to the following pseudo-code:
        /// 
        /// <code>(this - GetTime(primaryUnit)).GetTime(remainderUnit)</code>
        /// 
        /// If <code>remainderUnit</code> is represents a coarser granularity than
        /// <code>primaryUnit</code> (for example, the former is
        /// {@link TimeUnit#HOURS} but the latter is {@link TimeUnit#SECONDS}),
        /// this method shall return <code>0</code>.
        /// 
        /// If the resulting time cannot be expressed in the given units
        /// without overflowing, this method shall return {@link Long#MAX_VALUE}.
        /// 
        /// @see     #GetTime(TimeUnit)
        /// @see     Long#MAX_VALUE
        /// @see     TimeUnit
        /// </summary>
        /// <param name="primaryUnit"></param>
        /// <param name="remainderUnit">The time unit in which the return result will be measured</param>
        /// <returns></returns>
        public abstract long GetRemainder(TimeUnit primaryUnit, TimeUnit remainderUnit);


        // --- Query: ------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Whether this time represents a meaningful instant in time</returns>
        public abstract bool IsValid();


        // --- From Object: ------------------------------------------------------

        //public abstract Time clone();

        public abstract Bootstrap GetBootstrap();

        public abstract ModifiableTime Modify();
    }
}