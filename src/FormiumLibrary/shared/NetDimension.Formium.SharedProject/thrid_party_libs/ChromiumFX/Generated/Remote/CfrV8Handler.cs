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
    /// Structure that should be implemented to handle V8 function calls. The
    /// functions of this structure will be called on the thread associated with the
    /// V8 function.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8Handler : CfrBaseClient {

        internal static CfrV8Handler Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var call = new CfxV8HandlerGetGcHandleRemoteCall();
            call.self = remotePtr.ptr;
            call.RequestExecution(remotePtr.connection);
            return (CfrV8Handler)System.Runtime.InteropServices.GCHandle.FromIntPtr(call.gc_handle).Target;
        }



        private CfrV8Handler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrV8Handler() : base(new CfxV8HandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Handle execution of the function identified by |Name|. |Object| is the
        /// receiver ('this' object) of the function. |Arguments| is the list of
        /// arguments passed to the function. If execution succeeds set |Retval| to the
        /// function return value. If execution fails set |Exception| to the exception
        /// that will be thrown. Return true (1) if execution was handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrV8HandlerExecuteEventHandler Execute {
            add {
                if(m_Execute == null) {
                    var call = new CfxV8HandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Execute += value;
            }
            remove {
                m_Execute -= value;
                if(m_Execute == null) {
                    var call = new CfxV8HandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrV8HandlerExecuteEventHandler m_Execute;


    }

    namespace Event {

        /// <summary>
        /// Handle execution of the function identified by |Name|. |Object| is the
        /// receiver ('this' object) of the function. |Arguments| is the list of
        /// arguments passed to the function. If execution succeeds set |Retval| to the
        /// function return value. If execution fails set |Exception| to the exception
        /// that will be thrown. Return true (1) if execution was handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrV8HandlerExecuteEventHandler(object sender, CfrV8HandlerExecuteEventArgs e);

        /// <summary>
        /// Handle execution of the function identified by |Name|. |Object| is the
        /// receiver ('this' object) of the function. |Arguments| is the list of
        /// arguments passed to the function. If execution succeeds set |Retval| to the
        /// function return value. If execution fails set |Exception| to the exception
        /// that will be thrown. Return true (1) if execution was handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrV8HandlerExecuteEventArgs : CfrEventArgs {

            private CfxV8HandlerExecuteRemoteEventCall call;

            internal string m_name;
            internal bool m_name_fetched;
            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value[] m_arguments_managed;
            internal string m_exception_wrapped;

            internal CfrV8Value m_returnValue;
            private bool returnValueSet;

            internal CfrV8HandlerExecuteEventArgs(CfxV8HandlerExecuteRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    if(!m_name_fetched) {
                        m_name = call.name_str == IntPtr.Zero ? null : (call.name_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(connection, call.name_str), call.name_length));
                        m_name_fetched = true;
                    }
                    return m_name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Arguments parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public CfrV8Value[] Arguments {
                get {
                    CheckAccess();
                    if(m_arguments_managed == null) {
                        var arguments = new RemotePtr[(ulong)call.argumentsCount];
                        m_arguments_managed = new CfrV8Value[arguments.Length];
                        if(arguments.Length > 0) {
                            CfrRuntime.Marshal.Copy(new RemotePtr(connection, call.arguments), arguments, 0, arguments.Length);
                            for(int i = 0; i < arguments.Length; ++i) {
                                m_arguments_managed[i] = CfrV8Value.Wrap(arguments[i]);
                            }
                        }
                    }
                    return m_arguments_managed;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrV8Value returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Arguments={{{2}}}", Name, Object, Arguments);
            }
        }

    }
}
