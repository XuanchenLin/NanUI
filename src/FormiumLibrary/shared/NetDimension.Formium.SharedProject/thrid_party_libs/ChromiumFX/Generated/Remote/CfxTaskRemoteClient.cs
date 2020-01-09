// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    internal static class CfxTaskRemoteClient {

        static CfxTaskRemoteClient() {
            execute_native = execute;
            execute_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(execute_native);
        }

        internal static void SetCallback(IntPtr self, int index, bool active) {
            switch(index) {
                case 0:
                    CfxApi.Task.cfx_task_set_callback(self, index, active ? execute_native_ptr : IntPtr.Zero);
                    break;
            }
        }

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void execute_delegate(IntPtr gcHandlePtr);
        private static execute_delegate execute_native;
        private static IntPtr execute_native_ptr;

        internal static void execute(IntPtr gcHandlePtr) {
            var call = new CfxTaskExecuteRemoteEventCall();
            call.gcHandlePtr = gcHandlePtr;
            call.RequestExecution();
        }

    }
}
