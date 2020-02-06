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
    /// Structure to implement for receiving unstable plugin information. The
    /// functions of this structure will be called on the browser process IO thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
    /// </remarks>
    public class CfxWebPluginUnstableCallback : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            is_unstable_native = is_unstable;

            is_unstable_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(is_unstable_native);
        }

        // is_unstable
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void is_unstable_delegate(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int unstable);
        private static is_unstable_delegate is_unstable_native;
        private static IntPtr is_unstable_native_ptr;

        internal static void is_unstable(IntPtr gcHandlePtr, IntPtr path_str, int path_length, int unstable) {
            var self = (CfxWebPluginUnstableCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxIsUnstableEventArgs();
            e.m_path_str = path_str;
            e.m_path_length = path_length;
            e.m_unstable = unstable;
            self.m_IsUnstable?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        public CfxWebPluginUnstableCallback() : base(CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_ctor) {}

        /// <summary>
        /// Method that will be called for the requested plugin. |Unstable| will be
        /// true (1) if the plugin has reached the crash count threshold of 3 times in
        /// 120 seconds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public event CfxIsUnstableEventHandler IsUnstable {
            add {
                lock(eventLock) {
                    if(m_IsUnstable == null) {
                        CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_set_callback(NativePtr, 0, is_unstable_native_ptr);
                    }
                    m_IsUnstable += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_IsUnstable -= value;
                    if(m_IsUnstable == null) {
                        CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxIsUnstableEventHandler m_IsUnstable;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_IsUnstable != null) {
                m_IsUnstable = null;
                CfxApi.WebPluginUnstableCallback.cfx_web_plugin_unstable_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Method that will be called for the requested plugin. |Unstable| will be
        /// true (1) if the plugin has reached the crash count threshold of 3 times in
        /// 120 seconds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public delegate void CfxIsUnstableEventHandler(object sender, CfxIsUnstableEventArgs e);

        /// <summary>
        /// Method that will be called for the requested plugin. |Unstable| will be
        /// true (1) if the plugin has reached the crash count threshold of 3 times in
        /// 120 seconds.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_web_plugin_capi.h">cef/include/capi/cef_web_plugin_capi.h</see>.
        /// </remarks>
        public class CfxIsUnstableEventArgs : CfxEventArgs {

            internal IntPtr m_path_str;
            internal int m_path_length;
            internal string m_path;
            internal int m_unstable;

            internal CfxIsUnstableEventArgs() {}

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
