using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.SharedMem
{
    internal class FakeEngine : IRtpsEngine
    {
        protected FakeDiscovery discoveryModule = new FakeDiscovery();


        public IRtpsDiscovery DiscoveryModule
        {
            get { return discoveryModule; }
        }
    }
}
