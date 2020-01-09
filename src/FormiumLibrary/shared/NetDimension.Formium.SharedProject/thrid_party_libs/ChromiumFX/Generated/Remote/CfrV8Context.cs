// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a V8 context handle. V8 handles can only be accessed
    /// from the thread on which they are created. Valid threads for creating a V8
    /// handle include the render process main thread (TID_RENDERER) and WebWorker
    /// threads. A task runner for posting tasks on the associated thread can be
    /// retrieved via the CfrV8Context.GetTaskRunner() function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8Context : CfrBaseLibrary {

        internal static CfrV8Context Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrV8Context)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrV8Context(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }


        /// <summary>
        /// Returns the current (top) context object in the V8 context stack.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Context GetCurrentContext() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ContextGetCurrentContextRemoteCall();
            call.RequestExecution(connection);
            return CfrV8Context.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns the entered (bottom) context object in the V8 context stack.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static CfrV8Context GetEnteredContext() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ContextGetEnteredContextRemoteCall();
            call.RequestExecution(connection);
            return CfrV8Context.Wrap(new RemotePtr(connection, call.__retval));
        }

        /// <summary>
        /// Returns true (1) if V8 is currently inside a context.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public static bool InContext() {
            var connection = CfxRemoteCallContext.CurrentContext.connection;
            var call = new CfxV8ContextInContextRemoteCall();
            call.RequestExecution(connection);
            return call.__retval;
        }


        private CfrV8Context(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the task runner associated with this context. V8 handles can only
        /// be accessed from the thread on which they are created. This function can be
        /// called on any render process thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrTaskRunner TaskRunner {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ContextGetTaskRunnerRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrTaskRunner.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

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
                var call = new CfxV8ContextIsValidRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the browser for this context. This function will return an NULL
        /// reference for WebWorker contexts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrBrowser Browser {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ContextGetBrowserRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrBrowser.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the frame for this context. This function will return an NULL
        /// reference for WebWorker contexts.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrFrame Frame {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ContextGetFrameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrFrame.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the global object for this context. The context must be entered
        /// before calling this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public CfrV8Value Global {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxV8ContextGetGlobalRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrV8Value.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Enter this context. A context must be explicitly entered before creating a
        /// V8 Object, Array, Function or Date asynchronously. exit() must be called
        /// the same number of times as enter() before releasing this context. V8
        /// objects belong to the context in which they are created. Returns true (1)
        /// if the scope was entered successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Enter() {
            var connection = RemotePtr.connection;
            var call = new CfxV8ContextEnterRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Exit this context. Call this function only after calling enter(). Returns
        /// true (1) if the scope was exited successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Exit() {
            var connection = RemotePtr.connection;
            var call = new CfxV8ContextExitRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfrV8Context that) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ContextIsSameRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Execute a string of JavaScript code in this V8 context. The |scriptUrl|
        /// parameter is the URL where the script in question can be found, if any. The
        /// |startLine| parameter is the base line number to use for error reporting.
        /// On success |retval| will be set to the return value, if any, and the
        /// function will return true (1). On failure |exception| will be set to the
        /// exception, if any, and the function will return false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public bool Eval(string code, string scriptUrl, int startLine, out CfrV8Value retval, out CfrV8Exception exception) {
            var connection = RemotePtr.connection;
            var call = new CfxV8ContextEvalRemoteCall();
            call.@this = RemotePtr.ptr;
            call.code = code;
            call.scriptUrl = scriptUrl;
            call.startLine = startLine;
            call.RequestExecution(connection);
            retval = CfrV8Value.Wrap(new RemotePtr(connection, call.retval));
            exception = CfrV8Exception.Wrap(new RemotePtr(connection, call.exception));
            return call.__retval;
        }
    }
}
