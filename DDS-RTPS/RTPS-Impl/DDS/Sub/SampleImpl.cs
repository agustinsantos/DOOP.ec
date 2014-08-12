using Doopec.DDS.Core;
using org.omg.dds.core.modifiable;
using org.omg.dds.sub;
using Rtps.Structure;
using System;
using System.Collections.Generic;

namespace Doopec.DDS.Sub
{
    public class SampleImpl<TYPE> : ModifiableValueImpl<Sample<TYPE>, Sample<TYPE>>, Sample<TYPE>
    {
        private TYPE data;

        public SampleImpl(CacheChange<TYPE> change)
        {
            this.data = (TYPE)change.DataValue.Value;
        }

        public TYPE getData()
        {
            return data;
        }

        public SampleState getSampleState()
        {
            throw new NotImplementedException();
        }

        public ViewState getViewState()
        {
            throw new NotImplementedException();
        }

        public InstanceState getInstanceState()
        {
            throw new NotImplementedException();
        }

        public ModifiableTime getSourceTimestamp()
        {
            throw new NotImplementedException();
        }

        public ModifiableInstanceHandle getInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public ModifiableInstanceHandle getPublicationHandle()
        {
            throw new NotImplementedException();
        }

        public int getDisposedGenerationCount()
        {
            throw new NotImplementedException();
        }

        public int getNoWritersGenerationCount()
        {
            throw new NotImplementedException();
        }

        public int getSampleRank()
        {
            throw new NotImplementedException();
        }

        public int getGenerationRank()
        {
            throw new NotImplementedException();
        }

        public int getAbsoluteGenerationRank()
        {
            throw new NotImplementedException();
        }
    }

    public class SampleIteratorImpl<IT_DATA> : List<Sample<IT_DATA>>, SampleIterator<IT_DATA>
    {
        public void returnLoan()
        {
            throw new NotImplementedException();
        }

        public void remove()
        {
            throw new NotImplementedException();
        }

        public void set(Sample<IT_DATA> o)
        {
            throw new NotImplementedException();
        }

        public void add(Sample<IT_DATA> o)
        {
            this.Add(o);
        }
    }
}
