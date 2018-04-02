// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {

    /// <summary>
    /// Structure representing a rectangle.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/internal/cef_types.h">cef/include/internal/cef_types.h</see>.
    /// </remarks>
    public sealed class CfrRect : CfrStructure {

        internal static CfrRect Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            return (CfrRect)weakCache.GetOrAdd(remotePtr.ptr, () => new CfrRect(remotePtr));
        }


        private CfrRect(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrRect() : base(new CfxRectCtorRemoteCall(), new CfxRectDtorRemoteCall()) {}

        int m_X;
        bool m_X_fetched;

        public int X {
            get {
                if(!m_X_fetched) {
                    var call = new CfxRectGetXRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_X = call.value;
                    m_X_fetched = true;
                }
                return m_X;
            }
            set {
                var call = new CfxRectSetXRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_X = value;
                m_X_fetched = true;
            }
        }

        int m_Y;
        bool m_Y_fetched;

        public int Y {
            get {
                if(!m_Y_fetched) {
                    var call = new CfxRectGetYRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Y = call.value;
                    m_Y_fetched = true;
                }
                return m_Y;
            }
            set {
                var call = new CfxRectSetYRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Y = value;
                m_Y_fetched = true;
            }
        }

        int m_Width;
        bool m_Width_fetched;

        public int Width {
            get {
                if(!m_Width_fetched) {
                    var call = new CfxRectGetWidthRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Width = call.value;
                    m_Width_fetched = true;
                }
                return m_Width;
            }
            set {
                var call = new CfxRectSetWidthRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Width = value;
                m_Width_fetched = true;
            }
        }

        int m_Height;
        bool m_Height_fetched;

        public int Height {
            get {
                if(!m_Height_fetched) {
                    var call = new CfxRectGetHeightRemoteCall();
                    call.sender = RemotePtr.ptr;
                    call.RequestExecution(RemotePtr.connection);
                    m_Height = call.value;
                    m_Height_fetched = true;
                }
                return m_Height;
            }
            set {
                var call = new CfxRectSetHeightRemoteCall();
                call.sender = RemotePtr.ptr;
                call.value = value;
                call.RequestExecution(RemotePtr.connection);
                m_Height = value;
                m_Height_fetched = true;
            }
        }
    }
}
