// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Implement this structure for asynchronous task execution. If the task is
    /// posted successfully and if the associated message loop is still running then
    /// the execute() function will be called on the target thread. If the task fails
    /// to post then the task object may be destroyed on the source thread instead of
    /// the target thread. For this reason be cautious when performing work in the
    /// task object destructor.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
    /// </remarks>
    public class CfxTask : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            execute_native = execute;

            execute_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(execute_native);
        }

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void execute_delegate(IntPtr gcHandlePtr);
        private static execute_delegate execute_native;
        private static IntPtr execute_native_ptr;

        internal static void execute(IntPtr gcHandlePtr) {
            var self = (CfxTask)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxEventArgs();
            self.m_Execute?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxTask() : base(CfxApi.Task.cfx_task_ctor) {}

        /// <summary>
        /// Method that will be executed on the target thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public event CfxEventHandler Execute {
            add {
                lock(eventLock) {
                    if(m_Execute == null) {
                        CfxApi.Task.cfx_task_set_callback(NativePtr, 0, execute_native_ptr);
                    }
                    m_Execute += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Execute -= value;
                    if(m_Execute == null) {
                        CfxApi.Task.cfx_task_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_Execute;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Execute != null) {
                m_Execute = null;
                CfxApi.Task.cfx_task_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }
}
