using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket
{
    /// <summary>
    /// Holds information about the framework
    /// </summary>
    public sealed class Framework
    {
        /// <summary>
        /// Prevents creation of a framework object which would be useless
        /// </summary>
        private Framework()
        {
        }

        /// <summary>
        /// The current version of the framework
        /// </summary>
        public string Version
        {
            get
            {
                return "v0.0.2.3";
            }
        }

        /// <summary>
        /// Contains all authors that worked on the framework
        /// </summary>
        public string[] Authors
        {
            // Please add your name yourself if you want to be mentioned
            get
            {
                return new string[]
                {
                    "Michael Armbruster"
                };
            }
        }

        /// <summary>
        /// The name of the framework
        /// </summary>
        public string Name
        {
            get
            {
                return "BlitziSocket";
            }
        }
    }
}
