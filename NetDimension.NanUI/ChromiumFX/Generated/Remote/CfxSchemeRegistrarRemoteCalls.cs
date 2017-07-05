// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    internal class CfxSchemeRegistrarAddCustomSchemeRemoteCall : RemoteCall {

        internal CfxSchemeRegistrarAddCustomSchemeRemoteCall()
            : base(RemoteCallId.CfxSchemeRegistrarAddCustomSchemeRemoteCall) {}

        internal IntPtr @this;
        internal string schemeName;
        internal bool isStandard;
        internal bool isLocal;
        internal bool isDisplayIsolated;
        internal bool isSecure;
        internal bool isCorsEnabled;
        internal bool __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(@this);
            h.Write(schemeName);
            h.Write(isStandard);
            h.Write(isLocal);
            h.Write(isDisplayIsolated);
            h.Write(isSecure);
            h.Write(isCorsEnabled);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out @this);
            h.Read(out schemeName);
            h.Read(out isStandard);
            h.Read(out isLocal);
            h.Read(out isDisplayIsolated);
            h.Read(out isSecure);
            h.Read(out isCorsEnabled);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            var schemeName_pinned = new PinnedString(schemeName);
            __retval = 0 != CfxApi.SchemeRegistrar.cfx_scheme_registrar_add_custom_scheme(@this, schemeName_pinned.Obj.PinnedPtr, schemeName_pinned.Length, isStandard ? 1 : 0, isLocal ? 1 : 0, isDisplayIsolated ? 1 : 0, isSecure ? 1 : 0, isCorsEnabled ? 1 : 0);
            schemeName_pinned.Obj.Free();
        }
    }

}
