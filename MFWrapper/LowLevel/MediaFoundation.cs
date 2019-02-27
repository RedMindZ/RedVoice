using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MFWrapper
{
    public static class MediaFoundation
    {
        public const string EXPORTS_DLL = "MFExports.dll";



        public static void InitializeCOM(CoInit coInitFlags)
        {
            Marshal.ThrowExceptionForHR(NativeInitializeCOM((uint)coInitFlags));
        }

        public static void InitializeMediaFoundation(MFStartup startupFlags)
        {
            Marshal.ThrowExceptionForHR(NativeInitializeMediaFoundation((uint)startupFlags));
        }

        public static void UninitializeMediaFoundation()
        {
            Marshal.ThrowExceptionForHR(NativeUninitializeMediaFoundation());
        }

        public static void UninitializeCOM()
        {
            NativeUninitializeCOM();
        }



        [DllImport(EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "InitializeCOM")]
        private static extern int NativeInitializeCOM(uint dwCoInit);

        [DllImport(EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "InitializeMediaFoundation")]
        private static extern int NativeInitializeMediaFoundation(uint dwFlags);

        [DllImport(EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "UninitializeMediaFoundation")]
        private static extern int NativeUninitializeMediaFoundation();

        [DllImport(EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "UninitializeCOM")]
        private static extern void NativeUninitializeCOM();
    }
}
