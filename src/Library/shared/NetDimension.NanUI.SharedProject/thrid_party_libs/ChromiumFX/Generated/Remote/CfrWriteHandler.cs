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
    /// Structure the client can implement to provide a custom stream writer. The
    /// functions of this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfrWriteHandler : CfrBaseClient {


        private CfrWriteHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrWriteHandler() : base(new CfxWriteHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrWriteEventHandler Write {
            add {
                if(m_Write == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Write += value;
            }
            remove {
                m_Write -= value;
                if(m_Write == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrWriteEventHandler m_Write;


        /// <summary>
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrSeekEventHandler Seek {
            add {
                if(m_Seek == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Seek += value;
            }
            remove {
                m_Seek -= value;
                if(m_Seek == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrSeekEventHandler m_Seek;


        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrTellEventHandler Tell {
            add {
                if(m_Tell == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Tell += value;
            }
            remove {
                m_Tell -= value;
                if(m_Tell == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrTellEventHandler m_Tell;


        /// <summary>
        /// Flush the stream.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrFlushEventHandler Flush {
            add {
                if(m_Flush == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Flush += value;
            }
            remove {
                m_Flush -= value;
                if(m_Flush == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrFlushEventHandler m_Flush;


        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrMayBlockEventHandler MayBlock {
            add {
                if(m_MayBlock == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_MayBlock += value;
            }
            remove {
                m_MayBlock -= value;
                if(m_MayBlock == null) {
                    var call = new CfxWriteHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrMayBlockEventHandler m_MayBlock;


    }

    namespace Event {

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrWriteEventHandler(object sender, CfrWriteEventArgs e);

        /// <summary>
        /// Write raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfrWriteEventArgs : CfrEventArgs {

            private CfxWriteHandlerWriteRemoteEventCall call;


            internal ulong m_returnValue;
            private bool returnValueSet;

            internal CfrWriteEventArgs(CfxWriteHandlerWriteRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Ptr parameter for the <see cref="CfrWriteHandler.Write"/> render process callback.
            /// </summary>
            public RemotePtr Ptr {
                get {
                    CheckAccess();
                    return new RemotePtr(connection, call.ptr);
                }
            }
            /// <summary>
            /// Get the Size parameter for the <see cref="CfrWriteHandler.Write"/> render process callback.
            /// </summary>
            public ulong Size {
                get {
                    CheckAccess();
                    return (ulong)call.size;
                }
            }
            /// <summary>
            /// Get the N parameter for the <see cref="CfrWriteHandler.Write"/> render process callback.
            /// </summary>
            public ulong N {
                get {
                    CheckAccess();
                    return (ulong)call.n;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrWriteHandler.Write"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(ulong returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }

            public override string ToString() {
                return String.Format("Ptr={{{0}}}, Size={{{1}}}, N={{{2}}}", Ptr, Size, N);
            }
        }



        /// <summary>
        /// Flush the stream.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrFlushEventHandler(object sender, CfrFlushEventArgs e);

        /// <summary>
        /// Flush the stream.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfrFlushEventArgs : CfrEventArgs {

            private CfxWriteHandlerFlushRemoteEventCall call;


            internal int m_returnValue;
            private bool returnValueSet;

            internal CfrFlushEventArgs(CfxWriteHandlerFlushRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrWriteHandler.Flush"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(int returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }


    }
}
