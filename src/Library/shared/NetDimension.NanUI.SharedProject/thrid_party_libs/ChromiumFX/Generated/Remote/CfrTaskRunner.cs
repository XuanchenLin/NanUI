// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure that asynchronously executes tasks on the associated thread. It is
    /// safe to call the functions of this structure on any thread.
    /// 
    /// CEF maintains multiple internal threads that are used for handling different
    /// types of tasks in different processes. The CfrThreadId definitions in
    /// cef_types.h list the common CEF threads. Task runners are also available for
    /// other CEF threads as appropriate (for example, V8 WebWorker threads).
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
    /// </remarks>
    public class CfrTaskRunner : CfrBaseLibrary {

        internal static CfrTaskRunner Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrTaskRunner)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrTaskRunner(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
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
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxTaskRunnerGetForCurrentThreadRemoteCall();
            call.RequestExecution(connection);
            return CfrTaskRunner.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the task runner for the specified CEF thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public static CfrTaskRunner GetForThread(CfxThreadId threadId) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxTaskRunnerGetForThreadRemoteCall();
            call.threadId = (int)threadId;
            call.RequestExecution(connection);
            return CfrTaskRunner.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrTaskRunner(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if this object is pointing to the same task runner as
        /// |that| object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_task_capi.h">cef/include/capi/cef_task_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfrTaskRunner that) {
            var connection = RemotePtr.connection;
            var call = new CfxTaskRunnerIsSameRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxTaskRunnerBelongsToCurrentThreadRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxTaskRunnerBelongsToThreadRemoteCall();
            call.@this = RemotePtr.ptr;
            call.threadId = (int)threadId;
            call.RequestExecution(connection);
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
            var connection = RemotePtr.connection;
            var call = new CfxTaskRunnerPostTaskRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(task, connection)) throw new ArgumentException("Render process connection mismatch.", "task");
            call.task = CfrObject.Unwrap(task).ptr;
            call.RequestExecution(connection);
            GC.KeepAlive(task);
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
            var connection = RemotePtr.connection;
            var call = new CfxTaskRunnerPostDelayedTaskRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(task, connection)) throw new ArgumentException("Render process connection mismatch.", "task");
            call.task = CfrObject.Unwrap(task).ptr;
            call.delayMs = delayMs;
            call.RequestExecution(connection);
            GC.KeepAlive(task);
            return call.__retval;
        }
    }
}
