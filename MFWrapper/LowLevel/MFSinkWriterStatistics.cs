using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MFWrapper
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MFSinkWriterStatistics
    {
        uint cb;
        long llLastTimestampReceived;
        long llLastTimestampEncoded;
        long llLastTimestampProcessed;
        long llLastStreamTickReceived;
        long llLastSinkSampleRequest;
        ulong qwNumSamplesReceived;
        ulong qwNumSamplesEncoded;
        ulong qwNumSamplesProcessed;
        ulong qwNumStreamTicksReceived;
        uint dwByteCountQueued;
        ulong qwByteCountProcessed;
        uint dwNumOutstandingSinkSampleRequests;
        uint dwAverageSampleRateReceived;
        uint dwAverageSampleRateEncoded;
        uint dwAverageSampleRateProcessed;
    }
}
