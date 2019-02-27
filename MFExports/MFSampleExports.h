#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT CreateSample(IMFSample **ppIMFSample);

MFEXPORTS_API HRESULT MFSampleGetSampleFlags(IMFSample *pSample, DWORD *pdwSampleFlags);
MFEXPORTS_API HRESULT MFSampleSetSampleFlags(IMFSample *pSample, DWORD dwSampleFlags);
MFEXPORTS_API HRESULT MFSampleGetSampleTime(IMFSample *pSample, LONGLONG *phnsSampleTime);
MFEXPORTS_API HRESULT MFSampleSetSampleTime(IMFSample *pSample, LONGLONG hnsSampleTime);
MFEXPORTS_API HRESULT MFSampleGetSampleDuration(IMFSample *pSample, LONGLONG *phnsSampleDuration);
MFEXPORTS_API HRESULT MFSampleSetSampleDuration(IMFSample *pSample, LONGLONG hnsSampleDuration);
MFEXPORTS_API HRESULT MFSampleGetBufferCount(IMFSample *pSample, DWORD *pdwBufferCount);
MFEXPORTS_API HRESULT MFSampleGetBufferByIndex(IMFSample *pSample, DWORD dwIndex, IMFMediaBuffer **ppBuffer);
MFEXPORTS_API HRESULT MFSampleConvertToContiguousBuffer(IMFSample *pSample, IMFMediaBuffer **ppBuffer);
MFEXPORTS_API HRESULT MFSampleAddBuffer(IMFSample *pSample, IMFMediaBuffer *pBuffer);
MFEXPORTS_API HRESULT MFSampleRemoveBufferByIndex(IMFSample *pSample, DWORD dwIndex);
MFEXPORTS_API HRESULT MFSampleRemoveAllBuffers(IMFSample *pSample);
MFEXPORTS_API HRESULT MFSampleGetTotalLength(IMFSample *pSample, DWORD *pcbTotalLength);
MFEXPORTS_API HRESULT MFSampleCopyToBuffer(IMFSample *pSample, IMFMediaBuffer *pBuffer);