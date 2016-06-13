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
	/// Implement this structure to provide handler implementations. The handler
	/// instance will not be released until all objects related to the context have
	/// been destroyed.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
	/// </remarks>
	public class CfxRequestContextHandler : CfxBase {

        static CfxRequestContextHandler () {
            CfxApiLoader.LoadCfxRequestContextHandlerApi();
        }

        internal static CfxRequestContextHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_request_context_handler_get_gc_handle(nativePtr);
            return (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // get_cookie_manager
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_request_context_handler_get_cookie_manager_delegate(IntPtr gcHandlePtr, out IntPtr __retval);
        private static cfx_request_context_handler_get_cookie_manager_delegate cfx_request_context_handler_get_cookie_manager;
        private static IntPtr cfx_request_context_handler_get_cookie_manager_ptr;

        internal static void get_cookie_manager(IntPtr gcHandlePtr, out IntPtr __retval) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(IntPtr);
                return;
            }
            var e = new CfxGetCookieManagerEventArgs();
            var eventHandler = self.m_GetCookieManager;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = CfxCookieManager.Unwrap(e.m_returnValue);
        }

        // on_before_plugin_load
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_request_context_handler_on_before_plugin_load_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, ref int plugin_policy);
        private static cfx_request_context_handler_on_before_plugin_load_delegate cfx_request_context_handler_on_before_plugin_load;
        private static IntPtr cfx_request_context_handler_on_before_plugin_load_ptr;

        internal static void on_before_plugin_load(IntPtr gcHandlePtr, out int __retval, IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, ref int plugin_policy) {
            var self = (CfxRequestContextHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxOnBeforePluginLoadEventArgs(mime_type_str, mime_type_length, plugin_url_str, plugin_url_length, top_origin_url_str, top_origin_url_length, plugin_info, plugin_policy);
            var eventHandler = self.m_OnBeforePluginLoad;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            if(e.m_plugin_info_wrapped == null) CfxApi.cfx_release(e.m_plugin_info);
            plugin_policy = e.m_plugin_policy;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxRequestContextHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxRequestContextHandler() : base(CfxApi.cfx_request_context_handler_ctor) {}

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
                    if(m_GetCookieManager == null) {
                        if(cfx_request_context_handler_get_cookie_manager == null) {
                            cfx_request_context_handler_get_cookie_manager = get_cookie_manager;
                            cfx_request_context_handler_get_cookie_manager_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_request_context_handler_get_cookie_manager);
                        }
                        CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 0, cfx_request_context_handler_get_cookie_manager_ptr);
                    }
                    m_GetCookieManager += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetCookieManager -= value;
                    if(m_GetCookieManager == null) {
                        CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetCookieManagerEventHandler m_GetCookieManager;

        /// <summary>
        /// Called on multiple browser process threads before a plugin instance is
        /// loaded. |MimeType| is the mime type of the plugin that will be loaded.
        /// |PluginUrl| is the content URL that the plugin will load and may be NULL.
        /// |TopOriginUrl| is the URL for the top-level frame that contains the
        /// plugin when loading a specific plugin instance or NULL when building the
        /// initial list of enabled plugins for 'navigator.plugins' JavaScript state.
        /// |PluginInfo| includes additional information about the plugin that will be
        /// loaded. |PluginPolicy| is the recommended policy. Modify |PluginPolicy|
        /// and return true (1) to change the policy. Return false (0) to use the
        /// recommended policy. The default plugin policy can be set at runtime using
        /// the `--plugin-policy=[allow|Detect|block]` command-line flag. Decisions to
        /// mark a plugin as disabled by setting |PluginPolicy| to
        /// PLUGIN_POLICY_DISABLED may be cached when |TopOriginUrl| is NULL. To
        /// purge the plugin list cache and potentially trigger new calls to this
        /// function call CfxRequestContext.PurgePluginListCache.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_request_context_handler_capi.h">cef/include/capi/cef_request_context_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforePluginLoadEventHandler OnBeforePluginLoad {
            add {
                lock(eventLock) {
                    if(m_OnBeforePluginLoad == null) {
                        if(cfx_request_context_handler_on_before_plugin_load == null) {
                            cfx_request_context_handler_on_before_plugin_load = on_before_plugin_load;
                            cfx_request_context_handler_on_before_plugin_load_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_request_context_handler_on_before_plugin_load);
                        }
                        CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 1, cfx_request_context_handler_on_before_plugin_load_ptr);
                    }
                    m_OnBeforePluginLoad += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforePluginLoad -= value;
                    if(m_OnBeforePluginLoad == null) {
                        CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforePluginLoadEventHandler m_OnBeforePluginLoad;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_GetCookieManager != null) {
                m_GetCookieManager = null;
                CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnBeforePluginLoad != null) {
                m_OnBeforePluginLoad = null;
                CfxApi.cfx_request_context_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

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
        /// |TopOriginUrl| is the URL for the top-level frame that contains the
        /// plugin when loading a specific plugin instance or NULL when building the
        /// initial list of enabled plugins for 'navigator.plugins' JavaScript state.
        /// |PluginInfo| includes additional information about the plugin that will be
        /// loaded. |PluginPolicy| is the recommended policy. Modify |PluginPolicy|
        /// and return true (1) to change the policy. Return false (0) to use the
        /// recommended policy. The default plugin policy can be set at runtime using
        /// the `--plugin-policy=[allow|Detect|block]` command-line flag. Decisions to
        /// mark a plugin as disabled by setting |PluginPolicy| to
        /// PLUGIN_POLICY_DISABLED may be cached when |TopOriginUrl| is NULL. To
        /// purge the plugin list cache and potentially trigger new calls to this
        /// function call CfxRequestContext.PurgePluginListCache.
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
        /// |TopOriginUrl| is the URL for the top-level frame that contains the
        /// plugin when loading a specific plugin instance or NULL when building the
        /// initial list of enabled plugins for 'navigator.plugins' JavaScript state.
        /// |PluginInfo| includes additional information about the plugin that will be
        /// loaded. |PluginPolicy| is the recommended policy. Modify |PluginPolicy|
        /// and return true (1) to change the policy. Return false (0) to use the
        /// recommended policy. The default plugin policy can be set at runtime using
        /// the `--plugin-policy=[allow|Detect|block]` command-line flag. Decisions to
        /// mark a plugin as disabled by setting |PluginPolicy| to
        /// PLUGIN_POLICY_DISABLED may be cached when |TopOriginUrl| is NULL. To
        /// purge the plugin list cache and potentially trigger new calls to this
        /// function call CfxRequestContext.PurgePluginListCache.
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
            internal IntPtr m_top_origin_url_str;
            internal int m_top_origin_url_length;
            internal string m_top_origin_url;
            internal IntPtr m_plugin_info;
            internal CfxWebPluginInfo m_plugin_info_wrapped;
            internal int m_plugin_policy;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforePluginLoadEventArgs(IntPtr mime_type_str, int mime_type_length, IntPtr plugin_url_str, int plugin_url_length, IntPtr top_origin_url_str, int top_origin_url_length, IntPtr plugin_info, int plugin_policy) {
                m_mime_type_str = mime_type_str;
                m_mime_type_length = mime_type_length;
                m_plugin_url_str = plugin_url_str;
                m_plugin_url_length = plugin_url_length;
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
                return String.Format("MimeType={{{0}}}, PluginUrl={{{1}}}, TopOriginUrl={{{2}}}, PluginInfo={{{3}}}, PluginPolicy={{{4}}}", MimeType, PluginUrl, TopOriginUrl, PluginInfo, PluginPolicy);
            }
        }

    }
}
