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
        private const int Port = 9999;

        private UDPSimulator simulator;

        [TestInitialize]
        public void SetUp()
        {
            simulator = new UDPSimulator();
        }
        /*
        [TestMethod]
        public void TestPublishData()
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
                    if (submsg is Data)
                    {
                        Data d = submsg as Data;
                        foreach (var par in d.InlineQos.Value)
                            Debug.WriteLine("InlineQos: {0}", par);
                    }
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/packet1.dat", Host, Port);
            lock (key)
            {
               Assert.IsTrue( Monitor.Wait(key, 1000),"Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }

        */

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
                Assert.AreEqual(VendorId.OCI, msg.Header.VendorId);
                Assert.AreEqual(ProtocolVersion.PROTOCOLVERSION_2_1, msg.Header.Version);
             
                Debug.WriteLine("The number of SubMessages in the message is: {0}", msg.SubMessages.Count);
                //Assert.AreEqual(2, msg.SubMessages.Count);
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg.Kind);

                    switch(submsg.Kind )
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
                                Debug.WriteLine("The octetsToInlineQos value is: Aun no logro" );
                                Debug.WriteLine("The readerID is: {0}", d.ReaderId);
                                Debug.WriteLine("The writerID is: {0}", d.WriterId);
                                Debug.WriteLine("The writerSN is: {0}", d.WriterSN);
                                if(d.HasInlineQosFlag)
                                {
                                    foreach (var par in d.InlineQos.Value)
                                    {
                                        Debug.WriteLine("InlineQos: {0}", par);
                                    }

                                }
                                if(d.HasDataFlag||d.Header.Flags.IsLittleEndian)
                                {
                                    
                                    for(int i=0;i<=d.SerializedPayload.DataEncapsulation.SerializedPayload.Length-1;i++)
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
                                Debug.WriteLine("The fragmentNumberState value is: {0}",d.FragmentNumberState);
                                break;
                            }
                        case SubMessageKind.DATA_FRAG:
                            {
                                DataFrag d = submsg as DataFrag ;
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
                                if(d.HasInvalidateFlag ==false )
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
                                if(d.HasMulticastFlag)
                                {
                                    Debug.WriteLine("The multicastLocatorList value state is: {0}", d.MulticastLocatorList);
                                }
                                break;
                            }
                        case SubMessageKind.INFO_REPLY_IP4:
                            {
                                InfoReplyIp4 d= submsg as InfoReplyIp4;
                                
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

                   /* if (submsg is Data)
                    {
                        Data d = submsg as Data;
                        foreach (var par in d.InlineQos.Value)
                            Debug.WriteLine("InlineQos: {0}", par);
                    }*/
                }
                lock (key) Monitor.Pulse(key);
            };

            rec.Start();

            simulator.SendUDPPacket("SamplePackets/TestOpenDDS_rtps_reliability_runtest_local/Packet09.dat", Host, Port);
            lock (key)
            {
                Assert.IsTrue(Monitor.Wait(key, 1000), "Time-out. Message has not arrived or there is an error on it.");
            }
            rec.Close();
        }

        /*
        [TestMethod]
        public void TestPublishDataOpenDdsRtpsReliabilityRuntestLocal01()
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
                Assert.AreEqual(1, msg.SubMessages.Count);
               
                foreach (var submsg in msg.SubMessages)
                {
                    Debug.WriteLine("SubMessage: {0}", submsg);
                    if (submsg is Data)
                    {
                        Data d = submsg as Data;


                        if (d.HasDataFlag)
                        {
                            Debug.WriteLine("DataFlag: {0}", d.HasDataFlag);
                        }
                        else if(d.HasDataFlag==false )
                        {
                            Debug.WriteLine("DataFlag: {0}", d.HasDataFlag);
                        }
                      

                        
                        if (d.HasInlineQosFlag)
                        {
                            Debug.WriteLine("InlineQosFlag: {0}", d.HasInlineQosFlag);
                            foreach (var par in d.InlineQos.Value)
                            {
                                Debug.WriteLine("InlineQos: {0}", par);
                            }
                        }
                        else if (d.HasInlineQosFlag == false)
                        {
                            Debug.WriteLine("InlineQosFlag: {0}", d.HasInlineQosFlag);
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
        */
        /*
        [TestMethod]
        public void TestPublishDataOpenDdsRtpsReliabilityRuntestLocal03()
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
                    if (submsg is InfoDestination)
                    {
                        InfoDestination d = submsg as InfoDestination;

                        if (d.Header.Flags.IsLittleEndian)
                        {
                            Debug.WriteLine("HasFinalFlag: {0}", d.Header.Flags.IsLittleEndian);
                            
                        }
                        else if (d.Header.Flags.HasFinalFlag == false)
                        {
                            Debug.WriteLine("HasFinalFlag: {0}", d.Header.Flags.HasFinalFlag);
                        }

                    }

                    if (submsg is AckNack)
                    {
                        AckNack d = submsg as AckNack;

                        if (d.Header.Flags.IsLittleEndian)
                        {
                            Debug.WriteLine("EndiannessFlag: {0}", d.Header.Flags.IsLittleEndian);

                        }
                        else if (d.Header.Flags.IsLittleEndian == false)
                        {
                            Debug.WriteLine("EndiannessFlag: {0}", d.Header.Flags.IsLittleEndian);
                        }
                        if (d.Header.Flags.HasFinalFlag)
                        {
                            Debug.WriteLine("HasFinalFlag: {0}", d.Header.Flags.HasFinalFlag);
                        }
                        else if (d.Header.Flags.HasFinalFlag == false)
                        {
                            Debug.WriteLine("HasFinalFlag: {0}", d.Header.Flags.HasFinalFlag);
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
        */
    }
}
