using Doopec.DDS.Core;
using org.omg.dds.sub;
using System;

namespace Doopec.DDS.Sub
{
    public class SampleImpl<TYPE> :  ModifiableValueImpl<Sample<TYPE>, Sample<TYPE>>, Sample<TYPE>
    {
        public TYPE getData()
        {
            throw new NotImplementedException();
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

        public org.omg.dds.core.modifiable.ModifiableTime getSourceTimestamp()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle getInstanceHandle()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.modifiable.ModifiableInstanceHandle getPublicationHandle()
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
}
