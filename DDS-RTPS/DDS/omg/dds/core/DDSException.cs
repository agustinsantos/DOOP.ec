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


using org.omg.dds.core.policy;
using org.omg.dds.sub;
using System;

namespace org.omg.dds.core
{

    /*
     * DDS recognizes a number of ways in which an operation may return, which
     * are mapped to exceptions in the following way:
     * 
     * <table border="1" cellspacing="0" cellpadding="2">
     * <tr><th>Return</th><th>Description</th><th>Exception</th></tr>
     * <tr>
     *     <td>OK</td>
     *     <td>Normal, successful return.</td>
     *     <td>(<em>none</em>)</td>
     * </tr>
     * <tr>
     *     <td>NO_DATA</td>
     *     <td>Normal, successful return from a data access method such as
     *         {@link DataReader#take()}, but no data was available.
     *     </td>
     *     <td>(<em>none</em>)</td>
     * </tr>
     * <tr>
     *     <td>TIMEOUT</td>
     *     <td>Blocking operation failed to complete within the specified timeout
     *         duration.
     *     </td>
     *     <td>{@link java.util.concurrent.TimeoutException}</td>
     * </tr>
     * <tr>
     *     <td>BAD_PARAMETER</td>
     *     <td>An argument passed to a method was out of range or had a value
     *         that was otherwise illegal.
     *     </td>
     *     <td>{@link java.lang.IllegalArgumentException}</td>
     * </tr>
     * <tr>
     *     <td>UNSUPPORTED</td>
     *     <td>The method is not supported by this DDS implementation.
     *     </td>
     *     <td>{@link java.lang.UnsupportedOperationException}</td>
     * </tr>
     * <tr>
     *     <td>NOT_ENABLED</td>
     *     <td>The {@link Entity} has not yet been enabled for communication.</td>
     *     <td>{@link NotEnabledException}</td>
     * </tr>
     * <tr>
     *     <td>ALREADY_DELETED</td>
     *     <td>The object on which the method is invoked has already been closed.
     *     </td>
     *     <td>{@link AlreadyClosedException}</td>
     * </tr>
     * <tr>
     *     <td>ILLEGAL_OPERATION</td>
     *     <td>The method cannot be invoked in the current calling context (e.g.
     *         from within a listener callback).
     *     </td>
     *     <td>{@link IllegalOperationException}</td>
     * </tr>
     * <tr>
     *     <td>PRECONDITION_NOT_MET</td>
     *     <td>The object is not in the proper state to invoke the method.</td>
     *     <td>{@link PreconditionNotMetException}</td>
     * </tr>
     * <tr>
     *     <td>IMMUTABLE_POLICY</td>
     *     <td>An attempt was made to change a {@link QosPolicy} that cannot be
     *         changed.</td>
     *     <td>{@link ImmutablePolicyException}</td>
     * </tr>
     * <tr>
     *     <td>INCONSISTENT_POLICY</td>
     *     <td>Two or more {@link QosPolicy} property values have been specified
     *         that are inconsistent with one another.
     *     </td>
     *     <td>{@link ImmutablePolicyException}</td>
     * </tr>
     * <tr>
     *     <td>OUT_OF_RESOURCES</td>
     *     <td>An internal resource of the DDS implementation has been exhausted,
     *         preventing the successful completion of the method.
     *     </td>
     *     <td>{@link OutOfResourcesException}</td>
     * </tr>
     * <tr>
     *     <td>ERROR</td>
     *     <td>The method failed to complete successfully for another reason.</td>
     *     <td>{@link DDSException} (this class)</td>
     * </tr>
     * </table>
     */
    /// <summary>
    ///  DDS recognizes a number of ways in which an operation may return, which
    ///  are mapped to exceptions in the following way:
    /// <para>OK. Normal, successful return.</para> 
    /// <para>NO_DATA. Normal, successful return from a data access method such as DataReader take(), but no data was available.</para> 
    /// </summary>
    public abstract class DDSException : SystemException, DDSObject
    {
        protected DDSException()
            : base()
        {
        }

        protected DDSException(string message)
            : base(message)
        {
        }

        public DDSException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public abstract Bootstrap getBootstrap();
    }
}