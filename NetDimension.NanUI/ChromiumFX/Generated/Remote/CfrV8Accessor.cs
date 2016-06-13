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
	public class CfrV8Accessor : CfrBase {

        internal static CfrV8Accessor Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrV8Accessor)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrV8Accessor(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxV8AccessorCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        internal void raise_Get(object sender, CfrV8AccessorGetEventArgs e) {
            var handler = m_Get;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }

        internal void raise_Set(object sender, CfrV8AccessorSetEventArgs e) {
            var handler = m_Set;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }


        private CfrV8Accessor(IntPtr proxyId) : base(proxyId) {}
        public CfrV8Accessor() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
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
                    var call = new CfxV8AccessorGetActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_Get += value;
            }
            remove {
                m_Get -= value;
                if(m_Get == null) {
                    var call = new CfxV8AccessorGetDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrV8AccessorGetEventHandler m_Get;


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
                    var call = new CfxV8AccessorSetActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_Set += value;
            }
            remove {
                m_Set -= value;
                if(m_Set == null) {
                    var call = new CfxV8AccessorSetDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrV8AccessorSetEventHandler m_Set;


        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }

    namespace Event
	{

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

            bool NameFetched;
            string m_Name;
            bool ObjectFetched;
            CfrV8Value m_Object;
            bool ExceptionFetched;
            string m_Exception;

            private bool returnValueSet;

            internal CfrV8AccessorGetEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    if(!NameFetched) {
                        NameFetched = true;
                        var call = new CfxV8AccessorGetGetNameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Name = call.value;
                    }
                    return m_Name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(!ObjectFetched) {
                        ObjectFetched = true;
                        var call = new CfxV8AccessorGetGetObjectRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Object = CfrV8Value.Wrap(call.value);
                    }
                    return m_Object;
                }
            }
            /// <summary>
            /// Set the Retval out parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public CfrV8Value Retval {
                set {
                    CheckAccess();
                    var call = new CfxV8AccessorGetSetRetvalRenderProcessCall();
                    call.eventArgsId = eventArgsId;
                    call.value = CfrV8Value.Unwrap(value);
                    call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                }
            }
            /// <summary>
            /// Get or set the Exception parameter for the <see cref="CfrV8Accessor.Get"/> render process callback.
            /// </summary>
            public string Exception {
                get {
                    CheckAccess();
                    if(!ExceptionFetched) {
                        ExceptionFetched = true;
                        var call = new CfxV8AccessorGetGetExceptionRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Exception = call.value;
                    }
                    return m_Exception;
                }
                set {
                    CheckAccess();
                    m_Exception = value;
                    ExceptionFetched = true;
                    var call = new CfxV8AccessorGetSetExceptionRenderProcessCall();
                    call.eventArgsId = eventArgsId;
                    call.value = value;
                    call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
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
                var call = new CfxV8AccessorGetSetReturnValueRenderProcessCall();
                call.eventArgsId = eventArgsId;
                call.value = returnValue;
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Exception={{{2}}}", Name, Object, Exception);
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

            bool NameFetched;
            string m_Name;
            bool ObjectFetched;
            CfrV8Value m_Object;
            bool ValueFetched;
            CfrV8Value m_Value;
            bool ExceptionFetched;
            string m_Exception;

            private bool returnValueSet;

            internal CfrV8AccessorSetEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    if(!NameFetched) {
                        NameFetched = true;
                        var call = new CfxV8AccessorSetGetNameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Name = call.value;
                    }
                    return m_Name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(!ObjectFetched) {
                        ObjectFetched = true;
                        var call = new CfxV8AccessorSetGetObjectRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Object = CfrV8Value.Wrap(call.value);
                    }
                    return m_Object;
                }
            }
            /// <summary>
            /// Get the Value parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public CfrV8Value Value {
                get {
                    CheckAccess();
                    if(!ValueFetched) {
                        ValueFetched = true;
                        var call = new CfxV8AccessorSetGetValueRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Value = CfrV8Value.Wrap(call.value);
                    }
                    return m_Value;
                }
            }
            /// <summary>
            /// Get or set the Exception parameter for the <see cref="CfrV8Accessor.Set"/> render process callback.
            /// </summary>
            public string Exception {
                get {
                    CheckAccess();
                    if(!ExceptionFetched) {
                        ExceptionFetched = true;
                        var call = new CfxV8AccessorSetGetExceptionRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Exception = call.value;
                    }
                    return m_Exception;
                }
                set {
                    CheckAccess();
                    m_Exception = value;
                    ExceptionFetched = true;
                    var call = new CfxV8AccessorSetSetExceptionRenderProcessCall();
                    call.eventArgsId = eventArgsId;
                    call.value = value;
                    call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
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
                var call = new CfxV8AccessorSetSetReturnValueRenderProcessCall();
                call.eventArgsId = eventArgsId;
                call.value = returnValue;
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Value={{{2}}}, Exception={{{3}}}", Name, Object, Value, Exception);
            }
        }

    }
}
