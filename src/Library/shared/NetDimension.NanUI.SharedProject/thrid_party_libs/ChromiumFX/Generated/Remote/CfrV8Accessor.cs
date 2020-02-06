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
    /// Structure that should be implemented to handle V8 accessor calls. Accessor
    /// identifiers are registered by calling CfrV8Value.SetValue(). The
    /// functions of this structure will be called on the thread associated with the
    /// V8 accessor.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8Accessor : CfrBaseClient {


        private CfrV8Accessor(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrV8Accessor() : base(new CfxV8AccessorCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrV8AccessorGetEventHandler Get {
            add {
                if(m_Get == null) {
                    var call = new CfxV8AccessorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Get += value;
            }
            remove {
                m_Get -= value;
                if(m_Get == null) {
                    var call = new CfxV8AccessorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrV8AccessorGetEventHandler m_Get;


        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrV8AccessorSetEventHandler Set {
            add {
                if(m_Set == null) {
                    var call = new CfxV8AccessorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Set += value;
            }
            remove {
                m_Set -= value;
                if(m_Set == null) {
                    var call = new CfxV8AccessorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrV8AccessorSetEventHandler m_Set;


    }

    namespace Event {

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrV8AccessorGetEventHandler(object sender, CfrV8AccessorGetEventArgs e);

        /// <summary>
        /// Handle retrieval the accessor value identified by |Name|. |Object| is the
        /// receiver ('this' object) of the accessor. If retrieval succeeds set
        /// |Retval| to the return value. If retrieval fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor retrieval was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrV8AccessorGetEventArgs : CfrEventArgs {

            private CfxV8AccessorGetRemoteEventCall call;

            internal string m_name;
            internal bool m_name_fetched;
            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrV8AccessorGetEventArgs(CfxV8AccessorGetRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
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
            /// Get the Object parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public CfrV8Value Retval {
                set {
                    CheckAccess();
                    if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Accessor.Get"/> render process callback.
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
                return String.Format("Name={{{0}}}, Object={{{1}}}", Name, Object);
            }
        }

        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrV8AccessorSetEventHandler(object sender, CfrV8AccessorSetEventArgs e);

        /// <summary>
        /// Handle assignment of the accessor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the accessor. |Value| is the new value
        /// being assigned to the accessor. If assignment fails set |Exception| to the
        /// exception that will be thrown. Return true (1) if accessor assignment was
        /// handled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrV8AccessorSetEventArgs : CfrEventArgs {

            private CfxV8AccessorSetRemoteEventCall call;

            internal string m_name;
            internal bool m_name_fetched;
            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_value_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrV8AccessorSetEventArgs(CfxV8AccessorSetRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
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
            /// Get the Object parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public CfrV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.value));
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Accessor.Set"/> render process callback.
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
                return String.Format("Name={{{0}}}, Object={{{1}}}, Value={{{2}}}", Name, Object, Value);
            }
        }

    }
}
