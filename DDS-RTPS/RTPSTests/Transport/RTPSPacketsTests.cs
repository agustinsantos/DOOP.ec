using Common.Logging;
using Doopec.Utils.Transport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rtps.Messages;
using Rtps.Messages.Submessages;
using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading;
using Data = Rtps.Messages.Submessages.Data;

namespace Rtps.Tests.Transport
{
    [TestClass]
    public class RTPSPacketsTests
    {
        //private static string Host = "localhost"; //192.168.4.111";
        //private static string Host = "172.16.0.111";
        private static string Host = "224.0.1.111";
        private const int Port = 7400;

        private UDPSimulator simulator;

        [TestInitialize]
        public void SetUp()
        {
            simulator = new UDPSimulator();
        }

        [TestMethod]
        public void TestPublishPacket1()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS, msg.Header.Protocol);
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Assert.AreEqual(new byte[] { 0, 1, 3, 0, 0, 1, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef }, msg.Header.GuidPrefix.Prefix);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
                Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg);
                    switch (submsg.Kind)
                    {
                        case SubMessageKind.DATA:
                            Data d = submsg as Data;
                            foreach (var par in d.InlineQos.Value)
                                Debug.WriteLine("InlineQos: {0}", par);
                            break;
                        case SubMessageKind.INFO_TS:
                            InfoTimestamp its = submsg as InfoTimestamp;
                            Debug.WriteLine("The TimeStampFlag value state is: {0}", its.HasInvalidateFlag);
                            Debug.WriteLine("The EndiannessFlag value state is: {0}", its.Header.Flags.IsLittleEndian);
                            Debug.WriteLine("The octetsToNextHeader value is: {0}", its.Header.SubMessageLength);
                            if (its.HasInvalidateFlag == false)
                            {
                                Debug.WriteLine("The Timestamp value is: {0}", its.TimeStamp);

                            }
                            break;
                        default:
                            Assert.Fail("Only Timestamp and Data submesages are expected");
                            break;
                    }
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/packet1.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 5000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }

        [TestMethod]
        public void TestPublishPacket2()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS, msg.Header.Protocol);
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
                Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg);
                    switch (submsg.Kind)
                    {
                        case SubMessageKind.DATA:
                            Data d = submsg as Data;
                            foreach (var par in d.InlineQos.Value)
                                Debug.WriteLine("InlineQos: {0}", par);
                            break;
                        case SubMessageKind.INFO_TS:
                            InfoTimestamp its = submsg as InfoTimestamp;
                            Debug.WriteLine("The TimeStampFlag value state is: {0}", its.HasInvalidateFlag);
                            Debug.WriteLine("The EndiannessFlag value state is: {0}", its.Header.Flags.IsLittleEndian);
                            Debug.WriteLine("The octetsToNextHeader value is: {0}", its.Header.SubMessageLength);
                            if (its.HasInvalidateFlag == false)
                            {
                                Debug.WriteLine("The Timestamp value is: {0}", its.TimeStamp);

                            }
                            break;
                        default:
                            Assert.Fail("Only Timestamp and Data submesages are expected");
                            break;
                    }
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/packet3.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 2000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }

        [TestMethod]
        public void TestDiscoveryPacket()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS, msg.Header.Protocol);
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
                Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg);
                    switch (submsg.Kind)
                    {
                        case SubMessageKind.DATA:
                            Data d = submsg as Data;
                            foreach (var par in d.InlineQos.Value)
                                Debug.WriteLine("InlineQos: {0}", par);
                            break;
                        case SubMessageKind.INFO_TS:
                            InfoTimestamp its = submsg as InfoTimestamp;
                            Debug.WriteLine("The TimeStampFlag value state is: {0}", its.HasInvalidateFlag);
                            Debug.WriteLine("The EndiannessFlag value state is: {0}", its.Header.Flags.IsLittleEndian);
                            Debug.WriteLine("The octetsToNextHeader value is: {0}", its.Header.SubMessageLength);
                            if (its.HasInvalidateFlag == false)
                            {
                                Debug.WriteLine("The Timestamp value is: {0}", its.TimeStamp);

                            }
                            break;
                        default:
                            Assert.Fail("Only Timestamp and Data submesages are expected");
                            break;
                    }
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/DiscoveryPacketSample.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 2000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }
        /// <summary>
        /// This method is able to test all kinds of submessages ( not tested PAD INF_SrC_
        /// INF_REPLY, INFO_REPLY_IP4, PAD)
        /// </summary>
        [TestMethod]
        public void GeneralRTPSMessageTesterMethod()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS, msg.Header.Protocol);
                Debug.WriteLine("The Header Protocol is: {0}", msg.Header.Protocol);
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Debug.WriteLine("The VendorId value state is: {0}", msg.Header.VendorId);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
                Debug.WriteLine("The Protocol Version value state is: {0}", msg.Header.Version);

                Debug.WriteLine("The number of SubMessages in the message is: {0}", msg.SubMessages.Count);
                //Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg.Kind);

                    switch (submsg.Kind)
                    {
                        case SubMessageKind.DATA:
                            {
                                Data d = submsg as Data;
                               
                                Debug.WriteLine("The KeyFlag value state is: {0}", d.HasKeyFlag);
                                Debug.WriteLine("The DataFlag value state is: {0}", d.HasDataFlag);
                                Debug.WriteLine("The InlineQoSFlag value state is: {0}", d.HasInlineQosFlag);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The extraFlags value is: {0}", d.ExtraFlags.Value);
                                Debug.WriteLine("The octetsToInlineQos value is: Aun no logro");
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSN);
                                if (d.HasInlineQosFlag)
                                {
                                    foreach (var par in d.InlineQos.Value)
                                    {
                                        Debug.WriteLine("InlineQos: {0}", par);
                                    }

                                }
                                if (d.HasDataFlag || d.Header.Flags.IsLittleEndian)
                                {

                                    for (int i = 0; i <= d.SerializedPayload.DataEncapsulation.SerializedPayload.Length - 1; i++)
                                    {

                                        Debug.WriteLine("SerializedPayload: {0}", d.SerializedPayload.DataEncapsulation.SerializedPayload.GetValue(i));
                                    }
                                }
                                break;
                            }
                        case SubMessageKind.ACKNACK:
                            {
                                AckNack d = submsg as AckNack;
                                Debug.WriteLine("The FinalFlag value state is: {0}", d.HasFinalFlag);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The readerSNState is: {0}", d.ReaderSNState);
                                Debug.WriteLine("The Count is: {0}", d.Count);
                                break;
                            }
                        case SubMessageKind.NACK_FRAG:
                            {
                                NackFrag d = submsg as NackFrag;

                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSequenceNumber);
                                Debug.WriteLine("The fragmentNumberState value is: {0}", d.FragmentNumberState);
                                break;
                            }
                        case SubMessageKind.DATA_FRAG:
                            {
                                DataFrag d = submsg as DataFrag;
                                Debug.WriteLine("The KeyFlag value state is: {0}", d.HasKeyFlag);
                                Debug.WriteLine("The InlineQoSFlag value state is: {0}", d.HasInlineQosFlag);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The extraFlags value is: {0}", d.ExtraFlags);
                                Debug.WriteLine("The octetsToInlineQos value is: Aun no logro");
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSequenceNumber);
                                Debug.WriteLine("The FragmentNumber is: {0}", d.FragmentStartingNumber);
                                Debug.WriteLine("The fragmentsInSubmessage is: {0}", d.FragmentsInSubmessage);
                                Debug.WriteLine("The samplesize is: {0}", d.SampleSize);
                                if (d.HasInlineQosFlag)
                                {
                                    foreach (var par in d.ParameterList.Value)
                                    {
                                        Debug.WriteLine("InlineQos: {0}", par);
                                    }

                                }
                                for (int i = 0; i <= d.SerializedPayload.Length - 1; i++)
                                {

                                    Debug.WriteLine("SerializedPayload: {0}", d.SerializedPayload.GetValue(i));
                                }
                                break;
                            }
                        case SubMessageKind.GAP:
                            {
                                Gap d = submsg as Gap;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The GapStart number is: {0}", d.GapStart);
                                Debug.WriteLine("The GapList value is: {0}", d.GapList);
                                break;
                            }
                        case SubMessageKind.HEARTBEAT:
                            {
                                Heartbeat d = submsg as Heartbeat;
                                Debug.WriteLine("The LivelinessFlag value state is: {0}", d.HasLivelinessFlag);
                                Debug.WriteLine("The FinalFlag value state is: {0}", d.HasFinalFlag);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The firstSN is: {0}", d.FirstSequenceNumber);
                                Debug.WriteLine("The lastSN is: {0}", d.LastSequenceNumber);
                                Debug.WriteLine("The Count is: {0}", d.Count);

                                break;
                            }
                        case SubMessageKind.HEARTBEAT_FRAG:
                            {
                                HeartbeatFrag d = submsg as HeartbeatFrag;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSequenceNumber);
                                Debug.WriteLine("The FragmentNumber is: {0}", d.LastFragmentNumber);
                                Debug.WriteLine("The Count is: {0}", d.Count);

                                break;
                            }
                        case SubMessageKind.INFO_DST:
                            {
                                InfoDestination d = submsg as InfoDestination;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The guidPrefix value is: {0}", d.GuidPrefix);
                                break;
                            }

                        case SubMessageKind.INFO_TS:
                            {
                                InfoTimestamp d = submsg as InfoTimestamp;
                                Debug.WriteLine("The TimeStampFlag value state is: {0}", d.HasInvalidateFlag);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                if (d.HasInvalidateFlag == false)
                                {
                                    Debug.WriteLine("The Timestamp value is: {0}", d.TimeStamp);

                                }
                                break;
                            }
                        case SubMessageKind.INFO_SRC:
                            {
                                InfoSource d = submsg as InfoSource;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The ProtocolVersion value is: {0}", d.ProtocolVersion);
                                Debug.WriteLine("The vendorId value is: {0}", d.VendorId);
                                Debug.WriteLine("The guidPrefix value is: {0}", d.GuidPrefix);


                                break;
                            }
                        case SubMessageKind.INFO_REPLY:
                            {
                                InfoReply d = submsg as InfoReply;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The MulticastFlag value state is: {0}", d.HasMulticastFlag);
                                Debug.WriteLine("The unicastLocatorList value state is: {0}", d.UnicastLocatorList);
                                if (d.HasMulticastFlag)
                                {
                                    Debug.WriteLine("The multicastLocatorList value state is: {0}", d.MulticastLocatorList);
                                }
                                break;
                            }
                        case SubMessageKind.INFO_REPLY_IP4:
                            {
                                InfoReplyIp4 d = submsg as InfoReplyIp4;

                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Debug.WriteLine("The MulticastFlag value state is: {0}", d.HasMulticastFlag);
                                Debug.WriteLine("The unicastLocatorList value state is: {0}", d.UnicastLocator);
                                if (d.HasMulticastFlag)
                                {
                                    Debug.WriteLine("The multicastLocatorList value state is: {0}", d.MulticastLocator);
                                }
                                break;
                            }
                        case SubMessageKind.PAD:
                            {
                                Pad d = submsg as Pad;
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                break;
                            }
                    }

                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/TestOpenDDS_rtps_reliability_runtest_local/Packet04.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 1000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }
        /// <summary>
        /// Data Submessage Reference
        /// </summary>
         [TestMethod]
        public void TesOpenDDS_rtps_reliability_runtest_localPacket01()
        {
            object key = new object();
            UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

            rec.MessageReceived += (s, m) =>
            {
                Message msg = m.Message;
                Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);
                
                Debug.WriteLine("Message Header: {0}", msg.Header);
                Assert.AreEqual(ProtocolId.PROTOCOL_RTPS.ToString(), msg.Header.Protocol.ToString());
                Debug.WriteLine("The Header Protocol is: {0}", msg.Header.Protocol);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1.ToString(), msg.Header.Version.ToString());
                Debug.WriteLine("The Protocol Version value state is: {0}", msg.Header.Version);
                Assert.AreEqual(VendorId.OCI.ToString(), msg.Header.VendorId.ToString());
                Debug.WriteLine("The VendorId value state is: {0}", msg.Header.VendorId);
                Assert.AreEqual("01-03-08-00-27-B9-29-47-0A-AF-00-00", msg.Header.GuidPrefix.ToString());

                Debug.WriteLine("The guidPrefix value state is: {0}", msg.Header.GuidPrefix);


                Assert.AreEqual(1, msg.SubMessages.Count);
                Debug.WriteLine("The number of SubMessages in the message is: {0}", msg.SubMessages.Count);
                
                foreach (var submsg in msg.SubMessages)
                {
                    Assert.AreEqual(SubMessageKind.DATA, submsg.Kind );
                    Debug.WriteLine("SubMessage: {0}", submsg.Kind);
                    
                    switch (submsg.Kind)
                    {
                        case SubMessageKind.DATA:
                            {
                                Data d = submsg as Data;
                                
                                Assert.AreEqual(false, d.HasKeyFlag);
                                Debug.WriteLine("The KeyFlag value state is: {0}", d.HasKeyFlag);
                                Assert.AreEqual(true, d.HasDataFlag);
                                Debug.WriteLine("The DataFlag value state is: {0}", d.HasDataFlag);
                                Assert.AreEqual(false, d.HasInlineQosFlag);
                                Debug.WriteLine("The InlineQoSFlag value state is: {0}", d.HasInlineQosFlag);
                                Assert.AreEqual(true, d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Assert.AreEqual(0, d.Header.SubMessageLength);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Assert.AreEqual(0, d.ExtraFlags .Value);
                                Debug.WriteLine("The extraFlags value is: {0}", d.ExtraFlags.Value);
                                Debug.WriteLine("The octetsToInlineQos value is: ");
                                Assert.AreEqual(0, d.ReaderId.EntityKey0);
                                Assert.AreEqual(0, d.ReaderId.EntityKey1);
                                Assert.AreEqual(0, d.ReaderId.EntityKey2);
                                Debug.WriteLine("The readerIDEntityKey is: {0}-{1}-{2}", d.ReaderId.EntityKey0,d.ReaderId.EntityKey1,d.ReaderId.EntityKey2);
                                Assert.AreEqual(0,(int) d.ReaderId.TypeID);
                                Debug.WriteLine("The readerIDEntityKind value is: {0} ",(int)d.ReaderId.TypeID);
                                Assert.AreEqual(0, d.WriterId.EntityKey0);
                                Assert.AreEqual(1, d.WriterId.EntityKey1);
                                Assert.AreEqual(2, d.WriterId.EntityKey2);
                                Debug.WriteLine("The writerID is: {0}-{1}-{2}", d.WriterId.EntityKey0, d.WriterId.EntityKey1, d.WriterId.EntityKey2);
                                Assert.AreEqual(2, (int)d.WriterId.TypeID);
                                Debug.WriteLine("The writerIDEntityKind value is:{0} ",(int) d.WriterId.TypeID);
                                Assert.AreEqual("1", d.WriterSN.ToString());
                                
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSN);
                                if (d.HasInlineQosFlag)
                                {
                                    /*foreach (var par in d.InlineQos.Value)
                                    {
                                        Debug.WriteLine("InlineQos: {0}", par);
                                    }*/

                                }


                                
                                
                                if (d.HasDataFlag || d.Header.Flags.IsLittleEndian)
                                {

                                    for (int i = 0; i <= d.SerializedPayload.DataEncapsulation.SerializedPayload.Length - 1; i++)
                                    {
                                        
                                        Debug.WriteLine("SerializedPayload: {0}", d.SerializedPayload.DataEncapsulation.SerializedPayload.GetValue(i));
                                    }
                                }
                                break;
                            }
                    }

                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/TestOpenDDS_rtps_reliability_runtest_local/Packet01.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 1000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }


         [TestMethod]
         public void TesOpenDDS_rtps_reliability_runtest_localPacket02()
         {
             object key = new object();
             UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

             rec.MessageReceived += (s, m) =>
             {
                 Message msg = m.Message;
                 Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);

                 Debug.WriteLine("Message Header: {0}", msg.Header);
                 Assert.AreEqual(ProtocolId.PROTOCOL_RTPS.ToString(), msg.Header.Protocol.ToString());
                 Debug.WriteLine("The Header Protocol is: {0}", msg.Header.Protocol);
                 Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1.ToString(), msg.Header.Version.ToString());
                 Debug.WriteLine("The Protocol Version value state is: {0}", msg.Header.Version);
                 Assert.AreEqual(VendorId.OCI.ToString(), msg.Header.VendorId.ToString());
                 Debug.WriteLine("The VendorId value state is: {0}", msg.Header.VendorId);
                 Assert.AreEqual("01-03-08-00-27-B9-29-47-0A-AF-00-00", msg.Header.GuidPrefix.ToString());

                 Debug.WriteLine("The guidPrefix value state is: {0}", msg.Header.GuidPrefix);


                 Assert.AreEqual(1, msg.SubMessages.Count);
                 Debug.WriteLine("The number of SubMessages in the message is: {0}", msg.SubMessages.Count);

                 foreach (var submsg in msg.SubMessages)
                 {
                     Assert.AreEqual(SubMessageKind.HEARTBEAT, submsg.Kind);
                     Debug.WriteLine("SubMessage: {0}", submsg.Kind);

                     switch (submsg.Kind)
                     {
                         case SubMessageKind.HEARTBEAT:
                            {
                                Heartbeat d = submsg as Heartbeat;
                                Assert.AreEqual(false, d.HasLivelinessFlag);
                                Debug.WriteLine("The LivelinessFlag value state is: {0}", d.HasLivelinessFlag);
                                Assert.AreEqual(false, d.HasFinalFlag);
                                Debug.WriteLine("The FinalFlag value state is: {0}", d.HasFinalFlag);
                                Assert.AreEqual(true, d.Header.Flags.IsLittleEndian);
                                Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                Assert.AreEqual(0, d.Header.SubMessageLength);
                                Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                Assert.AreEqual(0, d.ReaderId.EntityKey0);
                                Assert.AreEqual(0, d.ReaderId.EntityKey1);
                                Assert.AreEqual(0, d.ReaderId.EntityKey2);
                                Debug.WriteLine("The readerIDEntityKey is: {0}-{1}-{2}", d.ReaderId.EntityKey0, d.ReaderId.EntityKey1, d.ReaderId.EntityKey2);
                                Assert.AreEqual(0, (int)d.ReaderId.TypeID);
                                Debug.WriteLine("The readerIDEntityKind value is: {0} ", (int)d.ReaderId.TypeID);
                                Assert.AreEqual(0, d.WriterId.EntityKey0);
                                Assert.AreEqual(1, d.WriterId.EntityKey1);
                                Assert.AreEqual(2, d.WriterId.EntityKey2);
                                Debug.WriteLine("The writerID is: {0}-{1}-{2}", d.WriterId.EntityKey0, d.WriterId.EntityKey1, d.WriterId.EntityKey2);
                                Assert.AreEqual(2, (int)d.WriterId.TypeID);
                                
                                Debug.WriteLine("The writerIDEntityKind value is:{0} ", (int)d.WriterId.TypeID);
                                Assert.AreEqual(1,d.FirstSequenceNumber);
                                Debug.WriteLine("The firstSN is: {0}", d.FirstSequenceNumber);
                                Assert.AreEqual(1,d.LastSequenceNumber);
                                Debug.WriteLine("The lastSN is: {0}", d.LastSequenceNumber);
                                Assert.AreEqual(1,d.Count);
                                Debug.WriteLine("The Count is: {0}", d.Count);

                                break;
                            }
                                
                     }

                 }
                 lock (key) Monitor.Pulse(key);
             };

             rec.Start();

             simulator.SendUDPPacket("SamplePackets/TestOpenDDS_rtps_reliability_runtest_local/Packet02.dat", Host, Port);
             lock (key)
             {
                 Assert.IsTrue(Monitor.Wait(key, 1000), "Time-out. Message has not arrived or there is an error on it.");
             }
             rec.Close();
         }

         [TestMethod]
         public void TesOpenDDS_rtps_reliability_runtest_localPacket03()
         {
             object key = new object();
             UDPReceiver rec = new UDPReceiver(new Uri("udp://" + Host + ":" + Port), 1024);

             rec.MessageReceived += (s, m) =>
             {
                 Message msg = m.Message;
                 Debug.WriteLine("New Message has arrived from {0}", m.Session.RemoteEndPoint);

                 Debug.WriteLine("Message Header: {0}", msg.Header);
                 Assert.AreEqual(ProtocolId.PROTOCOL_RTPS.ToString(), msg.Header.Protocol.ToString());
                 Debug.WriteLine("The Header Protocol is: {0}", msg.Header.Protocol);
                 Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1.ToString(), msg.Header.Version.ToString());
                 Debug.WriteLine("The Protocol Version value state is: {0}", msg.Header.Version);
                 Assert.AreEqual(VendorId.OCI.ToString(), msg.Header.VendorId.ToString());
                 Debug.WriteLine("The VendorId value state is: {0}", msg.Header.VendorId);
                 Assert.AreEqual("01-03-08-00-27-B9-29-47-0A-AF-00-01", msg.Header.GuidPrefix.ToString());

                 Debug.WriteLine("The guidPrefix value state is: {0}", msg.Header.GuidPrefix);


                 Assert.AreEqual(2, msg.SubMessages.Count);
                 Debug.WriteLine("The number of SubMessages in the message is: {0}", msg.SubMessages.Count);

                 foreach (var submsg in msg.SubMessages)
                 {
                     
                     Debug.WriteLine("SubMessage: {0}", submsg.Kind);

                     switch (submsg.Kind)
                     {
                         case SubMessageKind.INFO_DST:
                             {
                                 InfoDestination d = submsg as InfoDestination;

                                 Assert.AreEqual(true, d.Header.Flags.IsLittleEndian);
                                 Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                 Assert.AreEqual(12, d.Header.SubMessageLength);
                                 Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                 Assert.AreEqual("01-03-08-00-27-B9-29-47-0A-AF-00-00", d.GuidPrefix.ToString());

                                 Debug.WriteLine("The guidPrefix value is: {0}", d.GuidPrefix);
                                 break;
                             }
                         case SubMessageKind.ACKNACK:
                             {
                                 AckNack d = submsg as AckNack;
                                 Assert.AreEqual(true, d.HasFinalFlag);
                                 Debug.WriteLine("The FinalFlag value state is: {0}", d.HasFinalFlag);
                                 Assert.AreEqual(true, d.Header.Flags.IsLittleEndian);
                                 Debug.WriteLine("The EndiannessFlag value state is: {0}", d.Header.Flags.IsLittleEndian);
                                 Debug.WriteLine("The octetsToNextHeader value is: {0}", d.Header.SubMessageLength);
                                 Assert.AreEqual(0, d.ReaderId.EntityKey0);
                                 Assert.AreEqual(1, d.ReaderId.EntityKey1);
                                 Assert.AreEqual(5, d.ReaderId.EntityKey2);
                                 Debug.WriteLine("The readerIDEntityKey is: {0}-{1}-{2}", d.ReaderId.EntityKey0, d.ReaderId.EntityKey1, d.ReaderId.EntityKey2);
                                 Assert.AreEqual(7, (int)d.ReaderId.TypeID);
                                 Debug.WriteLine("The readerIDEntityKind value is: {0} ", (int)d.ReaderId.TypeID);
                                 Assert.AreEqual(0, d.WriterId.EntityKey0);
                                 Assert.AreEqual(1, d.WriterId.EntityKey1);
                                 Assert.AreEqual(2, d.WriterId.EntityKey2);
                                 Debug.WriteLine("The writerID is: {0}-{1}-{2}", d.WriterId.EntityKey0, d.WriterId.EntityKey1, d.WriterId.EntityKey2);
                                 Assert.AreEqual(2, (int)d.WriterId.TypeID);

                                 Debug.WriteLine("The writerIDEntityKind value is:{0} ", (int)d.WriterId.TypeID);
                                 Assert.AreEqual("2", d.ReaderSNState.BitmapBase.ToString());
                                 Assert.AreEqual(1, d.ReaderSNState.NumBits);
                                 Assert.AreEqual(0, d.ReaderSNState.Bitmaps[0]);
                                 
                                 Debug.WriteLine("The readerSNState is: {0}", d.ReaderSNState);
                                 Debug.WriteLine("The Count is: {0}", d.Count);
                                 break;
                             }


                     }

                 }
                 lock (key) Monitor.Pulse(key);
             };

             rec.Start();

             simulator.SendUDPPacket("SamplePackets/TestOpenDDS_rtps_reliability_runtest_local/Packet03.dat", Host, Port);
             lock (key)
             {
                 Assert.IsTrue(Monitor.Wait(key, 1000), "Time-out. Message has not arrived or there is an error on it.");
             }
             rec.Close();
         }

        
    }
}
