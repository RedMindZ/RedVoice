#include "stdafx.h"
#include "UnknownExports.h"



HRESULT UnknownQueryInterface(IUnknown* pUnknown, REFIID riid, void **ppvObject)
{
	MF_SOURCE_READER_ALL_STREAMS;
	return pUnknown->QueryInterface(riid, ppvObject);
}

ULONG UnknownAddRef(IUnknown* pUnknown)
{
	return pUnknown->AddRef();
}

ULONG UnknownRelease(IUnknown* pUnknown)
{
	return pUnknown->Release();
}