using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    [Flags]
    public enum MFSourceReaderControlFlag
    {
        None = 0x0, // Convenient value to set no flags
        Drain = 0x1
    }
}
