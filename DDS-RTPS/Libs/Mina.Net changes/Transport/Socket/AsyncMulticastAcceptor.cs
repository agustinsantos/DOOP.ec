using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Mina.Core.Buffer;
using Mina.Core.Future;
using Mina.Core.Service;
using Mina.Core.Session;
using Mina.Core.Write;
using Mina.Util;

namespace Mina.Transport.Socket
{
    /// <summary>
    /// <see cref="IoAcceptor"/> for datagram transport (UDP/IP).
    /// </summary>
    public partial class AsyncMulticastAcceptor : AsyncDatagramAcceptor
    {
        /// <inheritdoc/>
        protected override IEnumerable<EndPoint> BindInternal(IEnumerable<EndPoint> localEndPoints)
        {
            Dictionary<EndPoint, System.Net.Sockets.Socket> newListeners = new Dictionary<EndPoint, System.Net.Sockets.Socket>();
            try
            {
                // Process all the addresses
                foreach (EndPoint localEP in localEndPoints)
                {
                    EndPoint ep = localEP;
                    if (ep == null)
                        ep = new IPEndPoint(IPAddress.Any, 0);
                    System.Net.Sockets.Socket listenSocket = new System.Net.Sockets.Socket(ep.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
                    //listenSocket.Bind(ep);
                    if (ep is IPEndPoint)
                    {
                        IPEndPoint iep = ep as IPEndPoint;

                        listenSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(iep.Address));
                        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, iep.Port);
                        listenSocket.Bind(ipep);
                        newListeners[listenSocket.LocalEndPoint] = listenSocket;
                    }
                }
            }
            catch (Exception ex)
            {
                // Roll back if failed to bind all addresses
                foreach (System.Net.Sockets.Socket listenSocket in newListeners.Values)
                {
                    try
                    {
                        listenSocket.Close();
                    }
                    catch (Exception)
                    {
                        ExceptionMonitor.Instance.ExceptionCaught(ex);
                    }
                }

                throw;
            }

            foreach (KeyValuePair<EndPoint, System.Net.Sockets.Socket> pair in newListeners)
            {
                SocketContext ctx = new SocketContext(pair.Value, SessionConfig);
                _listenSockets[pair.Key] = ctx;
                BeginReceive(ctx);
            }

            _idleStatusChecker.Start();

            return newListeners.Keys;
        }
    }
}
