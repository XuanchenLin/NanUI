// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a DOM document. The functions of this structure
    /// should only be called on the render process main thread thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
    /// </remarks>
    public class CfxDomDocument : CfxBaseLibrary {

        internal static CfxDomDocument Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxDomDocument)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxDomDocument(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxDomDocument(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the document type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomDocumentType Type {
            get {
                return (CfxDomDocumentType)CfxApi.DomDocument.cfx_domdocument_get_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns the root document node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode Document {
            get {
                return CfxDomNode.Wrap(CfxApi.DomDocument.cfx_domdocument_get_document(NativePtr));
            }
        }

        /// <summary>
        /// Returns the BODY node of an HTML document.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode Body {
            get {
                return CfxDomNode.Wrap(CfxApi.DomDocument.cfx_domdocument_get_body(NativePtr));
            }
        }

        /// <summary>
        /// Returns the HEAD node of an HTML document.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode Head {
            get {
                return CfxDomNode.Wrap(CfxApi.DomDocument.cfx_domdocument_get_head(NativePtr));
            }
        }

        /// <summary>
        /// Returns the title of an HTML document.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string Title {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomDocument.cfx_domdocument_get_title(NativePtr));
            }
        }

        /// <summary>
        /// Returns the node that currently has keyboard focus.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode FocusedNode {
            get {
                return CfxDomNode.Wrap(CfxApi.DomDocument.cfx_domdocument_get_focused_node(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if a portion of the document is selected.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool HasSelection {
            get {
                return 0 != CfxApi.DomDocument.cfx_domdocument_has_selection(NativePtr);
            }
        }

        /// <summary>
        /// Returns the selection offset within the start node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public int SelectionStartOffset {
            get {
                return CfxApi.DomDocument.cfx_domdocument_get_selection_start_offset(NativePtr);
            }
        }

        /// <summary>
        /// Returns the selection offset within the end node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public int SelectionEndOffset {
            get {
                return CfxApi.DomDocument.cfx_domdocument_get_selection_end_offset(NativePtr);
            }
        }

        /// <summary>
        /// Returns the contents of this selection as markup.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string SelectionAsMarkup {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomDocument.cfx_domdocument_get_selection_as_markup(NativePtr));
            }
        }

        /// <summary>
        /// Returns the contents of this selection as text.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string SelectionAsText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomDocument.cfx_domdocument_get_selection_as_text(NativePtr));
            }
        }

        /// <summary>
        /// Returns the base URL for the document.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string BaseUrl {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomDocument.cfx_domdocument_get_base_url(NativePtr));
            }
        }

        /// <summary>
        /// Returns the document element with the specified ID value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode GetElementById(string id) {
            var id_pinned = new PinnedString(id);
            var __retval = CfxApi.DomDocument.cfx_domdocument_get_element_by_id(NativePtr, id_pinned.Obj.PinnedPtr, id_pinned.Length);
            id_pinned.Obj.Free();
            return CfxDomNode.Wrap(__retval);
        }

        /// <summary>
        /// Returns a complete URL based on the document base URL and the specified
        /// partial URL.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string GetCompleteUrl(string partialURL) {
            var partialURL_pinned = new PinnedString(partialURL);
            var __retval = CfxApi.DomDocument.cfx_domdocument_get_complete_url(NativePtr, partialURL_pinned.Obj.PinnedPtr, partialURL_pinned.Length);
            partialURL_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }
    }
}
