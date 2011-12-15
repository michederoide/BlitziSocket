using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type double
    /// </summary>
    public class DoubleInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a double)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Double; } }

        /// <summary>
        /// Creates a new DoubleInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public DoubleInformation(double Obj)
            : base(Obj)
        {
        }
    }
}
