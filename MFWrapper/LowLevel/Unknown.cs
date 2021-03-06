﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MFWrapper
{
    public abstract class Unknown : IDisposable
    {
        private bool _ownsInstance;
        protected IntPtr _instance;
        public IntPtr NativePointer => _instance;

        public Unknown(IntPtr instance, bool ownsInstance)
        {
            _instance = instance;
            _ownsInstance = ownsInstance;

            if (!_ownsInstance)
            {
                GC.SuppressFinalize(this);
            }
        }

        public void QueryInterface(in Guid riid, out IntPtr ppvObject)
        {
            Marshal.ThrowExceptionForHR(NativeUnknownQueryInterface(_instance, in riid, out ppvObject));
        }

        public uint AddRef() => NativeUnknownAddRef(_instance);
        public uint Release() => NativeUnknownRelease(_instance);

        #region Cleanup
        public void Dispose()
        {
            Dispose(true);

            if (_ownsInstance)
            {
                GC.SuppressFinalize(this); 
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_instance == IntPtr.Zero) return;

            if (disposing)
            {
                // Free managed resources
            }

            Release();

            _instance = IntPtr.Zero;
        }

        ~Unknown() => Dispose(false);
        #endregion



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "UnknownQueryInterface")]
        //                                                    IUnknown*        REFIID         void**
        private static extern int NativeUnknownQueryInterface(IntPtr pUnknown, in Guid riid, out IntPtr ppvObject);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "UnknownAddRef")]
        //                                             IUnknown*
        private static extern uint NativeUnknownAddRef(IntPtr pUnknown);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "UnknownRelease")]
        //                                              IUnknown*
        private static extern uint NativeUnknownRelease(IntPtr pUnknown);
    }
}
