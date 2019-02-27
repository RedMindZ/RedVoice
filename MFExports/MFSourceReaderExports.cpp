#include "stdafx.h"
#include "MFSourceReaderExports.h"



HRESULT CreateSourceReaderFromURL(LPCWSTR pwszURL, IMFAttributes* pAttributes, IMFSourceReader** ppSourceReader)
{
	return MFCreateSourceReaderFromURL(pwszURL, pAttributes, ppSourceReader);
}

HRESULT CreateSourceReaderFromByteStream(IMFByteStream *pByteStream, IMFAttributes *pAttributes, IMFSourceReader **ppSourceReader)
{
	return MFCreateSourceReaderFromByteStream(pByteStream, pAttributes, ppSourceReader);
}

HRESULT CreateSourceReaderFromMediaSource(IMFMediaSource *pMediaSource, IMFAttributes *pAttributes, IMFSourceReader **ppSourceReader)
{
	return MFCreateSourceReaderFromMediaSource(pMediaSource, pAttributes, ppSourceReader);
}




HRESULT MFSourceReaderGetStreamSelection(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, BOOL *pfSelected)
{
	return pSourceReader->GetStreamSelection(dwStreamIndex, pfSelected);
}

HRESULT MFSourceReaderSetStreamSelection(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, BOOL fSelected)
{
	return pSourceReader->SetStreamSelection(dwStreamIndex, fSelected);
}

HRESULT MFSourceReaderGetNativeMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD dwMediaTypeIndex, IMFMediaType **ppMediaType)
{
	return pSourceReader->GetNativeMediaType(dwStreamIndex, dwMediaTypeIndex, ppMediaType);
}

HRESULT MFSourceReaderGetCurrentMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, IMFMediaType **ppMediaType)
{
	return pSourceReader->GetCurrentMediaType(dwStreamIndex, ppMediaType);
}

HRESULT MFSourceReaderSetCurrentMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD *pdwReserved, IMFMediaType *pMediaType)
{
	return pSourceReader->SetCurrentMediaType(dwStreamIndex, pdwReserved, pMediaType);
}

HRESULT MFSourceReaderSetCurrentPosition(IMFSourceReader* pSourceReader, REFGUID guidTimeFormat, REFPROPVARIANT varPosition)
{
	return pSourceReader->SetCurrentPosition(guidTimeFormat, varPosition);
}

HRESULT MFSourceReaderReadSample(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD dwControlFlags, DWORD *pdwActualStreamIndex, DWORD *pdwStreamFlags, LONGLONG *pllTimestamp, IMFSample **ppSample)
{
	return pSourceReader->ReadSample(dwStreamIndex, dwControlFlags, pdwActualStreamIndex, pdwStreamFlags, pllTimestamp, ppSample);
}

HRESULT MFSourceReaderFlush(IMFSourceReader* pSourceReader, DWORD dwStreamIndex)
{
	return pSourceReader->Flush(dwStreamIndex);
}

HRESULT MFSourceReaderGetServiceForStream(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, REFGUID guidService, REFIID riid, LPVOID *ppvObject)
{
	return pSourceReader->GetServiceForStream(dwStreamIndex, guidService, riid, ppvObject);
}

HRESULT MFSourceReaderGetPresentationAttribute(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, REFGUID guidAttribute, PROPVARIANT *pvarAttribute)
{
	return pSourceReader->GetPresentationAttribute(dwStreamIndex, guidAttribute, pvarAttribute);
}