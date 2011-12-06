using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Including required namespaces
using System.Net;
using System.Net.Sockets;

namespace BlitziSocket.RawNet
{
    public abstract class LowTcpServer
    {
        /// <summary>
        /// This object represents the underlying system-provided listener
        /// <para>In this case, it is a TcpListener object</para>
        /// </summary>
        protected TcpListener SystemListener { get; set; }

        /// <summary>
        /// This object represents the underlying system-provided IPEndPoint on which this server will run
        /// </summary>
        protected IPEndPoint SystemEndPoint { get; set; }

        /// <summary>
        /// This object represents all currently connected clients
        /// </summary>
        protected List<ServerTcpClient> SystemClients { get; private set; }

        /// <summary>
        /// Provides the next connection ID for a new client
        /// </summary>
        protected uint NextID { get; set; }

        /// <summary>
        /// Creates a new LowTcpServer
        /// </summary>
        /// <param name="address">The local IP address the server should bind to</param>
        /// <param name="port">The port on which the server will run</param>
        protected LowTcpServer(IPAddress address, int port)
            : this(new IPEndPoint(address, port))
        {
        }

        /// <summary>
        /// Creates a new LowTcpServer
        /// <para>NOTE: The server will bind only on the loopback address 127.0.0.1</para>
        /// </summary>
        /// <param name="port">The port on which the server will run</param>
        [Obsolete("Use one of the other constructors instead", false)]
        protected LowTcpServer(int port)
            : this(new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), port))
        {
        }

        /// <summary>
        /// Creates a new LowTcpServer
        /// </summary>
        /// <param name="EndPoint">The EndPoint on which the server will run</param>
        protected LowTcpServer(IPEndPoint EndPoint)
        {
            SystemClients = new List<ServerTcpClient>();
            SystemEndPoint = EndPoint;
            SystemListener = new TcpListener(SystemEndPoint);
        }

        protected void ListenForSocket()
        {
            while(!SystemListener.Pending())
            {
                // Wait until a client wants to connect
            }
            SystemClients.Add(new ServerTcpClient(SystemListener.AcceptTcpClient(), NextID));
            NextID++;
        }
    }
}
