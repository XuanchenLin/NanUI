// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Structure used to implement render process callbacks. The functions of this
    /// structure will be called on the render process main thread (TID_RENDERER)
    /// unless otherwise indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
    /// </remarks>
    public class CfrRenderProcessHandler : CfrBaseClient {


        private CfrRenderProcessHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrRenderProcessHandler() : base(new CfxRenderProcessHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfrBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnRenderThreadCreatedEventHandler OnRenderThreadCreated {
            add {
                if(m_OnRenderThreadCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnRenderThreadCreated += value;
            }
            remove {
                m_OnRenderThreadCreated -= value;
                if(m_OnRenderThreadCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnRenderThreadCreatedEventHandler m_OnRenderThreadCreated;


        /// <summary>
        /// Called after WebKit has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrEventHandler OnWebKitInitialized {
            add {
                if(m_OnWebKitInitialized == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnWebKitInitialized += value;
            }
            remove {
                m_OnWebKitInitialized -= value;
                if(m_OnWebKitInitialized == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrEventHandler m_OnWebKitInitialized;


        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfrBrowserHost.CfrBrowserHostCreateBrowser(),
        /// CfrBrowserHost.CfrBrowserHostCreateBrowserSync(),
        /// CfrLifeSpanHandler.OnBeforePopup() or
        /// CfrBrowserView.CfrBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnBrowserCreatedEventHandler OnBrowserCreated {
            add {
                if(m_OnBrowserCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnBrowserCreated += value;
            }
            remove {
                m_OnBrowserCreated -= value;
                if(m_OnBrowserCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnBrowserCreatedEventHandler m_OnBrowserCreated;


        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnBrowserDestroyedEventHandler OnBrowserDestroyed {
            add {
                if(m_OnBrowserDestroyed == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnBrowserDestroyed += value;
            }
            remove {
                m_OnBrowserDestroyed -= value;
                if(m_OnBrowserDestroyed == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnBrowserDestroyedEventHandler m_OnBrowserDestroyed;


        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrGetLoadHandlerEventHandler GetLoadHandler {
            add {
                if(m_GetLoadHandler == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetLoadHandler += value;
            }
            remove {
                m_GetLoadHandler -= value;
                if(m_GetLoadHandler == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetLoadHandlerEventHandler m_GetLoadHandler;


        /// <summary>
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfrV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfrV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnContextCreatedEventHandler OnContextCreated {
            add {
                if(m_OnContextCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 5;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnContextCreated += value;
            }
            remove {
                m_OnContextCreated -= value;
                if(m_OnContextCreated == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 5;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnContextCreatedEventHandler m_OnContextCreated;


        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnContextReleasedEventHandler OnContextReleased {
            add {
                if(m_OnContextReleased == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 6;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnContextReleased += value;
            }
            remove {
                m_OnContextReleased -= value;
                if(m_OnContextReleased == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 6;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnContextReleasedEventHandler m_OnContextReleased;


        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfrSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnUncaughtExceptionEventHandler OnUncaughtException {
            add {
                if(m_OnUncaughtException == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 7;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnUncaughtException += value;
            }
            remove {
                m_OnUncaughtException -= value;
                if(m_OnUncaughtException == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 7;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnUncaughtExceptionEventHandler m_OnUncaughtException;


        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnFocusedNodeChangedEventHandler OnFocusedNodeChanged {
            add {
                if(m_OnFocusedNodeChanged == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 8;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnFocusedNodeChanged += value;
            }
            remove {
                m_OnFocusedNodeChanged -= value;
                if(m_OnFocusedNodeChanged == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 8;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnFocusedNodeChangedEventHandler m_OnFocusedNodeChanged;


        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public event CfrOnProcessMessageReceivedEventHandler OnProcessMessageReceived {
            add {
                if(m_OnProcessMessageReceived == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 9;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnProcessMessageReceived += value;
            }
            remove {
                m_OnProcessMessageReceived -= value;
                if(m_OnProcessMessageReceived == null) {
                    var call = new CfxRenderProcessHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 9;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnProcessMessageReceivedEventHandler m_OnProcessMessageReceived;


    }

    namespace Event {

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfrBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnRenderThreadCreatedEventHandler(object sender, CfrOnRenderThreadCreatedEventArgs e);

        /// <summary>
        /// Called after the render process main thread has been created. |ExtraInfo|
        /// is a read-only value originating from
        /// CfrBrowserProcessHandler.OnRenderProcessThreadCreated(). Do not
        /// keep a reference to |ExtraInfo| outside of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnRenderThreadCreatedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall call;

            internal CfrListValue m_extra_info_wrapped;

            internal CfrOnRenderThreadCreatedEventArgs(CfxRenderProcessHandlerOnRenderThreadCreatedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the ExtraInfo parameter for the <see cref="CfrRenderProcessHandler.OnRenderThreadCreated"/> render process callback.
            /// </summary>
            public CfrListValue ExtraInfo {
                get {
                    CheckAccess();
                    if(m_extra_info_wrapped == null) m_extra_info_wrapped = CfrListValue.Wrap(new RemotePtr(connection, call.extra_info));
                    return m_extra_info_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("ExtraInfo={{{0}}}", ExtraInfo);
            }
        }


        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfrBrowserHost.CfrBrowserHostCreateBrowser(),
        /// CfrBrowserHost.CfrBrowserHostCreateBrowserSync(),
        /// CfrLifeSpanHandler.OnBeforePopup() or
        /// CfrBrowserView.CfrBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnBrowserCreatedEventHandler(object sender, CfrOnBrowserCreatedEventArgs e);

        /// <summary>
        /// Called after a browser has been created. When browsing cross-origin a new
        /// browser will be created before the old browser with the same identifier is
        /// destroyed. |ExtraInfo| is a read-only value originating from
        /// CfrBrowserHost.CfrBrowserHostCreateBrowser(),
        /// CfrBrowserHost.CfrBrowserHostCreateBrowserSync(),
        /// CfrLifeSpanHandler.OnBeforePopup() or
        /// CfrBrowserView.CfrBrowserViewCreate().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnBrowserCreatedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrDictionaryValue m_extra_info_wrapped;

            internal CfrOnBrowserCreatedEventArgs(CfxRenderProcessHandlerOnBrowserCreatedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnBrowserCreated"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the ExtraInfo parameter for the <see cref="CfrRenderProcessHandler.OnBrowserCreated"/> render process callback.
            /// </summary>
            public CfrDictionaryValue ExtraInfo {
                get {
                    CheckAccess();
                    if(m_extra_info_wrapped == null) m_extra_info_wrapped = CfrDictionaryValue.Wrap(new RemotePtr(connection, call.extra_info));
                    return m_extra_info_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, ExtraInfo={{{1}}}", Browser, ExtraInfo);
            }
        }

        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnBrowserDestroyedEventHandler(object sender, CfrOnBrowserDestroyedEventArgs e);

        /// <summary>
        /// Called before a browser is destroyed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnBrowserDestroyedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;

            internal CfrOnBrowserDestroyedEventArgs(CfxRenderProcessHandlerOnBrowserDestroyedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnBrowserDestroyed"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetLoadHandlerEventHandler(object sender, CfrGetLoadHandlerEventArgs e);

        /// <summary>
        /// Return the handler for browser load status events.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrGetLoadHandlerEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall call;


            internal CfrLoadHandler m_returnValue;
            private bool returnValueSet;

            internal CfrGetLoadHandlerEventArgs(CfxRenderProcessHandlerGetLoadHandlerRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrRenderProcessHandler.GetLoadHandler"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrLoadHandler returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }

        /// <summary>
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfrV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfrV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnContextCreatedEventHandler(object sender, CfrOnContextCreatedEventArgs e);

        /// <summary>
        /// Called immediately after the V8 context for a frame has been created. To
        /// retrieve the JavaScript 'window' object use the
        /// CfrV8Context.GetGlobal() function. V8 handles can only be accessed
        /// from the thread on which they are created. A task runner for posting tasks
        /// on the associated thread can be retrieved via the
        /// CfrV8Context.GetTaskRunner() function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnContextCreatedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnContextCreatedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal CfrV8Context m_context_wrapped;

            internal CfrOnContextCreatedEventArgs(CfxRenderProcessHandlerOnContextCreatedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnContextCreated"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrRenderProcessHandler.OnContextCreated"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfrRenderProcessHandler.OnContextCreated"/> render process callback.
            /// </summary>
            public CfrV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfrV8Context.Wrap(new RemotePtr(connection, call.context));
                    return m_context_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}", Browser, Frame, Context);
            }
        }

        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnContextReleasedEventHandler(object sender, CfrOnContextReleasedEventArgs e);

        /// <summary>
        /// Called immediately before the V8 context for a frame is released. No
        /// references to the context should be kept after this function is called.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnContextReleasedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnContextReleasedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal CfrV8Context m_context_wrapped;

            internal CfrOnContextReleasedEventArgs(CfxRenderProcessHandlerOnContextReleasedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnContextReleased"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrRenderProcessHandler.OnContextReleased"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfrRenderProcessHandler.OnContextReleased"/> render process callback.
            /// </summary>
            public CfrV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfrV8Context.Wrap(new RemotePtr(connection, call.context));
                    return m_context_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}", Browser, Frame, Context);
            }
        }

        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfrSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnUncaughtExceptionEventHandler(object sender, CfrOnUncaughtExceptionEventArgs e);

        /// <summary>
        /// Called for global uncaught exceptions in a frame. Execution of this
        /// callback is disabled by default. To enable set
        /// CfrSettings.UncaughtExceptionStackSize > 0.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnUncaughtExceptionEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal CfrV8Context m_context_wrapped;
            internal CfrV8Exception m_exception_wrapped;
            internal CfrV8StackTrace m_stackTrace_wrapped;

            internal CfrOnUncaughtExceptionEventArgs(CfxRenderProcessHandlerOnUncaughtExceptionRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnUncaughtException"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrRenderProcessHandler.OnUncaughtException"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Context parameter for the <see cref="CfrRenderProcessHandler.OnUncaughtException"/> render process callback.
            /// </summary>
            public CfrV8Context Context {
                get {
                    CheckAccess();
                    if(m_context_wrapped == null) m_context_wrapped = CfrV8Context.Wrap(new RemotePtr(connection, call.context));
                    return m_context_wrapped;
                }
            }
            /// <summary>
            /// Get the Exception parameter for the <see cref="CfrRenderProcessHandler.OnUncaughtException"/> render process callback.
            /// </summary>
            public CfrV8Exception Exception {
                get {
                    CheckAccess();
                    if(m_exception_wrapped == null) m_exception_wrapped = CfrV8Exception.Wrap(new RemotePtr(connection, call.exception));
                    return m_exception_wrapped;
                }
            }
            /// <summary>
            /// Get the StackTrace parameter for the <see cref="CfrRenderProcessHandler.OnUncaughtException"/> render process callback.
            /// </summary>
            public CfrV8StackTrace StackTrace {
                get {
                    CheckAccess();
                    if(m_stackTrace_wrapped == null) m_stackTrace_wrapped = CfrV8StackTrace.Wrap(new RemotePtr(connection, call.stackTrace));
                    return m_stackTrace_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Context={{{2}}}, Exception={{{3}}}, StackTrace={{{4}}}", Browser, Frame, Context, Exception, StackTrace);
            }
        }

        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnFocusedNodeChangedEventHandler(object sender, CfrOnFocusedNodeChangedEventArgs e);

        /// <summary>
        /// Called when a new node in the the browser gets focus. The |Node| value may
        /// be NULL if no specific node has gained focus. The node object passed to
        /// this function represents a snapshot of the DOM at the time this function is
        /// executed. DOM objects are only valid for the scope of this function. Do not
        /// keep references to or attempt to access any DOM objects outside the scope
        /// of this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnFocusedNodeChangedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal CfrDomNode m_node_wrapped;

            internal CfrOnFocusedNodeChangedEventArgs(CfxRenderProcessHandlerOnFocusedNodeChangedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnFocusedNodeChanged"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrRenderProcessHandler.OnFocusedNodeChanged"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Node parameter for the <see cref="CfrRenderProcessHandler.OnFocusedNodeChanged"/> render process callback.
            /// </summary>
            public CfrDomNode Node {
                get {
                    CheckAccess();
                    if(m_node_wrapped == null) m_node_wrapped = CfrDomNode.Wrap(new RemotePtr(connection, call.node));
                    return m_node_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Node={{{2}}}", Browser, Frame, Node);
            }
        }

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnProcessMessageReceivedEventHandler(object sender, CfrOnProcessMessageReceivedEventArgs e);

        /// <summary>
        /// Called when a new message is received from a different process. Return true
        /// (1) if the message was handled or false (0) otherwise. Do not keep a
        /// reference to or attempt to access the message outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_render_process_handler_capi.h">cef/include/capi/cef_render_process_handler_capi.h</see>.
        /// </remarks>
        public class CfrOnProcessMessageReceivedEventArgs : CfrEventArgs {

            private CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall call;

            internal CfrBrowser m_browser_wrapped;
            internal CfrFrame m_frame_wrapped;
            internal CfrProcessMessage m_message_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrOnProcessMessageReceivedEventArgs(CfxRenderProcessHandlerOnProcessMessageReceivedRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfrRenderProcessHandler.OnProcessMessageReceived"/> render process callback.
            /// </summary>
            public CfrBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfrBrowser.Wrap(new RemotePtr(connection, call.browser));
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfrRenderProcessHandler.OnProcessMessageReceived"/> render process callback.
            /// </summary>
            public CfrFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfrFrame.Wrap(new RemotePtr(connection, call.frame));
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the SourceProcess parameter for the <see cref="CfrRenderProcessHandler.OnProcessMessageReceived"/> render process callback.
            /// </summary>
            public CfxProcessId SourceProcess {
                get {
                    CheckAccess();
                    return (CfxProcessId)call.source_process;
                }
            }
            /// <summary>
            /// Get the Message parameter for the <see cref="CfrRenderProcessHandler.OnProcessMessageReceived"/> render process callback.
            /// </summary>
            public CfrProcessMessage Message {
                get {
                    CheckAccess();
                    if(m_message_wrapped == null) m_message_wrapped = CfrProcessMessage.Wrap(new RemotePtr(connection, call.message));
                    return m_message_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrRenderProcessHandler.OnProcessMessageReceived"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, SourceProcess={{{2}}}, Message={{{3}}}", Browser, Frame, SourceProcess, Message);
            }
        }

    }
}
