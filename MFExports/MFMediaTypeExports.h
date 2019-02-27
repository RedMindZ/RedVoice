#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT CreateMediaType(IMFMediaType **ppMFType);
MFEXPORTS_API HRESULT CreateMediaTypeFromProperties(IUnknown *punkStream, IMFMediaType **ppMediaType);
MFEXPORTS_API HRESULT CreateMediaTypeFromRepresentation(GUID guidRepresentation, LPVOID pvRepresentation, IMFMediaType **ppIMediaType);

MFEXPORTS_API HRESULT MFMediaTypeGetMajorType(IMFMediaType *pMediaType, GUID *pguidMajorType);
MFEXPORTS_API HRESULT MFMediaTypeIsCompressedFormat(IMFMediaType *pMediaType, BOOL *pfCompressed);
MFEXPORTS_API HRESULT MFMediaTypeIsEqual(IMFMediaType *pMediaType, IMFMediaType *pOtherMediaType, DWORD *pdwFlags);
MFEXPORTS_API HRESULT MFMediaTypeGetRepresentation(IMFMediaType *pMediaType, GUID guidRepresentation, LPVOID *ppvRepresentation);
MFEXPORTS_API HRESULT MFMediaTypeFreeRepresentation(IMFMediaType *pMediaType, GUID guidRepresentation, LPVOID pvRepresentation);