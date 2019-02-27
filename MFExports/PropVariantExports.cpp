#include "stdafx.h"
#include "PropVariantExports.h"



void PVInit(PROPVARIANT *pvar)
{
	PropVariantInit(pvar);
}

HRESULT PVCopy(PROPVARIANT *pvarDest, PROPVARIANT *pvarSrc)
{
	return PropVariantCopy(pvarDest, pvarSrc);
}

HRESULT PVClear(PROPVARIANT *pvar)
{
	return PropVariantClear(pvar);
}