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
	/// Structure that supports the reading of XML data via the libxml streaming API.
	/// The functions of this structure should only be called on the thread that
	/// creates the object.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
	/// </remarks>
	public class CfxXmlReader : CfxBase {

        static CfxXmlReader () {
            CfxApiLoader.LoadCfxXmlReaderApi();
        }

        private static readonly WeakCache weakCache = new WeakCache();

        internal static CfxXmlReader Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            lock(weakCache) {
                var wrapper = (CfxXmlReader)weakCache.Get(nativePtr);
                if(wrapper == null) {
                    wrapper = new CfxXmlReader(nativePtr);
                    weakCache.Add(wrapper);
                } else {
                    CfxApi.cfx_release(nativePtr);
                }
                return wrapper;
            }
        }


        internal CfxXmlReader(IntPtr nativePtr) : base(nativePtr) {}

        /// <summary>
        /// Create a new CfxXmlReader object. The returned object's functions can
        /// only be called from the thread that created the object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public static CfxXmlReader Create(CfxStreamReader stream, CfxXmlEncodingType encodingType, string uri) {
            var uri_pinned = new PinnedString(uri);
            var __retval = CfxApi.cfx_xml_reader_create(CfxStreamReader.Unwrap(stream), (int)encodingType, uri_pinned.Obj.PinnedPtr, uri_pinned.Length);
            uri_pinned.Obj.Free();
            return CfxXmlReader.Wrap(__retval);
        }

        /// <summary>
        /// Returns true (1) if an error has been reported by the XML parser.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool HasError {
            get {
                return 0 != CfxApi.cfx_xml_reader_has_error(NativePtr);
            }
        }

        /// <summary>
        /// The below functions retrieve data for the node at the current cursor
        /// position.
        /// Returns the node type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public CfxXmlNodeType Type {
            get {
                return (CfxXmlNodeType)CfxApi.cfx_xml_reader_get_type(NativePtr);
            }
        }

        /// <summary>
        /// Returns the node depth. Depth starts at 0 for the root node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public int Depth {
            get {
                return CfxApi.cfx_xml_reader_get_depth(NativePtr);
            }
        }

        /// <summary>
        /// Returns the local name. See http://www.w3.org/TR/REC-xml-names/#NT-
        /// LocalPart for additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string LocalName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_local_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the namespace prefix. See http://www.w3.org/TR/REC-xml-names/ for
        /// additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string Prefix {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_prefix(NativePtr));
            }
        }

        /// <summary>
        /// Returns the qualified name, equal to (Prefix:)LocalName. See
        /// http://www.w3.org/TR/REC-xml-names/#ns-qualnames for additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string QualifiedName {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_qualified_name(NativePtr));
            }
        }

        /// <summary>
        /// Returns the URI defining the namespace associated with the node. See
        /// http://www.w3.org/TR/REC-xml-names/ for additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string NamespaceUri {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_namespace_uri(NativePtr));
            }
        }

        /// <summary>
        /// Returns the base URI of the node. See http://www.w3.org/TR/xmlbase/ for
        /// additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string BaseUri {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_base_uri(NativePtr));
            }
        }

        /// <summary>
        /// Returns the xml:lang scope within which the node resides. See
        /// http://www.w3.org/TR/REC-xml/#sec-lang-tag for additional details.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string XmlLang {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_xml_lang(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the node represents an NULL element. &lt;a/> is considered
        /// NULL but &lt;a>&lt;/a> is not.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool IsEmptyElement {
            get {
                return 0 != CfxApi.cfx_xml_reader_is_empty_element(NativePtr);
            }
        }

        /// <summary>
        /// Returns true (1) if the node has a text value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool HasValue {
            get {
                return 0 != CfxApi.cfx_xml_reader_has_value(NativePtr);
            }
        }

        /// <summary>
        /// Returns the text value.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string Value {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_value(NativePtr));
            }
        }

        /// <summary>
        /// Returns true (1) if the node has attributes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool HasAttributes {
            get {
                return 0 != CfxApi.cfx_xml_reader_has_attributes(NativePtr);
            }
        }

        /// <summary>
        /// Returns the number of attributes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public int AttributeCount {
            get {
                return CfxApi.cfx_xml_reader_get_attribute_count(NativePtr);
            }
        }

        /// <summary>
        /// Returns an XML representation of the current node's children.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string InnerXml {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_inner_xml(NativePtr));
            }
        }

        /// <summary>
        /// Returns an XML representation of the current node including its children.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string OuterXml {
            get {
                return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_outer_xml(NativePtr));
            }
        }

        /// <summary>
        /// Returns the line number for the current node.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public int LineNumber {
            get {
                return CfxApi.cfx_xml_reader_get_line_number(NativePtr);
            }
        }

        /// <summary>
        /// Moves the cursor to the next node in the document. This function must be
        /// called at least once to set the current cursor position. Returns true (1)
        /// if the cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToNextNode() {
            return 0 != CfxApi.cfx_xml_reader_move_to_next_node(NativePtr);
        }

        /// <summary>
        /// Close the document. This should be called directly to ensure that cleanup
        /// occurs on the correct thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool Close() {
            return 0 != CfxApi.cfx_xml_reader_close(NativePtr);
        }

        /// <summary>
        /// Returns the error string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string GetError() {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_error(NativePtr));
        }

        /// <summary>
        /// Returns the value of the attribute at the specified 0-based index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string GetAttribute(int index) {
            return StringFunctions.ConvertStringUserfree(CfxApi.cfx_xml_reader_get_attribute_byindex(NativePtr, index));
        }

        /// <summary>
        /// Returns the value of the attribute with the specified qualified name.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string GetAttribute(string qualifiedName) {
            var qualifiedName_pinned = new PinnedString(qualifiedName);
            var __retval = CfxApi.cfx_xml_reader_get_attribute_byqname(NativePtr, qualifiedName_pinned.Obj.PinnedPtr, qualifiedName_pinned.Length);
            qualifiedName_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Returns the value of the attribute with the specified local name and
        /// namespace URI.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public string GetAttribute(string localName, string namespaceURI) {
            var localName_pinned = new PinnedString(localName);
            var namespaceURI_pinned = new PinnedString(namespaceURI);
            var __retval = CfxApi.cfx_xml_reader_get_attribute_bylname(NativePtr, localName_pinned.Obj.PinnedPtr, localName_pinned.Length, namespaceURI_pinned.Obj.PinnedPtr, namespaceURI_pinned.Length);
            localName_pinned.Obj.Free();
            namespaceURI_pinned.Obj.Free();
            return StringFunctions.ConvertStringUserfree(__retval);
        }

        /// <summary>
        /// Attribute nodes are not traversed by default. The below functions can be
        /// used to move the cursor to an attribute node. move_to_carrying_element()
        /// can be called afterwards to return the cursor to the carrying element. The
        /// depth of an attribute node will be 1 + the depth of the carrying element.
        /// Moves the cursor to the attribute at the specified 0-based index. Returns
        /// true (1) if the cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToAttribute(int index) {
            return 0 != CfxApi.cfx_xml_reader_move_to_attribute_byindex(NativePtr, index);
        }

        /// <summary>
        /// Moves the cursor to the attribute with the specified qualified name.
        /// Returns true (1) if the cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToAttribute(string qualifiedName) {
            var qualifiedName_pinned = new PinnedString(qualifiedName);
            var __retval = CfxApi.cfx_xml_reader_move_to_attribute_byqname(NativePtr, qualifiedName_pinned.Obj.PinnedPtr, qualifiedName_pinned.Length);
            qualifiedName_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Moves the cursor to the attribute with the specified local name and
        /// namespace URI. Returns true (1) if the cursor position was set
        /// successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToAttribute(string localName, string namespaceURI) {
            var localName_pinned = new PinnedString(localName);
            var namespaceURI_pinned = new PinnedString(namespaceURI);
            var __retval = CfxApi.cfx_xml_reader_move_to_attribute_bylname(NativePtr, localName_pinned.Obj.PinnedPtr, localName_pinned.Length, namespaceURI_pinned.Obj.PinnedPtr, namespaceURI_pinned.Length);
            localName_pinned.Obj.Free();
            namespaceURI_pinned.Obj.Free();
            return 0 != __retval;
        }

        /// <summary>
        /// Moves the cursor to the first attribute in the current element. Returns
        /// true (1) if the cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToFirstAttribute() {
            return 0 != CfxApi.cfx_xml_reader_move_to_first_attribute(NativePtr);
        }

        /// <summary>
        /// Moves the cursor to the next attribute in the current element. Returns true
        /// (1) if the cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToNextAttribute() {
            return 0 != CfxApi.cfx_xml_reader_move_to_next_attribute(NativePtr);
        }

        /// <summary>
        /// Moves the cursor back to the carrying element. Returns true (1) if the
        /// cursor position was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_xml_reader_capi.h">cef/include/capi/cef_xml_reader_capi.h</see>.
        /// </remarks>
        public bool MoveToCarryingElement() {
            return 0 != CfxApi.cfx_xml_reader_move_to_carrying_element(NativePtr);
        }

        internal override void OnDispose(IntPtr nativePtr) {
            weakCache.Remove(nativePtr);
            base.OnDispose(nativePtr);
        }
    }
}
