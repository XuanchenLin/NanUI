// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxResourceBundleHandlerRemoteClient {

        static CfxResourceBundleHandlerRemoteClient() {
            get_localized_string_native = get_localized_string;
            get_data_resource_native = get_data_resource;
            get_data_resource_for_scale_native = get_data_resource_for_scale;
            get_localized_string_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_localized_string_native);
            get_data_resource_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_data_resource_native);
            get_data_resource_for_scale_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_data_resource_for_scale_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(self, index, active ? get_localized_string_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(self, index, active ? get_data_resource_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.ResourceBundleHandler.cfx_resource_bundle_handler_set_callback(self, index, active ? get_data_resource_for_scale_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // get_localized_string
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_localized_string_delegate(IntPtr gcHandlePtr, out int __retval, int string_id, out IntPtr string_str, out int string_length, out IntPtr string_gc_handle);
        private static get_localized_string_delegate get_localized_string_native;
        private static IntPtr get_localized_string_native_ptr;

        internal static void get_localized_string(IntPtr gcHandlePtr, out int __retval, int string_id, out IntPtr string_str, out int string_length, out IntPtr string_gc_handle) {
            var call = new CfxResourceBundleHandlerGetLocalizedStringRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.string_id = string_id;
            call.RequestExecution();
            if(call.@string != null && call.@string.Length > 0) {
                var string_pinned = new PinnedString(call.@string);
                string_str = string_pinned.Obj.PinnedPtr;
                string_length = string_pinned.Length;
                string_gc_handle = string_pinned.Obj.GCHandlePtr();
            } else {
                string_str = IntPtr.Zero;
                string_length = 0;
                string_gc_handle = IntPtr.Zero;
            }
            __retval = call.__retval;
        }

        // get_data_resource
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_data_resource_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out UIntPtr data_size);
        private static get_data_resource_delegate get_data_resource_native;
        private static IntPtr get_data_resource_native_ptr;

        internal static void get_data_resource(IntPtr gcHandlePtr, out int __retval, int resource_id, out IntPtr data, out UIntPtr data_size) {
            var call = new CfxResourceBundleHandlerGetDataResourceRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.resource_id = resource_id;
            call.RequestExecution();
            data = call.data;
            data_size = call.data_size;
            __retval = call.__retval;
        }

        // get_data_resource_for_scale
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_data_resource_for_scale_delegate(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out UIntPtr data_size);
        private static get_data_resource_for_scale_delegate get_data_resource_for_scale_native;
        private static IntPtr get_data_resource_for_scale_native_ptr;

        internal static void get_data_resource_for_scale(IntPtr gcHandlePtr, out int __retval, int resource_id, int scale_factor, out IntPtr data, out UIntPtr data_size) {
            var call = new CfxResourceBundleHandlerGetDataResourceForScaleRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.resource_id = resource_id;
            call.scale_factor = scale_factor;
            call.RequestExecution();
            data = call.data;
            data_size = call.data_size;
            __retval = call.__retval;
        }

    }
}
