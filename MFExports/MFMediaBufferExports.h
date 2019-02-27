#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT CreateMediaBufferFromMediaType(IMFMediaType* pMediaType, LONGLONG llDuration, DWORD dwMinLength, DWORD dwMinAlignment, IMFMediaBuffer** ppBuffer);
MFEXPORTS_API HRESULT CreateMediaBufferWrapper(IMFMediaBuffer *pBuffer, DWORD cbOffset, DWORD dwLength, IMFMediaBuffer **ppBuffer);

MFEXPORTS_API HRESULT MFMediaBufferLock(IMFMediaBuffer *pMediaBuffer, BYTE **ppbBuffer, DWORD *pcbMaxLength, DWORD *pcbCurrentLength);
MFEXPORTS_API HRESULT MFMediaBufferUnlock(IMFMediaBuffer *pMediaBuffer);
MFEXPORTS_API HRESULT MFMediaBufferGetCurrentLength(IMFMediaBuffer *pMediaBuffer, DWORD *pcbCurrentLength);
MFEXPORTS_API HRESULT MFMediaBufferSetCurrentLength(IMFMediaBuffer *pMediaBuffer, DWORD cbCurrentLength);
MFEXPORTS_API HRESULT MFMediaBufferGetMaxLength(IMFMediaBuffer *pMediaBuffer, DWORD *pcbMaxLength);