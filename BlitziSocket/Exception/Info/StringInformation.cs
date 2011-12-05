using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class StringInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.String; } }

        public StringInformation(string Obj)
            : base(Obj)
        {
        }
    }
}
