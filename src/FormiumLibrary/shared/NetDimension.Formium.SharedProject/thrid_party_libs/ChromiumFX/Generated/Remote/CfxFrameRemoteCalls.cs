// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxFrameIsValidRemoteCall : RemoteCall {

        internal CfxFrameIsValidRemoteCall()
            : base(RemoteCallId.CfxFrameIsValidRemoteCall) {}

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
            __retval = 0 != CfxApi.Frame.cfx_frame_is_valid(@this);
        }
    }

    internal class CfxFrameUndoRemoteCall : RemoteCall {

        internal CfxFrameUndoRemoteCall()
            : base(RemoteCallId.CfxFrameUndoRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_undo(@this);
        }
    }

    internal class CfxFrameRedoRemoteCall : RemoteCall {

        internal CfxFrameRedoRemoteCall()
            : base(RemoteCallId.CfxFrameRedoRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_redo(@this);
        }
    }

    internal class CfxFrameCutRemoteCall : RemoteCall {

        internal CfxFrameCutRemoteCall()
            : base(RemoteCallId.CfxFrameCutRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_cut(@this);
        }
    }

    internal class CfxFrameCopyRemoteCall : RemoteCall {

        internal CfxFrameCopyRemoteCall()
            : base(RemoteCallId.CfxFrameCopyRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_copy(@this);
        }
    }

    internal class CfxFramePasteRemoteCall : RemoteCall {

        internal CfxFramePasteRemoteCall()
            : base(RemoteCallId.CfxFramePasteRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_paste(@this);
        }
    }

    internal class CfxFrameDelRemoteCall : RemoteCall {

        internal CfxFrameDelRemoteCall()
            : base(RemoteCallId.CfxFrameDelRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_del(@this);
        }
    }

    internal class CfxFrameSelectAllRemoteCall : RemoteCall {

        internal CfxFrameSelectAllRemoteCall()
            : base(RemoteCallId.CfxFrameSelectAllRemoteCall) {}

        internal IntPtr @this;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_select_all(@this);
        }
    }

    internal class CfxFrameGetSourceRemoteCall : RemoteCall {

        internal CfxFrameGetSourceRemoteCall()
            : base(RemoteCallId.CfxFrameGetSourceRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out visitor);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_get_source(@this, visitor);
        }
    }

    internal class CfxFrameGetTextRemoteCall : RemoteCall {

        internal CfxFrameGetTextRemoteCall()
            : base(RemoteCallId.CfxFrameGetTextRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out visitor);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_get_text(@this, visitor);
        }
    }

    internal class CfxFrameLoadRequestRemoteCall : RemoteCall {

        internal CfxFrameLoadRequestRemoteCall()
            : base(RemoteCallId.CfxFrameLoadRequestRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr request;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(request);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out request);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_load_request(@this, request);
        }
    }

    internal class CfxFrameLoadUrlRemoteCall : RemoteCall {

        internal CfxFrameLoadUrlRemoteCall()
            : base(RemoteCallId.CfxFrameLoadUrlRemoteCall) {}

        internal IntPtr @this;
        internal string url;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(url);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out url);
        }

        protected override void RemoteProcedure() {
            var url_pinned = new PinnedString(url);
            CfxApi.Frame.cfx_frame_load_url(@this, url_pinned.Obj.PinnedPtr, url_pinned.Length);
            url_pinned.Obj.Free();
        }
    }

    internal class CfxFrameLoadStringRemoteCall : RemoteCall {

        internal CfxFrameLoadStringRemoteCall()
            : base(RemoteCallId.CfxFrameLoadStringRemoteCall) {}

        internal IntPtr @this;
        internal string stringVal;
        internal string url;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(stringVal);
            h.Write(url);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out stringVal);
            h.Read(out url);
        }

        protected override void RemoteProcedure() {
            var stringVal_pinned = new PinnedString(stringVal);
            var url_pinned = new PinnedString(url);
            CfxApi.Frame.cfx_frame_load_string(@this, stringVal_pinned.Obj.PinnedPtr, stringVal_pinned.Length, url_pinned.Obj.PinnedPtr, url_pinned.Length);
            stringVal_pinned.Obj.Free();
            url_pinned.Obj.Free();
        }
    }

    internal class CfxFrameExecuteJavaScriptRemoteCall : RemoteCall {

        internal CfxFrameExecuteJavaScriptRemoteCall()
            : base(RemoteCallId.CfxFrameExecuteJavaScriptRemoteCall) {}

        internal IntPtr @this;
        internal string code;
        internal string scriptUrl;
        internal int startLine;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(code);
            h.Write(scriptUrl);
            h.Write(startLine);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out code);
            h.Read(out scriptUrl);
            h.Read(out startLine);
        }

        protected override void RemoteProcedure() {
            var code_pinned = new PinnedString(code);
            var scriptUrl_pinned = new PinnedString(scriptUrl);
            CfxApi.Frame.cfx_frame_execute_java_script(@this, code_pinned.Obj.PinnedPtr, code_pinned.Length, scriptUrl_pinned.Obj.PinnedPtr, scriptUrl_pinned.Length, startLine);
            code_pinned.Obj.Free();
            scriptUrl_pinned.Obj.Free();
        }
    }

    internal class CfxFrameIsMainRemoteCall : RemoteCall {

        internal CfxFrameIsMainRemoteCall()
            : base(RemoteCallId.CfxFrameIsMainRemoteCall) {}

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
            __retval = 0 != CfxApi.Frame.cfx_frame_is_main(@this);
        }
    }

    internal class CfxFrameIsFocusedRemoteCall : RemoteCall {

        internal CfxFrameIsFocusedRemoteCall()
            : base(RemoteCallId.CfxFrameIsFocusedRemoteCall) {}

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
            __retval = 0 != CfxApi.Frame.cfx_frame_is_focused(@this);
        }
    }

    internal class CfxFrameGetNameRemoteCall : RemoteCall {

        internal CfxFrameGetNameRemoteCall()
            : base(RemoteCallId.CfxFrameGetNameRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Frame.cfx_frame_get_name(@this));
        }
    }

    internal class CfxFrameGetIdentifierRemoteCall : RemoteCall {

        internal CfxFrameGetIdentifierRemoteCall()
            : base(RemoteCallId.CfxFrameGetIdentifierRemoteCall) {}

        internal IntPtr @this;
        internal long __retval;

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
            __retval = CfxApi.Frame.cfx_frame_get_identifier(@this);
        }
    }

    internal class CfxFrameGetParentRemoteCall : RemoteCall {

        internal CfxFrameGetParentRemoteCall()
            : base(RemoteCallId.CfxFrameGetParentRemoteCall) {}

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
            __retval = CfxApi.Frame.cfx_frame_get_parent(@this);
        }
    }

    internal class CfxFrameGetUrlRemoteCall : RemoteCall {

        internal CfxFrameGetUrlRemoteCall()
            : base(RemoteCallId.CfxFrameGetUrlRemoteCall) {}

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
            __retval = StringFunctions.ConvertStringUserfree(CfxApi.Frame.cfx_frame_get_url(@this));
        }
    }

    internal class CfxFrameGetBrowserRemoteCall : RemoteCall {

        internal CfxFrameGetBrowserRemoteCall()
            : base(RemoteCallId.CfxFrameGetBrowserRemoteCall) {}

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
            __retval = CfxApi.Frame.cfx_frame_get_browser(@this);
        }
    }

    internal class CfxFrameGetV8ContextRemoteCall : RemoteCall {

        internal CfxFrameGetV8ContextRemoteCall()
            : base(RemoteCallId.CfxFrameGetV8ContextRemoteCall) {}

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
            __retval = CfxApi.Frame.cfx_frame_get_v8context(@this);
        }
    }

    internal class CfxFrameVisitDomRemoteCall : RemoteCall {

        internal CfxFrameVisitDomRemoteCall()
            : base(RemoteCallId.CfxFrameVisitDomRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr visitor;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(visitor);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out visitor);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_visit_dom(@this, visitor);
        }
    }

    internal class CfxFrameCreateUrlRequestRemoteCall : RemoteCall {

        internal CfxFrameCreateUrlRequestRemoteCall()
            : base(RemoteCallId.CfxFrameCreateUrlRequestRemoteCall) {}

        internal IntPtr @this;
        internal IntPtr request;
        internal IntPtr client;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(request);
            h.Write(client);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out request);
            h.Read(out client);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            __retval = CfxApi.Frame.cfx_frame_create_urlrequest(@this, request, client);
        }
    }

    internal class CfxFrameSendProcessMessageRemoteCall : RemoteCall {

        internal CfxFrameSendProcessMessageRemoteCall()
            : base(RemoteCallId.CfxFrameSendProcessMessageRemoteCall) {}

        internal IntPtr @this;
        internal int targetProcess;
        internal IntPtr message;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(targetProcess);
            h.Write(message);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out targetProcess);
            h.Read(out message);
        }

        protected override void RemoteProcedure() {
            CfxApi.Frame.cfx_frame_send_process_message(@this, (int)targetProcess, message);
        }
    }

}
