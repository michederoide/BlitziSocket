using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    /// <summary>
    /// Represents the type of the additional information used for an exception
    /// </summary>
    public enum InformationType : uint
    {
        /// <summary>
        /// Defines a char as additional information
        /// </summary>
        Char = 0x00000001,

        /// <summary>
        /// Defines a string as additional information
        /// </summary>
        String = 0x00000002,

        /// <summary>
        /// Defines a byte as additional information
        /// </summary>
        Byte = 0x00000003,

        /// <summary>
        /// Defines a short as additional information
        /// </summary>
        Short = 0x00000004,

        /// <summary>
        /// Defines an integer as additional information
        /// </summary>
        Integer = 0x000000005,

        /// <summary>
        /// Defines a long as additional information
        /// </summary>
        Long = 0x000000006,

        /// <summary>
        /// Defines a float as additional information
        /// </summary>
        Float = 0x00000007,

        /// <summary>
        /// Defines a double as additional information
        /// </summary>
        Double = 0x00000008,

        /// <summary>
        /// Defines an object as additional information
        /// </summary>
        Object = 0xFFFFFFFF
    }
}
