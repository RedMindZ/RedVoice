using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class MFMediaType : MFAttributes
    {
        public MFMediaType(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFMediaType() : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateMediaType(out _instance));
        }

        public MFMediaType(Unknown unknownStream) : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateMediaTypeFromProperties(unknownStream.NativePointer, out _instance));
        }

        public MFMediaType(Guid guidRepresentation, IntPtr pvRepresentation) : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateMediaTypeFromRepresentation(guidRepresentation, pvRepresentation, out _instance));
        }



        public void GetMajorType(out Guid pguidMajorType)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaTypeGetMajorType(_instance, out pguidMajorType));
        }

        public void IsCompressedFormat(out bool pfCompressed)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaTypeIsCompressedFormat(_instance, out pfCompressed));
        }

        public void IsEqual(MFMediaType pOtherMediaType, out uint pdwFlags)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaTypeIsEqual(_instance, pOtherMediaType._instance, out pdwFlags));
        }

        public void GetRepresentation(Guid guidRepresentation, out IntPtr ppvRepresentation)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaTypeGetRepresentation(_instance, guidRepresentation, out ppvRepresentation));
        }

        public void FreeRepresentation(Guid guidRepresentation, IntPtr pvRepresentation)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaTypeFreeRepresentation(_instance, guidRepresentation, pvRepresentation));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateMediaType")]
        //                                              IMFMediaType**
        private static extern int NativeCreateMediaType(out IntPtr ppMFType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateMediaTypeFromProperties")]
        //                                                            IUnknown*          IMFMediaType**
        private static extern int NativeCreateMediaTypeFromProperties(IntPtr punkStream, out IntPtr ppMediaType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateMediaTypeFromRepresentation")]
        //                                                                GUID                     LPVOID                   IMFMediaType**
        private static extern int NativeCreateMediaTypeFromRepresentation(Guid guidRepresentation, IntPtr pvRepresentation, out IntPtr ppIMediaType);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaTypeGetMajorType")]
        //                                                      IMFMediaType*      GUID*
        private static extern int NativeMFMediaTypeGetMajorType(IntPtr pMediaType, out Guid pguidMajorType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaTypeIsCompressedFormat")]
        //                                                            IMFMediaType*      BOOL*
        private static extern int NativeMFMediaTypeIsCompressedFormat(IntPtr pMediaType, [MarshalAs(UnmanagedType.Bool)] out bool pfCompressed);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaTypeIsEqual")]
        //                                                 IMFMediaType*      IMFMediaType*           DWORD*
        private static extern int NativeMFMediaTypeIsEqual(IntPtr pMediaType, IntPtr pOtherMediaType, out uint pdwFlags);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaTypeGetRepresentation")]
        //                                                           IMFMediaType*      GUID                     LPVOID*
        private static extern int NativeMFMediaTypeGetRepresentation(IntPtr pMediaType, Guid guidRepresentation, out IntPtr ppvRepresentation);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaTypeFreeRepresentation")]
        //                                                            IMFMediaType*      GUID                     LPVOID
        private static extern int NativeMFMediaTypeFreeRepresentation(IntPtr pMediaType, Guid guidRepresentation, IntPtr pvRepresentation);
        #endregion
    }
}
