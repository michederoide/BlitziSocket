using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type char
    /// </summary>
    public class CharInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a char)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Char; } }

        /// <summary>
        /// Creates a new CharInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public CharInformation(char Obj)
            : base(Obj)
        {
        }
    }
}
