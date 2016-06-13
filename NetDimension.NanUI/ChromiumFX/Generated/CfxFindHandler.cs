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
	/// Implement this structure to handle events related to find results. The
	/// functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_find_handler_capi.h">cef/include/capi/cef_find_handler_capi.h</see>.
	/// </remarks>
	public class CfxFindHandler : CfxBase {

        static CfxFindHandler () {
            CfxApiLoader.LoadCfxFindHandlerApi();
        }

        internal static CfxFindHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_find_handler_get_gc_handle(nativePtr);
            return (CfxFindHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_find_result
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_find_handler_on_find_result_delegate(IntPtr gcHandlePtr, IntPtr browser, int identifier, int count, IntPtr selectionRect, int activeMatchOrdinal, int finalUpdate);
        private static cfx_find_handler_on_find_result_delegate cfx_find_handler_on_find_result;
        private static IntPtr cfx_find_handler_on_find_result_ptr;

        internal static void on_find_result(IntPtr gcHandlePtr, IntPtr browser, int identifier, int count, IntPtr selectionRect, int activeMatchOrdinal, int finalUpdate) {
            var self = (CfxFindHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxFindHandlerOnFindResultEventArgs(browser, identifier, count, selectionRect, activeMatchOrdinal, finalUpdate);
            var eventHandler = self.m_OnFindResult;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        internal CfxFindHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxFindHandler() : base(CfxApi.cfx_find_handler_ctor) {}

        /// <summary>
        /// Called to report find results returned by CfxBrowserHost.Find().
        /// |Identifer| is the identifier passed to find(), |Count| is the number of
        /// matches currently identified, |SelectionRect| is the location of where the
        /// match was found (in window coordinates), |ActiveMatchOrdinal| is the
        /// current position in the search results, and |FinalUpdate| is true (1) if
        /// this is the last find notification.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_find_handler_capi.h">cef/include/capi/cef_find_handler_capi.h</see>.
        /// </remarks>
        public event CfxFindHandlerOnFindResultEventHandler OnFindResult {
            add {
                lock(eventLock) {
                    if(m_OnFindResult == null) {
                        if(cfx_find_handler_on_find_result == null) {
                            cfx_find_handler_on_find_result = on_find_result;
                            cfx_find_handler_on_find_result_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_find_handler_on_find_result);
                        }
                        CfxApi.cfx_find_handler_set_managed_callback(NativePtr, 0, cfx_find_handler_on_find_result_ptr);
                    }
                    m_OnFindResult += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFindResult -= value;
                    if(m_OnFindResult == null) {
                        CfxApi.cfx_find_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxFindHandlerOnFindResultEventHandler m_OnFindResult;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnFindResult != null) {
                m_OnFindResult = null;
                CfxApi.cfx_find_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called to report find results returned by CfxBrowserHost.Find().
		/// |Identifer| is the identifier passed to find(), |Count| is the number of
		/// matches currently identified, |SelectionRect| is the location of where the
		/// match was found (in window coordinates), |ActiveMatchOrdinal| is the
		/// current position in the search results, and |FinalUpdate| is true (1) if
		/// this is the last find notification.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_find_handler_capi.h">cef/include/capi/cef_find_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxFindHandlerOnFindResultEventHandler(object sender, CfxFindHandlerOnFindResultEventArgs e);

        /// <summary>
        /// Called to report find results returned by CfxBrowserHost.Find().
        /// |Identifer| is the identifier passed to find(), |Count| is the number of
        /// matches currently identified, |SelectionRect| is the location of where the
        /// match was found (in window coordinates), |ActiveMatchOrdinal| is the
        /// current position in the search results, and |FinalUpdate| is true (1) if
        /// this is the last find notification.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_find_handler_capi.h">cef/include/capi/cef_find_handler_capi.h</see>.
        /// </remarks>
        public class CfxFindHandlerOnFindResultEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_identifier;
            internal int m_count;
            internal IntPtr m_selectionRect;
            internal CfxRect m_selectionRect_wrapped;
            internal int m_activeMatchOrdinal;
            internal int m_finalUpdate;

            internal CfxFindHandlerOnFindResultEventArgs(IntPtr browser, int identifier, int count, IntPtr selectionRect, int activeMatchOrdinal, int finalUpdate) {
                m_browser = browser;
                m_identifier = identifier;
                m_count = count;
                m_selectionRect = selectionRect;
                m_activeMatchOrdinal = activeMatchOrdinal;
                m_finalUpdate = finalUpdate;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Identifier parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public int Identifier {
                get {
                    CheckAccess();
                    return m_identifier;
                }
            }
            /// <summary>
            /// Get the Count parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public int Count {
                get {
                    CheckAccess();
                    return m_count;
                }
            }
            /// <summary>
            /// Get the SelectionRect parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public CfxRect SelectionRect {
                get {
                    CheckAccess();
                    if(m_selectionRect_wrapped == null) m_selectionRect_wrapped = CfxRect.Wrap(m_selectionRect);
                    return m_selectionRect_wrapped;
                }
            }
            /// <summary>
            /// Get the ActiveMatchOrdinal parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public int ActiveMatchOrdinal {
                get {
                    CheckAccess();
                    return m_activeMatchOrdinal;
                }
            }
            /// <summary>
            /// Get the FinalUpdate parameter for the <see cref="CfxFindHandler.OnFindResult"/> callback.
            /// </summary>
            public bool FinalUpdate {
                get {
                    CheckAccess();
                    return 0 != m_finalUpdate;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Identifier={{{1}}}, Count={{{2}}}, SelectionRect={{{3}}}, ActiveMatchOrdinal={{{4}}}, FinalUpdate={{{5}}}", Browser, Identifier, Count, SelectionRect, ActiveMatchOrdinal, FinalUpdate);
            }
        }

    }
}
