using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.SharedMem
{
    internal class SharedMemoryEngine : IRtpsEngine
    {
        protected SharedMemoryDiscovery discoveryModule = new SharedMemoryDiscovery();


        public SharedMemoryDiscovery DiscoveryModule
        {
            get { return discoveryModule; }
        }
    }
}
