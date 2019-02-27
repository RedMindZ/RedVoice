using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Blob
    {
        uint cbSize;
        byte[] pBlobData;
    }
}
