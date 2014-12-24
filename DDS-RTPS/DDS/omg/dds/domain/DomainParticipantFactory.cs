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
    ///  can be accessed by means of the {@link #GetInstance(Bootstrap)} operation
    ///  on the DomainParticipantFactory.
    /// </summary>
    public abstract class DomainParticipantFactory : DDSObject
    {
        /// <summary>
        /// Singleton Access
        /// </summary>
        /// <param name="bootstrap">Identifies the Service instance to which the
        ///                         object will belong</param>
        /// <returns></returns>
        public static DomainParticipantFactory GetInstance(Bootstrap bootstrap)
        {
            return bootstrap.GetSPI().GetParticipantFactory();
        }



        // -----------------------------------------------------------------------
        // Instance Methods
        // -----------------------------------------------------------------------

        /// <summary>
        /// Create a new participant in the domain with ID 0 having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>New participant</returns>
        public abstract DomainParticipant CreateParticipant();

        /// <summary>
        /// Create a new participant in the domain with a fixed ID and having default QoS
        /// and no listener.
        /// </summary>
        /// <returns>New participant</returns>
        public abstract DomainParticipant CreateParticipant(int domainId);

        
        /// <summary>
        /// Create a new domain participant.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="qos"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status 
        ///                        changes</param>
        /// <returns></returns>
        public abstract DomainParticipant CreateParticipant(
                int domainId,
                DomainParticipantQos qos,
                DomainParticipantListener listener,
                ICollection<Type> statuses);

        
         
        /// <summary>
        /// Create a new domain participant.
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        /// <param name="listener"></param>
        /// <param name="statuses">Of which status changes the listener should be
        ///                        notified. A null collection signifies all status
        ///                        changes</param>
        /// <returns></returns>
        public abstract DomainParticipant CreateParticipant(
                int domainId,
                string qosLibraryName,
                string qosProfileName,
                DomainParticipantListener listener,
                ICollection<Type> statuses);

        public abstract DomainParticipant LookupParticipant(int domainId);

        public abstract DomainParticipantFactoryQos Qos {get ; set; }

        public abstract DomainParticipantQos GetDefaultParticipantQos();

        public abstract void SetDefaultParticipantQos(DomainParticipantQos qos);

        public abstract void SetDefaultParticipantQos(string qosLibraryName, string qosProfileName);


        public abstract Bootstrap GetBootstrap();
    }
}