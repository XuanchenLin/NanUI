// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chromium {
    internal class StringFunctions {

        static StringFunctions() {
            CfxApiLoader.LoadStringCollectionApi();
        }


        internal static string PtrToStringUni(IntPtr str, int length) {
            return
                str == IntPtr.Zero ? null
                : (length == 0 ? String.Empty : Marshal.PtrToStringUni(str, length));
        }


        public static string ConvertStringUserfree(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return string.Empty;

            int length = 0;
            var str = CfxApi.cfx_string_get_ptr(nativePtr, ref length);
            if(str.Equals(IntPtr.Zero))
                return string.Empty;
            var retval = Marshal.PtrToStringUni(str, length);
            CfxApi.cef_string_userfree_utf16_free(nativePtr);
            return retval;
        }


        //TODO: string list and string map


        // used in CfxPopupFeatures.AdditionalFeatures
        // the data is not meant to be modified by the application
        internal static List<string> WrapCfxStringList(IntPtr list) {
            if(list == IntPtr.Zero)
                return null;
            var size = CfxApi.Runtime.cfx_string_list_size(list);
            var target = new List<string>((int)size);
            CfxStringListCopyToManaged(list, target);
            return target;
        }

        // used in api calls to set and get data
        internal static IntPtr UnwrapCfxStringList(List<string> list, out PinnedString[] handles) {
            var target = AllocCfxStringList();
            CfxStringListCopyToNative(list, target, out handles);
            return target;
        }

        //unused
        //internal static List<string[]> WrapCfxStringMap(IntPtr value) {
        //    return null;
        //}

        // used in api call to get data
        internal static IntPtr UnwrapCfxStringMap(List<string[]> map, out PinnedString[] handles) {
            var target = AllocCfxStringMap();
            CfxStringMapCopyToNative(map, target, out handles);
            return target;
        }

        //unused
        //internal static List<string[]> WrapCfxStringMultimap(IntPtr value) {
        //    return null;
        //}

        // used in api calls to set and get data
        internal static IntPtr UnwrapCfxStringMultimap(List<string[]> map, out PinnedString[] handles) {
            var target = AllocCfxStringMultimap();
            CfxStringMultimapCopyToNative(map, target, out handles);
            return target;
        }

        internal static void FreePinnedStrings(PinnedString[] handles) {
            foreach(var h in handles) h.Obj.Free();
        }

        internal static IntPtr AllocCfxStringList() {
            var target = CfxApi.Runtime.cfx_string_list_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();
            return target;
        }

        internal static void FreeCfxStringList(IntPtr ptr) {
            CfxApi.Runtime.cfx_string_list_free(ptr);
        }

        internal static IntPtr AllocCfxStringMap() {
            var target = CfxApi.Runtime.cfx_string_map_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();
            return target;
        }

        internal static void FreeCfxStringMap(IntPtr ptr) {
            CfxApi.Runtime.cfx_string_map_free(ptr);
        }

        internal static IntPtr AllocCfxStringMultimap() {
            var target = CfxApi.Runtime.cfx_string_multimap_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();
            return target;
        }

        internal static void FreeCfxStringMultimap(IntPtr ptr) {
            CfxApi.Runtime.cfx_string_multimap_free(ptr);
        }

        internal static void CfxStringListCopyToManaged(IntPtr source, List<string> target) {
            var size = CfxApi.Runtime.cfx_string_list_size(source);
            IntPtr str;
            int length;
            target.Clear();
            UIntPtr current = UIntPtr.Zero;
            while(current != size) {
                if(CfxApi.Runtime.cfx_string_list_value(source, current, out str, out length) == 0) {
                    throw new CfxException("CfxStringList operation failed.");
                }
                target.Add(PtrToStringUni(str, length));
                current += 1;
            }
        }

        internal static void CfxStringListCopyToNative(List<string> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count];
            var ih = 0;
            CfxApi.Runtime.cfx_string_list_clear(target);
            foreach(var str in source) {
                var hValue = new PinnedString(str);
                CfxApi.Runtime.cfx_string_list_append(target, hValue.Obj.PinnedPtr, hValue.Length);
                handles[ih++] = hValue;
            }
        }

        internal static void CfxStringMapCopyToManaged(IntPtr source, List<string[]> target) {
            var size = CfxApi.Runtime.cfx_string_map_size(source);
            IntPtr str;
            int length;
            target.Clear();
            UIntPtr current = UIntPtr.Zero;
            while(current != size) {
                string[] pair = new string[2];
                if(CfxApi.Runtime.cfx_string_map_key(source, current, out str, out length) == 0) {
                    throw new CfxException("CfxStringMap operation failed.");
                }
                pair[0] = PtrToStringUni(str, length);
                if(CfxApi.Runtime.cfx_string_map_value(source, current, out str, out length) == 0) {
                    throw new CfxException("CfxStringMap operation failed.");
                }
                pair[1] = PtrToStringUni(str, length);
                target.Add(pair);
                current += 1;
            }
        }

        internal static void CfxStringMapCopyToNative(List<string[]> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count * 2];
            var ih = 0;
            CfxApi.Runtime.cfx_string_map_clear(target);
            foreach(var pair in source) {
                var hKey = new PinnedString(pair[0]);
                var hValue = new PinnedString(pair[1]);
                if(CfxApi.Runtime.cfx_string_map_append(target, hKey.Obj.PinnedPtr, hKey.Length, hValue.Obj.PinnedPtr, hValue.Length) == 0)
                    throw new CfxException("CfxStringMultimap operation failed.");
                handles[ih++] = hKey;
                handles[ih++] = hValue;
            }
        }


        internal static void CfxStringMultimapCopyToManaged(IntPtr source, List<string[]> target) {
            var size = CfxApi.Runtime.cfx_string_multimap_size(source);
            IntPtr str;
            int length;
            target.Clear();
            UIntPtr current = UIntPtr.Zero;
            while(current != size) {
                string[] pair = new string[2];
                if(CfxApi.Runtime.cfx_string_multimap_key(source, current, out str, out length) == 0) {
                    throw new CfxException("CfxStringMultimap operation failed.");
                }
                pair[0] = PtrToStringUni(str, length);
                if(CfxApi.Runtime.cfx_string_multimap_value(source, current, out str, out length) == 0) {
                    throw new CfxException("CfxStringMultimap operation failed.");
                }
                pair[1] = PtrToStringUni(str, length);
                target.Add(pair);
                current += 1;
            }
        }

        internal static void CfxStringMultimapCopyToNative(List<string[]> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count * 2];
            var ih = 0;
            CfxApi.Runtime.cfx_string_multimap_clear(target);
            foreach(var pair in source) {
                var hKey = new PinnedString(pair[0]);
                var hValue = new PinnedString(pair[1]);
                if(CfxApi.Runtime.cfx_string_multimap_append(target, hKey.Obj.PinnedPtr, hKey.Length, hValue.Obj.PinnedPtr, hValue.Length) == 0)
                    throw new CfxException("CfxStringMultimap operation failed.");
                handles[ih++] = hKey;
                handles[ih++] = hValue;
            }
        }

        internal static void CopyCfxStringList(List<string> source, List<string> target) {
            target.Clear();
            target.AddRange(source);
        }
    }
}
