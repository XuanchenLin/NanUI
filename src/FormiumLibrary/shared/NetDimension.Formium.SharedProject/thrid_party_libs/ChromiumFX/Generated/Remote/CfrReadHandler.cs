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
    /// Structure the client can implement to provide a custom stream reader. The
    /// functions of this structure may be called on any thread.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
    /// </remarks>
    public class CfrReadHandler : CfrBaseClient {


        private CfrReadHandler(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrReadHandler() : base(new CfxReadHandlerCtorWithGCHandleRemoteCall()) {
            lock(RemotePtr.connection.weakCache) {
                RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
            }
        }

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrReadHandlerReadEventHandler Read {
            add {
                if(m_Read == null) {
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Read += value;
            }
            remove {
                m_Read -= value;
                if(m_Read == null) {
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrReadHandlerReadEventHandler m_Read;


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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrTellEventHandler m_Tell;


        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public event CfrReadHandlerEofEventHandler Eof {
            add {
                if(m_Eof == null) {
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_Eof += value;
            }
            remove {
                m_Eof -= value;
                if(m_Eof == null) {
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 3;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrReadHandlerEofEventHandler m_Eof;


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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
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
                    var call = new CfxReadHandlerSetCallbackRemoteCall();
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
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrReadHandlerReadEventHandler(object sender, CfrReadHandlerReadEventArgs e);

        /// <summary>
        /// Read raw binary data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfrReadHandlerReadEventArgs : CfrEventArgs {

            private CfxReadHandlerReadRemoteEventCall call;


            internal ulong m_returnValue;
            private bool returnValueSet;

            internal CfrReadHandlerReadEventArgs(CfxReadHandlerReadRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Ptr parameter for the <see cref="CfrReadHandler.Read"/> render process callback.
            /// </summary>
            public RemotePtr Ptr {
                get {
                    CheckAccess();
                    return new RemotePtr(connection, call.ptr);
                }
            }
            /// <summary>
            /// Get the Size parameter for the <see cref="CfrReadHandler.Read"/> render process callback.
            /// </summary>
            public ulong Size {
                get {
                    CheckAccess();
                    return (ulong)call.size;
                }
            }
            /// <summary>
            /// Get the N parameter for the <see cref="CfrReadHandler.Read"/> render process callback.
            /// </summary>
            public ulong N {
                get {
                    CheckAccess();
                    return (ulong)call.n;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrReadHandler.Read"/> render process callback.
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
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrSeekEventHandler(object sender, CfrSeekEventArgs e);

        /// <summary>
        /// Seek to the specified offset position. |Whence| may be any one of SEEK_CUR,
        /// SEEK_END or SEEK_SET. Return zero on success and non-zero on failure.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public partial class CfrSeekEventArgs : CfrEventArgs {

            private CfxReadHandlerSeekRemoteEventCall call;


            internal int m_returnValue;
            private bool returnValueSet;

            internal CfrSeekEventArgs(CfxReadHandlerSeekRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Offset parameter for the <see cref="CfrReadHandler.Seek"/> render process callback.
            /// </summary>
            public long Offset {
                get {
                    CheckAccess();
                    return call.offset;
                }
            }
            /// <summary>
            /// Get the Whence parameter for the <see cref="CfrReadHandler.Seek"/> render process callback.
            /// </summary>
            public int Whence {
                get {
                    CheckAccess();
                    return call.whence;
                }
            }
            /// <summary>
            /// Set the return value for the <see cref="CfrReadHandler.Seek"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(int returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
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
        public delegate void CfrTellEventHandler(object sender, CfrTellEventArgs e);

        /// <summary>
        /// Return the current offset position.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public partial class CfrTellEventArgs : CfrEventArgs {

            private CfxReadHandlerTellRemoteEventCall call;


            internal long m_returnValue;
            private bool returnValueSet;

            internal CfrTellEventArgs(CfxReadHandlerTellRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrReadHandler.Tell"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(long returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrReadHandlerEofEventHandler(object sender, CfrReadHandlerEofEventArgs e);

        /// <summary>
        /// Return non-zero if at end of file.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public class CfrReadHandlerEofEventArgs : CfrEventArgs {

            private CfxReadHandlerEofRemoteEventCall call;


            internal int m_returnValue;
            private bool returnValueSet;

            internal CfrReadHandlerEofEventArgs(CfxReadHandlerEofRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrReadHandler.Eof"/> render process callback.
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

        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public delegate void CfrMayBlockEventHandler(object sender, CfrMayBlockEventArgs e);

        /// <summary>
        /// Return true (1) if this handler performs work like accessing the file
        /// system which may block. Used as a hint for determining the thread to access
        /// the handler from.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_stream_capi.h">cef/include/capi/cef_stream_capi.h</see>.
        /// </remarks>
        public partial class CfrMayBlockEventArgs : CfrEventArgs {

            private CfxReadHandlerMayBlockRemoteEventCall call;


            internal bool m_returnValue;
            private bool returnValueSet;

            internal CfrMayBlockEventArgs(CfxReadHandlerMayBlockRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrReadHandler.MayBlock"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(bool returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }

    }
}
