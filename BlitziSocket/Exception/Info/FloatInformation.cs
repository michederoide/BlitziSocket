using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class FloatInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Float; } }

        public FloatInformation(float Obj)
            : base(Obj)
        {
        }
    }
}
