using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    [Flags]
    public enum MFSourceReaderFlag
    {
        Error = 0x1,
        EndOfStream = 0x2,
        NewStream = 0x4,
        NativeMediaTypeChanged = 0x10,
        CurrentMediaTypeChanged = 0x20,
        StreamTick = 0x100,
        AllEffectsRemoved = 0x200
    }
}
