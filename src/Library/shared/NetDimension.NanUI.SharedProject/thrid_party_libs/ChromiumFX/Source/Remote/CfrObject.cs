// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;

namespace Chromium.Remote {

    /// <summary>
    /// Base class for all remote wrapper classes for CEF structs.
    /// </summary>
    public abstract class CfrObject : IDisposable {

        internal static RemotePtr Unwrap(CfrObject remoteObject) {
            return remoteObject == null ? RemotePtr.Zero : remoteObject.RemotePtr;
        }

        internal static bool CheckConnection(CfrObject obj, RemoteConnection connection) {
            return obj == null || obj.m_remotePtr.connection == connection;
        }


        private RemotePtr m_remotePtr;

        internal CfrObject() { }

        internal CfrObject(RemotePtr remotePtr) {
            m_remotePtr = remotePtr;
        }

        internal void SetRemotePtr(RemotePtr ptr) {
            m_remotePtr = ptr;
        }

        internal RemoteConnection connection {
            get {
                return RemotePtr.connection;
            }
        }

        /// <summary>
        /// Creates a remote call context for the render process this 
        /// object belongs to.
        /// </summary>
        /// <returns></returns>
        public CfxRemoteCallContext CreateRemoteCallContext() {
            return new CfxRemoteCallContext(RemotePtr.connection, 0);
        }

        /// <summary>
        /// Address of the underlying native CEF object
        /// in the render process memory space.
        /// </summary>
        public RemotePtr RemotePtr {
            get {
                if(m_remotePtr == RemotePtr.Zero) {
                    throw new ObjectDisposedException(this.GetType().Name);
                } else {
                    return m_remotePtr;
                }
            }
        }

        internal abstract void OnDispose(RemotePtr nativePtr);

        public void Dispose() {
            if(m_remotePtr != RemotePtr.Zero) {
                m_remotePtr.connection.weakCache.Remove(m_remotePtr.ptr);
                OnDispose(m_remotePtr);
                m_remotePtr = RemotePtr.Zero;
                GC.SuppressFinalize(this);
            }
        }

        ~CfrObject() {
            if(m_remotePtr != RemotePtr.Zero) {
                m_remotePtr.connection.weakCache.Remove(m_remotePtr.ptr);
                OnDispose(m_remotePtr);
                m_remotePtr = RemotePtr.Zero;
            }
        }
    }
}
