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
    public class FakeRtpsWriter<T> : StatefulWriter<T>, IDisposable
    {
        private IList<Reader<T>> readers = new List<Reader<T>>();
        private WriterWorker worker = new WriterWorker();

        public FakeRtpsWriter(Participant participant)
            : base(participant)
        {
            FakeDiscovery discoveryModule = ((FakeEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.RegisterEndpoint(this);
            discoveryModule.EndpointDiscovery += OnDiscoveryEndpoints;
            AddReaders(discoveryModule);

            worker.Start((int)this.heartbeatPeriod.AsMillis());
        }

        public void Dispose()
        {
            readers.Clear();
            FakeDiscovery discoveryModule = ((FakeEngine)RtpsEngine.Instance).DiscoveryModule;
            discoveryModule.UnregisterEndpoint(this);
            discoveryModule.EndpointDiscovery -= OnDiscoveryEndpoints;
            worker.End();
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

        private void AddReaders(FakeDiscovery discoveryModule)
        {
            foreach (var endpoint in discoveryModule.Endpoints)
            {
                if (endpoint is Reader<T>)
                    AddReader(endpoint as Reader<T>);
            }
        }
    }
}
