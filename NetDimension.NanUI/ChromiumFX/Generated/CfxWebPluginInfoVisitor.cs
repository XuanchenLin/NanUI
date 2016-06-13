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
	/// Structure to implement for visiting web plugin information. The functions of
	/// this structure will be called on the browser process UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
	/// </remarks>
	public class CfxWebPluginInfoVisitor : CfxBase {

        static CfxWebPluginInfoVisitor () {
            CfxApiLoader.LoadCfxWebPluginInfoVisitorApi();
        }

        internal static CfxWebPluginInfoVisitor Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_web_plugin_info_visitor_get_gc_handle(nativePtr);
            return (CfxWebPluginInfoVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // visit
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_web_plugin_info_visitor_visit_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr info, int count, int total);
        private static cfx_web_plugin_info_visitor_visit_delegate cfx_web_plugin_info_visitor_visit;
        private static IntPtr cfx_web_plugin_info_visitor_visit_ptr;

        internal static void visit(IntPtr gcHandlePtr, out int __retval, IntPtr info, int count, int total) {
            var self = (CfxWebPluginInfoVisitor)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxWebPluginInfoVisitorVisitEventArgs(info, count, total);
            var eventHandler = self.m_Visit;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_info_wrapped == null) CfxApi.cfx_release(e.m_info);
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxWebPluginInfoVisitor(IntPtr nativePtr) : base(nativePtr) {}
        public CfxWebPluginInfoVisitor() : base(CfxApi.cfx_web_plugin_info_visitor_ctor) {}

        /// <summary>
        /// Method that will be called once for each plugin. |Count| is the 0-based
        /// index for the current plugin. |Total| is the total number of plugins.
        /// Return false (0) to stop visiting plugins. This function may never be
        /// called if no plugins are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public event CfxWebPluginInfoVisitorVisitEventHandler Visit {
            add {
                lock(eventLock) {
                    if(m_Visit == null) {
                        if(cfx_web_plugin_info_visitor_visit == null) {
                            cfx_web_plugin_info_visitor_visit = visit;
                            cfx_web_plugin_info_visitor_visit_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_web_plugin_info_visitor_visit);
                        }
                        CfxApi.cfx_web_plugin_info_visitor_set_managed_callback(NativePtr, 0, cfx_web_plugin_info_visitor_visit_ptr);
                    }
                    m_Visit += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Visit -= value;
                    if(m_Visit == null) {
                        CfxApi.cfx_web_plugin_info_visitor_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxWebPluginInfoVisitorVisitEventHandler m_Visit;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Visit != null) {
                m_Visit = null;
                CfxApi.cfx_web_plugin_info_visitor_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Method that will be called once for each plugin. |Count| is the 0-based
		/// index for the current plugin. |Total| is the total number of plugins.
		/// Return false (0) to stop visiting plugins. This function may never be
		/// called if no plugins are found.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
		/// </remarks>
		public delegate void CfxWebPluginInfoVisitorVisitEventHandler(object sender, CfxWebPluginInfoVisitorVisitEventArgs e);

        /// <summary>
        /// Method that will be called once for each plugin. |Count| is the 0-based
        /// index for the current plugin. |Total| is the total number of plugins.
        /// Return false (0) to stop visiting plugins. This function may never be
        /// called if no plugins are found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public class CfxWebPluginInfoVisitorVisitEventArgs : CfxEventArgs {

            internal IntPtr m_info;
            internal CfxWebPluginInfo m_info_wrapped;
            internal int m_count;
            internal int m_total;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxWebPluginInfoVisitorVisitEventArgs(IntPtr info, int count, int total) {
                m_info = info;
                m_count = count;
                m_total = total;
            }

            /// <summary>
            /// Get the Info parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public CfxWebPluginInfo Info {
                get {
                    CheckAccess();
                    if(m_info_wrapped == null) m_info_wrapped = CfxWebPluginInfo.Wrap(m_info);
                    return m_info_wrapped;
                }
            }
            /// <summary>
            /// Get the Count parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public int Count {
                get {
                    CheckAccess();
                    return m_count;
                }
            }
            /// <summary>
            /// Get the Total parameter for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
            /// </summary>
            public int Total {
                get {
                    CheckAccess();
                    return m_total;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxWebPluginInfoVisitor.Visit"/> callback.
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
                return String.Format("Info={{{0}}}, Count={{{1}}}, Total={{{2}}}", Info, Count, Total);
            }
        }

    }
}
