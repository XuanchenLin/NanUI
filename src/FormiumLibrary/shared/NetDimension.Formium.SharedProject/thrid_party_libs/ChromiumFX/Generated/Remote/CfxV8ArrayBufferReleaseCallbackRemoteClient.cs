// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxV8ArrayBufferReleaseCallbackRemoteClient {

        static CfxV8ArrayBufferReleaseCallbackRemoteClient() {
            release_buffer_native = release_buffer;
            release_buffer_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(release_buffer_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_set_callback(self, index, active ? release_buffer_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // release_buffer
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void release_buffer_delegate(IntPtr gcHandlePtr, IntPtr buffer);
        private static release_buffer_delegate release_buffer_native;
        private static IntPtr release_buffer_native_ptr;

        internal static void release_buffer(IntPtr gcHandlePtr, IntPtr buffer) {
            var call = new CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.buffer = buffer;
            call.RequestExecution();
        }

    }
}
