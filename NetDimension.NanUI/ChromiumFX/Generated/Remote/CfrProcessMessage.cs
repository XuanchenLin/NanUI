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

	/// <summary>
	/// Structure representing a message. Can be used on any process and thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
	/// </remarks>
	public class CfrProcessMessage : CfrBase {

        internal static CfrProcessMessage Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrProcessMessage)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrProcessMessage(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        /// <summary>
        /// Create a new CfrProcessMessage object with the specified name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public static CfrProcessMessage Create(string name) {
            var call = new CfxProcessMessageCreateRenderProcessCall();
            call.name = name;
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return CfrProcessMessage.Wrap(call.__retval);
        }


        private CfrProcessMessage(IntPtr proxyId) : base(proxyId) {}

        /// <summary>
        /// Returns true (1) if this object is valid. Do not call any other functions
        /// if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var call = new CfxProcessMessageIsValidRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the values of this object are read-only. Some APIs may
        /// expose read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var call = new CfxProcessMessageIsReadOnlyRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the message name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public string Name {
            get {
                var call = new CfxProcessMessageGetNameRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the list of arguments.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfrListValue ArgumentList {
            get {
                var call = new CfxProcessMessageGetArgumentListRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return CfrListValue.Wrap(call.__retval);
            }
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_process_message_capi.h">cef/include/capi/cef_process_message_capi.h</see>.
        /// </remarks>
        public CfrProcessMessage Copy() {
            var call = new CfxProcessMessageCopyRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return CfrProcessMessage.Wrap(call.__retval);
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
