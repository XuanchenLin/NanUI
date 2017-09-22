// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxRectCtorRemoteCall : CtorRemoteCall {

        internal CfxRectCtorRemoteCall()
            : base(RemoteCallId.CfxRectCtorRemoteCall) {}

        protected override void RemoteProcedure() {
            __retval = CfxApi.Rect.cfx_rect_ctor();
        }
    }

    internal class CfxRectDtorRemoteCall : DtorRemoteCall {

        internal CfxRectDtorRemoteCall()
            : base(RemoteCallId.CfxRectDtorRemoteCall) {}

        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_dtor(nativePtr);
        }
    }

    internal class CfxRectGetXRemoteCall : RemoteCall {

        internal CfxRectGetXRemoteCall()
            : base(RemoteCallId.CfxRectGetXRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_get_x(sender, out value);
        }
    }
    internal class CfxRectSetXRemoteCall : RemoteCall {

        internal CfxRectSetXRemoteCall()
            : base(RemoteCallId.CfxRectSetXRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_set_x(sender, value);
        }
    }
    internal class CfxRectGetYRemoteCall : RemoteCall {

        internal CfxRectGetYRemoteCall()
            : base(RemoteCallId.CfxRectGetYRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_get_y(sender, out value);
        }
    }
    internal class CfxRectSetYRemoteCall : RemoteCall {

        internal CfxRectSetYRemoteCall()
            : base(RemoteCallId.CfxRectSetYRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_set_y(sender, value);
        }
    }
    internal class CfxRectGetWidthRemoteCall : RemoteCall {

        internal CfxRectGetWidthRemoteCall()
            : base(RemoteCallId.CfxRectGetWidthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_get_width(sender, out value);
        }
    }
    internal class CfxRectSetWidthRemoteCall : RemoteCall {

        internal CfxRectSetWidthRemoteCall()
            : base(RemoteCallId.CfxRectSetWidthRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_set_width(sender, value);
        }
    }
    internal class CfxRectGetHeightRemoteCall : RemoteCall {

        internal CfxRectGetHeightRemoteCall()
            : base(RemoteCallId.CfxRectGetHeightRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); }
        protected override void WriteReturn(StreamHandler h) { h.Write(value); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_get_height(sender, out value);
        }
    }
    internal class CfxRectSetHeightRemoteCall : RemoteCall {

        internal CfxRectSetHeightRemoteCall()
            : base(RemoteCallId.CfxRectSetHeightRemoteCall) {}
        internal IntPtr sender;
        internal int value;
        protected override void WriteArgs(StreamHandler h) { h.Write(sender); h.Write(value); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out sender); h.Read(out value); }
        protected override void RemoteProcedure() {
            CfxApi.Rect.cfx_rect_set_height(sender, value);
        }
    }
}
