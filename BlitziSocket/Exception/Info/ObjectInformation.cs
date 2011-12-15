using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the "type" object
    /// </summary>
    public class ObjectInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here an object)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Object; } }

        /// <summary>
        /// Creates a new ObjectInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public ObjectInformation(object Obj)
            : base(Obj)
        {
        }
    }
}
