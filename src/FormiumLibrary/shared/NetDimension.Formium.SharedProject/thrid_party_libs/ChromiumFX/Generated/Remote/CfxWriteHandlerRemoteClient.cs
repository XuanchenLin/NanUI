// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxWriteHandlerRemoteClient {

        static CfxWriteHandlerRemoteClient() {
            write_native = write;
            seek_native = seek;
            tell_native = tell;
            flush_native = flush;
            may_block_native = may_block;
            write_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(write_native);
            seek_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(seek_native);
            tell_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(tell_native);
            flush_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(flush_native);
            may_block_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(may_block_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.WriteHandler.cfx_write_handler_set_callback(self, index, active ? write_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.WriteHandler.cfx_write_handler_set_callback(self, index, active ? seek_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.WriteHandler.cfx_write_handler_set_callback(self, index, active ? tell_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.WriteHandler.cfx_write_handler_set_callback(self, index, active ? flush_native_ptr : IntPtr.Zero);
                    break;
                case 4:
                    CfxApi.WriteHandler.cfx_write_handler_set_callback(self, index, active ? may_block_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // write
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void write_delegate(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n);
        private static write_delegate write_native;
        private static IntPtr write_native_ptr;

        internal static void write(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n) {
            var call = new CfxWriteHandlerWriteRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.ptr = ptr;
            call.size = size;
            call.n = n;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // seek
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void seek_delegate(IntPtr gcHandlePtr, out int __retval, long offset, int whence);
        private static seek_delegate seek_native;
        private static IntPtr seek_native_ptr;

        internal static void seek(IntPtr gcHandlePtr, out int __retval, long offset, int whence) {
            var call = new CfxWriteHandlerSeekRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.offset = offset;
            call.whence = whence;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // tell
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void tell_delegate(IntPtr gcHandlePtr, out long __retval);
        private static tell_delegate tell_native;
        private static IntPtr tell_native_ptr;

        internal static void tell(IntPtr gcHandlePtr, out long __retval) {
            var call = new CfxWriteHandlerTellRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // flush
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void flush_delegate(IntPtr gcHandlePtr, out int __retval);
        private static flush_delegate flush_native;
        private static IntPtr flush_native_ptr;

        internal static void flush(IntPtr gcHandlePtr, out int __retval) {
            var call = new CfxWriteHandlerFlushRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // may_block
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void may_block_delegate(IntPtr gcHandlePtr, out int __retval);
        private static may_block_delegate may_block_native;
        private static IntPtr may_block_native_ptr;

        internal static void may_block(IntPtr gcHandlePtr, out int __retval) {
            var call = new CfxWriteHandlerMayBlockRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

    }
}
