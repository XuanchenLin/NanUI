// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {
    
    partial class CfxV8Value {

        /// <summary>
        /// Create a new CfxV8Value object of type object with accessor.
        /// This function should only be called from within the scope
        /// of a CfxRenderProcessHandler, CfxV8Handler or CfxV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfxV8Context reference.
        /// </summary>
        public static CfxV8Value CreateObject(CfxV8Accessor accessor) {
            return CreateObject(accessor, null);
        }

        /// <summary>
        /// Create a new CfxV8Value object of type object with interceptor.
        /// This function should only be called from within the scope
        /// of a CfxRenderProcessHandler, CfxV8Handler or CfxV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfxV8Context reference.
        /// </summary>
        public static CfxV8Value CreateObject(CfxV8Interceptor interceptor) {
            return CreateObject(null, interceptor);
        }
    }
}
