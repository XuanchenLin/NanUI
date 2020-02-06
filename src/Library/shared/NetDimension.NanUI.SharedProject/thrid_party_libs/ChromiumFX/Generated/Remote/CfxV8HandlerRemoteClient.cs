// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxV8HandlerRemoteClient {

        static CfxV8HandlerRemoteClient() {
            execute_native = execute;
            execute_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(execute_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.V8Handler.cfx_v8handler_set_callback(self, index, active ? execute_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void execute_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, UIntPtr argumentsCount, IntPtr arguments, out int arguments_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle);
        private static execute_delegate execute_native;
        private static IntPtr execute_native_ptr;

        internal static void execute(IntPtr gcHandlePtr, out int __retval, IntPtr name_str, int name_length, IntPtr @object, out int object_release, UIntPtr argumentsCount, IntPtr arguments, out int arguments_release, out IntPtr retval, out IntPtr exception_str, out int exception_length, out IntPtr exception_gc_handle) {
            var call = new CfxV8HandlerExecuteRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.name_str = name_str;
            call.name_length = name_length;
            call.@object = @object;
            call.argumentsCount = argumentsCount;
            call.arguments = arguments;
            call.RequestExecution();
            object_release = call.object_release;
            arguments_release = call.arguments_release;
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

    }
}
