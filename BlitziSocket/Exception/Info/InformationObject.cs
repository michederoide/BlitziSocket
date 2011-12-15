using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an informational object for an exception
    /// </summary>
    public abstract class InformationObject
    {
        /// <summary>
        /// Represents the type of the information
        /// </summary>
        public abstract InformationType InfoType { get; }

        /// <summary>
        /// The additional object for the exception information
        /// </summary>
        public object Object { get; protected set; }

        /// <summary>
        /// Creates a new InformationObject
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        internal InformationObject(object Obj)
        {
            if (Obj != null)
                Object = Obj;
            else
                Object = new NullObject();
        }
    }
}
