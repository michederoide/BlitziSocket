using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type float
    /// </summary>
    public class FloatInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a float)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Float; } }

        /// <summary>
        /// Creates a new FloatInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public FloatInformation(float Obj)
            : base(Obj)
        {
        }
    }
}
