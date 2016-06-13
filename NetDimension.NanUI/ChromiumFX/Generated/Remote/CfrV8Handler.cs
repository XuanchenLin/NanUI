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
	/// Structure that should be implemented to handle V8 function calls. The
	/// functions of this structure will be called on the thread associated with the
	/// V8 function.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
	/// </remarks>
	public class CfrV8Handler : CfrBase {

        internal static CfrV8Handler Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrV8Handler)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrV8Handler(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        internal static IntPtr CreateRemote() {
            var call = new CfxV8HandlerCtorRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return call.__retval;
        }

        internal void raise_Execute(object sender, CfrV8HandlerExecuteEventArgs e) {
            var handler = m_Execute;
            if(handler == null) return;
            handler(this, e);
            e.m_isInvalid = true;
        }


        private CfrV8Handler(IntPtr proxyId) : base(proxyId) {}
        public CfrV8Handler() : base(CreateRemote()) {
            connection.weakCache.Add(proxyId, this);
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
                    var call = new CfxV8HandlerExecuteActivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
                m_Execute += value;
            }
            remove {
                m_Execute -= value;
                if(m_Execute == null) {
                    var call = new CfxV8HandlerExecuteDeactivateRenderProcessCall();
                    call.sender = proxyId;
                    call.RequestExecution(this);
                }
            }
        }

        CfrV8HandlerExecuteEventHandler m_Execute;


        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }

    namespace Event
	{

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

            bool NameFetched;
            string m_Name;
            bool ObjectFetched;
            CfrV8Value m_Object;
            bool ArgumentsFetched;
            CfrV8Value[] m_Arguments;

            private bool returnValueSet;

            internal CfrV8HandlerExecuteEventArgs(ulong eventArgsId) : base(eventArgsId) {}

            /// <summary>
            /// Get the Name parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public string Name {
                get {
                    CheckAccess();
                    if(!NameFetched) {
                        NameFetched = true;
                        var call = new CfxV8HandlerExecuteGetNameRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Name = call.value;
                    }
                    return m_Name;
                }
            }
            /// <summary>
            /// Get the Object parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public CfrV8Value Object {
                get {
                    CheckAccess();
                    if(!ObjectFetched) {
                        ObjectFetched = true;
                        var call = new CfxV8HandlerExecuteGetObjectRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Object = CfrV8Value.Wrap(call.value);
                    }
                    return m_Object;
                }
            }
            /// <summary>
            /// Get the Arguments parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public CfrV8Value[] Arguments {
                get {
                    CheckAccess();
                    if(!ArgumentsFetched) {
                        ArgumentsFetched = true;
                        var call = new CfxV8HandlerExecuteGetArgumentsRenderProcessCall();
                        call.eventArgsId = eventArgsId;
                        call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                        m_Arguments = CfxArray.GetCfrObjects<CfrV8Value>(call.value, CfrV8Value.Wrap);
                    }
                    return m_Arguments;
                }
            }
            /// <summary>
            /// Set the Exception out parameter for the <see cref="CfrV8Handler.Execute"/> render process callback.
            /// </summary>
            public string Exception {
                set {
                    CheckAccess();
                    var call = new CfxV8HandlerExecuteSetExceptionRenderProcessCall();
                    call.eventArgsId = eventArgsId;
                    call.value = value;
                    call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
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
                var call = new CfxV8HandlerExecuteSetReturnValueRenderProcessCall();
                call.eventArgsId = eventArgsId;
                call.value = CfrObject.Unwrap(returnValue);
                call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Name={{{0}}}, Object={{{1}}}, Arguments={{{2}}}", Name, Object, Arguments);
            }
        }

    }
}
