// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chromium {

    /// <summary>
    /// Base class for all wrapper classes for scoped CEF library structs.
    /// Objects of this type will be disposed when they go out of scope. 
    /// </summary>
    public class CfxBaseScoped : CfxObject {

        internal CfxBaseScoped(IntPtr nativePtr) : base(nativePtr) { }

        /// <summary>
        /// Provides access to the underlying native cef struct.
        /// This is a scoped library struct derived from cef_base_scoped_t.
        /// It will be destroyed when the managed object goes out of scope.
        /// </summary>
        public sealed override IntPtr NativePtr {
            get {
                if(nativePtrUnchecked == IntPtr.Zero) {
                    throw new ObjectDisposedException(this.GetType().Name);
                } else {
                    return nativePtrUnchecked;
                }
            }
        }

        internal override void OnDispose(IntPtr nativePtr) {
            // do nothing
        }
    }
}
