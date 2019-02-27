#include "stdafx.h"
#include "MFMediaBufferExports.h"



HRESULT CreateMediaBufferFromMediaType(IMFMediaType* pMediaType, LONGLONG llDuration, DWORD dwMinLength, DWORD dwMinAlignment, IMFMediaBuffer** ppBuffer)
{
	return MFCreateMediaBufferFromMediaType(pMediaType, llDuration, dwMinLength, dwMinAlignment, ppBuffer);
}

HRESULT CreateMediaBufferWrapper(IMFMediaBuffer *pBuffer, DWORD cbOffset, DWORD dwLength, IMFMediaBuffer **ppBuffer)
{
	return MFCreateMediaBufferWrapper(pBuffer, cbOffset, dwLength, ppBuffer);
}

HRESULT MFMediaBufferLock(IMFMediaBuffer *pMediaBuffer, BYTE **ppbBuffer, DWORD *pcbMaxLength, DWORD *pcbCurrentLength)
{
	return pMediaBuffer->Lock(ppbBuffer, pcbMaxLength, pcbCurrentLength);
}

HRESULT MFMediaBufferUnlock(IMFMediaBuffer *pMediaBuffer)
{
	return pMediaBuffer->Unlock();
}

HRESULT MFMediaBufferGetCurrentLength(IMFMediaBuffer *pMediaBuffer, DWORD *pcbCurrentLength)
{
	return pMediaBuffer->GetCurrentLength(pcbCurrentLength);
}

HRESULT MFMediaBufferSetCurrentLength(IMFMediaBuffer *pMediaBuffer, DWORD cbCurrentLength)
{
	return pMediaBuffer->SetCurrentLength(cbCurrentLength);
}

HRESULT MFMediaBufferGetMaxLength(IMFMediaBuffer *pMediaBuffer, DWORD *pcbMaxLength)
{
	return pMediaBuffer->GetMaxLength(pcbMaxLength);
}