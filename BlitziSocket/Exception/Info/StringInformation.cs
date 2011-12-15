using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type string
    /// </summary>
    public class StringInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a string)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.String; } }

        /// <summary>
        /// Creates a new StringInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public StringInformation(string Obj)
            : base(Obj)
        {
        }
    }
}
