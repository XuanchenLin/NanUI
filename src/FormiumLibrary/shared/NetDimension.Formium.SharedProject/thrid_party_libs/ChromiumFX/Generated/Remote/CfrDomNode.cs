// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure used to represent a DOM node. The functions of this structure
    /// should only be called on the render process main thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
    /// </remarks>
    public class CfrDomNode : CfrBaseLibrary {

        internal static CfrDomNode Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            bool isNew = false;
            var wrapper = (CfrDomNode)weakCache.GetOrAdd(remotePtr.ptr, () =>  {
                isNew = true;
                return new CfrDomNode(remotePtr);
            });
            if(!isNew) {
                var call = new CfxApiReleaseRemoteCall();
                call.nativePtr = remotePtr.ptr;
                call.RequestExecution(remotePtr.connection);
            }
            return wrapper;
        }



        private CfrDomNode(RemotePtr remotePtr) : base(remotePtr) {}

        /// <summary>
        /// Returns the type for this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfxDomNodeType Type {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return (CfxDomNodeType)call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeIsTextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeIsElementRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeIsEditableRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeIsFormControlElementRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetFormControlElementTypeRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetValueRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetAsMarkupRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the document associated with this node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomDocument Document {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetDocumentRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomDocument.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the parent node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomNode Parent {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetParentRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomNode.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the previous sibling node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomNode PreviousSibling {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetPreviousSiblingRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomNode.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the next sibling node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomNode NextSibling {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetNextSiblingRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomNode.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeHasChildrenRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Return the first child node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomNode FirstChild {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetFirstChildRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomNode.Wrap(new RemotePtr(connection, call.__retval));
            }
        }

        /// <summary>
        /// Returns the last child node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrDomNode LastChild {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetLastChildRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return CfrDomNode.Wrap(new RemotePtr(connection, call.__retval));
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetElementTagNameRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeHasElementAttributesRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
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
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetElementInnerTextRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the bounds of the element.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public CfrRect ElementBounds {
            get {
                var connection = RemotePtr.connection;
                var call = new CfxDomNodeGetElementBoundsRemoteCall();
                call.@this = RemotePtr.ptr;
                call.RequestExecution(connection);
                if(call.__retval == IntPtr.Zero) throw new OutOfMemoryException("Render process out of memory.");
                return CfrRect.Wrap(new RemotePtr(connection, call.__retval));
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
        public bool IsSame(CfrDomNode that) {
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeIsSameRemoteCall();
            call.@this = RemotePtr.ptr;
            if(!CfrObject.CheckConnection(that, connection)) throw new ArgumentException("Render process connection mismatch.", "that");
            call.that = CfrObject.Unwrap(that).ptr;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Set the value of this node. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool SetValue(string value) {
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeSetValueRemoteCall();
            call.@this = RemotePtr.ptr;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this element has an attribute named |attrName|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public bool HasElementAttribute(string attrName) {
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeHasElementAttributeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.attrName = attrName;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns the element attribute named |attrName|.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public string GetElementAttribute(string attrName) {
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeGetElementAttributeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.attrName = attrName;
            call.RequestExecution(connection);
            return call.__retval;
        }

        /// <summary>
        /// Returns a map of all element attributes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_dom_capi.h">cef/include/capi/cef_dom_capi.h</see>.
        /// </remarks>
        public System.Collections.Generic.List<string[]> GetElementAttributes() {
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeGetElementAttributesRemoteCall();
            call.@this = RemotePtr.ptr;
            call.RequestExecution(connection);
            return call.__retval;
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
            var connection = RemotePtr.connection;
            var call = new CfxDomNodeSetElementAttributeRemoteCall();
            call.@this = RemotePtr.ptr;
            call.attrName = attrName;
            call.value = value;
            call.RequestExecution(connection);
            return call.__retval;
        }
    }
}
