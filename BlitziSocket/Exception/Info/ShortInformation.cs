using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class ShortInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Short; } }

        public ShortInformation(short Obj)
            : base(Obj)
        {
        }
    }
}
