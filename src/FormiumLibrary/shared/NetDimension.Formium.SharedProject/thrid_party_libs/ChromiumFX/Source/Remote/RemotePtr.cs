// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium.Remote {
    /// <summary>
    /// Represents an IntPtr in the remote process.
    /// </summary>
    public struct RemotePtr {
        /// <summary>
        /// Two remote pointers are equal if both are null or both are of the same value on the same connection.
        /// </summary>
        public static bool operator ==(RemotePtr p1, RemotePtr p2) { return p1.ptr == p2.ptr && (p1.connection == p2.connection || p1.ptr == IntPtr.Zero); }
        public static bool operator !=(RemotePtr p1, RemotePtr p2) { return !(p1.ptr == p2.ptr); }
        public static readonly RemotePtr Zero;

        internal RemoteConnection connection;
        internal IntPtr ptr;

        /// <summary>
        /// The process ID of the remote render process this remote IntPtr belongs to.
        /// </summary>
        public int RemoteProcessId {
            get {
                return connection.remoteProcessId;
            }
        }

        internal RemotePtr(RemoteConnection connection, IntPtr ptr) {
            this.connection = connection;
            this.ptr = ptr;
        }
        public override bool Equals(object obj) {
            return obj is RemotePtr && this == (RemotePtr)obj;
        }
        public override int GetHashCode() {
            if(connection == null) return ptr.GetHashCode();
            return ptr.GetHashCode() ^ connection.GetHashCode();
        }
    }
}
