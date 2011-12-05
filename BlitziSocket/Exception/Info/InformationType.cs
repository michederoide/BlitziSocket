using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlitziSocket.Exception.Info
{
    public enum InformationType : uint
    {
        Char = 0x00000001,
        String = 0x00000002,
        Byte = 0x00000003,
        Short = 0x00000004,
        Integer = 0x000000005,
        Long = 0x000000006,
        Float = 0x00000007,
        Double = 0x00000008,
        Object = 0xFFFFFFFF
    }
}
