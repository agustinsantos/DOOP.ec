using Doopec.Serializer;
using Doopec.Utils.Transport;
using Doopec.Encoders;
using log4net;
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
using System.Reflection;
using System.Text;
using Data = Rtps.Messages.Submessages.Data;
using Doopec.Rtps.Messages;
using Doopec.Serializer.Attributes;

namespace Doopec.Rtps.Behavior
{
    public class RtpsStatelessWriter<T> : StatelessWriter<T>, IDisposable where T : new()
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected List<UDPTransmitter> UDPTransmitters { get; private set; }
        private WriterWorker worker;
        protected Encapsulation Scheme { get; set; }

        public RtpsStatelessWriter(GUID guid)
            : base(guid)
        {
            Doopec.Serializer.Serializer.Initialize(typeof(T));
            UDPTransmitters = new List<UDPTransmitter>();
            Scheme = Encapsulation.CDR_BE;
        }

        protected void InitTransmitters()
        {
            foreach (var locator in MulticastLocatorList)
            {
                UDPTransmitter rec = new UDPTransmitter(locator, 1024);
                rec.ParticipantId = this.Guid;
                UDPTransmitters.Add(rec);
            }

            // TODO. Just for testing. I dont like so many messages
            //foreach (var locator in UnicastLocatorList)
            //{
            //    UDPTransmitter trans = new UDPTransmitter(locator, 1024);
            //    trans.ParticipantId = this.Guid;
            //    UDPTransmitters.Add(trans);
            //}
            worker = new WriterWorker(this.PeriodicWork);
        }

        protected void StartTransmitters()
        {
            foreach (var trans in UDPTransmitters)
            {
                trans.Start();
            }
            worker.Start((int)this.ResendDataPeriod.AsMillis());
        }
        protected virtual void PeriodicWork()
        {
            // the RTPS Writer to repeatedly announce the availability of data by sending a Heartbeat Message.
            log.DebugFormat("I have to send a Heartbeat Message,  at {0}", DateTime.Now);
            SendHeartbeat();
            if (HistoryCache.Changes.Count > 0)
            {
                foreach (var change in HistoryCache.Changes)
                {
                    //SendHeartbeat();
                    //SendData(change);
                    SendDataHeartbeat(change);
                }
                HistoryCache.Changes.Clear(); //TODO
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
            Message msg = new Message();
            EntityId readerId = EntityId.ENTITYID_UNKNOWN;
            EntityId writerId = change.WriterGuid.EntityId;
            SerializedPayload payload = new SerializedPayload();
            IoBuffer buff = IoBuffer.Allocate(1024);

            payload.DataEncapsulation = EncapsulationManager.Serialize<T>((T)change.DataValue.Value, Scheme);
            Data data = new Data(readerId, writerId, change.SequenceNumber.LongValue, null, payload);
            msg.SubMessages.Add(data);

            // Write Message to bytes1 array 
            SendData(msg);
        }

        public void SendDataHeartbeat(CacheChange<T> change)
        {
            // Create a Message with InfoSource
            Message msg = new Message();
            EntityId readerId = EntityId.ENTITYID_UNKNOWN;
            EntityId writerId = change.WriterGuid.EntityId;
            SerializedPayload payload = new SerializedPayload();
            IoBuffer buff = IoBuffer.Allocate(1024);
            payload.DataEncapsulation = buff.EncapsuleCDRData(change.DataValue.Value, BitConverter.IsLittleEndian ? ByteOrder.LittleEndian : ByteOrder.BigEndian);
            Data data = new Data(readerId, writerId, change.SequenceNumber.LongValue, null, payload);
            msg.SubMessages.Add(data);

            Heartbeat heartbeat = new Heartbeat();
            heartbeat.readerId = readerId;
            heartbeat.writerId = writerId;
            heartbeat.firstSN = change.SequenceNumber;
            heartbeat.lastSN = change.SequenceNumber;
            heartbeat.count = 1;
            msg.SubMessages.Add(heartbeat);

            SendData(msg);
        }

        /// <summary>
        /// Writes a message to network 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private void SendData(Message msg)
        {
            foreach (var trans in UDPTransmitters)
                trans.SendMessage(msg);
        }

        public void Dispose()
        {
            worker.End();
            foreach (var trans in UDPTransmitters)
            {
                trans.Close();
                trans.Dispose();
            }
            UDPTransmitters.Clear();
        }
    }
}
