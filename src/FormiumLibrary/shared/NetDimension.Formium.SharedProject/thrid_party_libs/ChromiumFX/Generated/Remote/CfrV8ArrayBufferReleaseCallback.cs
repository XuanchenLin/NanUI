// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Callback structure that is passed to CfrV8Value.CreateArrayBuffer.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfrV8ArrayBufferReleaseCallback : CfrBaseClient {

        internal static CfrV8ArrayBufferReleaseCallback Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var call = new CfxV8ArrayBufferReleaseCallbackGetGcHandleRemoteCall();
            call.self = remotePtr.ptr;
            call.RequestExecution(remotePtr.connection);
            return (CfrV8ArrayBufferReleaseCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(call.gc_handle).Target;
        }



        private CfrV8ArrayBufferReleaseCallback(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrV8ArrayBufferReleaseCallback() : base(new CfxV8ArrayBufferReleaseCallbackCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Called to release |Buffer| when the ArrayBuffer JS object is garbage
        /// collected. |Buffer| is the value that was passed to CreateArrayBuffer along
        /// with this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfrReleaseBufferEventHandler ReleaseBuffer {
            add {
                if(m_ReleaseBuffer == null) {
                    var call = new CfxV8ArrayBufferReleaseCallbackSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_ReleaseBuffer += value;
            }
            remove {
                m_ReleaseBuffer -= value;
                if(m_ReleaseBuffer == null) {
                    var call = new CfxV8ArrayBufferReleaseCallbackSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrReleaseBufferEventHandler m_ReleaseBuffer;


    }

    namespace Event {

        /// <summary>
        /// Called to release |Buffer| when the ArrayBuffer JS object is garbage
        /// collected. |Buffer| is the value that was passed to CreateArrayBuffer along
        /// with this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public delegate void CfrReleaseBufferEventHandler(object sender, CfrReleaseBufferEventArgs e);

        /// <summary>
        /// Called to release |Buffer| when the ArrayBuffer JS object is garbage
        /// collected. |Buffer| is the value that was passed to CreateArrayBuffer along
        /// with this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfrReleaseBufferEventArgs : CfrEventArgs {

            private CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall call;


            internal CfrReleaseBufferEventArgs(CfxV8ArrayBufferReleaseCallbackReleaseBufferRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Buffer parameter for the <see cref="CfrV8ArrayBufferReleaseCallback.ReleaseBuffer"/> render process callback.
            /// </summary>
            public RemotePtr Buffer {
                get {
                    CheckAccess();
                    return new RemotePtr(connection, call.buffer);
                }
            }

            public override string ToString() {
                return String.Format("Buffer={{{0}}}", Buffer);
            }
        }

    }
}
