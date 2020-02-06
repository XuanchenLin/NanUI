// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Chromium.Remote {
    /// <summary>
    /// Base class for all remote wrapper classes for CEF client structs.
    /// </summary>
    public abstract class CfrBaseClient : CfrBaseRefCounted {

        //static int cfrTaskCount;

        internal CfrBaseClient(CtorWithGCHandleRemoteCall call) {
            GCHandle handle = GCHandle.Alloc(this, GCHandleType.Weak);
            call.gcHandlePtr = GCHandle.ToIntPtr(handle);
            call.RequestExecution();
            SetRemotePtr(new RemotePtr(CfxRemoteCallContext.CurrentContext.connection, call.__retval));
            //if(this is CfrTask) Debug.Print("CfrTask created: " + System.Threading.Interlocked.Increment(ref cfrTaskCount));
        }

        internal CfrBaseClient(RemotePtr remotePtr) : base(remotePtr) { }

        /// <summary>
        /// When true, all CEF callback events are disabled for this handler. Incoming callbacks will return default values to CEF.
        /// </summary>
        public bool CallbacksDisabled { get; set; }

        internal sealed override void OnDispose(RemotePtr nativePtr) {
            //if(this is CfrTask) Debug.Print("CfrTask disposed: " + System.Threading.Interlocked.Decrement(ref cfrTaskCount));
            CallbacksDisabled = true;
            base.OnDispose(nativePtr);
        }
    }

    internal class SwitchGcHandleRemoteCall : RemoteCall {
        internal IntPtr gc_handle;
        internal int mode;
        internal SwitchGcHandleRemoteCall() : base(RemoteCallId.SwitchGcHandleRemoteCall) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gc_handle);
            h.Write((int)mode);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gc_handle);
            h.Read(out mode);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(gc_handle);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out gc_handle);
        }

        protected override void RemoteProcedure() {
            Debug.Assert((mode & (int)CfxApi.gc_handle_switch_mode.GC_HANDLE_REMOTE) == 0);
            CfxApi.SwitchGcHandle(ref gc_handle, (CfxApi.gc_handle_switch_mode)mode);
        }
    }

    internal class FreeGcHandleRemoteCall : RemoteCall {
        internal IntPtr gc_handle;
        internal FreeGcHandleRemoteCall() : base(RemoteCallId.FreeGcHandleRemoteCall, true) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(gc_handle);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out gc_handle);
        }

        protected override void RemoteProcedure() {
            CfxApi.SwitchGcHandle(ref gc_handle, CfxApi.gc_handle_switch_mode.GC_HANDLE_FREE);
        }
    }
}
