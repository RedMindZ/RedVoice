using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class MFSourceReader : Unknown
    {
        public MFSourceReader(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFSourceReader(string url, MFAttributes attributes) : base(IntPtr.Zero, true)
        {
            IntPtr pAttributes = attributes == null ? IntPtr.Zero : attributes.NativePointer;

            Marshal.ThrowExceptionForHR(NativeCreateSourceReaderFromURL(url, pAttributes, out _instance));
        }



        public void GetStreamSelection(uint dwStreamIndex, out bool pfSelected)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderGetStreamSelection(_instance, dwStreamIndex, out pfSelected));
        }

        public void SetStreamSelection(uint dwStreamIndex, bool fSelected)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderSetStreamSelection(_instance, dwStreamIndex, fSelected));
        }

        public void GetNativeMediaType(uint dwStreamIndex, uint dwMediaTypeIndex, out MFMediaType ppMediaType)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderGetNativeMediaType(_instance, dwStreamIndex, dwMediaTypeIndex, out IntPtr mediaTypePtr));
            ppMediaType = new MFMediaType(mediaTypePtr, true);
        }

        public void GetCurrentMediaType(uint dwStreamIndex, out MFMediaType ppMediaType)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderGetCurrentMediaType(_instance, dwStreamIndex, out IntPtr mediaTypePtr));
            ppMediaType = new MFMediaType(mediaTypePtr, true);
        }

        public void SetCurrentMediaType(uint dwStreamIndex, MFMediaType pMediaType)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderSetCurrentMediaType(_instance, dwStreamIndex, IntPtr.Zero, pMediaType.NativePointer));
        }

        public void SetCurrentPosition(ref Guid guidTimeFormat, ref PropVariant varPosition)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderSetCurrentPosition(_instance, ref guidTimeFormat, ref varPosition));
        }

        public void ReadSample(uint dwStreamIndex, MFSourceReaderControlFlag dwControlFlags, out uint pdwActualStreamIndex, out MFSourceReaderFlag pdwStreamFlags, out long pllTimestamp, out MFSample ppSample)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderReadSample(_instance, dwStreamIndex, dwControlFlags, out pdwActualStreamIndex, out pdwStreamFlags, out pllTimestamp, out IntPtr samplePtr));
            ppSample = new MFSample(samplePtr, true);
        }

        public void Flush(uint dwStreamIndex)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderFlush(_instance, dwStreamIndex));
        }

        public void GetServiceForStream(uint dwStreamIndex, ref Guid guidService, ref Guid riid, out IntPtr ppvObject)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderGetServiceForStream(_instance, dwStreamIndex, ref guidService, ref riid, out ppvObject));
        }

        public void GetPresentationAttribute(IntPtr pSourceReader, uint dwStreamIndex, ref Guid guidAttribute, out PropVariant pvarAttribute)
        {
            Marshal.ThrowExceptionForHR(NativeMFSourceReaderGetPresentationAttribute(_instance, dwStreamIndex, ref guidAttribute, out pvarAttribute));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSourceReaderFromURL")]
        //                                                        LPCWSTR                                           IMFAttributes*      IMFSourceReader**
        private static extern int NativeCreateSourceReaderFromURL([MarshalAs(UnmanagedType.LPWStr)] string pwszURL, IntPtr pAttributes, out IntPtr ppSourceReader);

        // ==================================
        // Might be implemented in the future
        // ==================================
        //
        // [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSourceReaderFromByteStream")]
        // private static extern int CreateSourceReaderFromByteStream(IMFByteStream* pByteStream, IMFAttributes* pAttributes, IMFSourceReader** ppSourceReader);
        //
        // [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSourceReaderFromMediaSource")]
        // private static extern int CreateSourceReaderFromMediaSource(IMFMediaSource* pMediaSource, IMFAttributes* pAttributes, IMFSourceReader** ppSourceReader);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderGetStreamSelection")]
        //                                                               IMFSourceReader*      DWORD               BOOL*
        private static extern int NativeMFSourceReaderGetStreamSelection(IntPtr pSourceReader, uint dwStreamIndex, [MarshalAs(UnmanagedType.Bool)] out bool pfSelected);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderSetStreamSelection")]
        //                                                               IMFSourceReader*      DWORD               BOOL
        private static extern int NativeMFSourceReaderSetStreamSelection(IntPtr pSourceReader, uint dwStreamIndex, [MarshalAs(UnmanagedType.Bool)] bool fSelected);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderGetNativeMediaType")]
        //                                                               IMFSourceReader*      DWORD               DWORD                  IMFMediaType**
        private static extern int NativeMFSourceReaderGetNativeMediaType(IntPtr pSourceReader, uint dwStreamIndex, uint dwMediaTypeIndex, out IntPtr ppMediaType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderGetCurrentMediaType")]
        //                                                                IMFSourceReader*      DWORD              IMFMediaType**
        private static extern int NativeMFSourceReaderGetCurrentMediaType(IntPtr pSourceReader, uint dwStreamIndex, out IntPtr ppMediaType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderSetCurrentMediaType")]
        //                                                                IMFSourceReader*      DWORD               DWORD*              IMFMediaType*
        private static extern int NativeMFSourceReaderSetCurrentMediaType(IntPtr pSourceReader, uint dwStreamIndex, IntPtr pdwReserved, IntPtr pMediaType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderSetCurrentPosition")]
        //                                                               IMFSourceReader*      REFGUID                  REFPROPVARIANT
        private static extern int NativeMFSourceReaderSetCurrentPosition(IntPtr pSourceReader, ref Guid guidTimeFormat, ref PropVariant varPosition);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderReadSample")]
        //                                                       IMFSourceReader*      DWORD               DWORD                                     DWORD*                         DWORD*                                 LONGLONG*              IMFSample**
        private static extern int NativeMFSourceReaderReadSample(IntPtr pSourceReader, uint dwStreamIndex, MFSourceReaderControlFlag dwControlFlags, out uint pdwActualStreamIndex, out MFSourceReaderFlag pdwStreamFlags, out long pllTimestamp, out IntPtr ppSample);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderFlush")]
        //                                                  IMFSourceReader*      DWORD
        private static extern int NativeMFSourceReaderFlush(IntPtr pSourceReader, uint dwStreamIndex);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderGetServiceForStream")]
        //                                                                IMFSourceReader*      DWORD               REFGUID               REFIID         LPVOID*
        private static extern int NativeMFSourceReaderGetServiceForStream(IntPtr pSourceReader, uint dwStreamIndex, ref Guid guidService, ref Guid riid, out IntPtr ppvObject);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSourceReaderGetPresentationAttribute")]
        //                                                                     IMFSourceReader*      DWORD               REFGUID                 PROPVARIANT*
        private static extern int NativeMFSourceReaderGetPresentationAttribute(IntPtr pSourceReader, uint dwStreamIndex, ref Guid guidAttribute, out PropVariant pvarAttribute);
        #endregion
    }
}
