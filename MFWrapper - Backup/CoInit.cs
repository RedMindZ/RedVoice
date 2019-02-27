using System;
using System.Collections.Generic;
using System.Text;

namespace MFWrapper
{
    [Flags]
    public enum CoInitBase
    {
        MultiThreaded = 0x0
    }

    [Flags]
    public enum CoInit
    {
        ApartmentThreaded = 0x2,
        MultiThreaded = CoInitBase.MultiThreaded,
        DisableOle1Dde = 0x4,
        SpeedOverMemory = 0x8
    }
}
