#pragma once

#include "ExportsHelper.h"


MFEXPORTS_API HRESULT CreateSinkWriterFromURL(LPCWSTR pwszOutputURL, IMFByteStream *pByteStream, IMFAttributes *pAttributes, IMFSinkWriter **ppSinkWriter);
MFEXPORTS_API HRESULT CreateSinkWriterFromMediaSink(IMFMediaSink *pMediaSink, IMFAttributes *pAttributes, IMFSinkWriter **ppSinkWriter);

MFEXPORTS_API HRESULT MFSinkWriterAddStream(IMFSinkWriter *pSinkWriter, IMFMediaType *pTargetMediaType, DWORD *pdwStreamIndex);
MFEXPORTS_API HRESULT MFSinkWriterSetInputMediaType(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, IMFMediaType *pInputMediaType, IMFAttributes *pEncodingParameters);
MFEXPORTS_API HRESULT MFSinkWriterBeginWriting(IMFSinkWriter *pSinkWriter);
MFEXPORTS_API HRESULT MFSinkWriterWriteSample(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, IMFSample *pSample);
MFEXPORTS_API HRESULT MFSinkWriterSendStreamTick(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, LONGLONG llTimestamp);
MFEXPORTS_API HRESULT MFSinkWriterPlaceMarker(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, LPVOID pvContext);
MFEXPORTS_API HRESULT MFSinkWriterNotifyEndOfSegment(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex);
MFEXPORTS_API HRESULT MFSinkWriterFlush(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex);
MFEXPORTS_API HRESULT MFSinkWriterFinalize(IMFSinkWriter *pSinkWriter);
MFEXPORTS_API HRESULT MFSinkWriterGetServiceForStream(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, REFGUID guidService, REFIID riid, LPVOID *ppvObject);
MFEXPORTS_API HRESULT MFSinkWriterGetStatistics(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, MF_SINK_WRITER_STATISTICS *pStats);