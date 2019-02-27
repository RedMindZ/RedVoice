#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT CreateAttributes(IMFAttributes** ppMFAttributes, UINT32 cInitialSize);

MFEXPORTS_API HRESULT MFAttributesGetItem(IMFAttributes *pAttributes, REFGUID guidKey, PROPVARIANT *pValue);
MFEXPORTS_API HRESULT MFAttributesGetItemType(IMFAttributes *pAttributes, REFGUID guidKey, MF_ATTRIBUTE_TYPE *pType);
MFEXPORTS_API HRESULT MFAttributesCompareItem(IMFAttributes *pAttributes, REFGUID guidKey, REFPROPVARIANT val, BOOL *pbResult);
MFEXPORTS_API HRESULT MFAttributesCompare(IMFAttributes *pAttributes, IMFAttributes *pTheirs, MF_ATTRIBUTES_MATCH_TYPE matchType, BOOL *pbResult);
MFEXPORTS_API HRESULT MFAttributesGetUINT32(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *punValue);
MFEXPORTS_API HRESULT MFAttributesGetUINT64(IMFAttributes *pAttributes, REFGUID guidKey, UINT64 *punValue);
MFEXPORTS_API HRESULT MFAttributesGetDouble(IMFAttributes *pAttributes, REFGUID guidKey, double *pfValue);
MFEXPORTS_API HRESULT MFAttributesGetGUID(IMFAttributes *pAttributes, REFGUID guidKey, GUID *pguidValue);
MFEXPORTS_API HRESULT MFAttributesGetStringLength(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *pcchLength);
MFEXPORTS_API HRESULT MFAttributesGetString(IMFAttributes *pAttributes, REFGUID guidKey, LPWSTR pwszValue, UINT32 cchBufSize, UINT32 *pcchLength);
MFEXPORTS_API HRESULT MFAttributesGetAllocatedString(IMFAttributes *pAttributes, REFGUID guidKey, LPWSTR *ppwszValue, UINT32 *pcchLength);
MFEXPORTS_API HRESULT MFAttributesGetBlobSize(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *pcbBlobSize);
MFEXPORTS_API HRESULT MFAttributesGetBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 *pBuf, UINT32 cbBufSize, UINT32 *pcbBlobSize);
MFEXPORTS_API HRESULT MFAttributesGetAllocatedBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 **ppBuf, UINT32 *pcbSize);
MFEXPORTS_API HRESULT MFAttributesGetUnknown(IMFAttributes *pAttributes, REFGUID guidKey, REFIID riid, LPVOID *ppv);
MFEXPORTS_API HRESULT MFAttributesSetItem(IMFAttributes *pAttributes, REFGUID guidKey, REFPROPVARIANT Value);
MFEXPORTS_API HRESULT MFAttributesDeleteItem(IMFAttributes *pAttributes, REFGUID guidKey);
MFEXPORTS_API HRESULT MFAttributesDeleteAllItems(IMFAttributes *pAttributes);
MFEXPORTS_API HRESULT MFAttributesSetUINT32(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 unValue);
MFEXPORTS_API HRESULT MFAttributesSetUINT64(IMFAttributes *pAttributes, REFGUID guidKey, UINT64 unValue);
MFEXPORTS_API HRESULT MFAttributesSetDouble(IMFAttributes *pAttributes, REFGUID guidKey, double fValue);
MFEXPORTS_API HRESULT MFAttributesSetGUID(IMFAttributes *pAttributes, REFGUID guidKey, REFGUID guidValue);
MFEXPORTS_API HRESULT MFAttributesSetString(IMFAttributes *pAttributes, REFGUID guidKey, LPCWSTR wszValue);
MFEXPORTS_API HRESULT MFAttributesSetBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 *pBuf, UINT32 cbBufSize);
MFEXPORTS_API HRESULT MFAttributesSetUnknown(IMFAttributes *pAttributes, REFGUID guidKey, IUnknown *pUnknown);
MFEXPORTS_API HRESULT MFAttributesLockStore(IMFAttributes *pAttributes);
MFEXPORTS_API HRESULT MFAttributesUnlockStore(IMFAttributes *pAttributes);
MFEXPORTS_API HRESULT MFAttributesGetCount(IMFAttributes *pAttributes, UINT32 *pcItems);
MFEXPORTS_API HRESULT MFAttributesGetItemByIndex(IMFAttributes *pAttributes, UINT32 unIndex, GUID *pguidKey, PROPVARIANT *pValue);
MFEXPORTS_API HRESULT MFAttributesCopyAllItems(IMFAttributes *pAttributes, IMFAttributes *pDest);