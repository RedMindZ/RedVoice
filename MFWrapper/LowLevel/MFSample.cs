using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class MFSample : MFAttributes
    {
        public MFSample(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFSample() : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateSample(out _instance));
        }



        public void GetSampleFlags(out uint pdwSampleFlags)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetSampleFlags(_instance, out pdwSampleFlags));
        }

        public void SetSampleFlags(uint dwSampleFlags)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleSetSampleFlags(_instance, dwSampleFlags));
        }

        public void GetSampleTime(out long phnsSampleTime)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetSampleTime(_instance, out phnsSampleTime));
        }

        public void SetSampleTime(long hnsSampleTime)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleSetSampleTime(_instance, hnsSampleTime));
        }

        public void GetSampleDuration(out long phnsSampleDuration)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetSampleDuration(_instance, out phnsSampleDuration));
        }

        public void SetSampleDuration(long hnsSampleDuration)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleSetSampleTime(_instance, hnsSampleDuration));
        }

        public void GetBufferCount(out uint pdwBufferCount)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetBufferCount(_instance, out pdwBufferCount));
        }

        public void GetBufferByIndex(uint dwIndex, out MFMediaBuffer ppBuffer)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetBufferByIndex(_instance, dwIndex, out IntPtr bufferPtr));
            ppBuffer = new MFMediaBuffer(bufferPtr, true);
        }

        public void ConvertToContiguousBuffer(out MFMediaBuffer ppBuffer)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleConvertToContiguousBuffer(_instance, out IntPtr bufferPtr));
            ppBuffer = new MFMediaBuffer(bufferPtr, true);
        }

        public void AddBuffer(MFMediaBuffer pBuffer)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleAddBuffer(_instance, pBuffer.NativePointer));
        }

        public void RemoveBufferByIndex(uint dwIndex)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleRemoveBufferByIndex(_instance, dwIndex));
        }

        public void RemoveAllBuffers()
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleRemoveAllBuffers(_instance));
        }

        public void GetTotalLength(IntPtr pSample, out uint pcbTotalLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleGetTotalLength(_instance, out pcbTotalLength));
        }

        public void CopyToBuffer(MFMediaBuffer pBuffer)
        {
            Marshal.ThrowExceptionForHR(NativeMFSampleCopyToBuffer(_instance, pBuffer.NativePointer));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSample")]
        //                                          IMFSample**
        private static extern int NativeCreateSample(out IntPtr ppIMFSample);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetSampleFlags")]
        //                                                     IMFSample*      DWORD*
        private static extern int NativeMFSampleGetSampleFlags(IntPtr pSample, out uint pdwSampleFlags);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleSetSampleFlags")]
        //                                                     IMFSample*      DWORD
        private static extern int NativeMFSampleSetSampleFlags(IntPtr pSample, uint dwSampleFlags);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetSampleTime")]
        //                                                    IMFSample*      LONGLONG*
        private static extern int NativeMFSampleGetSampleTime(IntPtr pSample, out long phnsSampleTime);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleSetSampleTime")]
        //                                                    IMFSample*      LONGLONG
        private static extern int NativeMFSampleSetSampleTime(IntPtr pSample, long hnsSampleTime);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetSampleDuration")]
        //                                                        IMFSample*      LONGLONG*
        private static extern int NativeMFSampleGetSampleDuration(IntPtr pSample, out long phnsSampleDuration);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleSetSampleDuration")]
        //                                                        IMFSample*      LONGLONG
        private static extern int NativeMFSampleSetSampleDuration(IntPtr pSample, long hnsSampleDuration);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetBufferCount")]
        //                                                     IMFSample*      DWORD*
        private static extern int NativeMFSampleGetBufferCount(IntPtr pSample, out uint pdwBufferCount);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetBufferByIndex")]
        //                                                       IMFSample*      DWORD         IMFMediaBuffer**
        private static extern int NativeMFSampleGetBufferByIndex(IntPtr pSample, uint dwIndex, out IntPtr ppBuffer);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleConvertToContiguousBuffer")]
        //                                                                IMFSample*      IMFMediaBuffer**
        private static extern int NativeMFSampleConvertToContiguousBuffer(IntPtr pSample, out IntPtr ppBuffer);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleAddBuffer")]
        //                                                IMFSample*      IMFMediaBuffer*
        private static extern int NativeMFSampleAddBuffer(IntPtr pSample, IntPtr pBuffer);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleRemoveBufferByIndex")]
        //                                                          IMFSample*      DWORD
        private static extern int NativeMFSampleRemoveBufferByIndex(IntPtr pSample, uint dwIndex);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleRemoveAllBuffers")]
        //                                                       IMFSample*
        private static extern int NativeMFSampleRemoveAllBuffers(IntPtr pSample);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleGetTotalLength")]
        //                                                     IMFSample*      DWORD*
        private static extern int NativeMFSampleGetTotalLength(IntPtr pSample, out uint pcbTotalLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSampleCopyToBuffer")]
        //                                                   IMFSample*      IMFMediaBuffer*
        private static extern int NativeMFSampleCopyToBuffer(IntPtr pSample, IntPtr pBuffer);
        #endregion
    }
}
