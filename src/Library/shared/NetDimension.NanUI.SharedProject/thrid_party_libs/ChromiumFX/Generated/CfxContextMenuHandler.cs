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
    /// Implement this structure to handle context menu events. The functions of this
    /// structure will be called on the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
    /// </remarks>
    public class CfxContextMenuHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_before_context_menu_native = on_before_context_menu;
            run_context_menu_native = run_context_menu;
            on_context_menu_command_native = on_context_menu_command;
            on_context_menu_dismissed_native = on_context_menu_dismissed;

            on_before_context_menu_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_context_menu_native);
            run_context_menu_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(run_context_menu_native);
            on_context_menu_command_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_context_menu_command_native);
            on_context_menu_dismissed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_context_menu_dismissed_native);
        }

        // on_before_context_menu
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_context_menu_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, IntPtr model, out int model_release);
        private static on_before_context_menu_delegate on_before_context_menu_native;
        private static IntPtr on_before_context_menu_native_ptr;

        internal static void on_before_context_menu(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, IntPtr model, out int model_release) {
            var self = (CfxContextMenuHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                params_release = 1;
                model_release = 1;
                return;
            }
            var e = new CfxOnBeforeContextMenuEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_params = parameters;
            e.m_model = model;
            self.m_OnBeforeContextMenu?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            params_release = e.m_params_wrapped == null? 1 : 0;
            model_release = e.m_model_wrapped == null? 1 : 0;
        }

        // run_context_menu
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void run_context_menu_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, IntPtr model, out int model_release, IntPtr callback, out int callback_release);
        private static run_context_menu_delegate run_context_menu_native;
        private static IntPtr run_context_menu_native_ptr;

        internal static void run_context_menu(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, IntPtr model, out int model_release, IntPtr callback, out int callback_release) {
            var self = (CfxContextMenuHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                params_release = 1;
                model_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxRunContextMenuEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_params = parameters;
            e.m_model = model;
            e.m_callback = callback;
            self.m_RunContextMenu?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            params_release = e.m_params_wrapped == null? 1 : 0;
            model_release = e.m_model_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_context_menu_command
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_menu_command_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, int command_id, int event_flags);
        private static on_context_menu_command_delegate on_context_menu_command_native;
        private static IntPtr on_context_menu_command_native_ptr;

        internal static void on_context_menu_command(IntPtr gcHandlePtr, out int __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr parameters, out int params_release, int command_id, int event_flags) {
            var self = (CfxContextMenuHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                browser_release = 1;
                frame_release = 1;
                params_release = 1;
                return;
            }
            var e = new CfxOnContextMenuCommandEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_params = parameters;
            e.m_command_id = command_id;
            e.m_event_flags = event_flags;
            self.m_OnContextMenuCommand?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            params_release = e.m_params_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_context_menu_dismissed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_context_menu_dismissed_delegate(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release);
        private static on_context_menu_dismissed_delegate on_context_menu_dismissed_native;
        private static IntPtr on_context_menu_dismissed_native_ptr;

        internal static void on_context_menu_dismissed(IntPtr gcHandlePtr, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release) {
            var self = (CfxContextMenuHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                browser_release = 1;
                frame_release = 1;
                return;
            }
            var e = new CfxOnContextMenuDismissedEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            self.m_OnContextMenuDismissed?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
        }

        public CfxContextMenuHandler() : base(CfxApi.ContextMenuHandler.cfx_context_menu_handler_ctor) {}

        /// <summary>
        /// Called before a context menu is displayed. |Params| provides information
        /// about the context menu state. |Model| initially contains the default
        /// context menu. The |Model| can be cleared to show no context menu or
        /// modified to show a custom menu. Do not keep references to |Params| or
        /// |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeContextMenuEventHandler OnBeforeContextMenu {
            add {
                lock(eventLock) {
                    if(m_OnBeforeContextMenu == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 0, on_before_context_menu_native_ptr);
                    }
                    m_OnBeforeContextMenu += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeContextMenu -= value;
                    if(m_OnBeforeContextMenu == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeContextMenuEventHandler m_OnBeforeContextMenu;

        /// <summary>
        /// Called to allow custom display of the context menu. |Params| provides
        /// information about the context menu state. |Model| contains the context menu
        /// model resulting from OnBeforeContextMenu. For custom display return true
        /// (1) and execute |Callback| either synchronously or asynchronously with the
        /// selected command ID. For default display return false (0). Do not keep
        /// references to |Params| or |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public event CfxRunContextMenuEventHandler RunContextMenu {
            add {
                lock(eventLock) {
                    if(m_RunContextMenu == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 1, run_context_menu_native_ptr);
                    }
                    m_RunContextMenu += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_RunContextMenu -= value;
                    if(m_RunContextMenu == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxRunContextMenuEventHandler m_RunContextMenu;

        /// <summary>
        /// Called to execute a command selected from the context menu. Return true (1)
        /// if the command was handled or false (0) for the default implementation. See
        /// CfxMenuId for the command ids that have default implementations. All
        /// user-defined command ids should be between MENU_ID_USER_FIRST and
        /// MENU_ID_USER_LAST. |Params| will have the same values as what was passed to
        /// on_before_context_menu(). Do not keep a reference to |Params| outside of
        /// this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnContextMenuCommandEventHandler OnContextMenuCommand {
            add {
                lock(eventLock) {
                    if(m_OnContextMenuCommand == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 2, on_context_menu_command_native_ptr);
                    }
                    m_OnContextMenuCommand += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextMenuCommand -= value;
                    if(m_OnContextMenuCommand == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnContextMenuCommandEventHandler m_OnContextMenuCommand;

        /// <summary>
        /// Called when the context menu is dismissed irregardless of whether the menu
        /// was NULL or a command was selected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnContextMenuDismissedEventHandler OnContextMenuDismissed {
            add {
                lock(eventLock) {
                    if(m_OnContextMenuDismissed == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 3, on_context_menu_dismissed_native_ptr);
                    }
                    m_OnContextMenuDismissed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnContextMenuDismissed -= value;
                    if(m_OnContextMenuDismissed == null) {
                        CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnContextMenuDismissedEventHandler m_OnContextMenuDismissed;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnBeforeContextMenu != null) {
                m_OnBeforeContextMenu = null;
                CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_RunContextMenu != null) {
                m_RunContextMenu = null;
                CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnContextMenuCommand != null) {
                m_OnContextMenuCommand = null;
                CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnContextMenuDismissed != null) {
                m_OnContextMenuDismissed = null;
                CfxApi.ContextMenuHandler.cfx_context_menu_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called before a context menu is displayed. |Params| provides information
        /// about the context menu state. |Model| initially contains the default
        /// context menu. The |Model| can be cleared to show no context menu or
        /// modified to show a custom menu. Do not keep references to |Params| or
        /// |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeContextMenuEventHandler(object sender, CfxOnBeforeContextMenuEventArgs e);

        /// <summary>
        /// Called before a context menu is displayed. |Params| provides information
        /// about the context menu state. |Model| initially contains the default
        /// context menu. The |Model| can be cleared to show no context menu or
        /// modified to show a custom menu. Do not keep references to |Params| or
        /// |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeContextMenuEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_params;
            internal CfxContextMenuParams m_params_wrapped;
            internal IntPtr m_model;
            internal CfxMenuModel m_model_wrapped;

            internal CfxOnBeforeContextMenuEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxContextMenuHandler.OnBeforeContextMenu"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxContextMenuHandler.OnBeforeContextMenu"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Params parameter for the <see cref="CfxContextMenuHandler.OnBeforeContextMenu"/> callback.
            /// </summary>
            public CfxContextMenuParams Params {
                get {
                    CheckAccess();
                    if(m_params_wrapped == null) m_params_wrapped = CfxContextMenuParams.Wrap(m_params);
                    return m_params_wrapped;
                }
            }
            /// <summary>
            /// Get the Model parameter for the <see cref="CfxContextMenuHandler.OnBeforeContextMenu"/> callback.
            /// </summary>
            public CfxMenuModel Model {
                get {
                    CheckAccess();
                    if(m_model_wrapped == null) m_model_wrapped = CfxMenuModel.Wrap(m_model);
                    return m_model_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Params={{{2}}}, Model={{{3}}}", Browser, Frame, Params, Model);
            }
        }

        /// <summary>
        /// Called to allow custom display of the context menu. |Params| provides
        /// information about the context menu state. |Model| contains the context menu
        /// model resulting from OnBeforeContextMenu. For custom display return true
        /// (1) and execute |Callback| either synchronously or asynchronously with the
        /// selected command ID. For default display return false (0). Do not keep
        /// references to |Params| or |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxRunContextMenuEventHandler(object sender, CfxRunContextMenuEventArgs e);

        /// <summary>
        /// Called to allow custom display of the context menu. |Params| provides
        /// information about the context menu state. |Model| contains the context menu
        /// model resulting from OnBeforeContextMenu. For custom display return true
        /// (1) and execute |Callback| either synchronously or asynchronously with the
        /// selected command ID. For default display return false (0). Do not keep
        /// references to |Params| or |Model| outside of this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public class CfxRunContextMenuEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_params;
            internal CfxContextMenuParams m_params_wrapped;
            internal IntPtr m_model;
            internal CfxMenuModel m_model_wrapped;
            internal IntPtr m_callback;
            internal CfxRunContextMenuCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxRunContextMenuEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Params parameter for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
            /// </summary>
            public CfxContextMenuParams Params {
                get {
                    CheckAccess();
                    if(m_params_wrapped == null) m_params_wrapped = CfxContextMenuParams.Wrap(m_params);
                    return m_params_wrapped;
                }
            }
            /// <summary>
            /// Get the Model parameter for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
            /// </summary>
            public CfxMenuModel Model {
                get {
                    CheckAccess();
                    if(m_model_wrapped == null) m_model_wrapped = CfxMenuModel.Wrap(m_model);
                    return m_model_wrapped;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
            /// </summary>
            public CfxRunContextMenuCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxRunContextMenuCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxContextMenuHandler.RunContextMenu"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Params={{{2}}}, Model={{{3}}}, Callback={{{4}}}", Browser, Frame, Params, Model, Callback);
            }
        }

        /// <summary>
        /// Called to execute a command selected from the context menu. Return true (1)
        /// if the command was handled or false (0) for the default implementation. See
        /// CfxMenuId for the command ids that have default implementations. All
        /// user-defined command ids should be between MENU_ID_USER_FIRST and
        /// MENU_ID_USER_LAST. |Params| will have the same values as what was passed to
        /// on_before_context_menu(). Do not keep a reference to |Params| outside of
        /// this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnContextMenuCommandEventHandler(object sender, CfxOnContextMenuCommandEventArgs e);

        /// <summary>
        /// Called to execute a command selected from the context menu. Return true (1)
        /// if the command was handled or false (0) for the default implementation. See
        /// CfxMenuId for the command ids that have default implementations. All
        /// user-defined command ids should be between MENU_ID_USER_FIRST and
        /// MENU_ID_USER_LAST. |Params| will have the same values as what was passed to
        /// on_before_context_menu(). Do not keep a reference to |Params| outside of
        /// this callback.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnContextMenuCommandEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_params;
            internal CfxContextMenuParams m_params_wrapped;
            internal int m_command_id;
            internal int m_event_flags;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnContextMenuCommandEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Params parameter for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
            /// </summary>
            public CfxContextMenuParams Params {
                get {
                    CheckAccess();
                    if(m_params_wrapped == null) m_params_wrapped = CfxContextMenuParams.Wrap(m_params);
                    return m_params_wrapped;
                }
            }
            /// <summary>
            /// Get the CommandId parameter for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
            /// </summary>
            public int CommandId {
                get {
                    CheckAccess();
                    return m_command_id;
                }
            }
            /// <summary>
            /// Get the EventFlags parameter for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
            /// </summary>
            public CfxEventFlags EventFlags {
                get {
                    CheckAccess();
                    return (CfxEventFlags)m_event_flags;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxContextMenuHandler.OnContextMenuCommand"/> callback.
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
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Params={{{2}}}, CommandId={{{3}}}, EventFlags={{{4}}}", Browser, Frame, Params, CommandId, EventFlags);
            }
        }

        /// <summary>
        /// Called when the context menu is dismissed irregardless of whether the menu
        /// was NULL or a command was selected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnContextMenuDismissedEventHandler(object sender, CfxOnContextMenuDismissedEventArgs e);

        /// <summary>
        /// Called when the context menu is dismissed irregardless of whether the menu
        /// was NULL or a command was selected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnContextMenuDismissedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;

            internal CfxOnContextMenuDismissedEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxContextMenuHandler.OnContextMenuDismissed"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxContextMenuHandler.OnContextMenuDismissed"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}", Browser, Frame);
            }
        }

    }
}
