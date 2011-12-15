using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Protocol
{
    /// <summary>
    /// Represents important system messages sent by client or server
    /// </summary>
    internal enum SystemMessages : uint
    {
        /// <summary>
        /// The server will close the connection immediately
        /// </summary>
        ServerClose = 0xF0C00000,

        /// <summary>
        /// The client will close the connection immediately
        /// </summary>
        ClientClose = 0xC0C00000,

        /// <summary>
        /// The client caught an exception with this connection
        /// </summary>
        ClientError = 0xC0FFFFFF,

        /// <summary>
        /// The server caught an exception with this connection
        /// </summary>
        ServerError = 0xF0FFFFFF
    }
}
