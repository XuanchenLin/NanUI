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
    /// Implement this structure to provide handler implementations. The handler
    /// instance will not be released until all objects related to the context have
    /// been destroyed.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
    /// </remarks>
    public class CfxRequestContextHandler : CfxBaseClient {

        internal static CfxRequestContextHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.RequestContextHandler.cfx_request_context_handler_get_gc_handle(nativePtr);
            return (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            get_cookie_manager_native = get_cookie_manager;
            on_before_plugin_load_native = on_before_plugin_load;

            get_cookie_manager_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_cookie_manager_native);
            on_before_plugin_load_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_plugin_load_native);
        }

        // get_cookie_manager
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_cookie_manager_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static get_cookie_manager_delegate get_cookie_manager_native;
        private static IntPtr get_cookie_manager_native_ptr;

        internal static void get_cookie_manager(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetCookieManagerEventArgs();
            self.m_GetCookieManager?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = CfxCookieManager.Unwrap(e.m_returnValue);
        }

        // on_before_plugin_load
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_plugin_load_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, int is_main_frame, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, out int plugin_info_release, ref int plugin_policy);
        private static on_before_plugin_load_delegate on_before_plugin_load_native;
        private static IntPtr on_before_plugin_load_native_ptr;

        internal static void on_before_plugin_load(IntPtr gcHandlePtr, out int __retval, IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, int is_main_frame, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, out int plugin_info_release, ref int plugin_policy) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                plugin_info_release = 1;
                return;
            }
            var e = new CfxOnBeforePluginLoadEventArgs(mime_type_str, mime_type_length, plugin_url_str, plugin_url_length, is_main_frame, top_origin_url_str, top_origin_url_length, plugin_info, plugin_policy);
            self.m_OnBeforePluginLoad?.Invoke(self, e);
            e.m_isInvalid = true;
            plugin_info_release = e.m_plugin_info_wrapped == null? 1 : 0;
            plugin_policy = e.m_plugin_policy;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxRequestContextHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRequestContextHandler() : base(CfxApi.RequestContextHandler.cfx_request_context_handler_ctor) {}

        /// <summary>
        /// Called on the browser process IO thread to retrieve the cookie manager. If
        /// this function returns NULL the default cookie manager retrievable via
        /// CfxRequestContext.GetDefaultCookieManager() will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetCookieManagerEventHandler GetCookieManager {
            add {
                lock(eventLock) {
                    if(m_GetCookieManager != null) {
                        throw new CfxException("Can't add more than one event handler to this type of event.");
                    }
                    CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, get_cookie_manager_native_ptr);
                    m_GetCookieManager += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetCookieManager -= value;
                    if(m_GetCookieManager == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the CfxCookieManager provided by the event handler attached to the GetCookieManager event, if any.
        /// Returns null if no event handler is attached.
        /// </summary>
        public CfxCookieManager RetrieveCookieManager() {
            var h = m_GetCookieManager;
            if(h != null) {
                var e = new CfxGetCookieManagerEventArgs();
                h(this, e);
                return e.m_returnValue;
            } else {
                return null;
            }
        }

        private CfxGetCookieManagerEventHandler m_GetCookieManager;

        /// <summary>
        /// Called on multiple browser process threads before a plugin instance is
        /// loaded. |MimeType| is the mime type of the plugin that will be loaded.
        /// |PluginUrl| is the content URL that the plugin will load and may be NULL.
        /// |IsMainFrame| will be true (1) if the plugin is being loaded in the main
        /// (top-level) frame, |TopOriginUrl| is the URL for the top-level frame that
        /// contains the plugin when loading a specific plugin instance or NULL when
        /// building the initial list of enabled plugins for 'navigator.plugins'
        /// JavaScript state. |PluginInfo| includes additional information about the
        /// plugin that will be loaded. |PluginPolicy| is the recommended policy.
        /// Modify |PluginPolicy| and return true (1) to change the policy. Return
        /// false (0) to use the recommended policy. The default plugin policy can be
        /// set at runtime using the `--plugin-policy=[allow|Detect|block]` command-
        /// line flag. Decisions to mark a plugin as disabled by setting
        /// |PluginPolicy| to PLUGIN_POLICY_DISABLED may be cached when
        /// |TopOriginUrl| is NULL. To purge the plugin list cache and potentially
        /// trigger new calls to this function call
        /// CfxRequestContext.PurgePluginListCache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforePluginLoadEventHandler OnBeforePluginLoad {
            add {
                lock(eventLock) {
                    if(m_OnBeforePluginLoad == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 1, on_before_plugin_load_native_ptr);
                    }
                    m_OnBeforePluginLoad += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforePluginLoad -= value;
                    if(m_OnBeforePluginLoad == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforePluginLoadEventHandler m_OnBeforePluginLoad;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetCookieManager != null) {
                m_GetCookieManager = null;
                CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforePluginLoad != null) {
                m_OnBeforePluginLoad = null;
                CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the browser process IO thread to retrieve the cookie manager. If
        /// this function returns NULL the default cookie manager retrievable via
        /// CfxRequestContext.GetDefaultCookieManager() will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetCookieManagerEventHandler(object sender, CfxGetCookieManagerEventArgs e);

        /// <summary>
        /// Called on the browser process IO thread to retrieve the cookie manager. If
        /// this function returns NULL the default cookie manager retrievable via
        /// CfxRequestContext.GetDefaultCookieManager() will be used.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetCookieManagerEventArgs : CfxEventArgs {


            internal CfxCookieManager m_returnValue;
            private bool returnValueSet;

            internal CfxGetCookieManagerEventArgs() {
            }

            /// <summary>
            /// Set the return value for the <see cref="CfxRequestContextHandler.GetCookieManager"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxCookieManager returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Called on multiple browser process threads before a plugin instance is
        /// loaded. |MimeType| is the mime type of the plugin that will be loaded.
        /// |PluginUrl| is the content URL that the plugin will load and may be NULL.
        /// |IsMainFrame| will be true (1) if the plugin is being loaded in the main
        /// (top-level) frame, |TopOriginUrl| is the URL for the top-level frame that
        /// contains the plugin when loading a specific plugin instance or NULL when
        /// building the initial list of enabled plugins for 'navigator.plugins'
        /// JavaScript state. |PluginInfo| includes additional information about the
        /// plugin that will be loaded. |PluginPolicy| is the recommended policy.
        /// Modify |PluginPolicy| and return true (1) to change the policy. Return
        /// false (0) to use the recommended policy. The default plugin policy can be
        /// set at runtime using the `--plugin-policy=[allow|Detect|block]` command-
        /// line flag. Decisions to mark a plugin as disabled by setting
        /// |PluginPolicy| to PLUGIN_POLICY_DISABLED may be cached when
        /// |TopOriginUrl| is NULL. To purge the plugin list cache and potentially
        /// trigger new calls to this function call
        /// CfxRequestContext.PurgePluginListCache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforePluginLoadEventHandler(object sender, CfxOnBeforePluginLoadEventArgs e);

        /// <summary>
        /// Called on multiple browser process threads before a plugin instance is
        /// loaded. |MimeType| is the mime type of the plugin that will be loaded.
        /// |PluginUrl| is the content URL that the plugin will load and may be NULL.
        /// |IsMainFrame| will be true (1) if the plugin is being loaded in the main
        /// (top-level) frame, |TopOriginUrl| is the URL for the top-level frame that
        /// contains the plugin when loading a specific plugin instance or NULL when
        /// building the initial list of enabled plugins for 'navigator.plugins'
        /// JavaScript state. |PluginInfo| includes additional information about the
        /// plugin that will be loaded. |PluginPolicy| is the recommended policy.
        /// Modify |PluginPolicy| and return true (1) to change the policy. Return
        /// false (0) to use the recommended policy. The default plugin policy can be
        /// set at runtime using the `--plugin-policy=[allow|Detect|block]` command-
        /// line flag. Decisions to mark a plugin as disabled by setting
        /// |PluginPolicy| to PLUGIN_POLICY_DISABLED may be cached when
        /// |TopOriginUrl| is NULL. To purge the plugin list cache and potentially
        /// trigger new calls to this function call
        /// CfxRequestContext.PurgePluginListCache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforePluginLoadEventArgs : CfxEventArgs {

            internal IntPtr m_mime_type_str;
            internal int m_mime_type_length;
            internal string m_mime_type;
            internal IntPtr m_plugin_url_str;
            internal int m_plugin_url_length;
            internal string m_plugin_url;
            internal int m_is_main_frame;
            internal IntPtr m_top_origin_url_str;
            internal int m_top_origin_url_length;
            internal string m_top_origin_url;
            internal IntPtr m_plugin_info;
            internal CfxWebPluginInfo m_plugin_info_wrapped;
            internal int m_plugin_policy;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforePluginLoadEventArgs(IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, int is_main_frame, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, int plugin_policy) {
                m_mime_type_str = mime_type_str;
                m_mime_type_length = mime_type_length;
                m_plugin_url_str = plugin_url_str;
                m_plugin_url_length = plugin_url_length;
                m_is_main_frame = is_main_frame;
                m_top_origin_url_str = top_origin_url_str;
                m_top_origin_url_length = top_origin_url_length;
                m_plugin_info = plugin_info;
                m_plugin_policy = plugin_policy;
            }

            /// <summary>
            /// Get the MimeType parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public string MimeType {
                get {
                    CheckAccess();
                    m_mime_type = StringFunctions.PtrToStringUni(m_mime_type_str, m_mime_type_length);
                    return m_mime_type;
                }
            }
            /// <summary>
            /// Get the PluginUrl parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public string PluginUrl {
                get {
                    CheckAccess();
                    m_plugin_url = StringFunctions.PtrToStringUni(m_plugin_url_str, m_plugin_url_length);
                    return m_plugin_url;
                }
            }
            /// <summary>
            /// Get the IsMainFrame parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public bool IsMainFrame {
                get {
                    CheckAccess();
                    return 0 != m_is_main_frame;
                }
            }
            /// <summary>
            /// Get the TopOriginUrl parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public string TopOriginUrl {
                get {
                    CheckAccess();
                    m_top_origin_url = StringFunctions.PtrToStringUni(m_top_origin_url_str, m_top_origin_url_length);
                    return m_top_origin_url;
                }
            }
            /// <summary>
            /// Get the PluginInfo parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public CfxWebPluginInfo PluginInfo {
                get {
                    CheckAccess();
                    if(m_plugin_info_wrapped == null) m_plugin_info_wrapped = CfxWebPluginInfo.Wrap(m_plugin_info);
                    return m_plugin_info_wrapped;
                }
            }
            /// <summary>
            /// Get or set the PluginPolicy parameter for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
            /// </summary>
            public CfxPluginPolicy PluginPolicy {
                get {
                    CheckAccess();
                    return (CfxPluginPolicy)m_plugin_policy;
                }
                set {
                    CheckAccess();
                    m_plugin_policy = (int)value;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestContextHandler.OnBeforePluginLoad"/> callback.
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
                return String.Format("MimeType={{{0}}}, PluginUrl={{{1}}}, IsMainFrame={{{2}}}, TopOriginUrl={{{3}}}, PluginInfo={{{4}}}, PluginPolicy={{{5}}}", MimeType, PluginUrl, IsMainFrame, TopOriginUrl, PluginInfo, PluginPolicy);
            }
        }

    }
}
