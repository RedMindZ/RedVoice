#include "stdafx.h"
#include "MediaFoundationExports.h"



HRESULT InitializeCOM(DWORD dwCoInit)
{
	return CoInitializeEx(NULL, dwCoInit);
}

HRESULT InitializeMediaFoundation(DWORD dwFlags)
{
	return MFStartup(MF_VERSION, dwFlags);
}

HRESULT UninitializeMediaFoundation()
{
	return MFShutdown();
}

void UninitializeCOM()
{
	CoUninitialize();
}