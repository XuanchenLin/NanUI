// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.



using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Chromium
{
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
            var size = CfxApi.cfx_string_list_size(list);
            var target = new List<string>(size);
            CfxStringListCopyToManaged(list, target);
            return target;
        }

        // used in api calls to set and get data
        internal static IntPtr UnwrapCfxStringList(List<string> list, out PinnedString[] handles) {

            var target = CfxApi.cfx_string_list_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();

            CfxStringListCopyToNative(list, target, out handles);
            return target;
        }

        //unused
        //internal static List<string[]> WrapCfxStringMap(IntPtr value) {
        //    return null;
        //}

        // used in api call to get data
        internal static IntPtr UnwrapCfxStringMap(List<string[]> map, out PinnedString[] handles) {
            var target = CfxApi.cfx_string_map_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();

            CfxStringMapCopyToNative(map, target, out handles);
            return target;
        }

        //unused
        //internal static List<string[]> WrapCfxStringMultimap(IntPtr value) {
        //    return null;
        //}

        // used in api calls to set and get data
        internal static IntPtr UnwrapCfxStringMultimap(List<string[]> map, out PinnedString[] handles) {
            var target = CfxApi.cfx_string_multimap_alloc();
            if(target == IntPtr.Zero)
                throw new OutOfMemoryException();

            CfxStringMultimapCopyToNative(map, target, out handles);
            return target;
        }

        internal static void FreePinnedStrings(PinnedString[] handles) {
            foreach(var h in handles) h.Obj.Free();
        }

        internal static void CfxStringListCopyToManaged(IntPtr source, List<string> target) {
            var size = CfxApi.cfx_string_list_size(source);
            IntPtr str = IntPtr.Zero;
            int length = 0;
            target.Clear();
            for(int i = 0; i < size; i++) {
                if(CfxApi.cfx_string_list_value(source, i, ref str, ref length) == 0) {
                    throw new CfxException("CfxStringList operation failed.");
                }
                target.Add(PtrToStringUni(str, length));
            }
        }

        internal static void CfxStringListCopyToNative(List<string> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count];
            var ih = 0;
            CfxApi.cfx_string_list_clear(target);
            foreach(var str in source) {
                var hValue = new PinnedString(str);
                CfxApi.cfx_string_list_append(target, hValue.Obj.PinnedPtr, hValue.Length);
                handles[ih++] = hValue;
            }
        }

        internal static void CfxStringMapCopyToManaged(IntPtr source, List<string[]> target) {
            var size = CfxApi.cfx_string_map_size(source);
            IntPtr str = IntPtr.Zero;
            int length = 0;
            target.Clear();
            for (int i = 0; i < size; i++) {
                string[] pair = new string[2];
                if (CfxApi.cfx_string_map_key(source, i, ref str, ref length) == 0) {
                    throw new CfxException("CfxStringMap operation failed.");
                }
                pair[0] = PtrToStringUni(str, length);
                if (CfxApi.cfx_string_map_value(source, i, ref str, ref length) == 0) {
                    throw new CfxException("CfxStringMap operation failed.");
                }
                pair[1] = PtrToStringUni(str, length);
                target.Add(pair);
            }
        }

        internal static void CfxStringMapCopyToNative(List<string[]> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count * 2];
            var ih = 0;
            CfxApi.cfx_string_map_clear(target);
            foreach (var pair in source) {
                var hKey = new PinnedString(pair[0]);
                var hValue = new PinnedString(pair[1]);
                if(CfxApi.cfx_string_map_append(target, hKey.Obj.PinnedPtr, hKey.Length, hValue.Obj.PinnedPtr, hValue.Length) == 0)
                    throw new CfxException("CfxStringMultimap operation failed.");
                handles[ih++] = hKey;
                handles[ih++] = hValue;
            }
        }


        internal static void CfxStringMultimapCopyToManaged(IntPtr source, List<string[]> target) {
            var size = CfxApi.cfx_string_multimap_size(source);
            IntPtr str = IntPtr.Zero;
            int length = 0;
            target.Clear();
            for(int i = 0; i < size; i++) {
                string[] pair = new string[2];
                if(CfxApi.cfx_string_multimap_key(source, i, ref str, ref length) == 0) {
                    throw new CfxException("CfxStringMultimap operation failed.");
                }
                pair[0] = PtrToStringUni(str, length);
                if (CfxApi.cfx_string_multimap_value(source, i, ref str, ref length) == 0) {
                    throw new CfxException("CfxStringMultimap operation failed.");
                }
                pair[1] = PtrToStringUni(str, length);
                target.Add(pair);
            }
        }

        internal static void CfxStringMultimapCopyToNative(List<string[]> source, IntPtr target, out PinnedString[] handles) {
            handles = new PinnedString[source.Count * 2];
            var ih = 0;
            CfxApi.cfx_string_multimap_clear(target);
            foreach(var pair in source) {
                var hKey = new PinnedString(pair[0]);
                var hValue = new PinnedString(pair[1]);
                if(CfxApi.cfx_string_multimap_append(target, hKey.Obj.PinnedPtr, hKey.Length, hValue.Obj.PinnedPtr, hValue.Length) == 0) 
                    throw new CfxException("CfxStringMultimap operation failed.");
                handles[ih++] = hKey;
                handles[ih++] = hValue;
            }
        }
    }
}
