// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxXmlReaderCreateRemoteCall : RemoteCall {

        internal CfxXmlReaderCreateRemoteCall()
            : base(RemoteCallId.CfxXmlReaderCreateRemoteCall) {}

        internal IntPtr stream;
        internal int encodingType;
        internal string uri;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(stream);
            h.Write(encodingType);
            h.Write(uri);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out stream);
            h.Read(out encodingType);
            h.Read(out uri);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var uri_pinned = new PinnedString(uri);
            __retval = CfxApi.XmlReader.cfx_xml_reader_create(stream, (int)encodingType, uri_pinned.Obj.PinnedPtr, uri_pinned.Length);
            uri_pinned.Obj.Free();
        }
    }

    internal class CfxXmlReaderMoveToNextNodeRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToNextNodeRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToNextNodeRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_next_node(@this);
        }
    }

    internal class CfxXmlReaderCloseRemoteCall : RemoteCall {

        internal CfxXmlReaderCloseRemoteCall()
            : base(RemoteCallId.CfxXmlReaderCloseRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_close(@this);
        }
    }

    internal class CfxXmlReaderHasErrorRemoteCall : RemoteCall {

        internal CfxXmlReaderHasErrorRemoteCall()
            : base(RemoteCallId.CfxXmlReaderHasErrorRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_has_error(@this);
        }
    }

    internal class CfxXmlReaderGetErrorRemoteCall : RemoteCall {

        internal CfxXmlReaderGetErrorRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetErrorRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_error(@this));
        }
    }

    internal class CfxXmlReaderGetTypeRemoteCall : RemoteCall {

        internal CfxXmlReaderGetTypeRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetTypeRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.XmlReader.cfx_xml_reader_get_type(@this);
        }
    }

    internal class CfxXmlReaderGetDepthRemoteCall : RemoteCall {

        internal CfxXmlReaderGetDepthRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetDepthRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.XmlReader.cfx_xml_reader_get_depth(@this);
        }
    }

    internal class CfxXmlReaderGetLocalNameRemoteCall : RemoteCall {

        internal CfxXmlReaderGetLocalNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetLocalNameRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_local_name(@this));
        }
    }

    internal class CfxXmlReaderGetPrefixRemoteCall : RemoteCall {

        internal CfxXmlReaderGetPrefixRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetPrefixRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_prefix(@this));
        }
    }

    internal class CfxXmlReaderGetQualifiedNameRemoteCall : RemoteCall {

        internal CfxXmlReaderGetQualifiedNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetQualifiedNameRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_qualified_name(@this));
        }
    }

    internal class CfxXmlReaderGetNamespaceUriRemoteCall : RemoteCall {

        internal CfxXmlReaderGetNamespaceUriRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetNamespaceUriRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_namespace_uri(@this));
        }
    }

    internal class CfxXmlReaderGetBaseUriRemoteCall : RemoteCall {

        internal CfxXmlReaderGetBaseUriRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetBaseUriRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_base_uri(@this));
        }
    }

    internal class CfxXmlReaderGetXmlLangRemoteCall : RemoteCall {

        internal CfxXmlReaderGetXmlLangRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetXmlLangRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_xml_lang(@this));
        }
    }

    internal class CfxXmlReaderIsEmptyElementRemoteCall : RemoteCall {

        internal CfxXmlReaderIsEmptyElementRemoteCall()
            : base(RemoteCallId.CfxXmlReaderIsEmptyElementRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_is_empty_element(@this);
        }
    }

    internal class CfxXmlReaderHasValueRemoteCall : RemoteCall {

        internal CfxXmlReaderHasValueRemoteCall()
            : base(RemoteCallId.CfxXmlReaderHasValueRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_has_value(@this);
        }
    }

    internal class CfxXmlReaderGetValueRemoteCall : RemoteCall {

        internal CfxXmlReaderGetValueRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetValueRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_value(@this));
        }
    }

    internal class CfxXmlReaderHasAttributesRemoteCall : RemoteCall {

        internal CfxXmlReaderHasAttributesRemoteCall()
            : base(RemoteCallId.CfxXmlReaderHasAttributesRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_has_attributes(@this);
        }
    }

    internal class CfxXmlReaderGetAttributeCountRemoteCall : RemoteCall {

        internal CfxXmlReaderGetAttributeCountRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetAttributeCountRemoteCall) {}

        internal IntPtr @this;
        internal ulong __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = (ulong)CfxApi.XmlReader.cfx_xml_reader_get_attribute_count(@this);
        }
    }

    internal class CfxXmlReaderGetAttributeByIndexRemoteCall : RemoteCall {

        internal CfxXmlReaderGetAttributeByIndexRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetAttributeByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_attribute_byindex(@this, index));
        }
    }

    internal class CfxXmlReaderGetAttributeByQNameRemoteCall : RemoteCall {

        internal CfxXmlReaderGetAttributeByQNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetAttributeByQNameRemoteCall) {}

        internal IntPtr @this;
        internal string qualifiedName;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(qualifiedName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out qualifiedName);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var qualifiedName_pinned = new PinnedString(qualifiedName);
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_attribute_byqname(@this, qualifiedName_pinned.Obj.PinnedPtr, qualifiedName_pinned.Length));
            qualifiedName_pinned.Obj.Free();
        }
    }

    internal class CfxXmlReaderGetAttributeByLNameRemoteCall : RemoteCall {

        internal CfxXmlReaderGetAttributeByLNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetAttributeByLNameRemoteCall) {}

        internal IntPtr @this;
        internal string localName;
        internal string namespaceURI;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(localName);
            h.Write(namespaceURI);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out localName);
            h.Read(out namespaceURI);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var localName_pinned = new PinnedString(localName);
            var namespaceURI_pinned = new PinnedString(namespaceURI);
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_attribute_bylname(@this, localName_pinned.Obj.PinnedPtr, localName_pinned.Length, namespaceURI_pinned.Obj.PinnedPtr, namespaceURI_pinned.Length));
            localName_pinned.Obj.Free();
            namespaceURI_pinned.Obj.Free();
        }
    }

    internal class CfxXmlReaderGetInnerXmlRemoteCall : RemoteCall {

        internal CfxXmlReaderGetInnerXmlRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetInnerXmlRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_inner_xml(@this));
        }
    }

    internal class CfxXmlReaderGetOuterXmlRemoteCall : RemoteCall {

        internal CfxXmlReaderGetOuterXmlRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetOuterXmlRemoteCall) {}

        internal IntPtr @this;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.XmlReader.cfx_xml_reader_get_outer_xml(@this));
        }
    }

    internal class CfxXmlReaderGetLineNumberRemoteCall : RemoteCall {

        internal CfxXmlReaderGetLineNumberRemoteCall()
            : base(RemoteCallId.CfxXmlReaderGetLineNumberRemoteCall) {}

        internal IntPtr @this;
        internal int __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.XmlReader.cfx_xml_reader_get_line_number(@this);
        }
    }

    internal class CfxXmlReaderMoveToAttributeByIndexRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToAttributeByIndexRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToAttributeByIndexRemoteCall) {}

        internal IntPtr @this;
        internal int index;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(index);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out index);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byindex(@this, index);
        }
    }

    internal class CfxXmlReaderMoveToAttributeByQNameRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToAttributeByQNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToAttributeByQNameRemoteCall) {}

        internal IntPtr @this;
        internal string qualifiedName;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(qualifiedName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out qualifiedName);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var qualifiedName_pinned = new PinnedString(qualifiedName);
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_byqname(@this, qualifiedName_pinned.Obj.PinnedPtr, qualifiedName_pinned.Length);
            qualifiedName_pinned.Obj.Free();
        }
    }

    internal class CfxXmlReaderMoveToAttributeByLNameRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToAttributeByLNameRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToAttributeByLNameRemoteCall) {}

        internal IntPtr @this;
        internal string localName;
        internal string namespaceURI;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(localName);
            h.Write(namespaceURI);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out localName);
            h.Read(out namespaceURI);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var localName_pinned = new PinnedString(localName);
            var namespaceURI_pinned = new PinnedString(namespaceURI);
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_attribute_bylname(@this, localName_pinned.Obj.PinnedPtr, localName_pinned.Length, namespaceURI_pinned.Obj.PinnedPtr, namespaceURI_pinned.Length);
            localName_pinned.Obj.Free();
            namespaceURI_pinned.Obj.Free();
        }
    }

    internal class CfxXmlReaderMoveToFirstAttributeRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToFirstAttributeRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToFirstAttributeRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_first_attribute(@this);
        }
    }

    internal class CfxXmlReaderMoveToNextAttributeRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToNextAttributeRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToNextAttributeRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_next_attribute(@this);
        }
    }

    internal class CfxXmlReaderMoveToCarryingElementRemoteCall : RemoteCall {

        internal CfxXmlReaderMoveToCarryingElementRemoteCall()
            : base(RemoteCallId.CfxXmlReaderMoveToCarryingElementRemoteCall) {}

        internal IntPtr @this;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.XmlReader.cfx_xml_reader_move_to_carrying_element(@this);
        }
    }

}
