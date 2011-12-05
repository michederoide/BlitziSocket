using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class ByteInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Byte; } }

        public ByteInformation(byte Obj)
            : base(Obj)
        {
        }
    }
}
