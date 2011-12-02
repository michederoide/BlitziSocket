using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Import additional important sockets
using System.Net;
using System.Net.Sockets;

// The RawNet Sub-namespace contains all low socket classes (like LowTcpClient, LowTcpServer, ...)
namespace BlitziSocket.RawNet
{
    public abstract class LowTcpClient
    {
        /// <summary>
        /// This object represents the underlying system-provided socket
        /// <para>In this case, it is a TcpClient object</para>
        /// </summary>
        protected TcpClient SystemSocket { get; set; }

        /// <summary>
        /// This object represents the underlying system-provided IPEndPoint
        /// </summary>
        protected IPEndPoint SystemEndPoint { get; set; }

        /// <summary>
        /// Are we connected to our server?
        /// </summary>
        public bool Connected
        {
            get
            {
                return SystemSocket.Connected;
            }
        }

        /// <summary>
        /// Create a new LowTcpClient
        /// </summary>
        protected LowTcpClient()
        {
            SystemSocket = new TcpClient();
        }

        protected bool InternalConnect(string host, int port)
        {
            return InternalConnect(new IPEndPoint(Dns.GetHostAddresses(host).First<IPAddress>(), port));
        }

        protected bool InternalConnect(IPEndPoint EndPoint)
        {
            SystemEndPoint = EndPoint;
            try
            {
                SystemSocket.Connect(SystemEndPoint);
            }
            catch (System.Exception e)
            {
                BlitziSocket.Exception.LowException Ex = new BlitziSocket.Exception.LowException("Could not connect to server", e);
                Ex.ErrorType = "ERROR";
                throw Ex;
            }
            return this.Connected;
        }   
    }
}
