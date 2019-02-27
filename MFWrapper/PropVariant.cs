using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MFWrapper
{
    [StructLayout(LayoutKind.Explicit)]
    public struct PropVariant
    {
        [FieldOffset(0)] ushort vt;
        [FieldOffset(2)] ushort wReserved1;
        [FieldOffset(4)] ushort wReserved2;
        [FieldOffset(6)] ushort wReserved3;
        
        [FieldOffset(8)] char cVal;
        [FieldOffset(8)] byte bVal;
        [FieldOffset(8)] short iVal;
        [FieldOffset(8)] ushort uiVal;
        [FieldOffset(8)] int lVal;
        [FieldOffset(8)] uint ulVal;
        [FieldOffset(8)] int intVal;
        [FieldOffset(8)] uint uintVal;
        [FieldOffset(8)] long hVal;
        [FieldOffset(8)] ulong uhVal;
        [FieldOffset(8)] float fltVal;
        [FieldOffset(8)] double dblVal;
        [FieldOffset(8)] short boolVal;
        [FieldOffset(8)] int scode;
        [FieldOffset(8)] long cyVal;
        [FieldOffset(8)] double date;
        [FieldOffset(8)] System.Runtime.InteropServices.ComTypes.FILETIME filetime;
        [FieldOffset(8)] IntPtr puuid; // CLSID*
        [FieldOffset(8)] IntPtr pclipdata; // CLIPDATA*
        [FieldOffset(8)] [MarshalAs(UnmanagedType.BStr)] string bstrVal;
        [FieldOffset(8)] Blob blob;
        [FieldOffset(8)] [MarshalAs(UnmanagedType.LPStr)] string pszVal;
        [FieldOffset(8)] [MarshalAs(UnmanagedType.LPWStr)] string pwszVal;
        [FieldOffset(8)] IntPtr punkVal; // IUnknown*
        [FieldOffset(8)] IntPtr pdispVal; // IDispatch*
        [FieldOffset(8)] IntPtr pStream; // IStream*
        [FieldOffset(8)] IntPtr pStorage; // IStorage*
        [FieldOffset(8)] IntPtr pVersionedStream; // LPVERSIONEDSTREAM
        [FieldOffset(8)] IntPtr parray; // LPSAFEARRAY
        [FieldOffset(8)] [MarshalAs(UnmanagedType.LPStr)] string pcVal;
        [FieldOffset(8)] byte[] pbVal;
        [FieldOffset(8)] IntPtr piVal; // SHORT*
        [FieldOffset(8)] IntPtr puiVal; // USHORT*
        [FieldOffset(8)] IntPtr plVal; // LONG*
        [FieldOffset(8)] IntPtr pulVal; // ULONG*
        [FieldOffset(8)] IntPtr pintVal; // INT*
        [FieldOffset(8)] IntPtr puintVal; // UINT*
        [FieldOffset(8)] IntPtr pfltVal; // FLOAT*
        [FieldOffset(8)] IntPtr pdblVal; // DOUBLE*
        [FieldOffset(8)] IntPtr pboolVal; // VARIANT_BOOL*
        [FieldOffset(8)] IntPtr pdecVal; // DECIMAL*
        [FieldOffset(8)] IntPtr pscode; // SCODE*
        [FieldOffset(8)] IntPtr pcyVal; // CY*
        [FieldOffset(8)] IntPtr pdate; // DATE*
        [FieldOffset(8)] IntPtr pbstrVal; // BSTR*
        [FieldOffset(8)] IntPtr ppunkVal; // IUnknown**
        [FieldOffset(8)] IntPtr ppdispVal; // IDispatch**
        [FieldOffset(8)] IntPtr pparray; // LPSAFEARRAY*
        [FieldOffset(8)] IntPtr pvarVal; // PROPVARIANT*



        public void Init()
        {
            NativePropVariantInit(ref this);
        }

        public void CopyTo(ref PropVariant other)
        {
            Marshal.ThrowExceptionForHR(NativePropVariantCopy(ref other, ref this));
        }

        public void Clear()
        {
            Marshal.ThrowExceptionForHR(NativePropVariantClear(ref this));
        }



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PVInit")]
        private static extern void NativePropVariantInit(ref PropVariant pvar);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PVCopy")]
        private static extern int NativePropVariantCopy(ref PropVariant pvarDest, ref PropVariant pvarSrc);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "PVClear")]
        private static extern int NativePropVariantClear(ref PropVariant pvar);
    }
}
