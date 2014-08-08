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
using org.omg.dds.core.status;
using System.Collections.Generic;

namespace org.omg.dds.core
{
    // TODO: Este interface no tiene todo lo que debería tener segun la especificacion
    public interface IEntity : DDSObject
    {
    }

    /// <summary>
    /// This class is the abstract base class for all the DCPS objects that
    ///  support QoS policies, a listener and a status condition.
    /// </summary>
    /// <typeparam name="SELF">The most-derived DDS-standard interface implemented by this entity.</typeparam>
    /// <typeparam name="LISTENER">The listener interface appropriate for this entity.</typeparam>
    /// <typeparam name="QOS">The QoS interface appropriate for this entity.</typeparam>
    public interface Entity<SELF, LISTENER, QOS> : IEntity
        where SELF : Entity<SELF, LISTENER, QOS>
        where LISTENER : EventListener
        where QOS : EntityQos
    // TODO: Entity deberia ser IDisposable, no??. Comprobar esto 
    {
        LISTENER getListener();
        void setListener(LISTENER listener);

        // TODO: Cambiar get/setListener por una propiedad llamada Listener 
#if TODO
        LISTENER Listener { get; set; }
#endif

        // TODO: Cambiar get/setQos por una propiedad llamada Qos 
#if TODO
        QOS Qos { get; set; }
#endif

        QOS getQos();

        /// <summary>
        /// Set the QoS to that specified in the given QoS
        /// </summary>
        /// <param name="qos"></param>
        void setQos(QOS qos);

        /// <summary>
        /// Set the QoS to that specified in the given QoS profile in the given
        /// QoS library
        /// </summary>
        /// <param name="qosLibraryName"></param>
        /// <param name="qosProfileName"></param>
        void setQos(string qosLibraryName, string qosProfileName);

        void Enable();

        StatusCondition<SELF> getStatusCondition();

        ICollection<TYPE> getStatusChanges<TYPE>(ICollection<TYPE> statuses);

        InstanceHandle getInstanceHandle();

        /// <summary>
        /// Halt communication and dispose the resources held by this entity.
        /// </summary>
        void Close();

        /// <summary>
        /// Indicates that references to this object may go out of scope but that
        /// the application expects to look it up again later. Therefore, the
        /// Service must consider this object to be still in use and may not
        /// Close it automatically.
        /// </summary>
        void Retain();
    }
}