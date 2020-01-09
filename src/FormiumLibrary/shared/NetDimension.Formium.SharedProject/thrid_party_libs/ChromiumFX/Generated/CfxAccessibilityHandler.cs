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
    /// Implement this structure to receive accessibility notification when
    /// accessibility events have been registered. The functions of this structure
    /// will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
    /// </remarks>
    public class CfxAccessibilityHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_accessibility_tree_change_native = on_accessibility_tree_change;
            on_accessibility_location_change_native = on_accessibility_location_change;

            on_accessibility_tree_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_accessibility_tree_change_native);
            on_accessibility_location_change_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_accessibility_location_change_native);
        }

        // on_accessibility_tree_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_accessibility_tree_change_delegate(IntPtr gcHandlePtr, IntPtr value, out int value_release);
        private static on_accessibility_tree_change_delegate on_accessibility_tree_change_native;
        private static IntPtr on_accessibility_tree_change_native_ptr;

        internal static void on_accessibility_tree_change(IntPtr gcHandlePtr, IntPtr value, out int value_release) {
            var self = (CfxAccessibilityHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                value_release = 1;
                return;
            }
            var e = new CfxOnAccessibilityTreeChangeEventArgs();
            e.m_value = value;
            self.m_OnAccessibilityTreeChange?.Invoke(self, e);
            e.m_isInvalid = true;
            value_release = e.m_value_wrapped == null? 1 : 0;
        }

        // on_accessibility_location_change
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_accessibility_location_change_delegate(IntPtr gcHandlePtr, IntPtr value, out int value_release);
        private static on_accessibility_location_change_delegate on_accessibility_location_change_native;
        private static IntPtr on_accessibility_location_change_native_ptr;

        internal static void on_accessibility_location_change(IntPtr gcHandlePtr, IntPtr value, out int value_release) {
            var self = (CfxAccessibilityHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                value_release = 1;
                return;
            }
            var e = new CfxOnAccessibilityLocationChangeEventArgs();
            e.m_value = value;
            self.m_OnAccessibilityLocationChange?.Invoke(self, e);
            e.m_isInvalid = true;
            value_release = e.m_value_wrapped == null? 1 : 0;
        }

        public CfxAccessibilityHandler() : base(CfxApi.AccessibilityHandler.cfx_accessibility_handler_ctor) {}

        /// <summary>
        /// Called after renderer process sends accessibility tree changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnAccessibilityTreeChangeEventHandler OnAccessibilityTreeChange {
            add {
                lock(eventLock) {
                    if(m_OnAccessibilityTreeChange == null) {
                        CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 0, on_accessibility_tree_change_native_ptr);
                    }
                    m_OnAccessibilityTreeChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnAccessibilityTreeChange -= value;
                    if(m_OnAccessibilityTreeChange == null) {
                        CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnAccessibilityTreeChangeEventHandler m_OnAccessibilityTreeChange;

        /// <summary>
        /// Called after renderer process sends accessibility location changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnAccessibilityLocationChangeEventHandler OnAccessibilityLocationChange {
            add {
                lock(eventLock) {
                    if(m_OnAccessibilityLocationChange == null) {
                        CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 1, on_accessibility_location_change_native_ptr);
                    }
                    m_OnAccessibilityLocationChange += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnAccessibilityLocationChange -= value;
                    if(m_OnAccessibilityLocationChange == null) {
                        CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnAccessibilityLocationChangeEventHandler m_OnAccessibilityLocationChange;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnAccessibilityTreeChange != null) {
                m_OnAccessibilityTreeChange = null;
                CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnAccessibilityLocationChange != null) {
                m_OnAccessibilityLocationChange = null;
                CfxApi.AccessibilityHandler.cfx_accessibility_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called after renderer process sends accessibility tree changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnAccessibilityTreeChangeEventHandler(object sender, CfxOnAccessibilityTreeChangeEventArgs e);

        /// <summary>
        /// Called after renderer process sends accessibility tree changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnAccessibilityTreeChangeEventArgs : CfxEventArgs {

            internal IntPtr m_value;
            internal CfxValue m_value_wrapped;

            internal CfxOnAccessibilityTreeChangeEventArgs() {}

            /// <summary>
            /// Get the Value parameter for the <see cref="CfxAccessibilityHandler.OnAccessibilityTreeChange"/> callback.
            /// </summary>
            public CfxValue Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfxValue.Wrap(m_value);
                    return m_value_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Value={{{0}}}", Value);
            }
        }

        /// <summary>
        /// Called after renderer process sends accessibility location changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnAccessibilityLocationChangeEventHandler(object sender, CfxOnAccessibilityLocationChangeEventArgs e);

        /// <summary>
        /// Called after renderer process sends accessibility location changes to the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_accessibility_handler_capi.h">cef/include/capi/cef_accessibility_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnAccessibilityLocationChangeEventArgs : CfxEventArgs {

            internal IntPtr m_value;
            internal CfxValue m_value_wrapped;

            internal CfxOnAccessibilityLocationChangeEventArgs() {}

            /// <summary>
            /// Get the Value parameter for the <see cref="CfxAccessibilityHandler.OnAccessibilityLocationChange"/> callback.
            /// </summary>
            public CfxValue Value {
                get {
                    CheckAccess();
                    if(m_value_wrapped == null) m_value_wrapped = CfxValue.Wrap(m_value);
                    return m_value_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Value={{{0}}}", Value);
            }
        }

    }
}
