using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Structure.Types
{
    public class Data
    {
        public Object Value { get; internal set; }

        public Data(Object data)
        {
            Value = data;
        }
    }
}
