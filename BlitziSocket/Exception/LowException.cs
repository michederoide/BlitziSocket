using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception
{
    /// <summary>
    /// Represents an exception thrown in the low level (from LowTcpClient, LowTcpServer, ...)
    /// </summary>
    [Serializable]
    public sealed class LowException : System.Exception
    {
        /// <summary>
        /// The error type of the exception ("ERROR", "WARN", "INFO", "TRACE", "DEBUG")
        /// </summary>
        public string ErrorType { get; internal set; }

        /// <summary>
        /// Contains all additional exception info (eg. objects)
        /// </summary>
        public ExceptionInfo[] AdditionalInformation { get; internal set; }

        /// <summary>
        /// Creates a new LowException for an exception thrown in Low-Classes (eg. LowTcpClient)
        /// </summary>
        /// <param name="message">The error message to use</param>
        /// <param name="inner">The usually thrown exception (usually a catched exception)</param>
        internal LowException( string message, System.Exception inner )
            : base( message, inner )
        {
            ErrorType = "NONE";
        }
    }
}
