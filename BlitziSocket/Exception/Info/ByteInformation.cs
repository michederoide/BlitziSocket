using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type byte
    /// </summary>
    public class ByteInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a byte)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Byte; } }

        /// <summary>
        /// Creates a new ByteInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public ByteInformation(byte Obj)
            : base(Obj)
        {
        }
    }
}
