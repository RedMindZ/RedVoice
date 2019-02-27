using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class MFMediaBuffer : Unknown
    {
        public MFMediaBuffer(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFMediaBuffer(MFMediaType mediaType, long duration, uint minLength, uint minAlignment) : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateMediaBufferFromMediaType(mediaType.NativePointer, duration, minLength, minAlignment, out _instance));
        }

        // Creates a wrapper around an existing media buffer
        public MFMediaBuffer(MFMediaBuffer other, uint offset, uint length) : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateMediaBufferWrapper(other._instance, offset, length, out _instance));
        }



        public void Lock(out IntPtr ppbBuffer, out uint pcbMaxLength, out uint pcbCurrentLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaBufferLock(_instance, out ppbBuffer, out pcbMaxLength, out pcbCurrentLength));
        }

        public void Unlock()
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaBufferUnlock(_instance));
        }

        public void GetCurrentLength(out uint pcbCurrentLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaBufferGetCurrentLength(_instance, out pcbCurrentLength));
        }

        public void SetCurrentLength(uint cbCurrentLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaBufferSetCurrentLength(_instance, cbCurrentLength));
        }

        public void GetMaxLength(out uint pcbMaxLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFMediaBufferGetMaxLength(_instance, out pcbMaxLength));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateMediaBufferFromMediaType")]
        //                                                             IMFMediaType*      LONGLONG         DWORD             DWORD                IMFMediaBuffer**
        private static extern int NativeCreateMediaBufferFromMediaType(IntPtr pMediaType, long llDuration, uint dwMinLength, uint dwMinAlignment, out IntPtr ppBuffer);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateMediaBufferWrapper")]
        //                                                       IMFMediaBuffer* DWORD          DWORD          IMFMediaBuffer**
        private static extern int NativeCreateMediaBufferWrapper(IntPtr pBuffer, uint cbOffset, uint dwLength, out IntPtr ppBuffer);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaBufferLock")]
        //                                                IMFMediaBuffer*      BYTE**                DWORD*                 DWORD*
        private static extern int NativeMFMediaBufferLock(IntPtr pMediaBuffer, out IntPtr ppbBuffer, out uint pcbMaxLength, out uint pcbCurrentLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaBufferUnlock")]
        //                                                  IMFMediaBuffer*
        private static extern int NativeMFMediaBufferUnlock(IntPtr pMediaBuffer);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaBufferGetCurrentLength")]
        //                                                            IMFMediaBuffer*      DWORD*
        private static extern int NativeMFMediaBufferGetCurrentLength(IntPtr pMediaBuffer, out uint pcbCurrentLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaBufferSetCurrentLength")]
        //                                                            IMFMediaBuffer*      DWORD
        private static extern int NativeMFMediaBufferSetCurrentLength(IntPtr pMediaBuffer, uint cbCurrentLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFMediaBufferGetMaxLength")]
        //                                                        IMFMediaBuffer*      DWORD*
        private static extern int NativeMFMediaBufferGetMaxLength(IntPtr pMediaBuffer, out uint pcbMaxLength);
        #endregion
    }
}
