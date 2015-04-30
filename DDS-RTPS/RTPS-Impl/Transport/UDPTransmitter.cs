using Doopec.Rtps.Encoders;
using log4net;
using Mina.Core.Future;
using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Mina.Transport.Socket;
using Rtps.Messages;
using Rtps.Structure.Types;
using System;
using System.Net;
using System.Reflection;

namespace Doopec.Utils.Transport
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
        /// <param name="bufferSize">Size of the buffer that will be used to Write messages.</param>
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
                log.Error(e.Exception);
            };
            connector.MessageReceived += (s, e) =>
            {
                log.Debug("Session recv...");
            };
            connector.MessageSent += (s, e) =>
            {
                log.Debug("Session sent...");
            };
            connector.SessionCreated += (s, e) =>
            {
                log.Debug("Session created...");
            };
            connector.SessionOpened += (s, e) =>
            {
                log.Debug("Session opened...");
            };
            connector.SessionClosed += (s, e) =>
            {
                log.Debug("Session closed...");
            };
            connector.SessionIdle += (s, e) =>
            {
                log.Debug("Session idle...");
            };
            IConnectFuture connFuture = connector.Connect(new IPEndPoint(locator.SocketAddress, locator.Port));
            connFuture.Await();

            connFuture.Complete += (s, e) =>
            {
                IConnectFuture f = (IConnectFuture)e.Future;
                if (f.Connected)
                {
                    log.Debug("...connected");
                    session = f.Session;
                }
                else
                {
                    log.Warn("Not connected...exiting");
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
