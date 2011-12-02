using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception
{
    [Serializable]
    public class LowException : System.Exception
    {
        public string ErrorType { get; internal set; }

        internal LowException( string message, System.Exception inner )
            : base( message, inner )
        {
            ErrorType = "NONE";
        }
    }
}
