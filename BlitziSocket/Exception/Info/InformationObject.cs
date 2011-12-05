using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public abstract class InformationObject
    {
        public abstract InformationType InfoType { get; }

        public object Object { get; protected set; }

        internal InformationObject(object Obj)
        {
            if (Obj != null)
                Object = Obj;
            else
                Object = new NullObject();
        }
    }
}
