using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type short
    /// </summary>
    public class ShortInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a short)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Short; } }

        /// <summary>
        /// Creates a new ShortInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public ShortInformation(short Obj)
            : base(Obj)
        {
        }
    }
}
