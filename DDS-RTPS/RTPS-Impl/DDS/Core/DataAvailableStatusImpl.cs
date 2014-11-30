using org.omg.dds.core.status;
using org.omg.dds.sub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.DDS.Core
{
    public class DataAvailableStatusImpl<TYPE> : DataAvailableStatus<TYPE>
    {
        public DataAvailableStatusImpl(DataReader<TYPE> source)
            : base(source)
        {
        }

        public override DataReader<TYPE> getSource()
        {
            return source as DataReader<TYPE>;
        }

        public override DataAvailableStatus<TYPE> CopyFrom(DataAvailableStatus<TYPE> other)
        {
            throw new NotImplementedException();
        }

        public override DataAvailableStatus<TYPE> finishModification()
        {
            throw new NotImplementedException();
        }

        public override DataAvailableStatus<TYPE> Clone()
        {
            throw new NotImplementedException();
        }

        public override DataAvailableStatus<TYPE> Modify()
        {
            throw new NotImplementedException();
        }

        public override org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
