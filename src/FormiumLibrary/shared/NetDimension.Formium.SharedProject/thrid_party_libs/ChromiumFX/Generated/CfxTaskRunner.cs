// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure that asynchronously executes tasks on the associated thread. It is
    /// safe to call the functions of this structure on any thread.
    /// 
    /// CEF maintains multiple internal threads that are used for handling different
    /// types of tasks in different processes. The CfxThreadId definitions in
    /// cef_types.h list the common CEF threads. Task runners are also available for
    /// other CEF threads as appropriate (for example, V8 WebWorker threads).
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
    /// </remarks>
    public class CfxTaskRunner : CfxBaseLibrary {

        internal static CfxTaskRunner Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxTaskRunner)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxTaskRunner(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
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
            return CfxTaskRunner.Wrap(CfxApi.TaskRunner.cfx_task_runner_get_for_current_thread());
        }

        /// <summary>
        /// Returns the task runner for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfxTaskRunner GetForThread(CfxThreadId threadId) {
            return CfxTaskRunner.Wrap(CfxApi.TaskRunner.cfx_task_runner_get_for_thread((int)threadId));
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
            return 0 != CfxApi.TaskRunner.cfx_task_runner_is_same(NativePtr, CfxTaskRunner.Unwrap(that));
        }

        /// <summary>
        /// Returns true (1) if this task runner belongs to the current thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToCurrentThread() {
            return 0 != CfxApi.TaskRunner.cfx_task_runner_belongs_to_current_thread(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if this task runner is for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToThread(CfxThreadId threadId) {
            return 0 != CfxApi.TaskRunner.cfx_task_runner_belongs_to_thread(NativePtr, (int)threadId);
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
            var __retval = CfxApi.TaskRunner.cfx_task_runner_post_task(NativePtr, CfxTask.Unwrap(task));
            GC.KeepAlive(task);
            return 0 != __retval;
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
            var __retval = CfxApi.TaskRunner.cfx_task_runner_post_delayed_task(NativePtr, CfxTask.Unwrap(task), delayMs);
            GC.KeepAlive(task);
            return 0 != __retval;
        }
    }
}
