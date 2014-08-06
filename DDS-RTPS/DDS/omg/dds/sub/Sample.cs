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
        /**
         * @return  the data associated with this sample. This method will return
         *          null if this sample contains no valid data.
         */
        TYPE getData();


        // --- Sample meta-data: -------------------------------------------------
        /**
         * @return the sampleState
         */
        SampleState getSampleState();

        /**
         * @return the viewState
         */
        ViewState getViewState();

        /**
         * @return the instanceState
         */
        InstanceState getInstanceState();

        ModifiableTime getSourceTimestamp();

        ModifiableInstanceHandle getInstanceHandle();

        ModifiableInstanceHandle getPublicationHandle();

        /**
         * @return the disposedGenerationCount
         */
        int getDisposedGenerationCount();

        /**
         * @return the noWritersGenerationCount
         */
        int getNoWritersGenerationCount();

        /**
         * @return the sampleRank
         */
        int getSampleRank();

        /**
         * @return the generationRank
         */
        int getGenerationRank();

        /**
         * @return the absoluteGenerationRank
         */
        int getAbsoluteGenerationRank();



    }


    // -----------------------------------------------------------------------
    // Types
    // -----------------------------------------------------------------------

    public interface SampleIterator<IT_DATA> : IEnumerable<Sample<IT_DATA>>
    {
        /**
         * The samples provided by this iterator have been loaned from a
         * pool maintained by the Service; return that loan now.
         */
        void returnLoan();

        // --- From ListIterator: --------------------------------------------
        /**
         * @exception UnsupportedOperationException always.
         */
        void remove();

        /**
         * @exception UnsupportedOperationException always.
         */
        void set(Sample<IT_DATA> o);

        /**
         * @exception UnsupportedOperationException always.
         */
        void add(Sample<IT_DATA> o);
    }
}