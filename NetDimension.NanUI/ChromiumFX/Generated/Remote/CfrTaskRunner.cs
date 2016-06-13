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

namespace Chromium.Remote
{

	/// <summary>
	/// Structure that asynchronously executes tasks on the associated thread. It is
	/// safe to call the functions of this structure on any thread.
	/// CEF maintains multiple internal threads that are used for handling different
	/// types of tasks in different processes. The CfrThreadId definitions in
	/// cef_types.h list the common CEF threads. Task runners are also available for
	/// other CEF threads as appropriate (for example, V8 WebWorker threads).
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
	/// </remarks>
	public class CfrTaskRunner : CfrBase {

        internal static CfrTaskRunner Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrTaskRunner)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrTaskRunner(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        /// <summary>
        /// Returns the task runner for the current thread. Only CEF threads will have
        /// task runners. An NULL reference will be returned if this function is called
        /// on an invalid thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfrTaskRunner GetForCurrentThread() {
            var call = new CfxTaskRunnerGetForCurrentThreadRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return CfrTaskRunner.Wrap(call.__retval);
        }

        /// <summary>
        /// Returns the task runner for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfrTaskRunner GetForThread(CfxThreadId threadId) {
            var call = new CfxTaskRunnerGetForThreadRenderProcessCall();
            call.threadId = (int)threadId;
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return CfrTaskRunner.Wrap(call.__retval);
        }


        private CfrTaskRunner(IntPtr proxyId) : base(proxyId) {}

        /// <summary>
        /// Returns true (1) if this object is pointing to the same task runner as
        /// |that| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfrTaskRunner that) {
            var call = new CfxTaskRunnerIsSameRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.that = CfrObject.Unwrap(that);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this task runner belongs to the current thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToCurrentThread() {
            var call = new CfxTaskRunnerBelongsToCurrentThreadRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this task runner is for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool BelongsToThread(CfxThreadId threadId) {
            var call = new CfxTaskRunnerBelongsToThreadRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.threadId = (int)threadId;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Post a task for execution on the thread associated with this task runner.
        /// Execution will occur asynchronously.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool PostTask(CfrTask task) {
            var call = new CfxTaskRunnerPostTaskRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.task = CfrObject.Unwrap(task);
            call.RequestExecution(this);
            return call.__retval;
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
        public bool PostDelayedTask(CfrTask task, long delayMs) {
            var call = new CfxTaskRunnerPostDelayedTaskRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.task = CfrObject.Unwrap(task);
            call.delayMs = delayMs;
            call.RequestExecution(this);
            return call.__retval;
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
