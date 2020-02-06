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
    /// Implement this structure to handle menu model events. The functions of this
    /// structure will be called on the browser process UI thread unless otherwise
    /// indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
    /// </remarks>
    public class CfxMenuModelDelegate : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            execute_command_native = execute_command;
            mouse_outside_menu_native = mouse_outside_menu;
            unhandled_open_submenu_native = unhandled_open_submenu;
            unhandled_close_submenu_native = unhandled_close_submenu;
            menu_will_show_native = menu_will_show;
            menu_closed_native = menu_closed;
            format_label_native = format_label;

            execute_command_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(execute_command_native);
            mouse_outside_menu_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(mouse_outside_menu_native);
            unhandled_open_submenu_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(unhandled_open_submenu_native);
            unhandled_close_submenu_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(unhandled_close_submenu_native);
            menu_will_show_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(menu_will_show_native);
            menu_closed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(menu_closed_native);
            format_label_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(format_label_native);
        }

        // execute_command
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void execute_command_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int command_id, int event_flags);
        private static execute_command_delegate execute_command_native;
        private static IntPtr execute_command_native_ptr;

        internal static void execute_command(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int command_id, int event_flags) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxExecuteCommandEventArgs();
            e.m_menu_model = menu_model;
            e.m_command_id = command_id;
            e.m_event_flags = event_flags;
            self.m_ExecuteCommand?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // mouse_outside_menu
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void mouse_outside_menu_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, IntPtr screen_point);
        private static mouse_outside_menu_delegate mouse_outside_menu_native;
        private static IntPtr mouse_outside_menu_native_ptr;

        internal static void mouse_outside_menu(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, IntPtr screen_point) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxMouseOutsideMenuEventArgs();
            e.m_menu_model = menu_model;
            e.m_screen_point = screen_point;
            self.m_MouseOutsideMenu?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // unhandled_open_submenu
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void unhandled_open_submenu_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int is_rtl);
        private static unhandled_open_submenu_delegate unhandled_open_submenu_native;
        private static IntPtr unhandled_open_submenu_native_ptr;

        internal static void unhandled_open_submenu(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int is_rtl) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxUnhandledOpenSubmenuEventArgs();
            e.m_menu_model = menu_model;
            e.m_is_rtl = is_rtl;
            self.m_UnhandledOpenSubmenu?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // unhandled_close_submenu
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void unhandled_close_submenu_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int is_rtl);
        private static unhandled_close_submenu_delegate unhandled_close_submenu_native;
        private static IntPtr unhandled_close_submenu_native_ptr;

        internal static void unhandled_close_submenu(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release, int is_rtl) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxUnhandledCloseSubmenuEventArgs();
            e.m_menu_model = menu_model;
            e.m_is_rtl = is_rtl;
            self.m_UnhandledCloseSubmenu?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // menu_will_show
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void menu_will_show_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release);
        private static menu_will_show_delegate menu_will_show_native;
        private static IntPtr menu_will_show_native_ptr;

        internal static void menu_will_show(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxMenuWillShowEventArgs();
            e.m_menu_model = menu_model;
            self.m_MenuWillShow?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // menu_closed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void menu_closed_delegate(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release);
        private static menu_closed_delegate menu_closed_native;
        private static IntPtr menu_closed_native_ptr;

        internal static void menu_closed(IntPtr gcHandlePtr, IntPtr menu_model, out int menu_model_release) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                menu_model_release = 1;
                return;
            }
            var e = new CfxMenuClosedEventArgs();
            e.m_menu_model = menu_model;
            self.m_MenuClosed?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
        }

        // format_label
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void format_label_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr menu_model, out int menu_model_release, ref IntPtr label_str, ref int label_length);
        private static format_label_delegate format_label_native;
        private static IntPtr format_label_native_ptr;

        internal static void format_label(IntPtr gcHandlePtr, out int __retval, IntPtr menu_model, out int menu_model_release, ref IntPtr label_str, ref int label_length) {
            var self = (CfxMenuModelDelegate)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                menu_model_release = 1;
                return;
            }
            var e = new CfxFormatLabelEventArgs();
            e.m_menu_model = menu_model;
            e.m_label_str = label_str;
            e.m_label_length = label_length;
            self.m_FormatLabel?.Invoke(self, e);
            e.m_isInvalid = true;
            menu_model_release = e.m_menu_model_wrapped == null? 1 : 0;
            if(e.m_label_changed) {
                var label_pinned = new PinnedString(e.m_label_wrapped);
                label_str = label_pinned.Obj.PinnedPtr;
                label_length = label_pinned.Length;
            }
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxMenuModelDelegate() : base(CfxApi.MenuModelDelegate.cfx_menu_model_delegate_ctor) {}

        /// <summary>
        /// Perform the action associated with the specified |CommandId| and optional
        /// |EventFlags|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxExecuteCommandEventHandler ExecuteCommand {
            add {
                lock(eventLock) {
                    if(m_ExecuteCommand == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 0, execute_command_native_ptr);
                    }
                    m_ExecuteCommand += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_ExecuteCommand -= value;
                    if(m_ExecuteCommand == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxExecuteCommandEventHandler m_ExecuteCommand;

        /// <summary>
        /// Called when the user moves the mouse outside the menu and over the owning
        /// window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxMouseOutsideMenuEventHandler MouseOutsideMenu {
            add {
                lock(eventLock) {
                    if(m_MouseOutsideMenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 1, mouse_outside_menu_native_ptr);
                    }
                    m_MouseOutsideMenu += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_MouseOutsideMenu -= value;
                    if(m_MouseOutsideMenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxMouseOutsideMenuEventHandler m_MouseOutsideMenu;

        /// <summary>
        /// Called on unhandled open submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxUnhandledOpenSubmenuEventHandler UnhandledOpenSubmenu {
            add {
                lock(eventLock) {
                    if(m_UnhandledOpenSubmenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 2, unhandled_open_submenu_native_ptr);
                    }
                    m_UnhandledOpenSubmenu += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_UnhandledOpenSubmenu -= value;
                    if(m_UnhandledOpenSubmenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxUnhandledOpenSubmenuEventHandler m_UnhandledOpenSubmenu;

        /// <summary>
        /// Called on unhandled close submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxUnhandledCloseSubmenuEventHandler UnhandledCloseSubmenu {
            add {
                lock(eventLock) {
                    if(m_UnhandledCloseSubmenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 3, unhandled_close_submenu_native_ptr);
                    }
                    m_UnhandledCloseSubmenu += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_UnhandledCloseSubmenu -= value;
                    if(m_UnhandledCloseSubmenu == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxUnhandledCloseSubmenuEventHandler m_UnhandledCloseSubmenu;

        /// <summary>
        /// The menu is about to show.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxMenuWillShowEventHandler MenuWillShow {
            add {
                lock(eventLock) {
                    if(m_MenuWillShow == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 4, menu_will_show_native_ptr);
                    }
                    m_MenuWillShow += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_MenuWillShow -= value;
                    if(m_MenuWillShow == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxMenuWillShowEventHandler m_MenuWillShow;

        /// <summary>
        /// The menu has closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxMenuClosedEventHandler MenuClosed {
            add {
                lock(eventLock) {
                    if(m_MenuClosed == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 5, menu_closed_native_ptr);
                    }
                    m_MenuClosed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_MenuClosed -= value;
                    if(m_MenuClosed == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxMenuClosedEventHandler m_MenuClosed;

        /// <summary>
        /// Optionally modify a menu item label. Return true (1) if |Label| was
        /// modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public event CfxFormatLabelEventHandler FormatLabel {
            add {
                lock(eventLock) {
                    if(m_FormatLabel == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 6, format_label_native_ptr);
                    }
                    m_FormatLabel += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_FormatLabel -= value;
                    if(m_FormatLabel == null) {
                        CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxFormatLabelEventHandler m_FormatLabel;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_ExecuteCommand != null) {
                m_ExecuteCommand = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_MouseOutsideMenu != null) {
                m_MouseOutsideMenu = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_UnhandledOpenSubmenu != null) {
                m_UnhandledOpenSubmenu = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_UnhandledCloseSubmenu != null) {
                m_UnhandledCloseSubmenu = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_MenuWillShow != null) {
                m_MenuWillShow = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_MenuClosed != null) {
                m_MenuClosed = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_FormatLabel != null) {
                m_FormatLabel = null;
                CfxApi.MenuModelDelegate.cfx_menu_model_delegate_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Perform the action associated with the specified |CommandId| and optional
        /// |EventFlags|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxExecuteCommandEventHandler(object sender, CfxExecuteCommandEventArgs e);

        /// <summary>
        /// Perform the action associated with the specified |CommandId| and optional
        /// |EventFlags|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxExecuteCommandEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;
            internal int m_command_id;
            internal int m_event_flags;

            internal CfxExecuteCommandEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.ExecuteCommand"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }
            /// <summary>
            /// Get the CommandId parameter for the <see cref="CfxMenuModelDelegate.ExecuteCommand"/> callback.
            /// </summary>
            public int CommandId {
                get {
                    CheckAccess();
                    return m_command_id;
                }
            }
            /// <summary>
            /// Get the EventFlags parameter for the <see cref="CfxMenuModelDelegate.ExecuteCommand"/> callback.
            /// </summary>
            public CfxEventFlags EventFlags {
                get {
                    CheckAccess();
                    return (CfxEventFlags)m_event_flags;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}, CommandId={{{1}}}, EventFlags={{{2}}}", MenuModel, CommandId, EventFlags);
            }
        }

        /// <summary>
        /// Called when the user moves the mouse outside the menu and over the owning
        /// window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxMouseOutsideMenuEventHandler(object sender, CfxMouseOutsideMenuEventArgs e);

        /// <summary>
        /// Called when the user moves the mouse outside the menu and over the owning
        /// window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxMouseOutsideMenuEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;
            internal IntPtr m_screen_point;
            internal CfxPoint m_screen_point_wrapped;

            internal CfxMouseOutsideMenuEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.MouseOutsideMenu"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }
            /// <summary>
            /// Get the ScreenPoint parameter for the <see cref="CfxMenuModelDelegate.MouseOutsideMenu"/> callback.
            /// </summary>
            public CfxPoint ScreenPoint {
                get {
                    CheckAccess();
                    if(m_screen_point_wrapped == null) m_screen_point_wrapped = CfxPoint.Wrap(m_screen_point);
                    return m_screen_point_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}, ScreenPoint={{{1}}}", MenuModel, ScreenPoint);
            }
        }

        /// <summary>
        /// Called on unhandled open submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxUnhandledOpenSubmenuEventHandler(object sender, CfxUnhandledOpenSubmenuEventArgs e);

        /// <summary>
        /// Called on unhandled open submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxUnhandledOpenSubmenuEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;
            internal int m_is_rtl;

            internal CfxUnhandledOpenSubmenuEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.UnhandledOpenSubmenu"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }
            /// <summary>
            /// Get the IsRtl parameter for the <see cref="CfxMenuModelDelegate.UnhandledOpenSubmenu"/> callback.
            /// </summary>
            public bool IsRtl {
                get {
                    CheckAccess();
                    return 0 != m_is_rtl;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}, IsRtl={{{1}}}", MenuModel, IsRtl);
            }
        }

        /// <summary>
        /// Called on unhandled close submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxUnhandledCloseSubmenuEventHandler(object sender, CfxUnhandledCloseSubmenuEventArgs e);

        /// <summary>
        /// Called on unhandled close submenu keyboard commands. |IsRtl| will be true
        /// (1) if the menu is displaying a right-to-left language.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxUnhandledCloseSubmenuEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;
            internal int m_is_rtl;

            internal CfxUnhandledCloseSubmenuEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.UnhandledCloseSubmenu"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }
            /// <summary>
            /// Get the IsRtl parameter for the <see cref="CfxMenuModelDelegate.UnhandledCloseSubmenu"/> callback.
            /// </summary>
            public bool IsRtl {
                get {
                    CheckAccess();
                    return 0 != m_is_rtl;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}, IsRtl={{{1}}}", MenuModel, IsRtl);
            }
        }

        /// <summary>
        /// The menu is about to show.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxMenuWillShowEventHandler(object sender, CfxMenuWillShowEventArgs e);

        /// <summary>
        /// The menu is about to show.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxMenuWillShowEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;

            internal CfxMenuWillShowEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.MenuWillShow"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}", MenuModel);
            }
        }

        /// <summary>
        /// The menu has closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxMenuClosedEventHandler(object sender, CfxMenuClosedEventArgs e);

        /// <summary>
        /// The menu has closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxMenuClosedEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;

            internal CfxMenuClosedEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.MenuClosed"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("MenuModel={{{0}}}", MenuModel);
            }
        }

        /// <summary>
        /// Optionally modify a menu item label. Return true (1) if |Label| was
        /// modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public delegate void CfxFormatLabelEventHandler(object sender, CfxFormatLabelEventArgs e);

        /// <summary>
        /// Optionally modify a menu item label. Return true (1) if |Label| was
        /// modified.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_menu_model_delegate_capi.h">cef/include/capi/cef_menu_model_delegate_capi.h</see>.
        /// </remarks>
        public class CfxFormatLabelEventArgs : CfxEventArgs {

            internal IntPtr m_menu_model;
            internal CfxMenuModel m_menu_model_wrapped;
            internal IntPtr m_label_str;
            internal int m_label_length;
            internal string m_label_wrapped;
            internal bool m_label_changed;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxFormatLabelEventArgs() {}

            /// <summary>
            /// Get the MenuModel parameter for the <see cref="CfxMenuModelDelegate.FormatLabel"/> callback.
            /// </summary>
            public CfxMenuModel MenuModel {
                get {
                    CheckAccess();
                    if(m_menu_model_wrapped == null) m_menu_model_wrapped = CfxMenuModel.Wrap(m_menu_model);
                    return m_menu_model_wrapped;
                }
            }
            /// <summary>
            /// Get or set the Label parameter for the <see cref="CfxMenuModelDelegate.FormatLabel"/> callback.
            /// </summary>
            public string Label {
                get {
                    CheckAccess();
                    if(!m_label_changed && m_label_wrapped == null) {
                        m_label_wrapped = StringFunctions.PtrToStringUni(m_label_str, m_label_length);
                    }
                    return m_label_wrapped;
                }
                set {
                    CheckAccess();
                    m_label_wrapped = value;
                    m_label_changed = true;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxMenuModelDelegate.FormatLabel"/> callback.
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
                return String.Format("MenuModel={{{0}}}, Label={{{1}}}", MenuModel, Label);
            }
        }

    }
}
