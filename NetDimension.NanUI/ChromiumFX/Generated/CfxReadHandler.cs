// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium
{
	using Event;

	/// <summary>
	/// Structure the client can implement to provide a custom stream reader. The
	/// functions of this structure may be called on any thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
	/// </remarks>
	public class CfxReadHandler : CfxBase {

        static CfxReadHandler () {
            CfxApiLoader.LoadCfxReadHandlerApi();
        }

        internal static CfxReadHandler Wrap(IntPtr nativePtr) {
            if(nativePtr == IntPtr.Zero) return null;
            var handlePtr = CfxApi.cfx_read_handler_get_gc_handle(nativePtr);
            return (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(handlePtr).Target;
        }


        private static object eventLock = new object();

        // read
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_read_handler_read_delegate(IntPtr gcHandlePtr, out int __retval, IntPtr ptr, int size, int n);
        private static cfx_read_handler_read_delegate cfx_read_handler_read;
        private static IntPtr cfx_read_handler_read_ptr;

        internal static void read(IntPtr gcHandlePtr, out int __retval, IntPtr ptr, int size, int n) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxReadEventArgs(ptr, size, n);
            var eventHandler = self.m_Read;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // seek
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_read_handler_seek_delegate(IntPtr gcHandlePtr, out int __retval, long offset, int whence);
        private static cfx_read_handler_seek_delegate cfx_read_handler_seek;
        private static IntPtr cfx_read_handler_seek_ptr;

        internal static void seek(IntPtr gcHandlePtr, out int __retval, long offset, int whence) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxSeekEventArgs(offset, whence);
            var eventHandler = self.m_Seek;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // tell
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_read_handler_tell_delegate(IntPtr gcHandlePtr, out long __retval);
        private static cfx_read_handler_tell_delegate cfx_read_handler_tell;
        private static IntPtr cfx_read_handler_tell_ptr;

        internal static void tell(IntPtr gcHandlePtr, out long __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(long);
                return;
            }
            var e = new CfxTellEventArgs();
            var eventHandler = self.m_Tell;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // eof
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_read_handler_eof_delegate(IntPtr gcHandlePtr, out int __retval);
        private static cfx_read_handler_eof_delegate cfx_read_handler_eof;
        private static IntPtr cfx_read_handler_eof_ptr;

        internal static void eof(IntPtr gcHandlePtr, out int __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxReadHandlerEofEventArgs();
            var eventHandler = self.m_Eof;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue;
        }

        // may_block
        [System.Runtime.InteropServices.UnmanagedFunctionPointer(System.Runtime.InteropServices.CallingConvention.StdCall, SetLastError = false)]
        private delegate void cfx_read_handler_may_block_delegate(IntPtr gcHandlePtr, out int __retval);
        private static cfx_read_handler_may_block_delegate cfx_read_handler_may_block;
        private static IntPtr cfx_read_handler_may_block_ptr;

        internal static void may_block(IntPtr gcHandlePtr, out int __retval) {
            var self = (CfxReadHandler)System.Runtime.InteropServices.GCHandle.FromIntPtr(gcHandlePtr).Target;
            if(self == null) {
                __retval = default(int);
                return;
            }
            var e = new CfxMayBlockEventArgs();
            var eventHandler = self.m_MayBlock;
            if(eventHandler != null) eventHandler(self, e);
            e.m_isInvalid = true;
            __retval = e.m_returnValue ? 1 : 0;
        }

        internal CfxReadHandler(IntPtr nativePtr) : base(nativePtr) {}
        public CfxReadHandler() : base(CfxApi.cfx_read_handler_ctor) {}

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfxReadEventHandler Read {
            add {
                lock(eventLock) {
                    if(m_Read == null) {
                        if(cfx_read_handler_read == null) {
                            cfx_read_handler_read = read;
                            cfx_read_handler_read_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_read_handler_read);
                        }
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 0, cfx_read_handler_read_ptr);
                    }
                    m_Read += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Read -= value;
                    if(m_Read == null) {
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxReadEventHandler m_Read;

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
                        if(cfx_read_handler_seek == null) {
                            cfx_read_handler_seek = seek;
                            cfx_read_handler_seek_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_read_handler_seek);
                        }
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 1, cfx_read_handler_seek_ptr);
                    }
                    m_Seek += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Seek -= value;
                    if(m_Seek == null) {
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
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
                        if(cfx_read_handler_tell == null) {
                            cfx_read_handler_tell = tell;
                            cfx_read_handler_tell_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_read_handler_tell);
                        }
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 2, cfx_read_handler_tell_ptr);
                    }
                    m_Tell += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Tell -= value;
                    if(m_Tell == null) {
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
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
                        if(cfx_read_handler_eof == null) {
                            cfx_read_handler_eof = eof;
                            cfx_read_handler_eof_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_read_handler_eof);
                        }
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 3, cfx_read_handler_eof_ptr);
                    }
                    m_Eof += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_Eof -= value;
                    if(m_Eof == null) {
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
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
                        if(cfx_read_handler_may_block == null) {
                            cfx_read_handler_may_block = may_block;
                            cfx_read_handler_may_block_ptr = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(cfx_read_handler_may_block);
                        }
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 4, cfx_read_handler_may_block_ptr);
                    }
                    m_MayBlock += value;
                }
            }
            remove {
                lock(eventLock) {
                    m_MayBlock -= value;
                    if(m_MayBlock == null) {
                        CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
                    }
                }
            }
        }

        private CfxMayBlockEventHandler m_MayBlock;

        internal override void OnDispose(IntPtr nativePtr) {
            if(m_Read != null) {
                m_Read = null;
                CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 0, IntPtr.Zero);
            }
            if(m_Seek != null) {
                m_Seek = null;
                CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 1, IntPtr.Zero);
            }
            if(m_Tell != null) {
                m_Tell = null;
                CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 2, IntPtr.Zero);
            }
            if(m_Eof != null) {
                m_Eof = null;
                CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 3, IntPtr.Zero);
            }
            if(m_MayBlock != null) {
                m_MayBlock = null;
                CfxApi.cfx_read_handler_set_managed_callback(NativePtr, 4, IntPtr.Zero);
            }
            base.OnDispose(nativePtr);
        }
    }


    namespace Event
	{

		/// <summary>
		/// Read raw binary data.
		/// </summary>
		/// <remarks>
		/// See also the original CEF documentation in
		/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
		/// </remarks>
		public delegate void CfxReadEventHandler(object sender, CfxReadEventArgs e);

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfxReadEventArgs : CfxEventArgs {

            internal IntPtr m_ptr;
            internal int m_size;
            internal int m_n;

            internal int m_returnValue;
            private bool returnValueSet;

            internal CfxReadEventArgs(IntPtr ptr, int size, int n) {
                m_ptr = ptr;
                m_size = size;
                m_n = n;
            }

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
            public int Size {
                get {
                    CheckAccess();
                    return m_size;
                }
            }
            /// <summary>
            /// Get the N parameter for the <see cref="CfxReadHandler.Read"/> callback.
            /// </summary>
            public int N {
                get {
                    CheckAccess();
                    return m_n;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfxReadHandler.Read"/> callback.
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

            internal CfxSeekEventArgs(long offset, int whence) {
                m_offset = offset;
                m_whence = whence;
            }

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

            internal CfxTellEventArgs() {
            }

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

            internal CfxReadHandlerEofEventArgs() {
            }

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

            internal CfxMayBlockEventArgs() {
            }

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
