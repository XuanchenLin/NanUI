// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium {
    using Event;

    /// <summary>
    /// Callback structure that is passed to CfxV8Value.CreateArrayBuffer.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
    /// </remarks>
    public class CfxV8ArrayBufferReleaseCallback : CfxBaseClient {

        internal static CfxV8ArrayBufferReleaseCallback Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_get_gc_handle(nativePtr);
            return (CfxV8ArrayBufferReleaseCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            release_buffer_native = release_buffer;

            release_buffer_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(release_buffer_native);
        }

        // release_buffer
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void release_buffer_delegate(IntPtr gcHandlePtr, IntPtr buffer);
        private static release_buffer_delegate release_buffer_native;
        private static IntPtr release_buffer_native_ptr;

        internal static void release_buffer(IntPtr gcHandlePtr, IntPtr buffer) {
            var self = (CfxV8ArrayBufferReleaseCallback)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                return;
            }
            var e = new CfxReleaseBufferEventArgs();
            e.m_buffer = buffer;
            self.m_ReleaseBuffer?.Invoke(self, e);
            e.m_isInvalid = true;
        }

        internal CfxV8ArrayBufferReleaseCallback(IntPtr nativePtr) : base(nativePtr) {}
        public CfxV8ArrayBufferReleaseCallback() : base(CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_ctor) {}

        /// <summary>
        /// Called to release |Buffer| when the ArrayBuffer JS object is garbage
        /// collected. |Buffer| is the value that was passed to CreateArrayBuffer along
        /// with this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public event CfxReleaseBufferEventHandler ReleaseBuffer {
            add {
                lock(eventLock) {
                    if(m_ReleaseBuffer == null) {
                        CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_set_callback(NativePtr, 0, release_buffer_native_ptr);
                    }
                    m_ReleaseBuffer += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_ReleaseBuffer -= value;
                    if(m_ReleaseBuffer == null) {
                        CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxReleaseBufferEventHandler m_ReleaseBuffer;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_ReleaseBuffer != null) {
                m_ReleaseBuffer = null;
                CfxApi.V8ArrayBufferReleaseCallback.cfx_v8array_buffer_release_callback_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
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
        public delegate void CfxReleaseBufferEventHandler(object sender, CfxReleaseBufferEventArgs e);

        /// <summary>
        /// Called to release |Buffer| when the ArrayBuffer JS object is garbage
        /// collected. |Buffer| is the value that was passed to CreateArrayBuffer along
        /// with this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_v8_capi.h">cef/include/capi/cef_v8_capi.h</see>.
        /// </remarks>
        public class CfxReleaseBufferEventArgs : CfxEventArgs {

            internal IntPtr m_buffer;

            internal CfxReleaseBufferEventArgs() {}

            /// <summary>
            /// Get the Buffer parameter for the <see cref="CfxV8ArrayBufferReleaseCallback.ReleaseBuffer"/> callback.
            /// </summary>
            public IntPtr Buffer {
                get {
                    CheckAccess();
                    return m_buffer;
                }
            }

            public override string ToString() {
                return String.Format("Buffer={{{0}}}", Buffer);
            }
        }

    }
}
