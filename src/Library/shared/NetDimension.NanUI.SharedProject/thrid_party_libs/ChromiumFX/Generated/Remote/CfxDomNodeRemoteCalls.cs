// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxDomNodeGetTypeRemoteCall : RemoteCall {

        internal CfxDomNodeGetTypeRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetTypeRemoteCall) {}

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
            __retval = CfxApi.DomNode.cfx_domnode_get_type(@this);
        }
    }

    internal class CfxDomNodeIsTextRemoteCall : RemoteCall {

        internal CfxDomNodeIsTextRemoteCall()
            : base(RemoteCallId.CfxDomNodeIsTextRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_is_text(@this);
        }
    }

    internal class CfxDomNodeIsElementRemoteCall : RemoteCall {

        internal CfxDomNodeIsElementRemoteCall()
            : base(RemoteCallId.CfxDomNodeIsElementRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_is_element(@this);
        }
    }

    internal class CfxDomNodeIsEditableRemoteCall : RemoteCall {

        internal CfxDomNodeIsEditableRemoteCall()
            : base(RemoteCallId.CfxDomNodeIsEditableRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_is_editable(@this);
        }
    }

    internal class CfxDomNodeIsFormControlElementRemoteCall : RemoteCall {

        internal CfxDomNodeIsFormControlElementRemoteCall()
            : base(RemoteCallId.CfxDomNodeIsFormControlElementRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_is_form_control_element(@this);
        }
    }

    internal class CfxDomNodeGetFormControlElementTypeRemoteCall : RemoteCall {

        internal CfxDomNodeGetFormControlElementTypeRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetFormControlElementTypeRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_form_control_element_type(@this));
        }
    }

    internal class CfxDomNodeIsSameRemoteCall : RemoteCall {

        internal CfxDomNodeIsSameRemoteCall()
            : base(RemoteCallId.CfxDomNodeIsSameRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr that;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(that);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out that);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = 0 != CfxApi.DomNode.cfx_domnode_is_same(@this, that);
        }
    }

    internal class CfxDomNodeGetNameRemoteCall : RemoteCall {

        internal CfxDomNodeGetNameRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_name(@this));
        }
    }

    internal class CfxDomNodeGetValueRemoteCall : RemoteCall {

        internal CfxDomNodeGetValueRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetValueRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_value(@this));
        }
    }

    internal class CfxDomNodeSetValueRemoteCall : RemoteCall {

        internal CfxDomNodeSetValueRemoteCall()
            : base(RemoteCallId.CfxDomNodeSetValueRemoteCall) {}

        internal IntPtr @this;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var value_pinned = new PinnedString(value);
            __retval = 0 != CfxApi.DomNode.cfx_domnode_set_value(@this, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            value_pinned.Obj.Free();
        }
    }

    internal class CfxDomNodeGetAsMarkupRemoteCall : RemoteCall {

        internal CfxDomNodeGetAsMarkupRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetAsMarkupRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_as_markup(@this));
        }
    }

    internal class CfxDomNodeGetDocumentRemoteCall : RemoteCall {

        internal CfxDomNodeGetDocumentRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetDocumentRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_document(@this);
        }
    }

    internal class CfxDomNodeGetParentRemoteCall : RemoteCall {

        internal CfxDomNodeGetParentRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetParentRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_parent(@this);
        }
    }

    internal class CfxDomNodeGetPreviousSiblingRemoteCall : RemoteCall {

        internal CfxDomNodeGetPreviousSiblingRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetPreviousSiblingRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_previous_sibling(@this);
        }
    }

    internal class CfxDomNodeGetNextSiblingRemoteCall : RemoteCall {

        internal CfxDomNodeGetNextSiblingRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetNextSiblingRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_next_sibling(@this);
        }
    }

    internal class CfxDomNodeHasChildrenRemoteCall : RemoteCall {

        internal CfxDomNodeHasChildrenRemoteCall()
            : base(RemoteCallId.CfxDomNodeHasChildrenRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_has_children(@this);
        }
    }

    internal class CfxDomNodeGetFirstChildRemoteCall : RemoteCall {

        internal CfxDomNodeGetFirstChildRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetFirstChildRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_first_child(@this);
        }
    }

    internal class CfxDomNodeGetLastChildRemoteCall : RemoteCall {

        internal CfxDomNodeGetLastChildRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetLastChildRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_last_child(@this);
        }
    }

    internal class CfxDomNodeGetElementTagNameRemoteCall : RemoteCall {

        internal CfxDomNodeGetElementTagNameRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetElementTagNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_element_tag_name(@this));
        }
    }

    internal class CfxDomNodeHasElementAttributesRemoteCall : RemoteCall {

        internal CfxDomNodeHasElementAttributesRemoteCall()
            : base(RemoteCallId.CfxDomNodeHasElementAttributesRemoteCall) {}

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
            __retval = 0 != CfxApi.DomNode.cfx_domnode_has_element_attributes(@this);
        }
    }

    internal class CfxDomNodeHasElementAttributeRemoteCall : RemoteCall {

        internal CfxDomNodeHasElementAttributeRemoteCall()
            : base(RemoteCallId.CfxDomNodeHasElementAttributeRemoteCall) {}

        internal IntPtr @this;
        internal string attrName;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(attrName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out attrName);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var attrName_pinned = new PinnedString(attrName);
            __retval = 0 != CfxApi.DomNode.cfx_domnode_has_element_attribute(@this, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length);
            attrName_pinned.Obj.Free();
        }
    }

    internal class CfxDomNodeGetElementAttributeRemoteCall : RemoteCall {

        internal CfxDomNodeGetElementAttributeRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetElementAttributeRemoteCall) {}

        internal IntPtr @this;
        internal string attrName;
        internal string __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(attrName);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out attrName);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var attrName_pinned = new PinnedString(attrName);
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_element_attribute(@this, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length));
            attrName_pinned.Obj.Free();
        }
    }

    internal class CfxDomNodeGetElementAttributesRemoteCall : RemoteCall {

        internal CfxDomNodeGetElementAttributesRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetElementAttributesRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string[]> __retval;

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
            __retval = new System.Collections.Generic.List<string[]>();
            var list = StringFunctions.AllocCfxStringMap();
            CfxApi.DomNode.cfx_domnode_get_element_attributes(@this, list);
            StringFunctions.CfxStringMapCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringMap(list);
        }
    }

    internal class CfxDomNodeSetElementAttributeRemoteCall : RemoteCall {

        internal CfxDomNodeSetElementAttributeRemoteCall()
            : base(RemoteCallId.CfxDomNodeSetElementAttributeRemoteCall) {}

        internal IntPtr @this;
        internal string attrName;
        internal string value;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(attrName);
            h.Write(value);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out attrName);
            h.Read(out value);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var attrName_pinned = new PinnedString(attrName);
            var value_pinned = new PinnedString(value);
            __retval = 0 != CfxApi.DomNode.cfx_domnode_set_element_attribute(@this, attrName_pinned.Obj.PinnedPtr, attrName_pinned.Length, value_pinned.Obj.PinnedPtr, value_pinned.Length);
            attrName_pinned.Obj.Free();
            value_pinned.Obj.Free();
        }
    }

    internal class CfxDomNodeGetElementInnerTextRemoteCall : RemoteCall {

        internal CfxDomNodeGetElementInnerTextRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetElementInnerTextRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.DomNode.cfx_domnode_get_element_inner_text(@this));
        }
    }

    internal class CfxDomNodeGetElementBoundsRemoteCall : RemoteCall {

        internal CfxDomNodeGetElementBoundsRemoteCall()
            : base(RemoteCallId.CfxDomNodeGetElementBoundsRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr __retval;

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
            __retval = CfxApi.DomNode.cfx_domnode_get_element_bounds(@this);
        }
    }

}
