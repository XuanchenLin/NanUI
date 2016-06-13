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
	/// Implement this structure to handle events related to JavaScript dialogs. The
	/// functions of this structure will be called on the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
	/// </remarks>
	public class CfxJsDialogHandler : CfxBase {

        static CfxJsDialogHandler () {
            CfxApiLoader.LoadCfxJsDialogHandlerApi();
        }

        internal static CfxJsDialogHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_jsdialog_handler_get_gc_handle(nativePtr);
            return (CfxJsDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // on_jsdialog
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_jsdialog_handler_on_jsdialog_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr origin_url_str, int origin_url_length, IntPtr accept_lang_str, int accept_lang_length, int dialog_type, IntPtr message_text_str, int message_text_length, IntPtr default_prompt_text_str, int default_prompt_text_length, IntPtr callback, out int suppress_message);
        private static cfx_jsdialog_handler_on_jsdialog_delegate cfx_jsdialog_handler_on_jsdialog;
        private static IntPtr cfx_jsdialog_handler_on_jsdialog_ptr;

        internal static void on_jsdialog(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr origin_url_str, int origin_url_length, IntPtr accept_lang_str, int accept_lang_length, int dialog_type, IntPtr message_text_str, int message_text_length, IntPtr default_prompt_text_str, int default_prompt_text_length, IntPtr callback, out int suppress_message) {
            var self = (CfxJsDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                suppress_message = default(int);
                return;
            }
            var e = new CfxOnJsDialogEventArgs(browser, origin_url_str, origin_url_length, accept_lang_str, accept_lang_length, dialog_type, message_text_str, message_text_length, default_prompt_text_str, default_prompt_text_length, callback);
            var eventHandler = self.m_OnJsDialog;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
            suppress_message = e.m_suppress_message;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_before_unload_dialog
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_jsdialog_handler_on_before_unload_dialog_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr message_text_str, int message_text_length, int is_reload, IntPtr callback);
        private static cfx_jsdialog_handler_on_before_unload_dialog_delegate cfx_jsdialog_handler_on_before_unload_dialog;
        private static IntPtr cfx_jsdialog_handler_on_before_unload_dialog_ptr;

        internal static void on_before_unload_dialog(IntPtr gcHandlePtr, out int __retval, IntPtr browser, IntPtr message_text_str, int message_text_length, int is_reload, IntPtr callback) {
            var self = (CfxJsDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnBeforeUnloadDialogEventArgs(browser, message_text_str, message_text_length, is_reload, callback);
            var eventHandler = self.m_OnBeforeUnloadDialog;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
            if(e.m_callback_wrapped == null) CfxApi.cfx_release(e.m_callback);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_reset_dialog_state
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_jsdialog_handler_on_reset_dialog_state_delegate(IntPtr gcHandlePtr, IntPtr browser);
        private static cfx_jsdialog_handler_on_reset_dialog_state_delegate cfx_jsdialog_handler_on_reset_dialog_state;
        private static IntPtr cfx_jsdialog_handler_on_reset_dialog_state_ptr;

        internal static void on_reset_dialog_state(IntPtr gcHandlePtr, IntPtr browser) {
            var self = (CfxJsDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnResetDialogStateEventArgs(browser);
            var eventHandler = self.m_OnResetDialogState;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        // on_dialog_closed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_jsdialog_handler_on_dialog_closed_delegate(IntPtr gcHandlePtr, IntPtr browser);
        private static cfx_jsdialog_handler_on_dialog_closed_delegate cfx_jsdialog_handler_on_dialog_closed;
        private static IntPtr cfx_jsdialog_handler_on_dialog_closed_ptr;

        internal static void on_dialog_closed(IntPtr gcHandlePtr, IntPtr browser) {
            var self = (CfxJsDialogHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                return;
            }
            var e = new CfxOnDialogClosedEventArgs(browser);
            var eventHandler = self.m_OnDialogClosed;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_browser_wrapped == null) CfxApi.cfx_release(e.m_browser);
        }

        internal CfxJsDialogHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxJsDialogHandler() : base(CfxApi.cfx_jsdialog_handler_ctor) {}

        /// <summary>
        /// Called to run a JavaScript dialog. If |OriginUrl| and |AcceptLang| are
        /// non-NULL they can be passed to the CfxFormatUrlForSecurityDisplay function
        /// to retrieve a secure and user-friendly display string. The
        /// |DefaultPromptText| value will be specified for prompt dialogs only. Set
        /// |SuppressMessage| to true (1) and return false (0) to suppress the message
        /// (suppressing messages is preferable to immediately executing the callback
        /// as this is used to detect presumably malicious behavior like spamming alert
        /// messages in onbeforeunload). Set |SuppressMessage| to false (0) and return
        /// false (0) to use the default implementation (the default implementation
        /// will show one modal dialog at a time and suppress any additional dialog
        /// requests until the displayed dialog is dismissed). Return true (1) if the
        /// application will use a custom dialog or if the callback has been executed
        /// immediately. Custom dialogs may be either modal or modeless. If a custom
        /// dialog is used the application must execute |Callback| once the custom
        /// dialog is dismissed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnJsDialogEventHandler OnJsDialog {
            add {
                lock(eventLock) {
                    if(m_OnJsDialog == null) {
                        if(cfx_jsdialog_handler_on_jsdialog == null) {
                            cfx_jsdialog_handler_on_jsdialog = on_jsdialog;
                            cfx_jsdialog_handler_on_jsdialog_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_jsdialog_handler_on_jsdialog);
                        }
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 0, cfx_jsdialog_handler_on_jsdialog_ptr);
                    }
                    m_OnJsDialog += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnJsDialog -= value;
                    if(m_OnJsDialog == null) {
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnJsDialogEventHandler m_OnJsDialog;

        /// <summary>
        /// Called to run a dialog asking the user if they want to leave a page. Return
        /// false (0) to use the default dialog implementation. Return true (1) if the
        /// application will use a custom dialog or if the callback has been executed
        /// immediately. Custom dialogs may be either modal or modeless. If a custom
        /// dialog is used the application must execute |Callback| once the custom
        /// dialog is dismissed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeUnloadDialogEventHandler OnBeforeUnloadDialog {
            add {
                lock(eventLock) {
                    if(m_OnBeforeUnloadDialog == null) {
                        if(cfx_jsdialog_handler_on_before_unload_dialog == null) {
                            cfx_jsdialog_handler_on_before_unload_dialog = on_before_unload_dialog;
                            cfx_jsdialog_handler_on_before_unload_dialog_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_jsdialog_handler_on_before_unload_dialog);
                        }
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 1, cfx_jsdialog_handler_on_before_unload_dialog_ptr);
                    }
                    m_OnBeforeUnloadDialog += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeUnloadDialog -= value;
                    if(m_OnBeforeUnloadDialog == null) {
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeUnloadDialogEventHandler m_OnBeforeUnloadDialog;

        /// <summary>
        /// Called to cancel any pending dialogs and reset any saved dialog state. Will
        /// be called due to events like page navigation irregardless of whether any
        /// dialogs are currently pending.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnResetDialogStateEventHandler OnResetDialogState {
            add {
                lock(eventLock) {
                    if(m_OnResetDialogState == null) {
                        if(cfx_jsdialog_handler_on_reset_dialog_state == null) {
                            cfx_jsdialog_handler_on_reset_dialog_state = on_reset_dialog_state;
                            cfx_jsdialog_handler_on_reset_dialog_state_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_jsdialog_handler_on_reset_dialog_state);
                        }
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 2, cfx_jsdialog_handler_on_reset_dialog_state_ptr);
                    }
                    m_OnResetDialogState += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnResetDialogState -= value;
                    if(m_OnResetDialogState == null) {
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnResetDialogStateEventHandler m_OnResetDialogState;

        /// <summary>
        /// Called when the default implementation dialog is closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnDialogClosedEventHandler OnDialogClosed {
            add {
                lock(eventLock) {
                    if(m_OnDialogClosed == null) {
                        if(cfx_jsdialog_handler_on_dialog_closed == null) {
                            cfx_jsdialog_handler_on_dialog_closed = on_dialog_closed;
                            cfx_jsdialog_handler_on_dialog_closed_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_jsdialog_handler_on_dialog_closed);
                        }
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 3, cfx_jsdialog_handler_on_dialog_closed_ptr);
                    }
                    m_OnDialogClosed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnDialogClosed -= value;
                    if(m_OnDialogClosed == null) {
                        CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnDialogClosedEventHandler m_OnDialogClosed;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnJsDialog != null) {
                m_OnJsDialog = null;
                CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforeUnloadDialog != null) {
                m_OnBeforeUnloadDialog = null;
                CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnResetDialogState != null) {
                m_OnResetDialogState = null;
                CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnDialogClosed != null) {
                m_OnDialogClosed = null;
                CfxApi.cfx_jsdialog_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Called to run a JavaScript dialog. If |OriginUrl| and |AcceptLang| are
		/// non-NULL they can be passed to the CfxFormatUrlForSecurityDisplay function
		/// to retrieve a secure and user-friendly display string. The
		/// |DefaultPromptText| value will be specified for prompt dialogs only. Set
		/// |SuppressMessage| to true (1) and return false (0) to suppress the message
		/// (suppressing messages is preferable to immediately executing the callback
		/// as this is used to detect presumably malicious behavior like spamming alert
		/// messages in onbeforeunload). Set |SuppressMessage| to false (0) and return
		/// false (0) to use the default implementation (the default implementation
		/// will show one modal dialog at a time and suppress any additional dialog
		/// requests until the displayed dialog is dismissed). Return true (1) if the
		/// application will use a custom dialog or if the callback has been executed
		/// immediately. Custom dialogs may be either modal or modeless. If a custom
		/// dialog is used the application must execute |Callback| once the custom
		/// dialog is dismissed.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
		/// </remarks>
		public delegate void CfxOnJsDialogEventHandler(object sender, CfxOnJsDialogEventArgs e);

        /// <summary>
        /// Called to run a JavaScript dialog. If |OriginUrl| and |AcceptLang| are
        /// non-NULL they can be passed to the CfxFormatUrlForSecurityDisplay function
        /// to retrieve a secure and user-friendly display string. The
        /// |DefaultPromptText| value will be specified for prompt dialogs only. Set
        /// |SuppressMessage| to true (1) and return false (0) to suppress the message
        /// (suppressing messages is preferable to immediately executing the callback
        /// as this is used to detect presumably malicious behavior like spamming alert
        /// messages in onbeforeunload). Set |SuppressMessage| to false (0) and return
        /// false (0) to use the default implementation (the default implementation
        /// will show one modal dialog at a time and suppress any additional dialog
        /// requests until the displayed dialog is dismissed). Return true (1) if the
        /// application will use a custom dialog or if the callback has been executed
        /// immediately. Custom dialogs may be either modal or modeless. If a custom
        /// dialog is used the application must execute |Callback| once the custom
        /// dialog is dismissed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnJsDialogEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_origin_url_str;
            internal int m_origin_url_length;
            internal string m_origin_url;
            internal IntPtr m_accept_lang_str;
            internal int m_accept_lang_length;
            internal string m_accept_lang;
            internal int m_dialog_type;
            internal IntPtr m_message_text_str;
            internal int m_message_text_length;
            internal string m_message_text;
            internal IntPtr m_default_prompt_text_str;
            internal int m_default_prompt_text_length;
            internal string m_default_prompt_text;
            internal IntPtr m_callback;
            internal CfxJsDialogCallback m_callback_wrapped;
            internal int m_suppress_message;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnJsDialogEventArgs(IntPtr browser, IntPtr origin_url_str, int origin_url_length, IntPtr accept_lang_str, int accept_lang_length, int dialog_type, IntPtr message_text_str, int message_text_length, IntPtr default_prompt_text_str, int default_prompt_text_length, IntPtr callback) {
                m_browser = browser;
                m_origin_url_str = origin_url_str;
                m_origin_url_length = origin_url_length;
                m_accept_lang_str = accept_lang_str;
                m_accept_lang_length = accept_lang_length;
                m_dialog_type = dialog_type;
                m_message_text_str = message_text_str;
                m_message_text_length = message_text_length;
                m_default_prompt_text_str = default_prompt_text_str;
                m_default_prompt_text_length = default_prompt_text_length;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the OriginUrl parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public string OriginUrl {
                get {
                    CheckAccess();
                    m_origin_url = StringFunctions.PtrToStringUni(m_origin_url_str, m_origin_url_length);
                    return m_origin_url;
                }
            }
            /// <summary>
            /// Get the AcceptLang parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public string AcceptLang {
                get {
                    CheckAccess();
                    m_accept_lang = StringFunctions.PtrToStringUni(m_accept_lang_str, m_accept_lang_length);
                    return m_accept_lang;
                }
            }
            /// <summary>
            /// Get the DialogType parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public CfxJsDialogType DialogType {
                get {
                    CheckAccess();
                    return (CfxJsDialogType)m_dialog_type;
                }
            }
            /// <summary>
            /// Get the MessageText parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public string MessageText {
                get {
                    CheckAccess();
                    m_message_text = StringFunctions.PtrToStringUni(m_message_text_str, m_message_text_length);
                    return m_message_text;
                }
            }
            /// <summary>
            /// Get the DefaultPromptText parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public string DefaultPromptText {
                get {
                    CheckAccess();
                    m_default_prompt_text = StringFunctions.PtrToStringUni(m_default_prompt_text_str, m_default_prompt_text_length);
                    return m_default_prompt_text;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public CfxJsDialogCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxJsDialogCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the SuppressMessage out parameter for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
            /// </summary>
            public bool SuppressMessage {
                set {
                    CheckAccess();
                    m_suppress_message = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxJsDialogHandler.OnJsDialog"/> callback.
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
                return String.Format("Browser={{{0}}}, OriginUrl={{{1}}}, AcceptLang={{{2}}}, DialogType={{{3}}}, MessageText={{{4}}}, DefaultPromptText={{{5}}}, Callback={{{6}}}", Browser, OriginUrl, AcceptLang, DialogType, MessageText, DefaultPromptText, Callback);
            }
        }

        /// <summary>
        /// Called to run a dialog asking the user if they want to leave a page. Return
        /// false (0) to use the default dialog implementation. Return true (1) if the
        /// application will use a custom dialog or if the callback has been executed
        /// immediately. Custom dialogs may be either modal or modeless. If a custom
        /// dialog is used the application must execute |Callback| once the custom
        /// dialog is dismissed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeUnloadDialogEventHandler(object sender, CfxOnBeforeUnloadDialogEventArgs e);

        /// <summary>
        /// Called to run a dialog asking the user if they want to leave a page. Return
        /// false (0) to use the default dialog implementation. Return true (1) if the
        /// application will use a custom dialog or if the callback has been executed
        /// immediately. Custom dialogs may be either modal or modeless. If a custom
        /// dialog is used the application must execute |Callback| once the custom
        /// dialog is dismissed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeUnloadDialogEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_message_text_str;
            internal int m_message_text_length;
            internal string m_message_text;
            internal int m_is_reload;
            internal IntPtr m_callback;
            internal CfxJsDialogCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeUnloadDialogEventArgs(IntPtr browser, IntPtr message_text_str, int message_text_length, int is_reload, IntPtr callback) {
                m_browser = browser;
                m_message_text_str = message_text_str;
                m_message_text_length = message_text_length;
                m_is_reload = is_reload;
                m_callback = callback;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxJsDialogHandler.OnBeforeUnloadDialog"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the MessageText parameter for the <see cref="CfxJsDialogHandler.OnBeforeUnloadDialog"/> callback.
            /// </summary>
            public string MessageText {
                get {
                    CheckAccess();
                    m_message_text = StringFunctions.PtrToStringUni(m_message_text_str, m_message_text_length);
                    return m_message_text;
                }
            }
            /// <summary>
            /// Get the IsReload parameter for the <see cref="CfxJsDialogHandler.OnBeforeUnloadDialog"/> callback.
            /// </summary>
            public bool IsReload {
                get {
                    CheckAccess();
                    return 0 != m_is_reload;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxJsDialogHandler.OnBeforeUnloadDialog"/> callback.
            /// </summary>
            public CfxJsDialogCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxJsDialogCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxJsDialogHandler.OnBeforeUnloadDialog"/> callback.
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
                return String.Format("Browser={{{0}}}, MessageText={{{1}}}, IsReload={{{2}}}, Callback={{{3}}}", Browser, MessageText, IsReload, Callback);
            }
        }

        /// <summary>
        /// Called to cancel any pending dialogs and reset any saved dialog state. Will
        /// be called due to events like page navigation irregardless of whether any
        /// dialogs are currently pending.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnResetDialogStateEventHandler(object sender, CfxOnResetDialogStateEventArgs e);

        /// <summary>
        /// Called to cancel any pending dialogs and reset any saved dialog state. Will
        /// be called due to events like page navigation irregardless of whether any
        /// dialogs are currently pending.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnResetDialogStateEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnResetDialogStateEventArgs(IntPtr browser) {
                m_browser = browser;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxJsDialogHandler.OnResetDialogState"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

        /// <summary>
        /// Called when the default implementation dialog is closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnDialogClosedEventHandler(object sender, CfxOnDialogClosedEventArgs e);

        /// <summary>
        /// Called when the default implementation dialog is closed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_jsdialog_handler_capi.h">cef/include/capi/cef_jsdialog_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnDialogClosedEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;

            internal CfxOnDialogClosedEventArgs(IntPtr browser) {
                m_browser = browser;
            }

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxJsDialogHandler.OnDialogClosed"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}", Browser);
            }
        }

    }
}
