#include "stdafx.h"
#include "MFSinkWriterExports.h"



HRESULT CreateSinkWriterFromURL(LPCWSTR pwszOutputURL, IMFByteStream *pByteStream, IMFAttributes *pAttributes, IMFSinkWriter **ppSinkWriter)
{
	return MFCreateSinkWriterFromURL(pwszOutputURL, pByteStream, pAttributes, ppSinkWriter);
}

HRESULT CreateSinkWriterFromMediaSink(IMFMediaSink *pMediaSink, IMFAttributes *pAttributes, IMFSinkWriter **ppSinkWriter)
{
	return MFCreateSinkWriterFromMediaSink(pMediaSink, pAttributes, ppSinkWriter);
}



HRESULT MFSinkWriterAddStream(IMFSinkWriter *pSinkWriter, IMFMediaType *pTargetMediaType, DWORD *pdwStreamIndex)
{
	
	return pSinkWriter->AddStream(pTargetMediaType, pdwStreamIndex);
}

HRESULT MFSinkWriterSetInputMediaType(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, IMFMediaType *pInputMediaType, IMFAttributes *pEncodingParameters)
{
	return pSinkWriter->SetInputMediaType(dwStreamIndex, pInputMediaType, pEncodingParameters);
}

HRESULT MFSinkWriterBeginWriting(IMFSinkWriter *pSinkWriter)
{
	return pSinkWriter->BeginWriting();
}

HRESULT MFSinkWriterWriteSample(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, IMFSample *pSample)
{
	return pSinkWriter->WriteSample(dwStreamIndex, pSample);
}

HRESULT MFSinkWriterSendStreamTick(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, LONGLONG llTimestamp)
{
	return pSinkWriter->SendStreamTick(dwStreamIndex, llTimestamp);
}

HRESULT MFSinkWriterPlaceMarker(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, LPVOID pvContext)
{
	return pSinkWriter->PlaceMarker(dwStreamIndex, pvContext);
}

HRESULT MFSinkWriterNotifyEndOfSegment(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex)
{
	return pSinkWriter->NotifyEndOfSegment(dwStreamIndex);
}

HRESULT MFSinkWriterFlush(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex)
{
	return pSinkWriter->Flush(dwStreamIndex);
}

HRESULT MFSinkWriterFinalize(IMFSinkWriter *pSinkWriter)
{
	return pSinkWriter->Finalize();
}

HRESULT MFSinkWriterGetServiceForStream(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, REFGUID guidService, REFIID riid, LPVOID *ppvObject)
{
	return pSinkWriter->GetServiceForStream(dwStreamIndex, guidService, riid, ppvObject);
}

HRESULT MFSinkWriterGetStatistics(IMFSinkWriter *pSinkWriter, DWORD dwStreamIndex, MF_SINK_WRITER_STATISTICS *pStats)
{
	return pSinkWriter->GetStatistics(dwStreamIndex, pStats);
}