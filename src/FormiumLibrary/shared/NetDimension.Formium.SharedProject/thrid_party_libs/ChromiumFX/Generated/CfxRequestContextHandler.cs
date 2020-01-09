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
            on_request_context_initialized_native = on_request_context_initialized;
            on_before_plugin_load_native = on_before_plugin_load;
            get_resource_request_handler_native = get_resource_request_handler;

            on_request_context_initialized_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_request_context_initialized_native);
            on_before_plugin_load_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_plugin_load_native);
            get_resource_request_handler_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_resource_request_handler_native);
        }

        // on_request_context_initialized
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_request_context_initialized_delegate(IntPtr gcHandlePtr, IntPtr request_context, out int request_context_release);
        private static on_request_context_initialized_delegate on_request_context_initialized_native;
        private static IntPtr on_request_context_initialized_native_ptr;

        internal static void on_request_context_initialized(IntPtr gcHandlePtr, IntPtr request_context, out int request_context_release) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                request_context_release = 1;
                return;
            }
            var e = new CfxOnRequestContextInitializedEventArgs();
            e.m_request_context = request_context;
            self.m_OnRequestContextInitialized?.Invoke(self, e);
            e.m_isInvalid = true;
            request_context_release = e.m_request_context_wrapped == null? 1 : 0;
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
            var e = new CfxOnBeforePluginLoadEventArgs();
            e.m_mime_type_str = mime_type_str;
            e.m_mime_type_length = mime_type_length;
            e.m_plugin_url_str = plugin_url_str;
            e.m_plugin_url_length = plugin_url_length;
            e.m_is_main_frame = is_main_frame;
            e.m_top_origin_url_str = top_origin_url_str;
            e.m_top_origin_url_length = top_origin_url_length;
            e.m_plugin_info = plugin_info;
            e.m_plugin_policy = plugin_policy;
            self.m_OnBeforePluginLoad?.Invoke(self, e);
            e.m_isInvalid = true;
            plugin_info_release = e.m_plugin_info_wrapped == null? 1 : 0;
            plugin_policy = e.m_plugin_policy;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_resource_request_handler
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_resource_request_handler_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_navigation, int is_download, IntPtr request_initiator_str, int request_initiator_length, out int disable_default_handling);
        private static get_resource_request_handler_delegate get_resource_request_handler_native;
        private static IntPtr get_resource_request_handler_native_ptr;

        internal static void get_resource_request_handler(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr browser, out int browser_release, IntPtr frame, out int frame_release, IntPtr request, out int request_release, int is_navigation, int is_download, IntPtr request_initiator_str, int request_initiator_length, out int disable_default_handling) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                browser_release = 1;
                frame_release = 1;
                request_release = 1;
                disable_default_handling = default(int);
                return;
            }
            var e = new CfxRequestContextHandlerGetResourceRequestHandlerEventArgs();
            e.m_browser = browser;
            e.m_frame = frame;
            e.m_request = request;
            e.m_is_navigation = is_navigation;
            e.m_is_download = is_download;
            e.m_request_initiator_str = request_initiator_str;
            e.m_request_initiator_length = request_initiator_length;
            self.m_GetResourceRequestHandler?.Invoke(self, e);
            e.m_isInvalid = true;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            frame_release = e.m_frame_wrapped == null? 1 : 0;
            request_release = e.m_request_wrapped == null? 1 : 0;
            disable_default_handling = e.m_disable_default_handling;
            __retval = CfxResourceRequestHandler.Unwrap(e.m_returnValue);
        }

        internal CfxRequestContextHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRequestContextHandler() : base(CfxApi.RequestContextHandler.cfx_request_context_handler_ctor) {}

        /// <summary>
        /// Called on the browser process UI thread immediately after the request
        /// context has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnRequestContextInitializedEventHandler OnRequestContextInitialized {
            add {
                lock(eventLock) {
                    if(m_OnRequestContextInitialized == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, on_request_context_initialized_native_ptr);
                    }
                    m_OnRequestContextInitialized += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnRequestContextInitialized -= value;
                    if(m_OnRequestContextInitialized == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnRequestContextInitializedEventHandler m_OnRequestContextInitialized;

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

        /// <summary>
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request, and may be NULL for requests originating from service workers or
        /// CfxUrlRequest. |Request| represents the request contents and cannot be
        /// modified in this callback. |IsNavigation| will be true (1) if the resource
        /// request is a navigation. |IsDownload| will be true (1) if the resource
        /// request is a download. |RequestInitiator| is the origin (scheme + domain)
        /// of the page that initiated the request. Set |DisableDefaultHandling| to
        /// true (1) to disable default handling of the request, in which case it will
        /// need to be handled via CfxResourceRequestHandler.GetResourceHandler
        /// or it will be canceled. To allow the resource load to proceed with default
        /// handling return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. This function will not be called if
        /// the client associated with |Browser| returns a non-NULL value from
        /// CfxRequestHandler.GetResourceRequestHandler for the same request
        /// (identified by CfxRequest.GetIdentifier).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public event CfxRequestContextHandlerGetResourceRequestHandlerEventHandler GetResourceRequestHandler {
            add {
                lock(eventLock) {
                    if(m_GetResourceRequestHandler == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 2, get_resource_request_handler_native_ptr);
                    }
                    m_GetResourceRequestHandler += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetResourceRequestHandler -= value;
                    if(m_GetResourceRequestHandler == null) {
                        CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxRequestContextHandlerGetResourceRequestHandlerEventHandler m_GetResourceRequestHandler;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnRequestContextInitialized != null) {
                m_OnRequestContextInitialized = null;
                CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforePluginLoad != null) {
                m_OnBeforePluginLoad = null;
                CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_GetResourceRequestHandler != null) {
                m_GetResourceRequestHandler = null;
                CfxApi.RequestContextHandler.cfx_request_context_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called on the browser process UI thread immediately after the request
        /// context has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnRequestContextInitializedEventHandler(object sender, CfxOnRequestContextInitializedEventArgs e);

        /// <summary>
        /// Called on the browser process UI thread immediately after the request
        /// context has been initialized.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnRequestContextInitializedEventArgs : CfxEventArgs {

            internal IntPtr m_request_context;
            internal CfxRequestContext m_request_context_wrapped;

            internal CfxOnRequestContextInitializedEventArgs() {}

            /// <summary>
            /// Get the RequestContext parameter for the <see cref="CfxRequestContextHandler.OnRequestContextInitialized"/> callback.
            /// </summary>
            public CfxRequestContext RequestContext {
                get {
                    CheckAccess();
                    if(m_request_context_wrapped == null) m_request_context_wrapped = CfxRequestContext.Wrap(m_request_context);
                    return m_request_context_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("RequestContext={{{0}}}", RequestContext);
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

            internal CfxOnBeforePluginLoadEventArgs() {}

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

        /// <summary>
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request, and may be NULL for requests originating from service workers or
        /// CfxUrlRequest. |Request| represents the request contents and cannot be
        /// modified in this callback. |IsNavigation| will be true (1) if the resource
        /// request is a navigation. |IsDownload| will be true (1) if the resource
        /// request is a download. |RequestInitiator| is the origin (scheme + domain)
        /// of the page that initiated the request. Set |DisableDefaultHandling| to
        /// true (1) to disable default handling of the request, in which case it will
        /// need to be handled via CfxResourceRequestHandler.GetResourceHandler
        /// or it will be canceled. To allow the resource load to proceed with default
        /// handling return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. This function will not be called if
        /// the client associated with |Browser| returns a non-NULL value from
        /// CfxRequestHandler.GetResourceRequestHandler for the same request
        /// (identified by CfxRequest.GetIdentifier).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxRequestContextHandlerGetResourceRequestHandlerEventHandler(object sender, CfxRequestContextHandlerGetResourceRequestHandlerEventArgs e);

        /// <summary>
        /// Called on the browser process IO thread before a resource request is
        /// initiated. The |Browser| and |Frame| values represent the source of the
        /// request, and may be NULL for requests originating from service workers or
        /// CfxUrlRequest. |Request| represents the request contents and cannot be
        /// modified in this callback. |IsNavigation| will be true (1) if the resource
        /// request is a navigation. |IsDownload| will be true (1) if the resource
        /// request is a download. |RequestInitiator| is the origin (scheme + domain)
        /// of the page that initiated the request. Set |DisableDefaultHandling| to
        /// true (1) to disable default handling of the request, in which case it will
        /// need to be handled via CfxResourceRequestHandler.GetResourceHandler
        /// or it will be canceled. To allow the resource load to proceed with default
        /// handling return NULL. To specify a handler for the resource return a
        /// CfxResourceRequestHandler object. This function will not be called if
        /// the client associated with |Browser| returns a non-NULL value from
        /// CfxRequestHandler.GetResourceRequestHandler for the same request
        /// (identified by CfxRequest.GetIdentifier).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public class CfxRequestContextHandlerGetResourceRequestHandlerEventArgs : CfxEventArgs {

            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_frame;
            internal CfxFrame m_frame_wrapped;
            internal IntPtr m_request;
            internal CfxRequest m_request_wrapped;
            internal int m_is_navigation;
            internal int m_is_download;
            internal IntPtr m_request_initiator_str;
            internal int m_request_initiator_length;
            internal string m_request_initiator;
            internal int m_disable_default_handling;

            internal CfxResourceRequestHandler m_returnValue;
            private bool returnValueSet;

            internal CfxRequestContextHandlerGetResourceRequestHandlerEventArgs() {}

            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Frame parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxFrame Frame {
                get {
                    CheckAccess();
                    if(m_frame_wrapped == null) m_frame_wrapped = CfxFrame.Wrap(m_frame);
                    return m_frame_wrapped;
                }
            }
            /// <summary>
            /// Get the Request parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public CfxRequest Request {
                get {
                    CheckAccess();
                    if(m_request_wrapped == null) m_request_wrapped = CfxRequest.Wrap(m_request);
                    return m_request_wrapped;
                }
            }
            /// <summary>
            /// Get the IsNavigation parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool IsNavigation {
                get {
                    CheckAccess();
                    return 0 != m_is_navigation;
                }
            }
            /// <summary>
            /// Get the IsDownload parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool IsDownload {
                get {
                    CheckAccess();
                    return 0 != m_is_download;
                }
            }
            /// <summary>
            /// Get the RequestInitiator parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public string RequestInitiator {
                get {
                    CheckAccess();
                    m_request_initiator = StringFunctions.PtrToStringUni(m_request_initiator_str, m_request_initiator_length);
                    return m_request_initiator;
                }
            }
            /// <summary>
            /// Set the DisableDefaultHandling out parameter for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// </summary>
            public bool DisableDefaultHandling {
                set {
                    CheckAccess();
                    m_disable_default_handling = value ? 1 : 0;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxRequestContextHandler.GetResourceRequestHandler"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxResourceRequestHandler returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Browser={{{0}}}, Frame={{{1}}}, Request={{{2}}}, IsNavigation={{{3}}}, IsDownload={{{4}}}, RequestInitiator={{{5}}}", Browser, Frame, Request, IsNavigation, IsDownload, RequestInitiator);
            }
        }

    }
}
