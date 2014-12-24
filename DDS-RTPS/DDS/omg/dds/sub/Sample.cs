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


using System.Collections;

using org.omg.dds.core.modifiable;
using System.Collections.Generic;

namespace org.omg.dds.sub
{

    public interface Sample<TYPE> : ModifiableValue<Sample<TYPE>, Sample<TYPE>>
    {
        // -----------------------------------------------------------------------
        // Methods
        // -----------------------------------------------------------------------

        // --- Sample data: ------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The data associated with this sample. This method will return
        ///          null if this sample contains no valid data
        /// </returns>
        TYPE GetData();


        // --- Sample meta-data: -------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <returns>The sampleState</returns>
        SampleState GetSampleState();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The viewState</returns>
        ViewState GetViewState();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The instanceState</returns>
        InstanceState GetInstanceState();

        ModifiableTime GetSourceTimestamp();

        ModifiableInstanceHandle GetInstanceHandle();

        ModifiableInstanceHandle GetPublicationHandle();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The disposedGenerationCount</returns>
        int GetDisposedGenerationCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The noWritersGenerationCount</returns>
        int GetNoWritersGenerationCount();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The sampleRank</returns>
        int GetSampleRank();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The generationRank</returns>
        int GetGenerationRank();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The absoluteGenerationRank</returns>
        int GetAbsoluteGenerationRank();



    }


    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public interface SampleIterator<IT_DATA> : IEnumerable<Sample<IT_DATA>>
    {
        /// <summary>
        /// The samples provided by this iterator have been loaned from a 
        /// pool maintained by the Service; return that loan now
        /// </summary>
        void ReturnLoan();

        // --- From ListIterator: --------------------------------------------
        /// <summary>
        /// @exception UnsupportedOperationException always
        /// </summary>
        void Remove();

        /// <summary>
        /// @exception UnsupportedOperationException always
        /// </summary>
        /// <param name="o"></param>
        void Set(Sample<IT_DATA> o);
        ///TODO how i can comment the tag @exception
        /// <summary>
        /// @exception UnsupportedOperationException always
        /// </summary>
        /// <param name="o"></param>
        void Add(Sample<IT_DATA> o);
    }
}