// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;

namespace Chromium.Remote {
    /// <summary>
    /// Marshals a callback from a client in the render process to the browser process.
    /// </summary>
    abstract class RemoteClientCall : RemoteCall {

        private static readonly Dictionary<ulong, object> eventArgs = new Dictionary<ulong, object>();
        private static ulong globalEventArgId;

        internal static ulong AddEventArgs(object o) {
            lock(eventArgs) {
                ++globalEventArgId;
                eventArgs.Add(globalEventArgId, o);
                return globalEventArgId;
            }
        }

        internal static object GetEventArgs(ulong id) {
            lock(eventArgs) {
                return eventArgs[id];
            }
        }

        internal static object RemoveEventArgs(ulong id) {
            lock(eventArgs) {
                var retval = eventArgs[id];
                eventArgs.Remove(id);
                return retval;
            }
        }


        internal IntPtr sender;
        internal ulong eventArgsId;

        internal RemoteClientCall(RemoteCallId callId) : base(callId) { }

        protected override void WriteArgs(StreamHandler h) {
            h.Write(sender);
            h.Write(eventArgsId);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out sender);
            h.Read(out eventArgsId);
        }

    }

    /// <summary>
    /// Marshals a callback from a client in the render process to the browser process.
    /// </summary>
    abstract class RemoteEventCall : RemoteCall {
        internal IntPtr gcHandlePtr;
        internal RemoteEventCall(RemoteCallId callId) : base(callId) { }
    }

    internal abstract class CtorRemoteCall : RemoteCall {
        internal IntPtr __retval;
        internal CtorRemoteCall(RemoteCallId callId) : base(callId) { }
        protected override void WriteReturn(StreamHandler h) { h.Write(__retval); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out __retval); }

    }

    internal abstract class CtorWithGCHandleRemoteCall : CtorRemoteCall {
        internal IntPtr gcHandlePtr;
        internal CtorWithGCHandleRemoteCall(RemoteCallId callId) : base(callId) { }
        protected override void WriteArgs(StreamHandler h) { h.Write(gcHandlePtr); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out gcHandlePtr); }
    }

    internal abstract class DtorRemoteCall : RemoteCall {
        internal IntPtr nativePtr;
        internal DtorRemoteCall(RemoteCallId callId) : base(callId) { }
        protected override void WriteArgs(StreamHandler h) { h.Write(nativePtr); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out nativePtr); }
    }

    internal abstract class SetCallbackRemoteCall : RemoteCall {
        internal IntPtr self;
        internal int index;
        internal bool active;
        internal SetCallbackRemoteCall(RemoteCallId callId) : base(callId) { }
        protected override void WriteArgs(StreamHandler h) { h.Write(self); h.Write(index); h.Write(active); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out self); h.Read(out index); h.Read(out active); }
    }

    internal abstract class GetGcHandleRemoteCall : RemoteCall {
        internal IntPtr self;
        internal IntPtr gc_handle;
        internal GetGcHandleRemoteCall(RemoteCallId callId) : base(callId) { }
        protected override void WriteArgs(StreamHandler h) { h.Write(self); }
        protected override void ReadArgs(StreamHandler h) { h.Read(out self); }
        protected override void WriteReturn(StreamHandler h) { h.Write(gc_handle); }
        protected override void ReadReturn(StreamHandler h) { h.Read(out gc_handle); }
    }
}
