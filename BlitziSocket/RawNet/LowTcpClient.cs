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
    /// <summary>
    /// Represents the abstract layer of a TcpClient
    /// </summary>
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
                try
                {
                    return SystemSocket.Connected;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Create a new LowTcpClient
        /// </summary>
        protected LowTcpClient()
        {
            SystemSocket = new TcpClient();
        }

        /// <summary>
        /// Connect to the host and its given port
        /// </summary>
        /// <param name="host">Which host should we connect to?</param>
        /// <param name="port">Which port should we use?</param>
        /// <returns>Did we successfully connect?</returns>
        protected bool InternalConnect(string host, int port)
        {
            return InternalConnect(new IPEndPoint(Dns.GetHostAddresses(host).First<IPAddress>(), port));
        }

        /// <summary>
        /// Connect to the host and its given port
        /// </summary>
        /// <param name="host">Which host should we connect to?</param>
        /// <param name="port">Which port should we use?</param>
        /// <returns>Did we successfully connect?</returns>
        public abstract bool ConnectToServer(string host, int port);

        /// <summary>
        /// Connects to the server
        /// </summary>
        /// <param name="EndPoint">The EndPoint of the server</param>
        /// <returns>Did we successfully connect?</returns>
        public abstract bool ConnectToServer(IPEndPoint EndPoint);

        /// <summary>
        /// Sends data to the server
        /// </summary>
        /// <param name="rawbytes">The bytes to send to the server</param>
        protected abstract void Send(byte[] rawbytes);

        /// <summary>
        /// Reads in bytes the stream got from the server
        /// <para>NOTE: The client should check for system messages before parsing the message</para>
        /// </summary>
        /// <returns>The available bytes that could be read from the stream</returns>
        protected abstract byte[] Read();

        /// <summary>
        /// Connects to the server
        /// </summary>
        /// <param name="EndPoint">The EndPoint of the server</param>
        /// <returns>Did we successfully connect?</returns>
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
                Ex.AdditionalInformation =
                    new BlitziSocket.Exception.ExceptionInfo[] {
                        new BlitziSocket.Exception.ExceptionInfo(new BlitziSocket.Exception.Info.ObjectInformation(SystemEndPoint))
                    };
                throw Ex;
            }
            return this.Connected;
        }

        /// <summary>
        /// Disconnects from the server
        /// </summary>
        /// <returns>Did we successfully disconnect?</returns>
        public abstract bool Disconnect();

        /// <summary>
        /// Disconnects this client from the server if connected
        /// </summary>
        /// <returns>Did we disconnect successfully?</returns>
        protected bool InternalDisconnect()
        {
            if (!Connected)
                return false;
            try
            {
                byte[] SystemMessage = Encoding.UTF8.GetBytes(((uint)BlitziSocket.Protocol.SystemMessages.ClientClose).ToString());
                SystemSocket.GetStream().Write(SystemMessage, 0, SystemMessage.Length);
                SystemSocket.Close();
                return true;
            }
            catch (System.Exception e)
            {
                BlitziSocket.Exception.LowException Ex = new BlitziSocket.Exception.LowException("Could not disconnect from server", e);
                Ex.ErrorType = "WARN";
                Ex.AdditionalInformation =
                    new BlitziSocket.Exception.ExceptionInfo[] {
                        new BlitziSocket.Exception.ExceptionInfo(new BlitziSocket.Exception.Info.ObjectInformation(SystemEndPoint)),
                        new BlitziSocket.Exception.ExceptionInfo(new BlitziSocket.Exception.Info.ObjectInformation(SystemSocket))
                    };
                throw Ex;
            }
        }
    }
}
