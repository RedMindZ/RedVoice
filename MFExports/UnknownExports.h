#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT UnknownQueryInterface(IUnknown* pUnknown, REFIID riid, void **ppvObject);
MFEXPORTS_API ULONG UnknownAddRef(IUnknown* pUnknown);
MFEXPORTS_API ULONG UnknownRelease(IUnknown* pUnknown);