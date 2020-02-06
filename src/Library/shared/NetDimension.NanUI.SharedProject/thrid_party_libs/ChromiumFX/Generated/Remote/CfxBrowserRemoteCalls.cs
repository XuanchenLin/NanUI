// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxBrowserCanGoBackRemoteCall : RemoteCall {

        internal CfxBrowserCanGoBackRemoteCall()
            : base(RemoteCallId.CfxBrowserCanGoBackRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_can_go_back(@this);
        }
    }

    internal class CfxBrowserGoBackRemoteCall : RemoteCall {

        internal CfxBrowserGoBackRemoteCall()
            : base(RemoteCallId.CfxBrowserGoBackRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Browser.cfx_browser_go_back(@this);
        }
    }

    internal class CfxBrowserCanGoForwardRemoteCall : RemoteCall {

        internal CfxBrowserCanGoForwardRemoteCall()
            : base(RemoteCallId.CfxBrowserCanGoForwardRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_can_go_forward(@this);
        }
    }

    internal class CfxBrowserGoForwardRemoteCall : RemoteCall {

        internal CfxBrowserGoForwardRemoteCall()
            : base(RemoteCallId.CfxBrowserGoForwardRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Browser.cfx_browser_go_forward(@this);
        }
    }

    internal class CfxBrowserIsLoadingRemoteCall : RemoteCall {

        internal CfxBrowserIsLoadingRemoteCall()
            : base(RemoteCallId.CfxBrowserIsLoadingRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_is_loading(@this);
        }
    }

    internal class CfxBrowserReloadRemoteCall : RemoteCall {

        internal CfxBrowserReloadRemoteCall()
            : base(RemoteCallId.CfxBrowserReloadRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Browser.cfx_browser_reload(@this);
        }
    }

    internal class CfxBrowserReloadIgnoreCacheRemoteCall : RemoteCall {

        internal CfxBrowserReloadIgnoreCacheRemoteCall()
            : base(RemoteCallId.CfxBrowserReloadIgnoreCacheRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Browser.cfx_browser_reload_ignore_cache(@this);
        }
    }

    internal class CfxBrowserStopLoadRemoteCall : RemoteCall {

        internal CfxBrowserStopLoadRemoteCall()
            : base(RemoteCallId.CfxBrowserStopLoadRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Browser.cfx_browser_stop_load(@this);
        }
    }

    internal class CfxBrowserGetIdentifierRemoteCall : RemoteCall {

        internal CfxBrowserGetIdentifierRemoteCall()
            : base(RemoteCallId.CfxBrowserGetIdentifierRemoteCall) {}

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
            __retval = CfxApi.Browser.cfx_browser_get_identifier(@this);
        }
    }

    internal class CfxBrowserIsSameRemoteCall : RemoteCall {

        internal CfxBrowserIsSameRemoteCall()
            : base(RemoteCallId.CfxBrowserIsSameRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_is_same(@this, that);
        }
    }

    internal class CfxBrowserIsPopupRemoteCall : RemoteCall {

        internal CfxBrowserIsPopupRemoteCall()
            : base(RemoteCallId.CfxBrowserIsPopupRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_is_popup(@this);
        }
    }

    internal class CfxBrowserHasDocumentRemoteCall : RemoteCall {

        internal CfxBrowserHasDocumentRemoteCall()
            : base(RemoteCallId.CfxBrowserHasDocumentRemoteCall) {}

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
            __retval = 0 != CfxApi.Browser.cfx_browser_has_document(@this);
        }
    }

    internal class CfxBrowserGetMainFrameRemoteCall : RemoteCall {

        internal CfxBrowserGetMainFrameRemoteCall()
            : base(RemoteCallId.CfxBrowserGetMainFrameRemoteCall) {}

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
            __retval = CfxApi.Browser.cfx_browser_get_main_frame(@this);
        }
    }

    internal class CfxBrowserGetFocusedFrameRemoteCall : RemoteCall {

        internal CfxBrowserGetFocusedFrameRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFocusedFrameRemoteCall) {}

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
            __retval = CfxApi.Browser.cfx_browser_get_focused_frame(@this);
        }
    }

    internal class CfxBrowserGetFrameByIdentifierRemoteCall : RemoteCall {

        internal CfxBrowserGetFrameByIdentifierRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFrameByIdentifierRemoteCall) {}

        internal IntPtr @this;
        internal long identifier;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(identifier);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out identifier);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Browser.cfx_browser_get_frame_byident(@this, identifier);
        }
    }

    internal class CfxBrowserGetFrameRemoteCall : RemoteCall {

        internal CfxBrowserGetFrameRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFrameRemoteCall) {}

        internal IntPtr @this;
        internal string name;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(name);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out name);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var name_pinned = new PinnedString(name);
            __retval = CfxApi.Browser.cfx_browser_get_frame(@this, name_pinned.Obj.PinnedPtr, name_pinned.Length);
            name_pinned.Obj.Free();
        }
    }

    internal class CfxBrowserGetFrameCountRemoteCall : RemoteCall {

        internal CfxBrowserGetFrameCountRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFrameCountRemoteCall) {}

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
            __retval = (ulong)CfxApi.Browser.cfx_browser_get_frame_count(@this);
        }
    }

    internal class CfxBrowserGetFrameIdentifiersRemoteCall : RemoteCall {

        internal CfxBrowserGetFrameIdentifiersRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFrameIdentifiersRemoteCall) {}

        internal IntPtr @this;
        internal long[] __retval;

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
            var identifiersCount = CfxApi.Browser.cfx_browser_get_frame_count(@this);
            __retval = new long[(ulong)identifiersCount];
            if(identifiersCount == UIntPtr.Zero) return;
            var retval_p = new PinnedObject(__retval);
            CfxApi.Browser.cfx_browser_get_frame_identifiers(@this, identifiersCount, retval_p.PinnedPtr);
            retval_p.Free();
        }
    }

    internal class CfxBrowserGetFrameNamesRemoteCall : RemoteCall {

        internal CfxBrowserGetFrameNamesRemoteCall()
            : base(RemoteCallId.CfxBrowserGetFrameNamesRemoteCall) {}

        internal IntPtr @this;
        internal System.Collections.Generic.List<string> __retval;

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
            __retval = new System.Collections.Generic.List<string>();
            var list = StringFunctions.AllocCfxStringList();
            CfxApi.Browser.cfx_browser_get_frame_names(@this, list);
            StringFunctions.CfxStringListCopyToManaged(list, __retval);
            StringFunctions.FreeCfxStringList(list);
        }
    }

}
