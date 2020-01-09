// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    /// <summary>
    /// Structure used to represent a DOM node. The functions of this structure
    /// should only be called on the render process main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
    /// </remarks>
    public class CfxDomNode : CfxBaseLibrary {

        internal static CfxDomNode Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            bool isNew = false;
            var wrapper = (CfxDomNode)weakCache.GetOrAdd(nativePtr, () =>  {
                isNew = true;
                return new CfxDomNode(nativePtr);
            });
            if(!isNew) {
                CfxApi.cfx_release(nativePtr);
            }
            return wrapper;
        }


        internal CfxDomNode(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Returns the type for this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNodeType Type {
            get {
                return (CfxDomNodeType)CfxApi.DomNode.cfx_domnode_get_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is a text node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool IsText {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_is_text(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is an element node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool IsElement {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_is_element(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is an editable node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool IsEditable {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_is_editable(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if this is a form control element node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool IsFormControlElement {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_is_form_control_element(NativePtr);
            }
        }

        /// <summary>
        /// Returns the type of this form control element node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string FormControlElementType {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_form_control_element_type(NativePtr));
            }
        }

        /// <summary>
        /// Returns the name of this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string Name {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the value of this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string Value {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_value(NativePtr));
            }
        }

        /// <summary>
        /// Returns the contents of this node as markup.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string AsMarkup {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_as_markup(NativePtr));
            }
        }

        /// <summary>
        /// Returns the document associated with this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomDocument Document {
            get {
                return CfxDomDocument.Wrap(CfxApi.DomNode.cfx_domnode_get_document(NativePtr));
            }
        }

        /// <summary>
        /// Returns the parent node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode Parent {
            get {
                return CfxDomNode.Wrap(CfxApi.DomNode.cfx_domnode_get_parent(NativePtr));
            }
        }

        /// <summary>
        /// Returns the previous sibling node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode PreviousSibling {
            get {
                return CfxDomNode.Wrap(CfxApi.DomNode.cfx_domnode_get_previous_sibling(NativePtr));
            }
        }

        /// <summary>
        /// Returns the next sibling node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode NextSibling {
            get {
                return CfxDomNode.Wrap(CfxApi.DomNode.cfx_domnode_get_next_sibling(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this node has child nodes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool HasChildren {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_has_children(NativePtr);
            }
        }

        /// <summary>
        /// Return the first child node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode FirstChild {
            get {
                return CfxDomNode.Wrap(CfxApi.DomNode.cfx_domnode_get_first_child(NativePtr));
            }
        }

        /// <summary>
        /// Returns the last child node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNode LastChild {
            get {
                return CfxDomNode.Wrap(CfxApi.DomNode.cfx_domnode_get_last_child(NativePtr));
            }
        }

        /// <summary>
        /// Returns the tag name of this element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string ElementTagName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_element_tag_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if this element has attributes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool HasElementAttributes {
            get {
                return 0 != CfxApi.DomNode.cfx_domnode_has_element_attributes(NativePtr);
            }
        }

        /// <summary>
        /// Returns the inner text of the element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string ElementInnerText {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_element_inner_text(NativePtr));
            }
        }

        /// <summary>
        /// Returns the bounds of the element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxRect ElementBounds {
            get {
                var __retval = CfxApi.DomNode.cfx_domnode_get_element_bounds(NativePtr);
                if(__retval == IntPtr.Zero) throw new OutOfMemoryException();
                return CfxRect.WrapOwned(__retval);
            }
        }

        /// <summary>
        /// Returns true (1) if this object is pointing to the same handle as |that|
        /// object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfxDomNode that) {
            return 0 != CfxApi.DomNode.cfx_domnode_is_same(NativePtr, CfxDomNode.Unwrap(that));
        }

        /// <summary>
        /// Set the value of this node. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool SetValue(string value) {
            var value_pinned = new PinnedString(value);
            var __retval = CfxApi.DomNode.cfx_domnode_set_value(NativePtr, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns true (1) if this element has an attribute named |attrName|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool HasElementAttribute(string attrName) {
            var attrName_pinned = new PinnedString(attrName);
            var __retval = CfxApi.DomNode.cfx_domnode_has_element_attribute(NativePtr, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length);
            attrName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Returns the element attribute named |attrName|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string GetElementAttribute(string attrName) {
            var attrName_pinned = new PinnedString(attrName);
            var __retval = CfxApi.DomNode.cfx_domnode_get_element_attribute(NativePtr, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length);
            attrName_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns a map of all element attributes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetElementAttributes() {
            System.Collections.Generic.List<string[]> attrMap = new System.Collections.Generic.List<string[]>();
            PinnedString[] attrMap_handles;
            var attrMap_unwrapped = StringFunctions.UnwrapCfxStringMap(attrMap, out attrMap_handles);
            CfxApi.DomNode.cfx_domnode_get_element_attributes(NativePtr, attrMap_unwrapped);
            StringFunctions.FreePinnedStrings(attrMap_handles);
            StringFunctions.CfxStringMapCopyToManaged(attrMap_unwrapped, attrMap);
            CfxApi.Runtime.cfx_string_map_free(attrMap_unwrapped);
            return attrMap;
        }

        /// <summary>
        /// Set the value for the element attribute named |attrName|. Returns true (1)
        /// on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool SetElementAttribute(string attrName, string value) {
            var attrName_pinned = new PinnedString(attrName);
            var value_pinned = new PinnedString(value);
            var __retval = CfxApi.DomNode.cfx_domnode_set_element_attribute(NativePtr, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            attrName_pinned.Obj.Free();
            value_pinned.Obj.Free();
            return 0 != __retval;
        }
    }
}
