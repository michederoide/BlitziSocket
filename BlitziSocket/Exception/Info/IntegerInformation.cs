using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class IntegerInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Integer; } }

        public IntegerInformation(int Obj)
            : base(Obj)
        {
        }
    }
}
