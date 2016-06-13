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

// Generated file. Do not edit.


using System;

namespace Chromium
{
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
	public class CfxTask : CfxBase {

        static CfxTask () {
            CfxApiLoader.LoadCfxTaskApi();
        }

        internal static CfxTask Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_task_get_gc_handle(nativePtr);
            return (CfxTask)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // execute
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_task_execute_delegate(IntPtr gcHandlePtr);
        private static cfx_task_execute_delegate cfx_task_execute;
        private static IntPtr cfx_task_execute_ptr;

        internal static void execute(IntPtr gcHandlePtr) {
            var self = (CfxTask)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxEventArgs();
            var eventHandler = self.m_Execute;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxTask(IntPtr nativePtr) : base(nativePtr) {}
        public CfxTask() : base(CfxApi.cfx_task_ctor) {}

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
                        if(cfx_task_execute == null) {
                            cfx_task_execute = execute;
                            cfx_task_execute_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_task_execute);
                        }
                        CfxApi.cfx_task_set_managed_callback(NativePtr, 0, cfx_task_execute_ptr);
                    }
                    m_Execute += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Execute -= value;
                    if(m_Execute == null) {
                        CfxApi.cfx_task_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxEventHandler m_Execute;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Execute != null) {
                m_Execute = null;
                CfxApi.cfx_task_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{


	}
}
