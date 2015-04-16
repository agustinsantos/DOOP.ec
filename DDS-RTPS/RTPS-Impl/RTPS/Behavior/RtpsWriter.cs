﻿using Doopec.Rtps.Encoders;
using Doopec.Rtps.RtpsTransport;
using Doopec.Rtps.SharedMem;
using Doopec.Utils.Transport;
using Mina.Core.Buffer;
using Rtps.Behavior;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Submessages.Elements;
using Rtps.Structure;
using Rtps.Structure.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data = Rtps.Messages.Submessages.Data;
using Doopec.Encoders;
using Doopec.Serializer;

namespace Doopec.Rtps.Behavior
{
    public class RtpsWriter<T> : StatefulWriter<T>, IDisposable
    {
        private IList<Reader<T>> readers = new List<Reader<T>>();
        private WriterWorker worker;
        UDPTransmitter trans;

        public RtpsWriter(Participant participant)
            : base(participant)
        {
            ITypeSerializer[] customSerializers = new ITypeSerializer[0];
            Doopec.Serializer.Serializer.Initialize(new Type[] { typeof(T) }, customSerializers);

            IRtpsDiscovery discoveryModule = RtpsEngineFactory.Instance.DiscoveryModule;
            discoveryModule.RegisterEndpoint(this);
            discoveryModule.EndpointDiscovery += OnDiscoveryEndpoints;
            AddReaders(discoveryModule);

            // TODO Andres. Revisar esta direccion. Deberia venir de alguna configuracion
            trans = new UDPTransmitter(new Uri("udp://localhost:9999"), 256);
            trans.Start();
            worker = new WriterWorker(this.PeriodicWork);
            worker.Start((int)this.heartbeatPeriod.AsMillis());
        }

        public void Dispose()
        {
            readers.Clear();
            IRtpsDiscovery discoveryModule = RtpsEngineFactory.Instance.DiscoveryModule;
            discoveryModule.UnregisterEndpoint(this);
            discoveryModule.EndpointDiscovery -= OnDiscoveryEndpoints;
            worker.End();
            trans.Close();
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

        private void AddReaders(IRtpsDiscovery discoveryModule)
        {
            foreach (var endpoint in discoveryModule.Endpoints)
            {
                if (endpoint is Reader<T>)
                    AddReader(endpoint as Reader<T>);
            }
        }
        private void PeriodicWork()
        {
            // the RTPS Writer to repeatedly announce the availability of data by sending a Heartbeat Message.
            Console.WriteLine("I have to send a Heartbeat Message,  at {0}", DateTime.Now);
            SendHeartbeat();
            if (HistoryCache.Changes.Count > 0)
                foreach (var change in HistoryCache.Changes)
                {
                    SendData(change);
                }
        }
        private void SendHeartbeat()
        {
            // Create a Message with Heartbeat
            Message m1 = new Message();

            Heartbeat heartbeat = new Heartbeat();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;

            heartbeat.readerId = id1;
            heartbeat.writerId = id2;
            heartbeat.firstSN = new SequenceNumber(10);
            heartbeat.lastSN = new SequenceNumber(20);
            heartbeat.count = 5;
            m1.SubMessages.Add(heartbeat);

            SendData(m1);
        }

        public void SendData(CacheChange<T> change)
        {
            // Create a Message with InfoSource
            Message m1 = new Message();
            EntityId id1 = EntityId.ENTITYID_UNKNOWN;
            EntityId id2 = EntityId.ENTITYID_UNKNOWN;
            SerializedPayload payload = new SerializedPayload();
            IoBuffer buff = IoBuffer.Allocate(1024);
            payload.DataEncapsulation = buff.EncapsuleCDRData(change.DataValue.Value, BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian);
            Data data = new Data(id1, id2, 1, null, payload);
            m1.SubMessages.Add(data);

            // Write Message to bytes1 array 
            SendData(m1);
        }

        /// <summary>
        /// Writes a message to network 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private void SendData(Message msg)
        {
            trans.SendMessage(msg);
        }
    }
}
