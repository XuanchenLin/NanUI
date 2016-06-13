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
	public class CfxBrowser : CfxBase {

        static CfxBrowser () {
            CfxApiLoader.LoadCfxBrowserApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxBrowser Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxBrowser)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxBrowser(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
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
                return CfxBrowserHost.Wrap(CfxApi.cfx_browser_get_host(NativePtr));
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
                return 0 != CfxApi.cfx_browser_can_go_back(NativePtr);
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
                return 0 != CfxApi.cfx_browser_can_go_forward(NativePtr);
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
                return 0 != CfxApi.cfx_browser_is_loading(NativePtr);
            }
        }

        /// <summary>
        /// Returns the globally unique identifier for this browser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public int Identifier {
            get {
                return CfxApi.cfx_browser_get_identifier(NativePtr);
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
                return 0 != CfxApi.cfx_browser_is_popup(NativePtr);
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
                return 0 != CfxApi.cfx_browser_has_document(NativePtr);
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
                return CfxFrame.Wrap(CfxApi.cfx_browser_get_main_frame(NativePtr));
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
                return CfxFrame.Wrap(CfxApi.cfx_browser_get_focused_frame(NativePtr));
            }
        }

        /// <summary>
        /// Returns the number of frames that currently exist.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public int FrameCount {
            get {
                return CfxApi.cfx_browser_get_frame_count(NativePtr);
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
                int identifiersCount = FrameCount;
                if(identifiersCount == 0) return new long[0];
                long[] retval = new long[identifiersCount];
                var retval_p = new PinnedObject(retval);
                CfxApi.cfx_browser_get_frame_identifiers(NativePtr, identifiersCount, retval_p.PinnedPtr);
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
            CfxApi.cfx_browser_go_back(NativePtr);
        }

        /// <summary>
        /// Navigate forwards.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void GoForward() {
            CfxApi.cfx_browser_go_forward(NativePtr);
        }

        /// <summary>
        /// Reload the current page.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void Reload() {
            CfxApi.cfx_browser_reload(NativePtr);
        }

        /// <summary>
        /// Reload the current page ignoring any cached data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void ReloadIgnoreCache() {
            CfxApi.cfx_browser_reload_ignore_cache(NativePtr);
        }

        /// <summary>
        /// Stop loading the page.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public void StopLoad() {
            CfxApi.cfx_browser_stop_load(NativePtr);
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
            return 0 != CfxApi.cfx_browser_is_same(NativePtr, CfxBrowser.Unwrap(that));
        }

        /// <summary>
        /// Returns the frame with the specified identifier, or NULL if not found.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public CfxFrame GetFrame(long identifier) {
            return CfxFrame.Wrap(CfxApi.cfx_browser_get_frame_byident(NativePtr, identifier));
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
            var __retval = CfxApi.cfx_browser_get_frame(NativePtr, name_pinned.Obj.PinnedPtr, name_pinned.Length);
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
            CfxApi.cfx_browser_get_frame_names(NativePtr, names_unwrapped);
            StringFunctions.FreePinnedStrings(names_handles);
            StringFunctions.CfxStringListCopyToManaged(names_unwrapped, names);
            CfxApi.cfx_string_list_free(names_unwrapped);
            return names;
        }

        /// <summary>
        /// Send a message to the specified |targetProcess|. Returns true (1) if the
        /// message was sent successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_browser_capi.h">cef/include/capi/cef_browser_capi.h</see>.
        /// </remarks>
        public bool SendProcessMessage(CfxProcessId targetProcess, CfxProcessMessage message) {
            return 0 != CfxApi.cfx_browser_send_process_message(NativePtr, (int)targetProcess, CfxProcessMessage.Unwrap(message));
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
