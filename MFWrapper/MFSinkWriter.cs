using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    public class MFSinkWriter : Unknown
    {
        public MFSinkWriter(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFSinkWriter(string url, MFAttributes attributes) : base(IntPtr.Zero, true)
        {
            IntPtr pAttributes = attributes != null ? attributes.NativePointer : IntPtr.Zero;

            Marshal.ThrowExceptionForHR(NativeCreateSinkWriterFromURL(url, IntPtr.Zero, pAttributes, out _instance));
        }



        public void NativeMFSinkWriterAddStream(MFMediaType pTargetMediaType, out uint pdwStreamIndex)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterAddStream(_instance, pTargetMediaType.NativePointer, out pdwStreamIndex));
        }

        public void NativeMFSinkWriterSetInputMediaType(uint dwStreamIndex, MFMediaType pInputMediaType, MFAttributes pEncodingParameters)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterSetInputMediaType(_instance, dwStreamIndex, pInputMediaType.NativePointer, pEncodingParameters.NativePointer));
        }

        public void NativeMFSinkWriterBeginWriting()
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterBeginWriting(_instance));
        }

        public void NativeMFSinkWriterWriteSample(uint dwStreamIndex, MFSample pSample)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterWriteSample(_instance, dwStreamIndex, pSample.NativePointer));
        }

        public void NativeMFSinkWriterSendStreamTick(uint dwStreamIndex, long llTimestamp)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterSendStreamTick(_instance, dwStreamIndex, llTimestamp));
        }

        public void NativeMFSinkWriterPlaceMarker(uint dwStreamIndex, IntPtr pvContext)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterPlaceMarker(_instance, dwStreamIndex, pvContext));
        }

        public void NativeMFSinkWriterNotifyEndOfSegment(uint dwStreamIndex)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterNotifyEndOfSegment(_instance, dwStreamIndex));
        }

        public void NativeMFSinkWriterFlush(uint dwStreamIndex)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterFlush(_instance, dwStreamIndex));
        }

        public void NativeMFSinkWriterFinalize()
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterFinalize(_instance));
        }

        public void NativeMFSinkWriterGetServiceForStream(uint dwStreamIndex, in Guid guidService, in Guid riid, out IntPtr ppvObject)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterGetServiceForStream(_instance, dwStreamIndex, in guidService, in riid, out ppvObject));
        }

        public void NativeMFSinkWriterGetStatistics(uint dwStreamIndex, out MFSinkWriterStatistics pStats)
        {
            Marshal.ThrowExceptionForHR(NativeMFSinkWriterGetStatistics(_instance, dwStreamIndex, out pStats));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSinkWriterFromURL")]
        //                                                      LPCWSTR                                                 IMFByteStream*      IMFAttributes*      IMFSinkWriter**
        private static extern int NativeCreateSinkWriterFromURL([MarshalAs(UnmanagedType.LPWStr)] string pwszOutputURL, IntPtr pByteStream, IntPtr pAttributes, out IntPtr ppSinkWriter);

        // ==================================
        // Might be implemented in the future
        // ==================================
        // 
        // [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateSinkWriterFromURL")]
        // private static extern int NativeCreateSinkWriterFromURL(IMFMediaSink* pMediaSink, IMFAttributes* pAttributes, IMFSinkWriter** ppSinkWriter);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterAddStream")]
        //                                                    IMFSinkWriter*      IMFMediaType*            DWORD*
        private static extern int NativeMFSinkWriterAddStream(IntPtr pSinkWriter, IntPtr pTargetMediaType, out uint pdwStreamIndex);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterSetInputMediaType")]
        //                                                            IMFSinkWriter*      DWORD               IMFMediaType*           IMFAttributes*
        private static extern int NativeMFSinkWriterSetInputMediaType(IntPtr pSinkWriter, uint dwStreamIndex, IntPtr pInputMediaType, IntPtr pEncodingParameters);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterBeginWriting")]
        //                                                       IMFSinkWriter*
        private static extern int NativeMFSinkWriterBeginWriting(IntPtr pSinkWriter);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterWriteSample")]
        //                                                      IMFSinkWriter*      DWORD               IMFSample*
        private static extern int NativeMFSinkWriterWriteSample(IntPtr pSinkWriter, uint dwStreamIndex, IntPtr pSample);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterSendStreamTick")]
        //                                                         IMFSinkWriter*      DWORD               LONGLONG
        private static extern int NativeMFSinkWriterSendStreamTick(IntPtr pSinkWriter, uint dwStreamIndex, long llTimestamp);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterPlaceMarker")]
        //                                                      IMFSinkWriter*      DWORD               LPVOID
        private static extern int NativeMFSinkWriterPlaceMarker(IntPtr pSinkWriter, uint dwStreamIndex, IntPtr pvContext);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterNotifyEndOfSegment")]
        //                                                             IMFSinkWriter*      DWORD
        private static extern int NativeMFSinkWriterNotifyEndOfSegment(IntPtr pSinkWriter, uint dwStreamIndex);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterFlush")]
        //                                                IMFSinkWriter*      DWORD
        private static extern int NativeMFSinkWriterFlush(IntPtr pSinkWriter, uint dwStreamIndex);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterFinalize")]
        //                                                   IMFSinkWriter*
        private static extern int NativeMFSinkWriterFinalize(IntPtr pSinkWriter);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterGetServiceForStream")]
        //                                                              IMFSinkWriter*      DWORD               REFGUID              REFIID        LPVOID*
        private static extern int NativeMFSinkWriterGetServiceForStream(IntPtr pSinkWriter, uint dwStreamIndex, in Guid guidService, in Guid riid, out IntPtr ppvObject);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFSinkWriterGetStatistics")]
        //                                                        IMFSinkWriter*      DWORD               MF_SINK_WRITER_STATISTICS*
        private static extern int NativeMFSinkWriterGetStatistics(IntPtr pSinkWriter, uint dwStreamIndex, out MFSinkWriterStatistics pStats);
        #endregion
    }
}
