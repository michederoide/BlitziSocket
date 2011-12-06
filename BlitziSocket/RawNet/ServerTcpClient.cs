using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Include all necessary namespaces
using System.Net;
using System.Net.Sockets;

namespace BlitziSocket.RawNet
{
    /// <summary>
    /// This class helps us to identify clients with a specific ID
    /// </summary>
    internal sealed class ServerTcpClient
    {
        /// <summary>
        /// Contains the underlaying system TcpClient
        /// </summary>
        internal TcpClient Client { get; private set; }

        /// <summary>
        /// Represents the connection ID of the client
        /// </summary>
        internal uint ConnectionID { get; private set; }

        /// <summary>
        /// Creates a new ServerTcpClient
        /// </summary>
        /// <param name="InnerClient">The underlaying TcpClient</param>
        /// <param name="ID">The connection ID of the client</param>
        internal ServerTcpClient(TcpClient InnerClient, uint ID)
        {
            Client = InnerClient;
            ConnectionID = ID;
        }
    }
}
