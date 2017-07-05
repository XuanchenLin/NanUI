// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {

    /// <summary>
    /// Base class for all wrapper classes for CEF structs.
    /// </summary>
    public abstract class CfxObject : IDisposable {

        private IntPtr m_nativePtr;
                
        internal CfxObject() {}

        internal CfxObject(IntPtr nativePtr) {
            this.m_nativePtr = nativePtr;
        }

        internal void SetNative(IntPtr nativePtr) {
            m_nativePtr = nativePtr;
        }

        internal IntPtr nativePtrUnchecked {
            get {
                return m_nativePtr;
            }
        }

        public abstract IntPtr NativePtr { get; }

        internal abstract void OnDispose(IntPtr nativePtr);

        public void Dispose() {
            if(m_nativePtr != IntPtr.Zero) {
                OnDispose(m_nativePtr);
                m_nativePtr = IntPtr.Zero;
                GC.SuppressFinalize(this);
            }
        }

        ~CfxObject() {
            if(m_nativePtr != IntPtr.Zero) {
                OnDispose(m_nativePtr);
                m_nativePtr = IntPtr.Zero;
            }
        }
    }
}
