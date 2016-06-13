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
	/// Provides information about the context menu state. The ethods of this
	/// structure can only be accessed on browser process the UI thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
	/// </remarks>
	public class CfxContextMenuParams : CfxBase {

        static CfxContextMenuParams () {
            CfxApiLoader.LoadCfxContextMenuParamsApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxContextMenuParams Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxContextMenuParams)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxContextMenuParams(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxContextMenuParams(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the X coordinate of the mouse where the context menu was invoked.
        /// Coords are relative to the associated RenderView's origin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public int Xcoord {
            get {
                return CfxApi.cfx_context_menu_params_get_xcoord(NativePtr);
            }
        }

        /// <summary>
        /// Returns the Y coordinate of the mouse where the context menu was invoked.
        /// Coords are relative to the associated RenderView's origin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public int Ycoord {
            get {
                return CfxApi.cfx_context_menu_params_get_ycoord(NativePtr);
            }
        }

        /// <summary>
        /// Returns flags representing the type of node that the context menu was
        /// invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public CfxContextMenuTypeFlags TypeFlags {
            get {
                return (CfxContextMenuTypeFlags)CfxApi.cfx_context_menu_params_get_type_flags(NativePtr);
            }
        }

        /// <summary>
        /// Returns the URL of the link, if any, that encloses the node that the
        /// context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string LinkUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_link_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the link URL, if any, to be used ONLY for "copy link address". We
        /// don't validate this field in the frontend process.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string UnfilteredLinkUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_unfiltered_link_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the source URL, if any, for the element that the context menu was
        /// invoked on. Example of elements with source URLs are img, audio, and video.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string SourceUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_source_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the context menu was invoked on an image which has non-
        /// NULL contents.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool HasImageContents {
            get {
                return 0 != CfxApi.cfx_context_menu_params_has_image_contents(NativePtr);
            }
        }

        /// <summary>
        /// Returns the URL of the top level page that the context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string PageUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_page_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the URL of the subframe that the context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string FrameUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_frame_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the character encoding of the subframe that the context menu was
        /// invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string FrameCharset {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_frame_charset(NativePtr));
            }
        }

        /// <summary>
        /// Returns the type of context node that the context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public CfxContextMenuMediaType MediaType {
            get {
                return (CfxContextMenuMediaType)CfxApi.cfx_context_menu_params_get_media_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns flags representing the actions supported by the media element, if
        /// any, that the context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public CfxContextMenuMediaStateFlags MediaStateFlags {
            get {
                return (CfxContextMenuMediaStateFlags)CfxApi.cfx_context_menu_params_get_media_state_flags(NativePtr);
            }
        }

        /// <summary>
        /// Returns the text of the selection, if any, that the context menu was
        /// invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string SelectionText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_selection_text(NativePtr));
            }
        }

        /// <summary>
        /// Returns the text of the misspelled word, if any, that the context menu was
        /// invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string MisspelledWord {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_context_menu_params_get_misspelled_word(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the context menu was invoked on an editable node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool IsEditable {
            get {
                return 0 != CfxApi.cfx_context_menu_params_is_editable(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the context menu was invoked on an editable node where
        /// spell-check is enabled.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool IsSpellCheckEnabled {
            get {
                return 0 != CfxApi.cfx_context_menu_params_is_spell_check_enabled(NativePtr);
            }
        }

        /// <summary>
        /// Returns flags representing the actions supported by the editable node, if
        /// any, that the context menu was invoked on.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public CfxContextMenuEditStateFlags EditStateFlags {
            get {
                return (CfxContextMenuEditStateFlags)CfxApi.cfx_context_menu_params_get_edit_state_flags(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the context menu contains items specified by the
        /// renderer process (for example, plugin placeholder or pepper plugin menu
        /// items).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool IsCustomMenu {
            get {
                return 0 != CfxApi.cfx_context_menu_params_is_custom_menu(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the context menu was invoked from a pepper plugin.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool IsPepperMenu {
            get {
                return 0 != CfxApi.cfx_context_menu_params_is_pepper_menu(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if suggestions exist, false (0) otherwise. Fills in
        /// |suggestions| from the spell check service for the misspelled word if there
        /// is one.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public bool GetDictionarySuggestions(System.Collections.Generic.List<string> suggestions) {
            PinnedString[] suggestions_handles;
            var suggestions_unwrapped = StringFunctions.UnwrapCfxStringList(suggestions, out suggestions_handles);
            var __retval = CfxApi.cfx_context_menu_params_get_dictionary_suggestions(NativePtr, suggestions_unwrapped);
            StringFunctions.FreePinnedStrings(suggestions_handles);
            StringFunctions.CfxStringListCopyToManaged(suggestions_unwrapped, suggestions);
            CfxApi.cfx_string_list_free(suggestions_unwrapped);
            return 0 != __retval;
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
