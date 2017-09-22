// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
namespace Chromium {
    /// <summary>
    /// Base class for all wrapper classes for ref counted CEF structs.
    /// </summary>
    public abstract class CfxBaseRefCounted : CfxObject {

        static internal CfxBaseRefCounted Cast(IntPtr nativePtr) {
            throw new Exception("Implement this");
        }

        static internal IntPtr Unwrap(CfxBaseRefCounted cfxBase) {
            if (cfxBase == null) {
                return IntPtr.Zero;
            } else {
                return cfxBase.NativePtr;
            }
        }


        internal CfxBaseRefCounted() {}
        internal CfxBaseRefCounted(IntPtr nativePtr) : base(nativePtr) {}
    }
}
