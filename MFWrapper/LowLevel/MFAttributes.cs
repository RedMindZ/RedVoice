﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MFWrapper
{
    public class MFAttributes : Unknown
    {
        public MFAttributes(IntPtr instance, bool ownsInstance) : base(instance, ownsInstance) { }

        public MFAttributes(uint initialSize) : base(IntPtr.Zero, true)
        {
            Marshal.ThrowExceptionForHR(NativeCreateAttributes(out _instance, initialSize));
        }



        public void GetItem(in Guid guidKey, out PropVariant propValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetItem(_instance, in guidKey, out propValue));
        }

        public void GetItemType(in Guid guidKey, out MFAttributeType attributeType)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetItemType(_instance, in guidKey, out attributeType));
        }

        public void CompareItem(in Guid guidKey, in PropVariant val, out bool pbResult)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesCompareItem(_instance, in guidKey, in val, out pbResult));
        }

        public void Compare(MFAttributes pTheirs, MFAttributesMatchType matchType, out bool pbResult)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesCompare(_instance, pTheirs._instance, matchType, out pbResult));
        }

        public void GetUINT32(in Guid guidKey, out uint punValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetUINT32(_instance, in guidKey, out punValue));
        }

        public void GetUINT64(in Guid guidKey, out ulong punValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetUINT64(_instance, in guidKey, out punValue));
        }

        public void GetDouble(in Guid guidKey, out double pfValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetDouble(_instance, in guidKey, out pfValue));
        }

        public void GetGUID(in Guid guidKey, out Guid pguidValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetGUID(_instance, in guidKey, out pguidValue));
        }

        public void GetStringLength(in Guid guidKey, out uint pcchLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetStringLength(_instance, in guidKey, out pcchLength));
        }

        public void GetString(in Guid guidKey, StringBuilder pwszValue, out uint pcchLength)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetString(_instance, in guidKey, pwszValue, (uint)pwszValue.Capacity, out pcchLength));
        }

        public void GetAllocatedString(in Guid guidKey, out string ppwszValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetAllocatedString(_instance, in guidKey, out IntPtr lpwstrValue, out uint pcchLength));
            ppwszValue = Marshal.PtrToStringUni(lpwstrValue, (int)pcchLength);
            Marshal.FreeCoTaskMem(lpwstrValue);
        }

        public void GetBlobSize(in Guid guidKey, out uint pcbBlobSize)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetBlobSize(_instance, in guidKey, out pcbBlobSize));
        }

        public void GetBlob(in Guid guidKey, byte[] pBuf, out uint pcbBlobSize)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetBlob(_instance, in guidKey, pBuf, (uint)pBuf.Length, out pcbBlobSize));
        }

        public void GetAllocatedBlob(in Guid guidKey, out byte[] buffer)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetAllocatedBlob(_instance, in guidKey, out IntPtr pBuf, out uint pcbSize));
            buffer = new byte[pcbSize];
            Marshal.Copy(pBuf, buffer, 0, buffer.Length);
            Marshal.FreeCoTaskMem(pBuf);
        }

        public void GetUnknown(in Guid guidKey, in Guid riid, out IntPtr ppv)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetUnknown(_instance, in guidKey, in riid, out ppv));
        }

        public void SetItem(in Guid guidKey, ref PropVariant val)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetItem(_instance, in guidKey, in val));
        }

        public void DeleteItem(in Guid guidKey)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesDeleteItem(_instance, in guidKey));
        }

        public void DeleteAllItems()
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesDeleteAllItems(_instance));
        }

        public void SetUINT32(in Guid guidKey, uint unValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetUINT32(_instance, in guidKey, unValue));
        }

        public void SetUINT64(in Guid guidKey, ulong unValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetUINT64(_instance, in guidKey, unValue));
        }

        public void SetDouble(in Guid guidKey, double fValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetDouble(_instance, in guidKey, fValue));
        }

        public void SetGUID(in Guid guidKey, in Guid guidValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetGUID(_instance, in guidKey, in guidValue));
        }

        public void SetString(in Guid guidKey, string wszValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetString(_instance, in guidKey, wszValue));
        }

        public void SetBlob(in Guid guidKey, byte[] pBuf)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetBlob(_instance, in guidKey, pBuf, (uint)pBuf.Length));
        }

        public void SetUnknown(in Guid guidKey, Unknown pUnknown)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesSetUnknown(_instance, in guidKey, pUnknown.NativePointer));
        }

        public void LockStore()
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesLockStore(_instance));
        }

        public void UnlockStore()
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesUnlockStore(_instance));
        }

        public void GetCount(out uint pcItems)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetCount(_instance, out pcItems));
        }

        public void GetItemByIndex(uint unIndex, out Guid pguidKey, out PropVariant pValue)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesGetItemByIndex(_instance, unIndex, out pguidKey, out pValue));
        }

        public void CopyAllItems(MFAttributes pDest)
        {
            Marshal.ThrowExceptionForHR(NativeMFAttributesCopyAllItems(_instance, pDest._instance));
        }



        #region Native Methods
        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "CreateAttributes")]
        //                                               IMFAttributes**            UINT32
        private static extern int NativeCreateAttributes(out IntPtr ppMFAttributes, uint cInitialSize);



        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetItem")]
        //                                                  IMFAttributes*      REFGUID          PROPVARIANT*
        private static extern int NativeMFAttributesGetItem(IntPtr pAttributes, in Guid guidKey, out PropVariant pValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetItemType")]
        //                                                      IMFAttributes*      REFGUID          MF_ATTRIBUTE_TYPE*
        private static extern int NativeMFAttributesGetItemType(IntPtr pAttributes, in Guid guidKey, out MFAttributeType pType);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesCompareItem")]
        //                                                      IMFAttributes*      REFGUID          REFPROPVARIANT        BOOL*
        private static extern int NativeMFAttributesCompareItem(IntPtr pAttributes, in Guid guidKey, in PropVariant Value, [MarshalAs(UnmanagedType.Bool)] out bool pbResult);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesCompare")]
        //                                                  IMFAttributes*      IMFAttributes*  MF_ATTRIBUTES_MATCH_TYPE         BOOL*
        private static extern int NativeMFAttributesCompare(IntPtr pAttributes, IntPtr pTheirs, MFAttributesMatchType MatchType, [MarshalAs(UnmanagedType.Bool)] out bool pbResult);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetUINT32")]
        //                                                    IMFAttributes*      REFGUID          UINT32*
        private static extern int NativeMFAttributesGetUINT32(IntPtr pAttributes, in Guid guidKey, out uint punValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetUINT64")]
        //                                                    IMFAttributes*      REFGUID          UINT64*
        private static extern int NativeMFAttributesGetUINT64(IntPtr pAttributes, in Guid guidKey, out ulong punValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetDouble")]
        //                                                    IMFAttributes*      REFGUID          double*
        private static extern int NativeMFAttributesGetDouble(IntPtr pAttributes, in Guid guidKey, out double pfValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetGUID")]
        //                                                  IMFAttributes*      REFGUID          GUID*
        private static extern int NativeMFAttributesGetGUID(IntPtr pAttributes, in Guid guidKey, out Guid pguidValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetStringLength")]
        //                                                          IMFAttributes*      REFGUID          UINT32*
        private static extern int NativeMFAttributesGetStringLength(IntPtr pAttributes, in Guid guidKey, out uint pcchLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetString")]
        //                                                    IMFAttributes*      REFGUID          LPWSTR                                                     UINT32           UINT32*
        private static extern int NativeMFAttributesGetString(IntPtr pAttributes, in Guid guidKey, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszValue, uint cchBufSize, out uint pcchLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetAllocatedString")]
        //                                                             IMFAttributes*      REFGUID          LPWSTR*                UINT32*
        private static extern int NativeMFAttributesGetAllocatedString(IntPtr pAttributes, in Guid guidKey, out IntPtr ppwszValue, out uint pcchLength);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetBlobSize")]
        //                                                      IMFAttributes*      REFGUID          UINT32*
        private static extern int NativeMFAttributesGetBlobSize(IntPtr pAttributes, in Guid guidKey, out uint pcbBlobSize);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetBlob")]
        //                                                  IMFAttributes*      REFGUID          UINT8*       UINT32          UINT32*
        private static extern int NativeMFAttributesGetBlob(IntPtr pAttributes, in Guid guidKey, byte[] pBuf, uint cbBufSize, out uint pcbBlobSize);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetAllocatedBlob")]
        //                                                           IMFAttributes*      REFGUID          UINT8**           UINT32*
        private static extern int NativeMFAttributesGetAllocatedBlob(IntPtr pAttributes, in Guid guidKey, out IntPtr ppBuf, out uint pcbSize);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetUnknown")]
        //                                                     IMFAttributes*      REFGUID          REFIID        LPVOID*
        private static extern int NativeMFAttributesGetUnknown(IntPtr pAttributes, in Guid guidKey, in Guid riid, out IntPtr ppv);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetItem")]
        //                                                  IMFAttributes*      REFGUID          REFPROPVARIANT
        private static extern int NativeMFAttributesSetItem(IntPtr pAttributes, in Guid guidKey, in PropVariant Value);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesDeleteItem")]
        //                                                     IMFAttributes*      REFGUID
        private static extern int NativeMFAttributesDeleteItem(IntPtr pAttributes, in Guid guidKey);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesDeleteAllItems")]
        //                                                         IMFAttributes*
        private static extern int NativeMFAttributesDeleteAllItems(IntPtr pAttributes);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetUINT32")]
        //                                                    IMFAttributes*      REFGUID          UINT32
        private static extern int NativeMFAttributesSetUINT32(IntPtr pAttributes, in Guid guidKey, uint unValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetUINT64")]
        //                                                    IMFAttributes*      REFGUID          UINT64
        private static extern int NativeMFAttributesSetUINT64(IntPtr pAttributes, in Guid guidKey, ulong unValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetDouble")]
        //                                                    IMFAttributes*      REFGUID          double
        private static extern int NativeMFAttributesSetDouble(IntPtr pAttributes, in Guid guidKey, double fValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetGUID")]
        //                                                  IMFAttributes*      REFGUID          REFGUID
        private static extern int NativeMFAttributesSetGUID(IntPtr pAttributes, in Guid guidKey, in Guid guidValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetString")]
        //                                                    IMFAttributes*      REFGUID           LPCWSTR
        private static extern int NativeMFAttributesSetString(IntPtr pAttributes, in Guid guidKey, [MarshalAs(UnmanagedType.LPWStr)] string wszValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetBlob")]
        //                                                  IMFAttributes*      REFGUID          UINT8*       UINT32
        private static extern int NativeMFAttributesSetBlob(IntPtr pAttributes, in Guid guidKey, byte[] pBuf, uint cbBufSize);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesSetUnknown")]
        //                                                     IMFAttributes*      REFGUID          IUnknown*
        private static extern int NativeMFAttributesSetUnknown(IntPtr pAttributes, in Guid guidKey, IntPtr pUnknown);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesLockStore")]
        //                                                    IMFAttributes*
        private static extern int NativeMFAttributesLockStore(IntPtr pAttributes);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesUnlockStore")]
        //                                                      IMFAttributes*
        private static extern int NativeMFAttributesUnlockStore(IntPtr pAttributes);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetCount")]
        //                                                   IMFAttributes*      UINT32*
        private static extern int NativeMFAttributesGetCount(IntPtr pAttributes, out uint pcItems);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesGetItemByIndex")]
        //                                                         IMFAttributes*      UINT32        GUID*              PROPVARIANT*
        private static extern int NativeMFAttributesGetItemByIndex(IntPtr pAttributes, uint unIndex, out Guid pguidKey, out PropVariant pValue);

        [DllImport(MediaFoundation.EXPORTS_DLL, CallingConvention = CallingConvention.Cdecl, EntryPoint = "MFAttributesCopyAllItems")]
        //                                                       IMFAttributes*      IMFAttributes*
        private static extern int NativeMFAttributesCopyAllItems(IntPtr pAttributes, IntPtr pDest);
        #endregion
    }
}
