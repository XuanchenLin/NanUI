// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Provides information about the context menu state. The ethods of this
    /// structure can only be accessed on browser process the UI thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
    /// </remarks>
    public class CfxContextMenuParams : CfxBaseLibrary {

        internal static CfxContextMenuParams Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxContextMenuParams)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxContextMenuParams(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
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
                return CfxApi.ContextMenuParams.cfx_context_menu_params_get_xcoord(NativePtr);
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
                return CfxApi.ContextMenuParams.cfx_context_menu_params_get_ycoord(NativePtr);
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
                return (CfxContextMenuTypeFlags)CfxApi.ContextMenuParams.cfx_context_menu_params_get_type_flags(NativePtr);
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_link_url(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_unfiltered_link_url(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_source_url(NativePtr));
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
                return 0 != CfxApi.ContextMenuParams.cfx_context_menu_params_has_image_contents(NativePtr);
            }
        }

        /// <summary>
        /// Returns the title text or the alt text if the context menu was invoked on
        /// an image.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_context_menu_handler_capi.h">cef/include/capi/cef_context_menu_handler_capi.h</see>.
        /// </remarks>
        public string TitleText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_title_text(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_page_url(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_url(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_frame_charset(NativePtr));
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
                return (CfxContextMenuMediaType)CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_type(NativePtr);
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
                return (CfxContextMenuMediaStateFlags)CfxApi.ContextMenuParams.cfx_context_menu_params_get_media_state_flags(NativePtr);
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_selection_text(NativePtr));
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
                return StringFunctions.ConvertStringUserfree(CfxApi.ContextMenuParams.cfx_context_menu_params_get_misspelled_word(NativePtr));
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
                return 0 != CfxApi.ContextMenuParams.cfx_context_menu_params_is_editable(NativePtr);
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
                return 0 != CfxApi.ContextMenuParams.cfx_context_menu_params_is_spell_check_enabled(NativePtr);
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
                return (CfxContextMenuEditStateFlags)CfxApi.ContextMenuParams.cfx_context_menu_params_get_edit_state_flags(NativePtr);
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
                return 0 != CfxApi.ContextMenuParams.cfx_context_menu_params_is_custom_menu(NativePtr);
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
                return 0 != CfxApi.ContextMenuParams.cfx_context_menu_params_is_pepper_menu(NativePtr);
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
            var __retval = CfxApi.ContextMenuParams.cfx_context_menu_params_get_dictionary_suggestions(NativePtr, suggestions_unwrapped);
            StringFunctions.FreePinnedStrings(suggestions_handles);
            StringFunctions.CfxStringListCopyToManaged(suggestions_unwrapped, suggestions);
            CfxApi.Runtime.cfx_string_list_free(suggestions_unwrapped);
            return 0 != __retval;
        }
    }
}
