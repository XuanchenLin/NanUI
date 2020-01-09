// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Implement this structure to handle events related to find results. The
    /// functions of this structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_find_handler_capi.h">cef/include/capi/cef_find_handler_capi.h</see>.
    /// </remarks>
    public class CfxFindHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_find_result_native = on_find_result;

            on_find_result_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_find_result_native);
        }

        // on_find_result
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_find_result_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int identifier, int count, IntPtr selectionRect, int activeMatchOrdinal, int finalUpdate);
        private static on_find_result_delegate on_find_result_native;
        private static IntPtr on_find_result_native_ptr;

        internal static void on_find_result(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, int identifier, int count, IntPtr selectionRect, int activeMatchOrdinal, int finalUpdate) {
            var self = (CfxFindHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                return;
            }
            var e = new CfxOnFindResultEventArgs();
            e.m_browser = browser;
            e.m_identifier = identifier;
            e.m_count = count;
            e.m_selectionRect = selectionRect;
            e.m_activeMatchOrdinal = activeMatchOrdinal;
            e.m_finalUpdate = finalUpdate;
            self.m_OnFindResult?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
        }

        public CfxFindHandler() : base(CfxApi.FindHandler.cfx_find_handler_ctor) {}

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
        public event CfxOnFindResultEventHandler OnFindResult {
            add {
                lock(eventLock) {
                    if(m_OnFindResult == null) {
                        CfxApi.FindHandler.cfx_find_handler_set_callback(NativePtr, 0, on_find_result_native_ptr);
                    }
                    m_OnFindResult += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnFindResult -= value;
                    if(m_OnFindResult == null) {
                        CfxApi.FindHandler.cfx_find_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnFindResultEventHandler m_OnFindResult;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnFindResult != null) {
                m_OnFindResult = null;
                CfxApi.FindHandler.cfx_find_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

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
        public delegate void CfxOnFindResultEventHandler(object sender, CfxOnFindResultEventArgs e);

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
        public class CfxOnFindResultEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_identifier;
            internal int m_count;
            internal IntPtr m_selectionRect;
            internal CfxRect m_selectionRect_wrapped;
            internal int m_activeMatchOrdinal;
            internal int m_finalUpdate;

            internal CfxOnFindResultEventArgs() {}

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
