using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Include necessary namespaces
using System.Net;

namespace BlitziSocket.Net
{
    /// <summary>
    /// Uses text input and output with a TCP server
    /// </summary>
    public class TextTcpClient : BlitziSocket.RawNet.LowTcpClient
    {
        /// <summary>
        /// Connect to the host and its given port
        /// </summary>
        /// <param name="host">Which host should we connect to?</param>
        /// <param name="port">Which port should we use?</param>
        /// <returns>Did we successfully connect?</returns>
        public override bool ConnectToServer(string host, int port)
        {
            return base.InternalConnect(host, port);
        }

        /// <summary>
        /// Connects to the server
        /// </summary>
        /// <param name="EndPoint">The EndPoint of the server</param>
        /// <returns>Did we successfully connect?</returns>
        public override bool ConnectToServer(IPEndPoint EndPoint)
        {
            return base.InternalConnect(EndPoint);
        }

        /// <summary>
        /// Disconnects from the server if connected
        /// </summary>
        /// <returns>Did we successfully disconnect?</returns>
        public override bool Disconnect()
        {
            return base.InternalDisconnect();
        }

        /// <summary>
        /// Reads in bytes the stream got from the server
        /// <para>NOTE: An empty byte array is returned if we disconnect from the server</para>
        /// </summary>
        /// <returns>The available bytes that could be read from the stream</returns>
        protected override byte[] Read()
        {
            int DataAvailable = SystemSocket.Available;
            byte[] bytes = new byte[DataAvailable];
            SystemSocket.GetStream().Read(bytes, 0, DataAvailable);
            string message = new string(Encoding.UTF8.GetChars(bytes));
            if (message.Equals(((uint)BlitziSocket.Protocol.SystemMessages.ServerClose).ToString()))
            {
                SystemSocket.Close();
                return new byte[] { };
            }
            return bytes;
        }

        /// <summary>
        /// Reads the response from the server
        /// </summary>
        /// <returns>Returns the response from the server as string or an empty string if there is no response</returns>
        public string GetResponseText()
        {
            byte[] bytes = this.Read();
            StringBuilder sb = new StringBuilder();
            sb.Append(Encoding.UTF8.GetChars(bytes));
            return sb.ToString();
        }

        /// <summary>
        /// Sends data to the server
        /// </summary>
        /// <param name="rawbytes">The bytes to send to the server</param>
        protected override void Send(byte[] rawbytes)
        {
            SystemSocket.GetStream().Write(rawbytes, 0, rawbytes.Length);
        }

        /// <summary>
        /// Sends a message to the server
        /// </summary>
        /// <param name="message">The message for the server as plain text</param>
        public void SendText(string message)
        {
            this.Send(Encoding.UTF8.GetBytes(message));
        }

        /// <summary>
        /// Sends a message to the server with delimiters after each part of the message
        /// </summary>
        /// <param name="delimiter">The delimiter which will connect the message parts</param>
        /// <param name="messages">The message parts as plain text(s)</param>
        public void SendText(string delimiter, params string[] messages)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(messages[0]);
            for (int i = 1; i < messages.Length; i++)
            {
                sb.Append(delimiter);
                sb.Append(messages[i]);
            }
            this.Send(Encoding.UTF8.GetBytes(sb.ToString()));
        }
    }
}
