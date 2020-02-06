// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a browser window. When used in the browser
    /// process the functions of this structure may be called on any thread unless
    /// otherwise indicated in the comments. When used in the render process the
    /// functions of this structure may only be called on the main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
    /// </remarks>
    public class CfxBrowser : CfxBaseLibrary {

        internal static CfxBrowser Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxBrowser)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxBrowser(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxBrowser(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the browser host object. This function can only be called in the
        /// browser process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxBrowserHost Host {
            get {
                return CfxBrowserHost.Wrap(CfxApi.Browser.cfx_browser_get_host(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the browser can navigate backwards.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool CanGoBack {
            get {
                return 0 != CfxApi.Browser.cfx_browser_can_go_back(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the browser can navigate forwards.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool CanGoForward {
            get {
                return 0 != CfxApi.Browser.cfx_browser_can_go_forward(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the browser is currently loading.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsLoading {
            get {
                return 0 != CfxApi.Browser.cfx_browser_is_loading(NativePtr);
            }
        }

        /// <summary>
        /// Returns the globally unique identifier for this browser. This value is also
        /// used as the tabId for extension APIs.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public int Identifier {
            get {
                return CfxApi.Browser.cfx_browser_get_identifier(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the window is a popup window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsPopup {
            get {
                return 0 != CfxApi.Browser.cfx_browser_is_popup(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if a document has been loaded in the browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool HasDocument {
            get {
                return 0 != CfxApi.Browser.cfx_browser_has_document(NativePtr);
            }
        }

        /// <summary>
        /// Returns the main (top-level) frame for the browser window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxFrame MainFrame {
            get {
                return CfxFrame.Wrap(CfxApi.Browser.cfx_browser_get_main_frame(NativePtr));
            }
        }

        /// <summary>
        /// Returns the focused frame for the browser window.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxFrame FocusedFrame {
            get {
                return CfxFrame.Wrap(CfxApi.Browser.cfx_browser_get_focused_frame(NativePtr));
            }
        }

        /// <summary>
        /// Returns the number of frames that currently exist.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public ulong FrameCount {
            get {
                return (ulong)CfxApi.Browser.cfx_browser_get_frame_count(NativePtr);
            }
        }

        /// <summary>
        /// Returns the identifiers of all existing frames.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public long[] FrameIdentifiers {
            get {
                var identifiersCount = FrameCount;
                if(identifiersCount == 0) return new long[0];
                long[] retval = new long[identifiersCount];
                var retval_p = new PinnedObject(retval);
                CfxApi.Browser.cfx_browser_get_frame_identifiers(NativePtr, (UIntPtr)identifiersCount, retval_p.PinnedPtr);
                retval_p.Free();
                return retval;
            }
        }

        /// <summary>
        /// Navigate backwards.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void GoBack() {
            CfxApi.Browser.cfx_browser_go_back(NativePtr);
        }

        /// <summary>
        /// Navigate forwards.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void GoForward() {
            CfxApi.Browser.cfx_browser_go_forward(NativePtr);
        }

        /// <summary>
        /// Reload the current page.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void Reload() {
            CfxApi.Browser.cfx_browser_reload(NativePtr);
        }

        /// <summary>
        /// Reload the current page ignoring any cached data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ReloadIgnoreCache() {
            CfxApi.Browser.cfx_browser_reload_ignore_cache(NativePtr);
        }

        /// <summary>
        /// Stop loading the page.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void StopLoad() {
            CfxApi.Browser.cfx_browser_stop_load(NativePtr);
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxBrowser that) {
            return 0 != CfxApi.Browser.cfx_browser_is_same(NativePtr, CfxBrowser.Unwrap(that));
        }

        /// <summary>
        /// Returns the frame with the specified identifier, or NULL if not found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxFrame GetFrame(long identifier) {
            return CfxFrame.Wrap(CfxApi.Browser.cfx_browser_get_frame_byident(NativePtr, identifier));
        }

        /// <summary>
        /// Returns the frame with the specified name, or NULL if not found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxFrame GetFrame(string name) {
            var name_pinned = new PinnedString(name);
            var __retval = CfxApi.Browser.cfx_browser_get_frame(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
            return CfxFrame.Wrap(__retval);
        }

        /// <summary>
        /// Returns the names of all existing frames.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string> GetFrameNames() {
            System.Collections.Generic.List<string> names = new System.Collections.Generic.List<string>();
            PinnedString[] names_handles;
            var names_unwrapped = StringFunctions.UnwrapCfxStringList(names, out names_handles);
            CfxApi.Browser.cfx_browser_get_frame_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.Runtime.cfx_string_list_free(names_unwrapped);
            return names;
        }
    }
}
