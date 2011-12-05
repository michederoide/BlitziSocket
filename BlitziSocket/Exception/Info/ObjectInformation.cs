using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class ObjectInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Object; } }

        public ObjectInformation(object Obj)
            : base(Obj)
        {
        }
    }
}
