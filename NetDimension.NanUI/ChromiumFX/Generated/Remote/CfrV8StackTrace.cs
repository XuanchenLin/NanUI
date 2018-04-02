// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a V8 stack trace handle. V8 handles can only be
    /// accessed from the thread on which they are created. Valid threads for
    /// creating a V8 handle include the render process main thread (TID_RENDERER)
    /// and WebWorker threads. A task runner for posting tasks on the associated
    /// thread can be retrieved via the CfrV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8StackTrace : CfrBaseLibrary {

        internal static CfrV8StackTrace Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrV8StackTrace)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrV8StackTrace(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Returns the stack trace for the currently active context. |frameLimit| is
        /// the maximum number of frames that will be captured.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8StackTrace GetCurrent(int frameLimit) {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8StackTraceGetCurrentRemoteCall();
            call.frameLimit = frameLimit;
            call.RequestExecution(connection);
            return CfrV8StackTrace.Wrap(new RemotePtr(connection, call.__retval));
        }


        private CfrV8StackTrace(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns true (1) if the underlying handle is valid and it can be accessed
        /// on the current thread. Do not call any other functions if this function
        /// returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8StackTraceIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the number of stack frames.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public int FrameCount {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8StackTraceGetFrameCountRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the stack frame at the specified 0-based index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrV8StackFrame GetFrame(int index) {
            var connection = RemotePtr.connection;
            var call = new CfxV8StackTraceGetFrameRemoteCall();
            call.@this = RemotePtr.ptr;
            call.index = index;
            call.RequestExecution(connection);
            return CfrV8StackFrame.Wrap(new RemotePtr(connection, call.__retval));
        }
    }
}
