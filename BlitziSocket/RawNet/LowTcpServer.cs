using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Including required namespaces
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace BlitziSocket.RawNet
{
    /// <summary>
    /// Represents the abstract layer of a TcpServer
    /// </summary>
    public abstract class LowTcpServer
    {
        /// <summary>
        /// This object represents the underlying system-provided listener
        /// <para>In this case, it is a TcpListener object</para>
        /// </summary>
        protected TcpListener SystemListener { get; set; }

        /// <summary>
        /// Are we still listening for new connections?
        /// </summary>
        protected bool Listening { get; set; }

        /// <summary>
        /// Our thread which listens to new connections
        /// </summary>
        protected Thread ThreadedListener { get; set; }

        /// <summary>
        /// Our thread which will run the server
        /// </summary>
        protected Thread ThreadedRunner { get; set; }

        /// <summary>
        /// Is the server still running?
        /// </summary>
        public bool Running { get; protected set; }

        /// <summary>
        /// This object represents the underlying system-provided IPEndPoint on which this server will run
        /// </summary>
        protected IPEndPoint SystemEndPoint { get; set; }

        /// <summary>
        /// This object represents all currently connected clients
        /// </summary>
        internal List<ServerTcpClient> SystemClients { get; private set; }

        /// <summary>
        /// Provides the next connection ID for a new client
        /// </summary>
        protected uint NextID { get; set; }

        /// <summary>
        /// How many milliseconds should the server wait after all clients have been handled before handling them again
        /// </summary>
        protected const int Tick = 20;

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
        /// Handles the client (for example reading messages from it
        /// </summary>
        /// <param name="Client">The client which should be handled</param>
        protected abstract void HandleClient(ServerTcpClient Client);

        /// <summary>
        /// Repeats the handling of clients every [Tick] milliseconds
        /// </summary>
        protected void RepeatRunner()
        {
            while(Running)
            {
                foreach(ServerTcpClient Client in SystemClients)
                {
                    HandleClient(Client);
                }
                Thread.Sleep(Tick);
            }
            // STOP!!! We need to close the connection to the clients
            foreach (ServerTcpClient Client in SystemClients)
                CloseClient(Client.ConnectionID);
        }

        /// <summary>
        /// Starts the server without starting to listen the server
        /// </summary>
        protected void InternalStartRunning()
        {
            if(Running)
                return;
            Running = true;
            ThreadedRunner = new Thread(new ThreadStart(RepeatRunner));
            ThreadedRunner.Start();
        }

        /// <summary>
        /// Stops the execution of the server and disconnects all clients
        /// </summary>
        protected void InternalStopRunning()
        {
            Listening = false;
            Running = false;
        }

        /// <summary>
        /// Internal method to repeat listening to connections
        /// </summary>
        protected void RepeatListening()
        {
            while(Listening)
                ListenForSocket();
        }

        /// <summary>
        /// (Starts the server and) starts listening for new connections
        /// </summary>
        protected void InternalStartListening()
        {
            if (!Running)
                InternalStartRunning();
            if (Listening)
                return;
            Listening = true;
            ThreadedListener = new Thread(new ThreadStart(RepeatListening));
            ThreadedListener.Start();
        }

        /// <summary>
        /// Stops the server from listening for new connections
        /// </summary>
        protected void InternalStopListening()
        {
            Listening = false;
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

        /// <summary>
        /// Listens for a socket and saves it in the list
        /// </summary>
        /// <returns>The newly connected TcpClient</returns>
        protected ServerTcpClient ListenForSocket()
        {
            // Wait until a client wants to connect
            while (!SystemListener.Pending()) ;
            int index = SystemClients.Count;
            try
            {
                SystemClients.Add(new ServerTcpClient(SystemListener.AcceptTcpClient(), NextID));
                NextID++;
                return SystemClients[index];
            }
            catch (System.Exception e)
            {
                BlitziSocket.Exception.LowException Ex = new BlitziSocket.Exception.LowException("Could not retrieve the connection of a new client", e);
                Ex.ErrorType = "WARN";
                Ex.AdditionalInformation = new BlitziSocket.Exception.ExceptionInfo[] {
                    new BlitziSocket.Exception.ExceptionInfo(new BlitziSocket.Exception.Info.ObjectInformation(SystemListener)),
                    new BlitziSocket.Exception.ExceptionInfo(new BlitziSocket.Exception.Info.LongInformation(NextID - 1))
                };
                throw Ex;
            }
        }

        /// <summary>
        /// Closes the connection for the given client immediately
        /// </summary>
        /// <param name="ConnectionID">The unique connection ID of the client</param>
        protected void CloseClient(uint ConnectionID)
        {
            int ClientIndex = -1;
            foreach (ServerTcpClient Client in SystemClients)
            {
                if (Client.ConnectionID.Equals(ConnectionID))
                {
                    ClientIndex = SystemClients.IndexOf(Client);
                    break;
                }
            }
            if (ClientIndex == -1)
                return;
            byte[] SystemMessage = Encoding.UTF8.GetBytes(((uint)BlitziSocket.Protocol.SystemMessages.ServerClose).ToString());
            SystemClients[ClientIndex].Client.GetStream().Write(SystemMessage, 0, SystemMessage.Length);
            SystemClients[ClientIndex].Client.Close();
            SystemClients.RemoveAt(ClientIndex);
        }

        /// <summary>
        /// Closes the connection for the given client immediately
        /// </summary>
        /// <param name="ClientToClose">The ServerTcpClient to close</param>
        [Obsolete("Use the method CloseClient(uint) instead")]
        protected void CloseClient(ServerTcpClient ClientToClose)
        {
            CloseClient(ClientToClose.ConnectionID);
        }
    }
}
