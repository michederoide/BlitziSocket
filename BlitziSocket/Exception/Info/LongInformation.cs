using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public class LongInformation : InformationObject
    {
        public override InformationType InfoType { get { return InformationType.Long; } }

        public LongInformation(long Obj)
            : base(Obj)
        {
        }
    }
}
