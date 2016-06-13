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
	/// Structure that asynchronously executes tasks on the associated thread. It is
	/// safe to call the functions of this structure on any thread.
	/// CEF maintains multiple internal threads that are used for handling different
	/// types of tasks in different processes. The CfxThreadId definitions in
	/// cef_types.h list the common CEF threads. Task runners are also available for
	/// other CEF threads as appropriate (for example, V8 WebWorker threads).
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
	/// </remarks>
	public class CfxTaskRunner : CfxBase {

        static CfxTaskRunner () {
            CfxApiLoader.LoadCfxTaskRunnerApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxTaskRunner Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxTaskRunner)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxTaskRunner(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxTaskRunner(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the task runner for the current thread. Only CEF threads will have
        /// task runners. An NULL reference will be returned if this function is called
        /// on an invalid thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfxTaskRunner GetForCurrentThread() {
            return CfxTaskRunner.Wrap(CfxApi.cfx_task_runner_get_for_current_thread());
        }

        /// <summary>
        /// Returns the task runner for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfxTaskRunner GetForThread(CfxThreadId threadId) {
            return CfxTaskRunner.Wrap(CfxApi.cfx_task_runner_get_for_thread((int)threadId));
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same task runner as
        /// |that| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxTaskRunner that) {
            return 0 != CfxApi.cfx_task_runner_is_same(NativePtr, CfxTaskRunner.Unwrap(that));
        }

        /// <summary>
        /// Returns true (1) if this task runner belongs to the current thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToCurrentThread() {
            return 0 != CfxApi.cfx_task_runner_belongs_to_current_thread(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if this task runner is for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToThread(CfxThreadId threadId) {
            return 0 != CfxApi.cfx_task_runner_belongs_to_thread(NativePtr, (int)threadId);
        }

        /// <summary>
        /// Post a task for execution on the thread associated with this task runner.
        /// Execution will occur asynchronously.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool PostTask(CfxTask task) {
            return 0 != CfxApi.cfx_task_runner_post_task(NativePtr, CfxTask.Unwrap(task));
        }

        /// <summary>
        /// Post a task for delayed execution on the thread associated with this task
        /// runner. Execution will occur asynchronously. Delayed tasks are not
        /// supported on V8 WebWorker threads and will be executed without the
        /// specified delay.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool PostDelayedTask(CfxTask task, long delayMs) {
            return 0 != CfxApi.cfx_task_runner_post_delayed_task(NativePtr, CfxTask.Unwrap(task), delayMs);
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
