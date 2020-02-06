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
    /// Structure to implement for visiting cookie values. The functions of this
    /// structure will always be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
    /// </remarks>
    public class CfxCookieVisitor : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            visit_native = visit;

            visit_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(visit_native);
        }

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void visit_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr cookie, int count, int total, out int deleteCookie);
        private static visit_delegate visit_native;
        private static IntPtr visit_native_ptr;

        internal static void visit(IntPtr gcHandlePtr, out int __retval, IntPtr cookie, int count, int total, out int deleteCookie) {
            var self = (CfxCookieVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                deleteCookie = default(int);
                return;
            }
            var e = new CfxCookieVisitorVisitEventArgs();
            e.m_cookie = cookie;
            e.m_count = count;
            e.m_total = total;
            self.m_Visit?.Invoke(self, e);
            e.m_isInvalid = true;
            deleteCookie = e.m_deleteCookie;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxCookieVisitor() : base(CfxApi.CookieVisitor.cfx_cookie_visitor_ctor) {}

        /// <summary>
        /// Method that will be called once for each cookie. |Count| is the 0-based
        /// index for the current cookie. |Total| is the total number of cookies. Set
        /// |DeleteCookie| to true (1) to delete the cookie currently being visited.
        /// Return false (0) to stop visiting cookies. This function may never be
        /// called if no cookies are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public event CfxCookieVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        CfxApi.CookieVisitor.cfx_cookie_visitor_set_callback(NativePtr, 0, visit_native_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.CookieVisitor.cfx_cookie_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxCookieVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.CookieVisitor.cfx_cookie_visitor_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called once for each cookie. |Count| is the 0-based
        /// index for the current cookie. |Total| is the total number of cookies. Set
        /// |DeleteCookie| to true (1) to delete the cookie currently being visited.
        /// Return false (0) to stop visiting cookies. This function may never be
        /// called if no cookies are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public delegate void CfxCookieVisitorVisitEventHandler(object sender, CfxCookieVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be called once for each cookie. |Count| is the 0-based
        /// index for the current cookie. |Total| is the total number of cookies. Set
        /// |DeleteCookie| to true (1) to delete the cookie currently being visited.
        /// Return false (0) to stop visiting cookies. This function may never be
        /// called if no cookies are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_cookie_capi.h">cef/include/capi/cef_cookie_capi.h</see>.
        /// </remarks>
        public class CfxCookieVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_cookie;
            internal CfxCookie m_cookie_wrapped;
            internal int m_count;
            internal int m_total;
            internal int m_deleteCookie;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxCookieVisitorVisitEventArgs() {}

            /// <summary>
            /// Get the Cookie parameter for the <see cref="CfxCookieVisitor.Visit"/> callback.
            /// </summary>
            public CfxCookie Cookie {
                get {
                    CheckAccess();
                    if(m_cookie_wrapped == null) m_cookie_wrapped = CfxCookie.Wrap(m_cookie);
                    return m_cookie_wrapped;
                }
            }
            /// <summary>
            /// Get the Count parameter for the <see cref="CfxCookieVisitor.Visit"/> callback.
            /// </summary>
            public int Count {
                get {
                    CheckAccess();
                    return m_count;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxCookieVisitor.Visit"/> callback.
            /// </summary>
            public int Total {
                get {
                    CheckAccess();
                    return m_total;
                }
            }
            /// <summary>
            /// Set the DeleteCookie out parameter for the <see cref="CfxCookieVisitor.Visit"/> callback.
            /// </summary>
            public bool DeleteCookie {
                set {
                    CheckAccess();
                    m_deleteCookie = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxCookieVisitor.Visit"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Cookie={{{0}}}, Count={{{1}}}, Total={{{2}}}", Cookie, Count, Total);
            }
        }

    }
}
