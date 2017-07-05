// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxV8InterceptorRemoteClient {

        static CfxV8InterceptorRemoteClient() {
            get_byname_native = get_byname;
            get_byindex_native = get_byindex;
            set_byname_native = set_byname;
            set_byindex_native = set_byindex;
            get_byname_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_byname_native);
            get_byindex_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_byindex_native);
            set_byname_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(set_byname_native);
            set_byindex_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(set_byindex_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(self, index, active ? get_byname_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(self, index, active ? get_byindex_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(self, index, active ? set_byname_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.V8Interceptor.cfx_v8interceptor_set_callback(self, index, active ? set_byindex_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // get_byname
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_byname_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static get_byname_delegate get_byname_native;
        private static IntPtr get_byname_native_ptr;

        internal static void get_byname(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var call = new CfxV8InterceptorGetByNameRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.name_str = name_str;
            call.name_length = name_length;
            call.@object = @object;
            call.RequestExecution();
            object_release = call.object_release;
            retval = call.retval;
            if(call.exception != null && call.exception.Length > 0) {
                var exception_pinned = new PinnedString(call.exception);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.GCHandlePtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            __retval = call.__retval;
        }

        // get_byindex
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_byindex_delegate(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static get_byindex_delegate get_byindex_native;
        private static IntPtr get_byindex_native_ptr;

        internal static void get_byindex(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var call = new CfxV8InterceptorGetByIndexRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.index = index;
            call.@object = @object;
            call.RequestExecution();
            object_release = call.object_release;
            retval = call.retval;
            if(call.exception != null && call.exception.Length > 0) {
                var exception_pinned = new PinnedString(call.exception);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.GCHandlePtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            __retval = call.__retval;
        }

        // set_byname
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void set_byname_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static set_byname_delegate set_byname_native;
        private static IntPtr set_byname_native_ptr;

        internal static void set_byname(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var call = new CfxV8InterceptorSetByNameRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.name_str = name_str;
            call.name_length = name_length;
            call.@object = @object;
            call.value = value;
            call.RequestExecution();
            object_release = call.object_release;
            value_release = call.value_release;
            if(call.exception != null && call.exception.Length > 0) {
                var exception_pinned = new PinnedString(call.exception);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.GCHandlePtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            __retval = call.__retval;
        }

        // set_byindex
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void set_byindex_delegate(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static set_byindex_delegate set_byindex_native;
        private static IntPtr set_byindex_native_ptr;

        internal static void set_byindex(IntPtr gcHandlePtr, out int __retval, int index, IntPtr @object, out int object_release, IntPtr value, out int value_release, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var call = new CfxV8InterceptorSetByIndexRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.index = index;
            call.@object = @object;
            call.value = value;
            call.RequestExecution();
            object_release = call.object_release;
            value_release = call.value_release;
            if(call.exception != null && call.exception.Length > 0) {
                var exception_pinned = new PinnedString(call.exception);
                exception_str = exception_pinned.Obj.PinnedPtr;
                exception_length = exception_pinned.Length;
                exception_gc_handle = exception_pinned.Obj.GCHandlePtr();
            } else {
                exception_str = IntPtr.Zero;
                exception_length = 0;
                exception_gc_handle = IntPtr.Zero;
            }
            __retval = call.__retval;
        }

    }
}
