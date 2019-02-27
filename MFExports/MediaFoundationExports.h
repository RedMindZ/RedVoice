#pragma once

#include "ExportsHelper.h"

MFEXPORTS_API HRESULT InitializeCOM(DWORD dwCoInit);
MFEXPORTS_API HRESULT InitializeMediaFoundation(DWORD dwFlags);
MFEXPORTS_API HRESULT UninitializeMediaFoundation();
MFEXPORTS_API void UninitializeCOM();