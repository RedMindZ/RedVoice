#pragma once

#ifdef MFEXPORTS_EXPORTS
#define MFEXPORTS_API extern "C" __declspec(dllexport)
#else
#define MFEXPORTS_API extern "C" __declspec(dllimport)
#endif