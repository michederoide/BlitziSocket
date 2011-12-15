using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents an exception information with the type long
    /// </summary>
    public class LongInformation : InformationObject
    {
        /// <summary>
        /// Represents the type of the information (here a long)
        /// </summary>
        public override InformationType InfoType { get { return InformationType.Long; } }

        /// <summary>
        /// Creates a new LongInformation
        /// </summary>
        /// <param name="Obj">The additional object to describe the exception</param>
        public LongInformation(long Obj)
            : base(Obj)
        {
        }
    }
}
