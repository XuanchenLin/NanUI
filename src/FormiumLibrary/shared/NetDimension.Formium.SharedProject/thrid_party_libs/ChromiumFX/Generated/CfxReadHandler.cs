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
    /// Structure the client can implement to provide a custom stream reader. The
    /// functions of this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfxReadHandler : CfxBaseClient {

        private static object eventLock = new object();

        internal static void SetNativeCallbacks() {
            read_native = read;
            seek_native = seek;
            tell_native = tell;
            eof_native = eof;
            may_block_native = may_block;

            read_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(read_native);
            seek_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(seek_native);
            tell_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(tell_native);
            eof_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(eof_native);
            may_block_native_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(may_block_native);
        }

        // read
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void read_delegate(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n);
        private static read_delegate read_native;
        private static IntPtr read_native_ptr;

        internal static void read(IntPtr gcHandlePtr, out UIntPtr __retval, IntPtr ptr, UIntPtr size, UIntPtr n) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(UIntPtr);
                return;
            }
            var e = new CfxReadHandlerReadEventArgs();
            e.m_ptr = ptr;
            e.m_size = size;
            e.m_n = n;
            self.m_Read?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = (UIntPtr)e.m_returnValue;
        }

        // seek
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void seek_delegate(IntPtr gcHandlePtr, out int __retval, long offset, int whence);
        private static seek_delegate seek_native;
        private static IntPtr seek_native_ptr;

        internal static void seek(IntPtr gcHandlePtr, out int __retval, long offset, int whence) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                return;
            }
            var e = new CfxSeekEventArgs();
            e.m_offset = offset;
            e.m_whence = whence;
            self.m_Seek?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // tell
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void tell_delegate(IntPtr gcHandlePtr, out long __retval);
        private static tell_delegate tell_native;
        private static IntPtr tell_native_ptr;

        internal static void tell(IntPtr gcHandlePtr, out long __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(long);
                return;
            }
            var e = new CfxTellEventArgs();
            self.m_Tell?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // eof
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void eof_delegate(IntPtr gcHandlePtr, out int __retval);
        private static eof_delegate eof_native;
        private static IntPtr eof_native_ptr;

        internal static void eof(IntPtr gcHandlePtr, out int __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                return;
            }
            var e = new CfxReadHandlerEofEventArgs();
            self.m_Eof?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // may_block
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void may_block_delegate(IntPtr gcHandlePtr, out int __retval);
        private static may_block_delegate may_block_native;
        private static IntPtr may_block_native_ptr;

        internal static void may_block(IntPtr gcHandlePtr, out int __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null || self.CallbacksDisabled) {
                __retval = default(int);
                return;
            }
            var e = new CfxMayBlockEventArgs();
            self.m_MayBlock?.Invoke(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue ? 1 : 0;
        }

        public CfxReadHandler() : base(CfxApi.ReadHandler.cfx_read_handler_ctor) {}

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxReadHandlerReadEventHandler Read {
            add {
                lock(eventLock) {
                    if(m_Read == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 0, read_native_ptr);
                    }
                    m_Read += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Read -= value;
                    if(m_Read == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxReadHandlerReadEventHandler m_Read;

        /// <summary>
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxSeekEventHandler Seek {
            add {
                lock(eventLock) {
                    if(m_Seek == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 1, seek_native_ptr);
                    }
                    m_Seek += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Seek -= value;
                    if(m_Seek == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 1, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxSeekEventHandler m_Seek;

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxTellEventHandler Tell {
            add {
                lock(eventLock) {
                    if(m_Tell == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 2, tell_native_ptr);
                    }
                    m_Tell += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Tell -= value;
                    if(m_Tell == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 2, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxTellEventHandler m_Tell;

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxReadHandlerEofEventHandler Eof {
            add {
                lock(eventLock) {
                    if(m_Eof == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 3, eof_native_ptr);
                    }
                    m_Eof += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Eof -= value;
                    if(m_Eof == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 3, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxReadHandlerEofEventHandler m_Eof;

        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxMayBlockEventHandler MayBlock {
            add {
                lock(eventLock) {
                    if(m_MayBlock == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 4, may_block_native_ptr);
                    }
                    m_MayBlock += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_MayBlock -= value;
                    if(m_MayBlock == null) {
                        CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxMayBlockEventHandler m_MayBlock;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Read != null) {
                m_Read = null;
                CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_Seek != null) {
                m_Seek = null;
                CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_Tell != null) {
                m_Tell = null;
                CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_Eof != null) {
                m_Eof = null;
                CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_MayBlock != null) {
                m_MayBlock = null;
                CfxApi.ReadHandler.cfx_read_handler_set_callback(NativePtr, 4, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event {

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfxReadHandlerReadEventHandler(object sender, CfxReadHandlerReadEventArgs e);

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxReadHandlerReadEventArgs : CfxEventArgs {

            internal IntPtr m_ptr;
            internal UIntPtr m_size;
            internal UIntPtr m_n;

            internal ulong m_returnValue;
            private bool returnValueSet;

            internal CfxReadHandlerReadEventArgs() {}

            /// <summary>
            /// Get the Ptr parameter for the <see cref="CfxReadHandler.Read"/> callback.
            /// </summary>
            public IntPtr Ptr {
                get {
                    CheckAccess();
                    return m_ptr;
                }
            }
            /// <summary>
            /// Get the Size parameter for the <see cref="CfxReadHandler.Read"/> callback.
            /// </summary>
            public ulong Size {
                get {
                    CheckAccess();
                    return (ulong)m_size;
                }
            }
            /// <summary>
            /// Get the N parameter for the <see cref="CfxReadHandler.Read"/> callback.
            /// </summary>
            public ulong N {
                get {
                    CheckAccess();
                    return (ulong)m_n;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.Read"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(ulong returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Ptr={{{0}}}, Size={{{1}}}, N={{{2}}}", Ptr, Size, N);
            }
        }

        /// <summary>
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfxSeekEventHandler(object sender, CfxSeekEventArgs e);

        /// <summary>
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxSeekEventArgs : CfxEventArgs {

            internal long m_offset;
            internal int m_whence;

            internal int m_returnValue;
            private bool returnValueSet;

            internal CfxSeekEventArgs() {}

            /// <summary>
            /// Get the Offset parameter for the <see cref="CfxReadHandler.Seek"/> callback.
            /// </summary>
            public long Offset {
                get {
                    CheckAccess();
                    return m_offset;
                }
            }
            /// <summary>
            /// Get the Whence parameter for the <see cref="CfxReadHandler.Seek"/> callback.
            /// </summary>
            public int Whence {
                get {
                    CheckAccess();
                    return m_whence;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.Seek"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(int returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }

            public override string ToString() {
                return String.Format("Offset={{{0}}}, Whence={{{1}}}", Offset, Whence);
            }
        }

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfxTellEventHandler(object sender, CfxTellEventArgs e);

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxTellEventArgs : CfxEventArgs {


            internal long m_returnValue;
            private bool returnValueSet;

            internal CfxTellEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.Tell"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(long returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfxReadHandlerEofEventHandler(object sender, CfxReadHandlerEofEventArgs e);

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxReadHandlerEofEventArgs : CfxEventArgs {


            internal int m_returnValue;
            private bool returnValueSet;

            internal CfxReadHandlerEofEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.Eof"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(int returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfxMayBlockEventHandler(object sender, CfxMayBlockEventArgs e);

        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxMayBlockEventArgs : CfxEventArgs {


            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfxMayBlockEventArgs() {}

            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.MayBlock"/> callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                CheckAccess();
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                returnValueSet = true;
                this.m_returnValue = returnValue;
            }
        }

    }
}
