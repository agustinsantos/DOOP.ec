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

        public TYPE GetData()
        {
            return data;
        }

        public SampleState GetSampleState()
        {
            throw new NotImplementedException();
        }

        public ViewState GetViewState()
        {
            throw new NotImplementedException();
        }

        public InstanceState GetInstanceState()
        {
            throw new NotImplementedException();
        }

        public ModifiableTime GetSourceTimestamp()
        {
            throw new NotImplementedException();
        }

        public ModifiableInstanceHandle GetInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public ModifiableInstanceHandle GetPublicationHandle()
        {
            throw new NotImplementedException();
        }

        public int GetDisposedGenerationCount()
        {
            throw new NotImplementedException();
        }

        public int GetNoWritersGenerationCount()
        {
            throw new NotImplementedException();
        }

        public int GetSampleRank()
        {
            throw new NotImplementedException();
        }

        public int GetGenerationRank()
        {
            throw new NotImplementedException();
        }

        public int GetAbsoluteGenerationRank()
        {
            throw new NotImplementedException();
        }
    }

    public class SampleIteratorImpl<IT_DATA> : List<Sample<IT_DATA>>, SampleIterator<IT_DATA>
    {
        public void ReturnLoan()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public void Set(Sample<IT_DATA> o)
        {
            throw new NotImplementedException();
        }

        public void Add(Sample<IT_DATA> o)
        {
            this.Add(o);
        }
    }
}
