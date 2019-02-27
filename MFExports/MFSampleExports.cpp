#include "stdafx.h"
#include "MFSampleExports.h"



HRESULT CreateSample(IMFSample **ppIMFSample)
{
	return MFCreateSample(ppIMFSample);
}

HRESULT MFSampleGetSampleFlags(IMFSample *pSample, DWORD *pdwSampleFlags)
{
	return pSample->GetSampleFlags(pdwSampleFlags);
}

HRESULT MFSampleSetSampleFlags(IMFSample *pSample, DWORD dwSampleFlags)
{
	return pSample->SetSampleFlags(dwSampleFlags);
}

HRESULT MFSampleGetSampleTime(IMFSample *pSample, LONGLONG *phnsSampleTime)
{
	return pSample->GetSampleTime(phnsSampleTime);
}

HRESULT MFSampleSetSampleTime(IMFSample *pSample, LONGLONG hnsSampleTime)
{
	return pSample->SetSampleTime(hnsSampleTime);
}

HRESULT MFSampleGetSampleDuration(IMFSample *pSample, LONGLONG *phnsSampleDuration)
{
	return pSample->GetSampleDuration(phnsSampleDuration);
}

HRESULT MFSampleSetSampleDuration(IMFSample *pSample, LONGLONG hnsSampleDuration)
{
	return pSample->SetSampleDuration(hnsSampleDuration);
}

HRESULT MFSampleGetBufferCount(IMFSample *pSample, DWORD *pdwBufferCount)
{
	return pSample->GetBufferCount(pdwBufferCount);
}

HRESULT MFSampleGetBufferByIndex(IMFSample *pSample, DWORD dwIndex, IMFMediaBuffer **ppBuffer)
{
	return pSample->GetBufferByIndex(dwIndex, ppBuffer);
}

HRESULT MFSampleConvertToContiguousBuffer(IMFSample *pSample, IMFMediaBuffer **ppBuffer)
{
	return pSample->ConvertToContiguousBuffer(ppBuffer);
}

HRESULT MFSampleAddBuffer(IMFSample *pSample, IMFMediaBuffer *pBuffer)
{
	return pSample->AddBuffer(pBuffer);
}

HRESULT MFSampleRemoveBufferByIndex(IMFSample *pSample, DWORD dwIndex)
{
	return pSample->RemoveBufferByIndex(dwIndex);
}

HRESULT MFSampleRemoveAllBuffers(IMFSample *pSample)
{
	return pSample->RemoveAllBuffers();
}

HRESULT MFSampleGetTotalLength(IMFSample *pSample, DWORD *pcbTotalLength)
{
	return pSample->GetTotalLength(pcbTotalLength);
}

HRESULT MFSampleCopyToBuffer(IMFSample *pSample, IMFMediaBuffer *pBuffer)
{
	return pSample->CopyToBuffer(pBuffer);
}