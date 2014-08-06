using log4net;
using Mina.Core.Future;
using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Transport.Socket;
using rtps.messages.elements;
using rtps.messages.message;
using RTPS.Utils.Network.Encoders;
using System;
using System.Net;
using System.Reflection;

namespace RTPS.Utils.Network
{
    public class UDPTransmitter : ITransmitter
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Locator locator;
        private IoConnector connector;
        private int bufferSize;


        IoSession session;

        public UDPTransmitter(Uri uri, int bufferSize)
        {
            var addresses = System.Net.Dns.GetHostAddresses(uri.Host);
            int port = (uri.Port < 0 ? 0 : uri.Port);
            if (addresses != null && addresses.Length >= 1)
                this.locator = new Locator(addresses[0], port);
         }

 
        /// <summary>
        /// Constructor for UDPTransmitter.
        /// </summary>
        /// <param name="locator">Locator where the messages will be sent.</param>
        /// <param name="bufferSize">Size of the buffer that will be used to write messages.</param>
        public UDPTransmitter(Locator locator, int bufferSize)
        {
            this.locator = locator;
            this.bufferSize = bufferSize;


         }

        public void Start()
        {
            connector = new AsyncDatagramConnector();
            connector.FilterChain.AddLast("RTPS", new ProtocolCodecFilter(new MessageCodecFactory()));

            connector.ExceptionCaught += (s, e) =>
            {
                Console.WriteLine(e.Exception);
            };
            connector.MessageReceived += (s, e) =>
            {
                Console.WriteLine("Session recv...");
            };
            connector.MessageSent += (s, e) =>
            {
                Console.WriteLine("Session sent...");
            };
            connector.SessionCreated += (s, e) =>
            {
                Console.WriteLine("Session created...");
            };
            connector.SessionOpened += (s, e) =>
            {
                Console.WriteLine("Session opened...");
            };
            connector.SessionClosed += (s, e) =>
            {
                Console.WriteLine("Session closed...");
            };
            connector.SessionIdle += (s, e) =>
            {
                Console.WriteLine("Session idle...");
            };
            IConnectFuture connFuture = connector.Connect(new IPEndPoint(locator.SocketAddress, locator.Port));
            connFuture.Await();

            connFuture.Complete += (s, e) =>
            {
                IConnectFuture f = (IConnectFuture)e.Future;
                if (f.Connected)
                {
                    Console.WriteLine("...connected");
                    session = f.Session;
                }
                else
                {
                    Console.WriteLine("Not connected...exiting");
                }
            };
        }

        /**
         * Sends a Message to a Locator of this UDPWriter.
         * If an overflow occurs during writing of Message, only submessages that
         * were succesfully written will be sent.
         * 
         * @param m Message to send
         * @return true, if Message did not fully fit into buffer of this UDPWriter
         */
        public void SendMessage(Message m)
        {
            if (session != null)
            {
                session.Write(m);
            }
        }

        public void Close()
        {
            session.Close(false);
        }
    }
}
