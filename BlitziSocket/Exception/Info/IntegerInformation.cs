using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type integer
    /// </summary>
    public class IntegerInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here an integer)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Integer; } }

        /// <summary>
        /// Creates a new IntegerInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public IntegerInformation(int Obj)
            : base(Obj)
        {
        }
    }
}
