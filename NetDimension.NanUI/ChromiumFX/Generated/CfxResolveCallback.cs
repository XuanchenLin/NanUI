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

namespace Chromium
{
	using Event;

	/// <summary>
	/// Callback structure for CfxRequestContext.ResolveHost.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
	/// </remarks>
	public class CfxResolveCallback : CfxBase {

        static CfxResolveCallback () {
            CfxApiLoader.LoadCfxResolveCallbackApi();
        }

        internal static CfxResolveCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_resolve_callback_get_gc_handle(nativePtr);
            return (CfxResolveCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_resolve_completed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_resolve_callback_on_resolve_completed_delegate(IntPtr gcHandlePtr, int result, IntPtr resolved_ips);
        private static cfx_resolve_callback_on_resolve_completed_delegate cfx_resolve_callback_on_resolve_completed;
        private static IntPtr cfx_resolve_callback_on_resolve_completed_ptr;

        internal static void on_resolve_completed(IntPtr gcHandlePtr, int result, IntPtr resolved_ips) {
            var self = (CfxResolveCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxResolveCallbackOnResolveCompletedEventArgs(result, resolved_ips);
            var eventHandler = self.m_OnResolveCompleted;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxResolveCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxResolveCallback() : base(CfxApi.cfx_resolve_callback_ctor) {}

        /// <summary>
        /// Called after the ResolveHost request has completed. |Result| will be the
        /// result code. |ResolvedIps| will be the list of resolved IP addresses or
        /// NULL if the resolution failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public event CfxResolveCallbackOnResolveCompletedEventHandler OnResolveCompleted {
            add {
                lock(eventLock) {
                    if(m_OnResolveCompleted == null) {
                        if(cfx_resolve_callback_on_resolve_completed == null) {
                            cfx_resolve_callback_on_resolve_completed = on_resolve_completed;
                            cfx_resolve_callback_on_resolve_completed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_resolve_callback_on_resolve_completed);
                        }
                        CfxApi.cfx_resolve_callback_set_managed_callback(NativePtr, 0, cfx_resolve_callback_on_resolve_completed_ptr);
                    }
                    m_OnResolveCompleted += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResolveCompleted -= value;
                    if(m_OnResolveCompleted == null) {
                        CfxApi.cfx_resolve_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxResolveCallbackOnResolveCompletedEventHandler m_OnResolveCompleted;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnResolveCompleted != null) {
                m_OnResolveCompleted = null;
                CfxApi.cfx_resolve_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called after the ResolveHost request has completed. |Result| will be the
		/// result code. |ResolvedIps| will be the list of resolved IP addresses or
		/// NULL if the resolution failed.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
		/// </remarks>
		public delegate void CfxResolveCallbackOnResolveCompletedEventHandler(object sender, CfxResolveCallbackOnResolveCompletedEventArgs e);

        /// <summary>
        /// Called after the ResolveHost request has completed. |Result| will be the
        /// result code. |ResolvedIps| will be the list of resolved IP addresses or
        /// NULL if the resolution failed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_capi.h">cef/include/capi/cef_request_context_capi.h</see>.
        /// </remarks>
        public class CfxResolveCallbackOnResolveCompletedEventArgs : CfxEventArgs {

            internal int m_result;
            internal IntPtr m_resolved_ips;

            internal CfxResolveCallbackOnResolveCompletedEventArgs(int result, IntPtr resolved_ips) {
                m_result = result;
                m_resolved_ips = resolved_ips;
            }

            /// <summary>
            /// Get the Result parameter for the <see cref="CfxResolveCallback.OnResolveCompleted"/> callback.
            /// </summary>
            public CfxErrorCode Result {
                get {
                    CheckAccess();
                    return (CfxErrorCode)m_result;
                }
            }
            /// <summary>
            /// Get the ResolvedIps parameter for the <see cref="CfxResolveCallback.OnResolveCompleted"/> callback.
            /// </summary>
            public System.Collections.Generic.List<string> ResolvedIps {
                get {
                    CheckAccess();
                    return StringFunctions.WrapCfxStringList(m_resolved_ips);
                }
            }

            public override string ToString() {
                return String.Format("Result={{{0}}}, ResolvedIps={{{1}}}", Result, ResolvedIps);
            }
        }

    }
}
