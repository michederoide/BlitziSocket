using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class DoubleInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Double; } }

        public DoubleInformation(double Obj)
            : base(Obj)
        {
        }
    }
}
