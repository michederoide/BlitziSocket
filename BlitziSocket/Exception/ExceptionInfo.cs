using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BlitziSocket.Exception.Info;

namespace BlitziSocket.Exception
{
    public sealed class ExceptionInfo
    {
        /// <summary>
        /// The additional object to use with the exception info
        /// <para>Don't use null for an empty object, use BlitziSocket.Exception.NullObject instead</para>
        /// <para>To use a suitable object and type, check the type of the InformationObject</para>
        /// </summary>
        public InformationObject AdditionalObject { get; private set; }

        /// <summary>
        /// The information type of the additional information
        /// </summary>
        public InformationType InfoType { get; private set; }

        internal ExceptionInfo(InformationObject Information)
        {
            AdditionalObject = Information;
            InfoType = AdditionalObject.InfoType;
        }
    }
}
