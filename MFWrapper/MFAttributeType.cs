using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MFWrapper
{
    public enum MFAttributeType
    {
        UInt32 = VarEnum.VT_UI4,
        UInt64 = VarEnum.VT_UI8,
        Double = VarEnum.VT_R8,
        Guid = VarEnum.VT_CLSID,
        String = VarEnum.VT_LPWSTR,
        Blob = VarEnum.VT_VECTOR | VarEnum.VT_UI1,
        IUnknown = VarEnum.VT_UNKNOWN
    }
}
