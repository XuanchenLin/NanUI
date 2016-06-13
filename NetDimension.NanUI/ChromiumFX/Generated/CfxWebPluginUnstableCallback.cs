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
	/// Structure to implement for receiving unstable plugin information. The
	/// functions of this structure will be called on the browser process IO thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
	/// </remarks>
	public class CfxWebPluginUnstableCallback : CfxBase {

        static CfxWebPluginUnstableCallback () {
            CfxApiLoader.LoadCfxWebPluginUnstableCallbackApi();
        }

        internal static CfxWebPluginUnstableCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_web_plugin_unstable_callback_get_gc_handle(nativePtr);
            return (CfxWebPluginUnstableCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // is_unstable
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_web_plugin_unstable_callback_is_unstable_delegate(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int unstable);
        private static cfx_web_plugin_unstable_callback_is_unstable_delegate cfx_web_plugin_unstable_callback_is_unstable;
        private static IntPtr cfx_web_plugin_unstable_callback_is_unstable_ptr;

        internal static void is_unstable(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int unstable) {
            var self = (CfxWebPluginUnstableCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxWebPluginUnstableCallbackIsUnstableEventArgs(path_str, path_length, unstable);
            var eventHandler = self.m_IsUnstable;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
        }

        internal CfxWebPluginUnstableCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxWebPluginUnstableCallback() : base(CfxApi.cfx_web_plugin_unstable_callback_ctor) {}

        /// <summary>
        /// Method that will be called for the requested plugin. |Unstable| will be
        /// true (1) if the plugin has reached the crash count threshold of 3 times in
        /// 120 seconds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public event CfxWebPluginUnstableCallbackIsUnstableEventHandler IsUnstable {
            add {
                lock(eventLock) {
                    if(m_IsUnstable == null) {
                        if(cfx_web_plugin_unstable_callback_is_unstable == null) {
                            cfx_web_plugin_unstable_callback_is_unstable = is_unstable;
                            cfx_web_plugin_unstable_callback_is_unstable_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_web_plugin_unstable_callback_is_unstable);
                        }
                        CfxApi.cfx_web_plugin_unstable_callback_set_managed_callback(NativePtr, 0, cfx_web_plugin_unstable_callback_is_unstable_ptr);
                    }
                    m_IsUnstable += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_IsUnstable -= value;
                    if(m_IsUnstable == null) {
                        CfxApi.cfx_web_plugin_unstable_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxWebPluginUnstableCallbackIsUnstableEventHandler m_IsUnstable;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_IsUnstable != null) {
                m_IsUnstable = null;
                CfxApi.cfx_web_plugin_unstable_callback_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Method that will be called for the requested plugin. |Unstable| will be
		/// true (1) if the plugin has reached the crash count threshold of 3 times in
		/// 120 seconds.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
		/// </remarks>
		public delegate void CfxWebPluginUnstableCallbackIsUnstableEventHandler(object sender, CfxWebPluginUnstableCallbackIsUnstableEventArgs e);

        /// <summary>
        /// Method that will be called for the requested plugin. |Unstable| will be
        /// true (1) if the plugin has reached the crash count threshold of 3 times in
        /// 120 seconds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public class CfxWebPluginUnstableCallbackIsUnstableEventArgs : CfxEventArgs {

            internal IntPtr m_path_str;
            internal int m_path_length;
            internal string m_path;
            internal int m_unstable;

            internal CfxWebPluginUnstableCallbackIsUnstableEventArgs(IntPtr path_str, int path_length, int unstable) {
                m_path_str = path_str;
                m_path_length = path_length;
                m_unstable = unstable;
            }

            /// <summary>
            /// Get the Path parameter for the <see cref="CfxWebPluginUnstableCallback.IsUnstable"/> callback.
            /// </summary>
            public string Path {
                get {
                    CheckAccess();
                    m_path = StringFunctions.PtrToStringUni(m_path_str, m_path_length);
                    return m_path;
                }
            }
            /// <summary>
            /// Get the Unstable parameter for the <see cref="CfxWebPluginUnstableCallback.IsUnstable"/> callback.
            /// </summary>
            public bool Unstable {
                get {
                    CheckAccess();
                    return 0 != m_unstable;
                }
            }

            public override string ToString() {
                return String.Format("Path={{{0}}}, Unstable={{{1}}}", Path, Unstable);
            }
        }

    }
}
