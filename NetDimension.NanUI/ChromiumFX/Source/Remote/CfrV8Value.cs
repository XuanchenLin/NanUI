// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium.Remote {
    partial class CfrV8Value {

        public static implicit operator CfrV8Value(bool value) {
            return CfrV8Value.CreateBool(value);
        }

        public static implicit operator CfrV8Value(CfrTime value) {
            return CfrV8Value.CreateDate(value);
        }

        public static implicit operator CfrV8Value(double value) {
            return CfrV8Value.CreateDouble(value);
        }

        public static implicit operator CfrV8Value(int value) {
            return CfrV8Value.CreateInt(value);
        }

        public static implicit operator CfrV8Value(string value) {
            return CfrV8Value.CreateString(value);
        }

        public static implicit operator CfrV8Value(uint value) {
            return CfrV8Value.CreateUint(value);
        }

        /// <summary>
        /// Create a new CfrV8Value object of type object with accessor.
        /// This function should only be called from within the scope
        /// of a CfrRenderProcessHandler, CfrV8Handler or CfrV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfrV8Context reference.
        /// </summary>
        public static CfrV8Value CreateObject(CfrV8Accessor accessor) {
            return CreateObject(accessor, null);
        }

        /// <summary>
        /// Create a new CfrV8Value object of type object with interceptor.
        /// This function should only be called from within the scope
        /// of a CfrRenderProcessHandler, CfrV8Handler or CfrV8Accessor
        /// callback, or in combination with calling enter() and exit() on a stored
        /// CfrV8Context reference.
        /// </summary>
        public static CfrV8Value CreateObject(CfrV8Interceptor interceptor) {
            return CreateObject(null, interceptor);
        }

        public override string ToString() {
            return StringValue;
        }
    }
}
