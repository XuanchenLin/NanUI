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
    /// Implement this structure to handle events related to browser extensions. The
    /// functions of this structure will be called on the UI thread. See
    /// CfxRequestContext.LoadExtension for information about extension loading.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
    /// </remarks>
    public class CfxExtensionHandler : CfxBaseClient {

        internal static CfxExtensionHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.ExtensionHandler.cfx_extension_handler_get_gc_handle(nativePtr);
            return (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            on_extension_load_failed_native = on_extension_load_failed;
            on_extension_loaded_native = on_extension_loaded;
            on_extension_unloaded_native = on_extension_unloaded;
            on_before_background_browser_native = on_before_background_browser;
            on_before_browser_native = on_before_browser;
            get_active_browser_native = get_active_browser;
            can_access_browser_native = can_access_browser;
            get_extension_resource_native = get_extension_resource;

            on_extension_load_failed_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_extension_load_failed_native);
            on_extension_loaded_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_extension_loaded_native);
            on_extension_unloaded_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_extension_unloaded_native);
            on_before_background_browser_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_background_browser_native);
            on_before_browser_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(on_before_browser_native);
            get_active_browser_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_active_browser_native);
            can_access_browser_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(can_access_browser_native);
            get_extension_resource_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(get_extension_resource_native);
        }

        // on_extension_load_failed
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_extension_load_failed_delegate(IntPtr gcHandlePtr, int result);
        private static on_extension_load_failed_delegate on_extension_load_failed_native;
        private static IntPtr on_extension_load_failed_native_ptr;

        internal static void on_extension_load_failed(IntPtr gcHandlePtr, int result) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxOnExtensionLoadFailedEventArgs();
            e.m_result = result;
            self.m_OnExtensionLoadFailed?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        // on_extension_loaded
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_extension_loaded_delegate(IntPtr gcHandlePtr, IntPtr extension, out int extension_release);
        private static on_extension_loaded_delegate on_extension_loaded_native;
        private static IntPtr on_extension_loaded_native_ptr;

        internal static void on_extension_loaded(IntPtr gcHandlePtr, IntPtr extension, out int extension_release) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                extension_release = 1;
                return;
            }
            var e = new CfxOnExtensionLoadedEventArgs();
            e.m_extension = extension;
            self.m_OnExtensionLoaded?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
        }

        // on_extension_unloaded
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_extension_unloaded_delegate(IntPtr gcHandlePtr, IntPtr extension, out int extension_release);
        private static on_extension_unloaded_delegate on_extension_unloaded_native;
        private static IntPtr on_extension_unloaded_native_ptr;

        internal static void on_extension_unloaded(IntPtr gcHandlePtr, IntPtr extension, out int extension_release) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                extension_release = 1;
                return;
            }
            var e = new CfxOnExtensionUnloadedEventArgs();
            e.m_extension = extension;
            self.m_OnExtensionUnloaded?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
        }

        // on_before_background_browser
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_background_browser_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr url_str, int url_length, out IntPtr client, IntPtr settings);
        private static on_before_background_browser_delegate on_before_background_browser_native;
        private static IntPtr on_before_background_browser_native_ptr;

        internal static void on_before_background_browser(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr url_str, int url_length, out IntPtr client, IntPtr settings) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                extension_release = 1;
                client = default(IntPtr);
                return;
            }
            var e = new CfxOnBeforeBackgroundBrowserEventArgs();
            e.m_extension = extension;
            e.m_url_str = url_str;
            e.m_url_length = url_length;
            e.m_settings = settings;
            self.m_OnBeforeBackgroundBrowser?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
            client = CfxClient.Unwrap(e.m_client_wrapped);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // on_before_browser
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void on_before_browser_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, IntPtr active_browser, out int active_browser_release, int index, IntPtr url_str, int url_length, int active, IntPtr windowInfo, out IntPtr client, IntPtr settings);
        private static on_before_browser_delegate on_before_browser_native;
        private static IntPtr on_before_browser_native_ptr;

        internal static void on_before_browser(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, IntPtr active_browser, out int active_browser_release, int index, IntPtr url_str, int url_length, int active, IntPtr windowInfo, out IntPtr client, IntPtr settings) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                extension_release = 1;
                browser_release = 1;
                active_browser_release = 1;
                client = default(IntPtr);
                return;
            }
            var e = new CfxOnBeforeBrowserEventArgs();
            e.m_extension = extension;
            e.m_browser = browser;
            e.m_active_browser = active_browser;
            e.m_index = index;
            e.m_url_str = url_str;
            e.m_url_length = url_length;
            e.m_active = active;
            e.m_windowInfo = windowInfo;
            e.m_settings = settings;
            self.m_OnBeforeBrowser?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            active_browser_release = e.m_active_browser_wrapped == null? 1 : 0;
            client = CfxClient.Unwrap(e.m_client_wrapped);
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_active_browser
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_active_browser_delegate(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, int include_incognito);
        private static get_active_browser_delegate get_active_browser_native;
        private static IntPtr get_active_browser_native_ptr;

        internal static void get_active_browser(IntPtr gcHandlePtr, out IntPtr __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, int include_incognito) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(IntPtr);
                extension_release = 1;
                browser_release = 1;
                return;
            }
            var e = new CfxGetActiveBrowserEventArgs();
            e.m_extension = extension;
            e.m_browser = browser;
            e.m_include_incognito = include_incognito;
            self.m_GetActiveBrowser?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            __retval = CfxBrowser.Unwrap(e.m_returnValue);
        }

        // can_access_browser
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void can_access_browser_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, int include_incognito, IntPtr target_browser, out int target_browser_release);
        private static can_access_browser_delegate can_access_browser_native;
        private static IntPtr can_access_browser_native_ptr;

        internal static void can_access_browser(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, int include_incognito, IntPtr target_browser, out int target_browser_release) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                extension_release = 1;
                browser_release = 1;
                target_browser_release = 1;
                return;
            }
            var e = new CfxCanAccessBrowserEventArgs();
            e.m_extension = extension;
            e.m_browser = browser;
            e.m_include_incognito = include_incognito;
            e.m_target_browser = target_browser;
            self.m_CanAccessBrowser?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            target_browser_release = e.m_target_browser_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        // get_extension_resource
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void get_extension_resource_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, IntPtr file_str, int file_length, IntPtr callback, out int callback_release);
        private static get_extension_resource_delegate get_extension_resource_native;
        private static IntPtr get_extension_resource_native_ptr;

        internal static void get_extension_resource(IntPtr gcHandlePtr, out int __retval, IntPtr extension, out int extension_release, IntPtr browser, out int browser_release, IntPtr file_str, int file_length, IntPtr callback, out int callback_release) {
            var self = (CfxExtensionHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                extension_release = 1;
                browser_release = 1;
                callback_release = 1;
                return;
            }
            var e = new CfxGetExtensionResourceEventArgs();
            e.m_extension = extension;
            e.m_browser = browser;
            e.m_file_str = file_str;
            e.m_file_length = file_length;
            e.m_callback = callback;
            self.m_GetExtensionResource?.Invoke(self, e);
            e.m_isInvalid = true;
            extension_release = e.m_extension_wrapped == null? 1 : 0;
            browser_release = e.m_browser_wrapped == null? 1 : 0;
            callback_release = e.m_callback_wrapped == null? 1 : 0;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxExtensionHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxExtensionHandler() : base(CfxApi.ExtensionHandler.cfx_extension_handler_ctor) {}

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request fails. |Result|
        /// will be the error code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnExtensionLoadFailedEventHandler OnExtensionLoadFailed {
            add {
                lock(eventLock) {
                    if(m_OnExtensionLoadFailed == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 0, on_extension_load_failed_native_ptr);
                    }
                    m_OnExtensionLoadFailed += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnExtensionLoadFailed -= value;
                    if(m_OnExtensionLoadFailed == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnExtensionLoadFailedEventHandler m_OnExtensionLoadFailed;

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request succeeds.
        /// |Extension| is the loaded extension.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnExtensionLoadedEventHandler OnExtensionLoaded {
            add {
                lock(eventLock) {
                    if(m_OnExtensionLoaded == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 1, on_extension_loaded_native_ptr);
                    }
                    m_OnExtensionLoaded += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnExtensionLoaded -= value;
                    if(m_OnExtensionLoaded == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnExtensionLoadedEventHandler m_OnExtensionLoaded;

        /// <summary>
        /// Called after the CfxExtension.Unload request has completed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnExtensionUnloadedEventHandler OnExtensionUnloaded {
            add {
                lock(eventLock) {
                    if(m_OnExtensionUnloaded == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 2, on_extension_unloaded_native_ptr);
                    }
                    m_OnExtensionUnloaded += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnExtensionUnloaded -= value;
                    if(m_OnExtensionUnloaded == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnExtensionUnloadedEventHandler m_OnExtensionUnloaded;

        /// <summary>
        /// Called when an extension needs a browser to host a background script
        /// specified via the "background" manifest key. The browser will have no
        /// visible window and cannot be displayed. |Extension| is the extension that
        /// is loading the background script. |Url| is an internally generated
        /// reference to an HTML page that will be used to load the background script
        /// via a &lt;script> src attribute. To allow creation of the browser optionally
        /// modify |Client| and |Settings| and return false (0). To cancel creation of
        /// the browser (and consequently cancel load of the background script) return
        /// true (1). Successful creation will be indicated by a call to
        /// CfxLifeSpanHandler.OnAfterCreated, and
        /// CfxBrowserHost.IsBackgroundHost will return true (1) for the resulting
        /// browser. See https://developer.chrome.com/extensions/event_pages for more
        /// information about extension background script usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeBackgroundBrowserEventHandler OnBeforeBackgroundBrowser {
            add {
                lock(eventLock) {
                    if(m_OnBeforeBackgroundBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 3, on_before_background_browser_native_ptr);
                    }
                    m_OnBeforeBackgroundBrowser += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeBackgroundBrowser -= value;
                    if(m_OnBeforeBackgroundBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeBackgroundBrowserEventHandler m_OnBeforeBackgroundBrowser;

        /// <summary>
        /// Called when an extension API (e.g. chrome.tabs.create) requests creation of
        /// a new browser. |Extension| and |Browser| are the source of the API call.
        /// |ActiveBrowser| may optionally be specified via the windowId property or
        /// returned via the get_active_browser() callback and provides the default
        /// |Client| and |Settings| values for the new browser. |Index| is the position
        /// value optionally specified via the index property. |Url| is the URL that
        /// will be loaded in the browser. |Active| is true (1) if the new browser
        /// should be active when opened.  To allow creation of the browser optionally
        /// modify |WindowInfo|, |Client| and |Settings| and return false (0). To
        /// cancel creation of the browser return true (1). Successful creation will be
        /// indicated by a call to CfxLifeSpanHandler.OnAfterCreated. Any
        /// modifications to |WindowInfo| will be ignored if |ActiveBrowser| is
        /// wrapped in a CfxBrowserView.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxOnBeforeBrowserEventHandler OnBeforeBrowser {
            add {
                lock(eventLock) {
                    if(m_OnBeforeBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 4, on_before_browser_native_ptr);
                    }
                    m_OnBeforeBrowser += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_OnBeforeBrowser -= value;
                    if(m_OnBeforeBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxOnBeforeBrowserEventHandler m_OnBeforeBrowser;

        /// <summary>
        /// Called when no tabId is specified to an extension API call that accepts a
        /// tabId parameter (e.g. chrome.tabs.*). |Extension| and |Browser| are the
        /// source of the API call. Return the browser that will be acted on by the API
        /// call or return NULL to act on |Browser|. The returned browser must share
        /// the same CfxRequestContext as |Browser|. Incognito browsers should not
        /// be considered unless the source extension has incognito access enabled, in
        /// which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetActiveBrowserEventHandler GetActiveBrowser {
            add {
                lock(eventLock) {
                    if(m_GetActiveBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 5, get_active_browser_native_ptr);
                    }
                    m_GetActiveBrowser += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetActiveBrowser -= value;
                    if(m_GetActiveBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 5, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetActiveBrowserEventHandler m_GetActiveBrowser;

        /// <summary>
        /// Called when the tabId associated with |TargetBrowser| is specified to an
        /// extension API call that accepts a tabId parameter (e.g. chrome.tabs.*).
        /// |Extension| and |Browser| are the source of the API call. Return true (1)
        /// to allow access of false (0) to deny access. Access to incognito browsers
        /// should not be allowed unless the source extension has incognito access
        /// enabled, in which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxCanAccessBrowserEventHandler CanAccessBrowser {
            add {
                lock(eventLock) {
                    if(m_CanAccessBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 6, can_access_browser_native_ptr);
                    }
                    m_CanAccessBrowser += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_CanAccessBrowser -= value;
                    if(m_CanAccessBrowser == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 6, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxCanAccessBrowserEventHandler m_CanAccessBrowser;

        /// <summary>
        /// Called to retrieve an extension resource that would normally be loaded from
        /// disk (e.g. if a file parameter is specified to chrome.tabs.executeScript).
        /// |Extension| and |Browser| are the source of the resource request. |File| is
        /// the requested relative file path. To handle the resource request return
        /// true (1) and execute |Callback| either synchronously or asynchronously. For
        /// the default behavior which reads the resource from the extension directory
        /// on disk return false (0). Localization substitutions will not be applied to
        /// resources handled via this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public event CfxGetExtensionResourceEventHandler GetExtensionResource {
            add {
                lock(eventLock) {
                    if(m_GetExtensionResource == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 7, get_extension_resource_native_ptr);
                    }
                    m_GetExtensionResource += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_GetExtensionResource -= value;
                    if(m_GetExtensionResource == null) {
                        CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 7, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxGetExtensionResourceEventHandler m_GetExtensionResource;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_OnExtensionLoadFailed != null) {
                m_OnExtensionLoadFailed = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_OnExtensionLoaded != null) {
                m_OnExtensionLoaded = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_OnExtensionUnloaded != null) {
                m_OnExtensionUnloaded = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_OnBeforeBackgroundBrowser != null) {
                m_OnBeforeBackgroundBrowser = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_OnBeforeBrowser != null) {
                m_OnBeforeBrowser = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            if(m_GetActiveBrowser != null) {
                m_GetActiveBrowser = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 5, IntPtr.Zero);
            }
            if(m_CanAccessBrowser != null) {
                m_CanAccessBrowser = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 6, IntPtr.Zero);
            }
            if(m_GetExtensionResource != null) {
                m_GetExtensionResource = null;
                CfxApi.ExtensionHandler.cfx_extension_handler_set_callback(NativePtr, 7, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request fails. |Result|
        /// will be the error code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnExtensionLoadFailedEventHandler(object sender, CfxOnExtensionLoadFailedEventArgs e);

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request fails. |Result|
        /// will be the error code.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnExtensionLoadFailedEventArgs : CfxEventArgs {

            internal int m_result;

            internal CfxOnExtensionLoadFailedEventArgs() {}

            /// <summary>
            /// Get the Result parameter for the <see cref="CfxExtensionHandler.OnExtensionLoadFailed"/> callback.
            /// </summary>
            public CfxErrorCode Result {
                get {
                    CheckAccess();
                    return (CfxErrorCode)m_result;
                }
            }

            public override string ToString() {
                return String.Format("Result={{{0}}}", Result);
            }
        }

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request succeeds.
        /// |Extension| is the loaded extension.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnExtensionLoadedEventHandler(object sender, CfxOnExtensionLoadedEventArgs e);

        /// <summary>
        /// Called if the CfxRequestContext.LoadExtension request succeeds.
        /// |Extension| is the loaded extension.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnExtensionLoadedEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;

            internal CfxOnExtensionLoadedEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.OnExtensionLoaded"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Extension={{{0}}}", Extension);
            }
        }

        /// <summary>
        /// Called after the CfxExtension.Unload request has completed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnExtensionUnloadedEventHandler(object sender, CfxOnExtensionUnloadedEventArgs e);

        /// <summary>
        /// Called after the CfxExtension.Unload request has completed.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnExtensionUnloadedEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;

            internal CfxOnExtensionUnloadedEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.OnExtensionUnloaded"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Extension={{{0}}}", Extension);
            }
        }

        /// <summary>
        /// Called when an extension needs a browser to host a background script
        /// specified via the "background" manifest key. The browser will have no
        /// visible window and cannot be displayed. |Extension| is the extension that
        /// is loading the background script. |Url| is an internally generated
        /// reference to an HTML page that will be used to load the background script
        /// via a &lt;script> src attribute. To allow creation of the browser optionally
        /// modify |Client| and |Settings| and return false (0). To cancel creation of
        /// the browser (and consequently cancel load of the background script) return
        /// true (1). Successful creation will be indicated by a call to
        /// CfxLifeSpanHandler.OnAfterCreated, and
        /// CfxBrowserHost.IsBackgroundHost will return true (1) for the resulting
        /// browser. See https://developer.chrome.com/extensions/event_pages for more
        /// information about extension background script usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeBackgroundBrowserEventHandler(object sender, CfxOnBeforeBackgroundBrowserEventArgs e);

        /// <summary>
        /// Called when an extension needs a browser to host a background script
        /// specified via the "background" manifest key. The browser will have no
        /// visible window and cannot be displayed. |Extension| is the extension that
        /// is loading the background script. |Url| is an internally generated
        /// reference to an HTML page that will be used to load the background script
        /// via a &lt;script> src attribute. To allow creation of the browser optionally
        /// modify |Client| and |Settings| and return false (0). To cancel creation of
        /// the browser (and consequently cancel load of the background script) return
        /// true (1). Successful creation will be indicated by a call to
        /// CfxLifeSpanHandler.OnAfterCreated, and
        /// CfxBrowserHost.IsBackgroundHost will return true (1) for the resulting
        /// browser. See https://developer.chrome.com/extensions/event_pages for more
        /// information about extension background script usage.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeBackgroundBrowserEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;
            internal IntPtr m_url_str;
            internal int m_url_length;
            internal string m_url;
            internal CfxClient m_client_wrapped;
            internal IntPtr m_settings;
            internal CfxBrowserSettings m_settings_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeBackgroundBrowserEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.OnBeforeBackgroundBrowser"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }
            /// <summary>
            /// Get the Url parameter for the <see cref="CfxExtensionHandler.OnBeforeBackgroundBrowser"/> callback.
            /// </summary>
            public string Url {
                get {
                    CheckAccess();
                    m_url = StringFunctions.PtrToStringUni(m_url_str, m_url_length);
                    return m_url;
                }
            }
            /// <summary>
            /// Set the Client out parameter for the <see cref="CfxExtensionHandler.OnBeforeBackgroundBrowser"/> callback.
            /// </summary>
            public CfxClient Client {
                set {
                    CheckAccess();
                    m_client_wrapped = value;
                }
            }
            /// <summary>
            /// Get the Settings parameter for the <see cref="CfxExtensionHandler.OnBeforeBackgroundBrowser"/> callback.
            /// </summary>
            public CfxBrowserSettings Settings {
                get {
                    CheckAccess();
                    if(m_settings_wrapped == null) m_settings_wrapped = CfxBrowserSettings.Wrap(m_settings);
                    return m_settings_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxExtensionHandler.OnBeforeBackgroundBrowser"/> callback.
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
                return String.Format("Extension={{{0}}}, Url={{{1}}}, Settings={{{2}}}", Extension, Url, Settings);
            }
        }

        /// <summary>
        /// Called when an extension API (e.g. chrome.tabs.create) requests creation of
        /// a new browser. |Extension| and |Browser| are the source of the API call.
        /// |ActiveBrowser| may optionally be specified via the windowId property or
        /// returned via the get_active_browser() callback and provides the default
        /// |Client| and |Settings| values for the new browser. |Index| is the position
        /// value optionally specified via the index property. |Url| is the URL that
        /// will be loaded in the browser. |Active| is true (1) if the new browser
        /// should be active when opened.  To allow creation of the browser optionally
        /// modify |WindowInfo|, |Client| and |Settings| and return false (0). To
        /// cancel creation of the browser return true (1). Successful creation will be
        /// indicated by a call to CfxLifeSpanHandler.OnAfterCreated. Any
        /// modifications to |WindowInfo| will be ignored if |ActiveBrowser| is
        /// wrapped in a CfxBrowserView.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxOnBeforeBrowserEventHandler(object sender, CfxOnBeforeBrowserEventArgs e);

        /// <summary>
        /// Called when an extension API (e.g. chrome.tabs.create) requests creation of
        /// a new browser. |Extension| and |Browser| are the source of the API call.
        /// |ActiveBrowser| may optionally be specified via the windowId property or
        /// returned via the get_active_browser() callback and provides the default
        /// |Client| and |Settings| values for the new browser. |Index| is the position
        /// value optionally specified via the index property. |Url| is the URL that
        /// will be loaded in the browser. |Active| is true (1) if the new browser
        /// should be active when opened.  To allow creation of the browser optionally
        /// modify |WindowInfo|, |Client| and |Settings| and return false (0). To
        /// cancel creation of the browser return true (1). Successful creation will be
        /// indicated by a call to CfxLifeSpanHandler.OnAfterCreated. Any
        /// modifications to |WindowInfo| will be ignored if |ActiveBrowser| is
        /// wrapped in a CfxBrowserView.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxOnBeforeBrowserEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;
            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_active_browser;
            internal CfxBrowser m_active_browser_wrapped;
            internal int m_index;
            internal IntPtr m_url_str;
            internal int m_url_length;
            internal string m_url;
            internal int m_active;
            internal IntPtr m_windowInfo;
            internal CfxClient m_client_wrapped;
            internal IntPtr m_settings;
            internal CfxBrowserSettings m_settings_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxOnBeforeBrowserEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }
            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the ActiveBrowser parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxBrowser ActiveBrowser {
                get {
                    CheckAccess();
                    if(m_active_browser_wrapped == null) m_active_browser_wrapped = CfxBrowser.Wrap(m_active_browser);
                    return m_active_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the Index parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public int Index {
                get {
                    CheckAccess();
                    return m_index;
                }
            }
            /// <summary>
            /// Get the Url parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public string Url {
                get {
                    CheckAccess();
                    m_url = StringFunctions.PtrToStringUni(m_url_str, m_url_length);
                    return m_url;
                }
            }
            /// <summary>
            /// Get the Active parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public bool Active {
                get {
                    CheckAccess();
                    return 0 != m_active;
                }
            }
            /// <summary>
            /// Get the WindowInfo parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxWindowInfo WindowInfo {
                get {
                    CheckAccess();
                    return CfxWindowInfo.Wrap(m_windowInfo);
                }
            }
            /// <summary>
            /// Set the Client out parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxClient Client {
                set {
                    CheckAccess();
                    m_client_wrapped = value;
                }
            }
            /// <summary>
            /// Get the Settings parameter for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
            /// </summary>
            public CfxBrowserSettings Settings {
                get {
                    CheckAccess();
                    if(m_settings_wrapped == null) m_settings_wrapped = CfxBrowserSettings.Wrap(m_settings);
                    return m_settings_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxExtensionHandler.OnBeforeBrowser"/> callback.
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
                return String.Format("Extension={{{0}}}, Browser={{{1}}}, ActiveBrowser={{{2}}}, Index={{{3}}}, Url={{{4}}}, Active={{{5}}}, WindowInfo={{{6}}}, Settings={{{7}}}", Extension, Browser, ActiveBrowser, Index, Url, Active, WindowInfo, Settings);
            }
        }

        /// <summary>
        /// Called when no tabId is specified to an extension API call that accepts a
        /// tabId parameter (e.g. chrome.tabs.*). |Extension| and |Browser| are the
        /// source of the API call. Return the browser that will be acted on by the API
        /// call or return NULL to act on |Browser|. The returned browser must share
        /// the same CfxRequestContext as |Browser|. Incognito browsers should not
        /// be considered unless the source extension has incognito access enabled, in
        /// which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetActiveBrowserEventHandler(object sender, CfxGetActiveBrowserEventArgs e);

        /// <summary>
        /// Called when no tabId is specified to an extension API call that accepts a
        /// tabId parameter (e.g. chrome.tabs.*). |Extension| and |Browser| are the
        /// source of the API call. Return the browser that will be acted on by the API
        /// call or return NULL to act on |Browser|. The returned browser must share
        /// the same CfxRequestContext as |Browser|. Incognito browsers should not
        /// be considered unless the source extension has incognito access enabled, in
        /// which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetActiveBrowserEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;
            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_include_incognito;

            internal CfxBrowser m_returnValue;
            private bool returnValueSet;

            internal CfxGetActiveBrowserEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.GetActiveBrowser"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }
            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxExtensionHandler.GetActiveBrowser"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IncludeIncognito parameter for the <see cref="CfxExtensionHandler.GetActiveBrowser"/> callback.
            /// </summary>
            public bool IncludeIncognito {
                get {
                    CheckAccess();
                    return 0 != m_include_incognito;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxExtensionHandler.GetActiveBrowser"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfxBrowser returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Extension={{{0}}}, Browser={{{1}}}, IncludeIncognito={{{2}}}", Extension, Browser, IncludeIncognito);
            }
        }

        /// <summary>
        /// Called when the tabId associated with |TargetBrowser| is specified to an
        /// extension API call that accepts a tabId parameter (e.g. chrome.tabs.*).
        /// |Extension| and |Browser| are the source of the API call. Return true (1)
        /// to allow access of false (0) to deny access. Access to incognito browsers
        /// should not be allowed unless the source extension has incognito access
        /// enabled, in which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxCanAccessBrowserEventHandler(object sender, CfxCanAccessBrowserEventArgs e);

        /// <summary>
        /// Called when the tabId associated with |TargetBrowser| is specified to an
        /// extension API call that accepts a tabId parameter (e.g. chrome.tabs.*).
        /// |Extension| and |Browser| are the source of the API call. Return true (1)
        /// to allow access of false (0) to deny access. Access to incognito browsers
        /// should not be allowed unless the source extension has incognito access
        /// enabled, in which case |IncludeIncognito| will be true (1).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxCanAccessBrowserEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;
            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal int m_include_incognito;
            internal IntPtr m_target_browser;
            internal CfxBrowser m_target_browser_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxCanAccessBrowserEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.CanAccessBrowser"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }
            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxExtensionHandler.CanAccessBrowser"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the IncludeIncognito parameter for the <see cref="CfxExtensionHandler.CanAccessBrowser"/> callback.
            /// </summary>
            public bool IncludeIncognito {
                get {
                    CheckAccess();
                    return 0 != m_include_incognito;
                }
            }
            /// <summary>
            /// Get the TargetBrowser parameter for the <see cref="CfxExtensionHandler.CanAccessBrowser"/> callback.
            /// </summary>
            public CfxBrowser TargetBrowser {
                get {
                    CheckAccess();
                    if(m_target_browser_wrapped == null) m_target_browser_wrapped = CfxBrowser.Wrap(m_target_browser);
                    return m_target_browser_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxExtensionHandler.CanAccessBrowser"/> callback.
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
                return String.Format("Extension={{{0}}}, Browser={{{1}}}, IncludeIncognito={{{2}}}, TargetBrowser={{{3}}}", Extension, Browser, IncludeIncognito, TargetBrowser);
            }
        }

        /// <summary>
        /// Called to retrieve an extension resource that would normally be loaded from
        /// disk (e.g. if a file parameter is specified to chrome.tabs.executeScript).
        /// |Extension| and |Browser| are the source of the resource request. |File| is
        /// the requested relative file path. To handle the resource request return
        /// true (1) and execute |Callback| either synchronously or asynchronously. For
        /// the default behavior which reads the resource from the extension directory
        /// on disk return false (0). Localization substitutions will not be applied to
        /// resources handled via this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public delegate void CfxGetExtensionResourceEventHandler(object sender, CfxGetExtensionResourceEventArgs e);

        /// <summary>
        /// Called to retrieve an extension resource that would normally be loaded from
        /// disk (e.g. if a file parameter is specified to chrome.tabs.executeScript).
        /// |Extension| and |Browser| are the source of the resource request. |File| is
        /// the requested relative file path. To handle the resource request return
        /// true (1) and execute |Callback| either synchronously or asynchronously. For
        /// the default behavior which reads the resource from the extension directory
        /// on disk return false (0). Localization substitutions will not be applied to
        /// resources handled via this function.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_extension_handler_capi.h">cef/include/capi/cef_extension_handler_capi.h</see>.
        /// </remarks>
        public class CfxGetExtensionResourceEventArgs : CfxEventArgs {

            internal IntPtr m_extension;
            internal CfxExtension m_extension_wrapped;
            internal IntPtr m_browser;
            internal CfxBrowser m_browser_wrapped;
            internal IntPtr m_file_str;
            internal int m_file_length;
            internal string m_file;
            internal IntPtr m_callback;
            internal CfxGetExtensionResourceCallback m_callback_wrapped;

            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxGetExtensionResourceEventArgs() {}

            /// <summary>
            /// Get the Extension parameter for the <see cref="CfxExtensionHandler.GetExtensionResource"/> callback.
            /// </summary>
            public CfxExtension Extension {
                get {
                    CheckAccess();
                    if(m_extension_wrapped == null) m_extension_wrapped = CfxExtension.Wrap(m_extension);
                    return m_extension_wrapped;
                }
            }
            /// <summary>
            /// Get the Browser parameter for the <see cref="CfxExtensionHandler.GetExtensionResource"/> callback.
            /// </summary>
            public CfxBrowser Browser {
                get {
                    CheckAccess();
                    if(m_browser_wrapped == null) m_browser_wrapped = CfxBrowser.Wrap(m_browser);
                    return m_browser_wrapped;
                }
            }
            /// <summary>
            /// Get the File parameter for the <see cref="CfxExtensionHandler.GetExtensionResource"/> callback.
            /// </summary>
            public string File {
                get {
                    CheckAccess();
                    m_file = StringFunctions.PtrToStringUni(m_file_str, m_file_length);
                    return m_file;
                }
            }
            /// <summary>
            /// Get the Callback parameter for the <see cref="CfxExtensionHandler.GetExtensionResource"/> callback.
            /// </summary>
            public CfxGetExtensionResourceCallback Callback {
                get {
                    CheckAccess();
                    if(m_callback_wrapped == null) m_callback_wrapped = CfxGetExtensionResourceCallback.Wrap(m_callback);
                    return m_callback_wrapped;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxExtensionHandler.GetExtensionResource"/> callback.
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
                return String.Format("Extension={{{0}}}, Browser={{{1}}}, File={{{2}}}, Callback={{{3}}}", Extension, Browser, File, Callback);
            }
        }

    }
}
