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
    /// Structure that should be implemented to handle V8 interceptor calls. The
    /// functions of this structure will be called on the thread associated with the
    /// V8 interceptor. Interceptor's named property handlers (with first argument of
    /// type CfrString) are called when object is indexed by string. Indexed property
    /// handlers (with first argument of type int) are called when object is indexed
    /// by integer.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8Interceptor : CfrBaseClient {


        private CfrV8Interceptor(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrV8Interceptor() : base(new CfxV8InterceptorCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrGetByNameEventHandler GetByName {
            add {
                if(m_GetByName == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetByName += value;
            }
            remove {
                m_GetByName -= value;
                if(m_GetByName == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetByNameEventHandler m_GetByName;


        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrGetByIndexEventHandler GetByIndex {
            add {
                if(m_GetByIndex == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetByIndex += value;
            }
            remove {
                m_GetByIndex -= value;
                if(m_GetByIndex == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetByIndexEventHandler m_GetByIndex;


        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrSetByNameEventHandler SetByName {
            add {
                if(m_SetByName == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_SetByName += value;
            }
            remove {
                m_SetByName -= value;
                if(m_SetByName == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrSetByNameEventHandler m_SetByName;


        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrSetByIndexEventHandler SetByIndex {
            add {
                if(m_SetByIndex == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_SetByIndex += value;
            }
            remove {
                m_SetByIndex -= value;
                if(m_SetByIndex == null) {
                    var call = new CfxV8InterceptorSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrSetByIndexEventHandler m_SetByIndex;


    }

    namespace Event {

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetByNameEventHandler(object sender, CfrGetByNameEventArgs e);

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Name|. |Object| is
        /// the receiver ('this' object) of the interceptor. If retrieval succeeds, set
        /// |Retval| to the return value. If the requested value does not exist, don't
        /// set either |Retval| or |Exception|. If retrieval fails, set |Exception| to
        /// the exception that will be thrown. If the property has an associated
        /// accessor, it will be called only if you don't set |Retval|. Return true (1)
        /// if interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrGetByNameEventArgs : CfrEventArgs {

            private CfxV8InterceptorGetByNameRemoteEventCall call;

            internal string m_name;
            internal bool m_name_fetched;
            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrGetByNameEventArgs(CfxV8InterceptorGetByNameRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Interceptor.GetByName"/> render process callback.
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
            /// Get the Object parameter for the <see cref="CfrV8Interceptor.GetByName"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfrV8Interceptor.GetByName"/> render process callback.
            /// </summary>
            public CfrV8Value Retval {
                set {
                    CheckAccess();
                    if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Interceptor.GetByName"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Interceptor.GetByName"/> render process callback.
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
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetByIndexEventHandler(object sender, CfrGetByIndexEventArgs e);

        /// <summary>
        /// Handle retrieval of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. If retrieval succeeds,
        /// set |Retval| to the return value. If the requested value does not exist,
        /// don't set either |Retval| or |Exception|. If retrieval fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor retrieval was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrGetByIndexEventArgs : CfrEventArgs {

            private CfxV8InterceptorGetByIndexRemoteEventCall call;

            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_retval_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrGetByIndexEventArgs(CfxV8InterceptorGetByIndexRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Index parameter for the <see cref="CfrV8Interceptor.GetByIndex"/> render process callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return call.index;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Interceptor.GetByIndex"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfrV8Interceptor.GetByIndex"/> render process callback.
            /// </summary>
            public CfrV8Value Retval {
                set {
                    CheckAccess();
                    if(!CfrObject.CheckConnection(value, connection)) throw new ArgumentException("Render process connection mismatch.", "value");
                    m_retval_wrapped = value;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Interceptor.GetByIndex"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Interceptor.GetByIndex"/> render process callback.
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
                return String.Format("Index={{{0}}}, Object={{{1}}}", Index, Object);
            }
        }

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrSetByNameEventHandler(object sender, CfrSetByNameEventArgs e);

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Name|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. This setter will always
        /// be called, even when the property has an associated accessor. Return true
        /// (1) if interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrSetByNameEventArgs : CfrEventArgs {

            private CfxV8InterceptorSetByNameRemoteEventCall call;

            internal string m_name;
            internal bool m_name_fetched;
            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_value_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrSetByNameEventArgs(CfxV8InterceptorSetByNameRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Interceptor.SetByName"/> render process callback.
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
            /// Get the Object parameter for the <see cref="CfrV8Interceptor.SetByName"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfrV8Interceptor.SetByName"/> render process callback.
            /// </summary>
            public CfrV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.value));
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Interceptor.SetByName"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Interceptor.SetByName"/> render process callback.
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

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrSetByIndexEventHandler(object sender, CfrSetByIndexEventArgs e);

        /// <summary>
        /// Handle assignment of the interceptor value identified by |Index|. |Object|
        /// is the receiver ('this' object) of the interceptor. |Value| is the new
        /// value being assigned to the interceptor. If assignment fails, set
        /// |Exception| to the exception that will be thrown. Return true (1) if
        /// interceptor assignment was handled, false (0) otherwise.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrSetByIndexEventArgs : CfrEventArgs {

            private CfxV8InterceptorSetByIndexRemoteEventCall call;

            internal CfrV8Value m_object_wrapped;
            internal CfrV8Value m_value_wrapped;
            internal string m_exception_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrSetByIndexEventArgs(CfxV8InterceptorSetByIndexRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Index parameter for the <see cref="CfrV8Interceptor.SetByIndex"/> render process callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return call.index;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Interceptor.SetByIndex"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(m_object_wrapped == null) m_object_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.@object));
                    return m_object_wrapped;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfrV8Interceptor.SetByIndex"/> render process callback.
            /// </summary>
            public CfrV8Value Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfrV8Value.Wrap(new RemotePtr(connection, call.value));
                    return m_value_wrapped;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Interceptor.SetByIndex"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    m_exception_wrapped = value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrV8Interceptor.SetByIndex"/> render process callback.
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
                return String.Format("Index={{{0}}}, Object={{{1}}}, Value={{{2}}}", Index, Object, Value);
            }
        }

    }
}
