#include "stdafx.h"
#include "MFAttributesExports.h"



HRESULT CreateAttributes(IMFAttributes** ppMFAttributes, UINT32 cInitialSize)
{
	return MFCreateAttributes(ppMFAttributes, cInitialSize);
}

HRESULT MFAttributesGetItem(IMFAttributes *pAttributes, REFGUID guidKey, PROPVARIANT *pValue)
{
	return pAttributes->GetItem(guidKey, pValue);
}

HRESULT MFAttributesGetItemType(IMFAttributes *pAttributes, REFGUID guidKey, MF_ATTRIBUTE_TYPE *pType)
{
	return pAttributes->GetItemType(guidKey, pType);
}

HRESULT MFAttributesCompareItem(IMFAttributes *pAttributes, REFGUID guidKey, REFPROPVARIANT val, BOOL *pbResult)
{
	return pAttributes->CompareItem(guidKey, val, pbResult);
}

HRESULT MFAttributesCompare(IMFAttributes *pAttributes, IMFAttributes *pTheirs, MF_ATTRIBUTES_MATCH_TYPE matchType, BOOL *pbResult)
{
	return pAttributes->Compare(pTheirs, matchType, pbResult);
}

HRESULT MFAttributesGetUINT32(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *punValue)
{
	return pAttributes->GetUINT32(guidKey, punValue);
}

HRESULT MFAttributesGetUINT64(IMFAttributes *pAttributes, REFGUID guidKey, UINT64 *punValue)
{
	return pAttributes->GetUINT64(guidKey, punValue);
}

HRESULT MFAttributesGetDouble(IMFAttributes *pAttributes, REFGUID guidKey, double *pfValue)
{
	return pAttributes->GetDouble(guidKey, pfValue);
}

HRESULT MFAttributesGetGUID(IMFAttributes *pAttributes, REFGUID guidKey, GUID *pguidValue)
{
	return pAttributes->GetGUID(guidKey, pguidValue);
}

HRESULT MFAttributesGetStringLength(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *pcchLength)
{
	return pAttributes->GetStringLength(guidKey, pcchLength);
}

HRESULT MFAttributesGetString(IMFAttributes *pAttributes, REFGUID guidKey, LPWSTR pwszValue, UINT32 cchBufSize, UINT32 *pcchLength)
{
	return pAttributes->GetString(guidKey, pwszValue, cchBufSize, pcchLength);
}

HRESULT MFAttributesGetAllocatedString(IMFAttributes *pAttributes, REFGUID guidKey, LPWSTR *ppwszValue, UINT32 *pcchLength)
{
	return pAttributes->GetAllocatedString(guidKey, ppwszValue, pcchLength);
}

HRESULT MFAttributesGetBlobSize(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 *pcbBlobSize)
{
	return pAttributes->GetBlobSize(guidKey, pcbBlobSize);
}

HRESULT MFAttributesGetBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 *pBuf, UINT32 cbBufSize, UINT32 *pcbBlobSize)
{
	return pAttributes->GetBlob(guidKey, pBuf, cbBufSize, pcbBlobSize);
}

HRESULT MFAttributesGetAllocatedBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 **ppBuf, UINT32 *pcbSize)
{
	return pAttributes->GetAllocatedBlob(guidKey, ppBuf, pcbSize);
}

HRESULT MFAttributesGetUnknown(IMFAttributes *pAttributes, REFGUID guidKey, REFIID riid, LPVOID *ppv)
{
	return pAttributes->GetUnknown(guidKey, riid, ppv);
}

HRESULT MFAttributesSetItem(IMFAttributes *pAttributes, REFGUID guidKey, REFPROPVARIANT val)
{
	return pAttributes->SetItem(guidKey, val);
}

HRESULT MFAttributesDeleteItem(IMFAttributes *pAttributes, REFGUID guidKey)
{
	return pAttributes->DeleteItem(guidKey);
}

HRESULT MFAttributesDeleteAllItems(IMFAttributes *pAttributes)
{
	return pAttributes->DeleteAllItems();
}

HRESULT MFAttributesSetUINT32(IMFAttributes *pAttributes, REFGUID guidKey, UINT32 unValue)
{
	return pAttributes->SetUINT32(guidKey, unValue);
}

HRESULT MFAttributesSetUINT64(IMFAttributes *pAttributes, REFGUID guidKey, UINT64 unValue)
{
	return pAttributes->SetUINT64(guidKey, unValue);
}

HRESULT MFAttributesSetDouble(IMFAttributes *pAttributes, REFGUID guidKey, double fValue)
{
	return pAttributes->SetDouble(guidKey, fValue);
}

HRESULT MFAttributesSetGUID(IMFAttributes *pAttributes, REFGUID guidKey, REFGUID guidValue)
{
	return pAttributes->SetGUID(guidKey, guidValue);
}

HRESULT MFAttributesSetString(IMFAttributes *pAttributes, REFGUID guidKey, LPCWSTR wszValue)
{
	return pAttributes->SetString(guidKey, wszValue);
}

HRESULT MFAttributesSetBlob(IMFAttributes *pAttributes, REFGUID guidKey, UINT8 *pBuf, UINT32 cbBufSize)
{
	return pAttributes->SetBlob(guidKey, pBuf, cbBufSize);
}

HRESULT MFAttributesSetUnknown(IMFAttributes *pAttributes, REFGUID guidKey, IUnknown *pUnknown)
{
	return pAttributes->SetUnknown(guidKey, pUnknown);
}

HRESULT MFAttributesLockStore(IMFAttributes *pAttributes)
{
	return pAttributes->LockStore();
}

HRESULT MFAttributesUnlockStore(IMFAttributes *pAttributes)
{
	return pAttributes->UnlockStore();
}

HRESULT MFAttributesGetCount(IMFAttributes *pAttributes, UINT32 *pcItems)
{
	return pAttributes->GetCount(pcItems);
}

HRESULT MFAttributesGetItemByIndex(IMFAttributes *pAttributes, UINT32 unIndex, GUID *pguidKey, PROPVARIANT *pValue)
{
	return pAttributes->GetItemByIndex(unIndex, pguidKey, pValue);
}

HRESULT MFAttributesCopyAllItems(IMFAttributes *pAttributes, IMFAttributes *pDest)
{
	return pAttributes->CopyAllItems(pDest);
}