// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// A simple thread abstraction that establishes a message loop on a new thread.
    /// The consumer uses CfrTaskRunner to execute code on the thread's message
    /// loop. The thread is terminated when the CfrThread object is destroyed or
    /// stop() is called. All pending tasks queued on the thread's message loop will
    /// run to completion before the thread is terminated. cef_thread_create() can be
    /// called on any valid CEF thread in either the browser or render process. This
    /// structure should only be used for tasks that require a dedicated thread. In
    /// most cases you can post tasks to an existing CEF thread instead of creating a
    /// new one; see cef_task.h for details.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
    /// </remarks>
    public class CfrThread : CfrBaseLibrary {

        internal static CfrThread Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrThread)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrThread(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Create and start a new thread. This function does not block waiting for the
        /// thread to run initialization. |displayName| is the name that will be used to
        /// identify the thread. |priority| is the thread execution priority.
        /// |messageLoopType| indicates the set of asynchronous events that the thread
        /// can process. If |stoppable| is true (1) the thread will stopped and joined on
        /// destruction or when stop() is called; otherwise, the the thread cannot be
        /// stopped and will be leaked on shutdown. On Windows the |comInitMode| value
        /// specifies how COM will be initialized for the thread. If |comInitMode| is
        /// set to COM_INIT_MODE_STA then |messageLoopType| must be set to ML_TYPE_UI.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
        /// </remarks>
        public static CfrThread Create(string displayName, CfxThreadPriority priority, CfxMessageLoopType messageLoopType, bool stoppable, CfxComInitMode comInitMode) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxThreadCreateRemoteCall();
            call.displayName = displayName;
            call.priority = (int)priority;
            call.messageLoopType = (int)messageLoopType;
            call.stoppable = stoppable;
            call.comInitMode = (int)comInitMode;
            call.RequestExecution(connection);
            return CfrThread.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrThread(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the CfrTaskRunner that will execute code on this thread's
        /// message loop. This function is safe to call from any thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
        /// </remarks>
        public CfrTaskRunner TaskRunner {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxThreadGetTaskRunnerRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrTaskRunner.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the platform thread ID. It will return the same value after stop()
        /// is called. This function is safe to call from any thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
        /// </remarks>
        public uint PlatformThreadId {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxThreadGetPlatformThreadIdRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the thread is currently running. This function must be
        /// called from the same thread that called cef_thread_create().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
        /// </remarks>
        public bool IsRunning {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxThreadIsRunningRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Stop and join the thread. This function must be called from the same thread
        /// that called cef_thread_create(). Do not call this function if
        /// cef_thread_create() was called with a |stoppable| value of false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_thread_capi.h">cef/include/capi/cef_thread_capi.h</see>.
        /// </remarks>
        public void Stop() {
            var connection = RemotePtr.connection;
            var call = new CfxThreadStopRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
        }
    }
}
