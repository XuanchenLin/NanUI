// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Runtime.InteropServices;

namespace Chromium {
    internal struct PinnedObject {

        public IntPtr PinnedPtr;
        private GCHandle handle;
        
        public PinnedObject(object o) {
            if(o == null) {
                handle = new GCHandle();
                PinnedPtr = IntPtr.Zero;
            } else {
                handle = GCHandle.Alloc(o, GCHandleType.Pinned);
                PinnedPtr = handle.AddrOfPinnedObject();
            }
        }

        public IntPtr GCHandlePtr() {
            return GCHandle.ToIntPtr(handle);
        }

        public void Free() {
            if (PinnedPtr != IntPtr.Zero) {
                handle.Free();
            }
        }

    }
}
