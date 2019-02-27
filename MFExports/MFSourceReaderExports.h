#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT CreateSourceReaderFromURL(LPCWSTR pwszURL, IMFAttributes* pAttributes, IMFSourceReader** ppSourceReader);
MFEXPORTS_API HRESULT CreateSourceReaderFromByteStream(IMFByteStream *pByteStream, IMFAttributes *pAttributes, IMFSourceReader **ppSourceReader);
MFEXPORTS_API HRESULT CreateSourceReaderFromMediaSource(IMFMediaSource *pMediaSource, IMFAttributes *pAttributes, IMFSourceReader **ppSourceReader);

MFEXPORTS_API HRESULT MFSourceReaderGetStreamSelection(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, BOOL *pfSelected);
MFEXPORTS_API HRESULT MFSourceReaderSetStreamSelection(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, BOOL fSelected);
MFEXPORTS_API HRESULT MFSourceReaderGetNativeMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD dwMediaTypeIndex, IMFMediaType **ppMediaType);
MFEXPORTS_API HRESULT MFSourceReaderGetCurrentMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, IMFMediaType **ppMediaType);
MFEXPORTS_API HRESULT MFSourceReaderSetCurrentMediaType(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD *pdwReserved, IMFMediaType *pMediaType);
MFEXPORTS_API HRESULT MFSourceReaderSetCurrentPosition(IMFSourceReader* pSourceReader, REFGUID guidTimeFormat, REFPROPVARIANT varPosition);
MFEXPORTS_API HRESULT MFSourceReaderReadSample(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, DWORD dwControlFlags, DWORD *pdwActualStreamIndex, DWORD *pdwStreamFlags, LONGLONG *pllTimestamp, IMFSample **ppSample);
MFEXPORTS_API HRESULT MFSourceReaderFlush(IMFSourceReader* pSourceReader, DWORD dwStreamIndex);
MFEXPORTS_API HRESULT MFSourceReaderGetServiceForStream(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, REFGUID guidService, REFIID riid, LPVOID *ppvObject);
MFEXPORTS_API HRESULT MFSourceReaderGetPresentationAttribute(IMFSourceReader* pSourceReader, DWORD dwStreamIndex, REFGUID guidAttribute, PROPVARIANT *pvarAttribute);