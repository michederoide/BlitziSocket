using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class CharInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Char; } }

        public CharInformation(char Obj)
            : base(Obj)
        {
        }
    }
}
