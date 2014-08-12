using Doopec.Rtps.SharedMem;
using Rtps.Behavior;
using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Behavior
{
    public class SharedMemoryWriter<T> : StatefulWriter<T>, IDisposable
    {
        private IList<Reader<T>> readers = new List<Reader<T>>();

        public SharedMemoryWriter(Participant participant)
            : base(participant)
        {
            SharedMemoryDiscovery discoveryModule = ((SharedMemoryEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.RegisterEndpoint(this);
            discoveryModule.EndpointDiscovery += OnDiscoveryEndpoints;
            AddReaders(discoveryModule);
        }

        public void Dispose()
        {
            readers.Clear();
            SharedMemoryDiscovery discoveryModule = ((SharedMemoryEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.UnregisterEndpoint(this);
            discoveryModule.EndpointDiscovery -= OnDiscoveryEndpoints;
        }

        private void OnDiscoveryEndpoints(object sender, DiscoveryEventArgs e)
        {
            Reader<T> reader = e.EventData as Reader<T>;
            if (reader == null) 
                return;
             if (e.Reason == EventReason.NEW_ENDPOINT)
                 readers.Add(reader);
             else if (e.Reason == EventReason.NEW_ENDPOINT)
                 readers.Remove(reader);
        }

        private void AddReader(Reader<T> writer)
        {
            readers.Add(writer);
        }

        private void AddReaders(SharedMemoryDiscovery discoveryModule)
        {
            foreach (var endpoint in discoveryModule.Endpoints)
            {
                if (endpoint is Reader<T>)
                    AddReader(endpoint as Reader<T>);
            }
        }
    }
}
