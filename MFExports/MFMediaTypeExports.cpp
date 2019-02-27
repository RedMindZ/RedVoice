#include "stdafx.h"
#include "MFMediaTypeExports.h"



HRESULT CreateMediaType(IMFMediaType **ppMFType)
{
	return MFCreateMediaType(ppMFType);
}

HRESULT CreateMediaTypeFromProperties(IUnknown *punkStream, IMFMediaType **ppMediaType)
{
	return MFCreateMediaTypeFromProperties(punkStream, ppMediaType);
}

HRESULT CreateMediaTypeFromRepresentation(GUID guidRepresentation, LPVOID pvRepresentation, IMFMediaType **ppIMediaType)
{
	return MFCreateMediaTypeFromRepresentation(guidRepresentation, pvRepresentation, ppIMediaType);
}

HRESULT MFMediaTypeGetMajorType(IMFMediaType *pMediaType, GUID *pguidMajorType)
{
	return pMediaType->GetMajorType(pguidMajorType);
}

HRESULT MFMediaTypeIsCompressedFormat(IMFMediaType *pMediaType, BOOL *pfCompressed)
{
	return pMediaType->IsCompressedFormat(pfCompressed);
}

HRESULT MFMediaTypeIsEqual(IMFMediaType *pMediaType, IMFMediaType *pOtherMediaType, DWORD *pdwFlags)
{
	return pMediaType->IsEqual(pOtherMediaType, pdwFlags);
}

HRESULT MFMediaTypeGetRepresentation(IMFMediaType *pMediaType, GUID guidRepresentation, LPVOID *ppvRepresentation)
{
	return pMediaType->GetRepresentation(guidRepresentation, ppvRepresentation);
}

HRESULT MFMediaTypeFreeRepresentation(IMFMediaType *pMediaType, GUID guidRepresentation, LPVOID pvRepresentation)
{
	return pMediaType->FreeRepresentation(guidRepresentation, pvRepresentation);
}