// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxReadHandlerRemoteClient {

        static CfxReadHandlerRemoteClient() {
            read_native = read;
            seek_native = seek;
            tell_native = tell;
            eof_native = eof;
            may_block_native = may_block;
            read_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(read_native);
            seek_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(seek_native);
            tell_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(tell_native);
            eof_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(eof_native);
            may_block_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(may_block_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.ReadHandler.cfx_read_handler_set_callback(self, index, active ? read_native_ptr : IntPtr.Zero);
                    break;
                case 1:
                    CfxApi.ReadHandler.cfx_read_handler_set_callback(self, index, active ? seek_native_ptr : IntPtr.Zero);
                    break;
                case 2:
                    CfxApi.ReadHandler.cfx_read_handler_set_callback(self, index, active ? tell_native_ptr : IntPtr.Zero);
                    break;
                case 3:
                    CfxApi.ReadHandler.cfx_read_handler_set_callback(self, index, active ? eof_native_ptr : IntPtr.Zero);
                    break;
                case 4:
                    CfxApi.ReadHandler.cfx_read_handler_set_callback(self, index, active ? may_block_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // read
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void read_delegate(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n);
        private static read_delegate read_native;
        private static IntPtr read_native_ptr;

        internal static void read(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n) {
            var call = new CfxReadHandlerReadRemoteEventCall();
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
            var call = new CfxReadHandlerSeekRemoteEventCall();
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
            var call = new CfxReadHandlerTellRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

        // eof
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void eof_delegate(IntPtr gcHandlePtr, out int __retval);
        private static eof_delegate eof_native;
        private static IntPtr eof_native_ptr;

        internal static void eof(IntPtr gcHandlePtr, out int __retval) {
            var call = new CfxReadHandlerEofRemoteEventCall();
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
            var call = new CfxReadHandlerMayBlockRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
            __retval = call.__retval;
        }

    }
}
