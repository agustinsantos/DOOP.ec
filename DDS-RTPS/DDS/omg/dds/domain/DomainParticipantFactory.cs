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
using org.omg.dds.core.status;
using System;
using System.Collections.Generic;

namespace org.omg.dds.domain
{
    /// <summary>
    /// The sole purpose of this class is to allow the creation and destruction of
    ///  {@link DomainParticipant} objects. DomainParticipantFactory itself has no
    ///  factory. It is a pre-existing per-{@link Bootstrap} singleton object that
    ///  can be accessed by means of the {@link #getInstance(Bootstrap)} operation
    ///  on the DomainParticipantFactory.
    /// </summary>
    public abstract class DomainParticipantFactory : DDSObject
    {
        /// <summary>
        /// Singleton Access
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the
        ///                  object will belong.</param>
        /// <returns></returns>
        public static DomainParticipantFactory getInstance(Bootstrap bootstrap)
        {
            return bootstrap.getSPI().getParticipantFactory();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// Create a new participant in the domain with ID 0 having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>new participant</returns>
        public abstract DomainParticipant createParticipant();

        /// <summary>
        /// Create a new participant in the domain with a fixed ID and having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>new participant</returns>
        public abstract DomainParticipant createParticipant(int domainId);

        /**
         * Create a new domain participant.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        public abstract DomainParticipant createParticipant(
                int domainId,
                DomainParticipantQos qos,
                DomainParticipantListener listener,
                ICollection<Type> statuses);

        /**
         * Create a new domain participant.
         * 
         * @param statuses  Of which status changes the listener should be
         *                  notified. A null collection signifies all status
         *                  changes.
         */
        public abstract DomainParticipant createParticipant(
                int domainId,
                string qosLibraryName,
                string qosProfileName,
                DomainParticipantListener listener,
                ICollection<Type> statuses);

        public abstract DomainParticipant lookupParticipant(int domainId);

        public abstract DomainParticipantFactoryQos getQos();
        public abstract void setQos(DomainParticipantFactoryQos qos);

        public abstract DomainParticipantQos getDefaultParticipantQos();

        public abstract void setDefaultParticipantQos(DomainParticipantQos qos);

        public abstract void setDefaultParticipantQos(string qosLibraryName, string qosProfileName);


        public abstract Bootstrap getBootstrap();
    }
}