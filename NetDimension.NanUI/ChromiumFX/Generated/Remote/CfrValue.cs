// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote
{

	/// <summary>
	/// Structure that wraps other data value types. Complex types (binary,
	/// dictionary and list) will be referenced but not owned by this object. Can be
	/// used on any process and thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
	/// </remarks>
	public class CfrValue : CfrBase {

        internal static CfrValue Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrValue)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrValue(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        /// <summary>
        /// Creates a new object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfrValue Create() {
            var call = new CfxValueCreateRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return CfrValue.Wrap(call.__retval);
        }


        private CfrValue(IntPtr proxyId) : base(proxyId) {}

        /// <summary>
        /// Returns true (1) if the underlying data is valid. This will always be true
        /// (1) for simple types. For complex types (binary, dictionary and list) the
        /// underlying data may become invalid if owned by another object (e.g. list or
        /// dictionary) and that other object is then modified or destroyed. This value
        /// object can be re-used by calling Set*() even if the underlying data is
        /// invalid.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var call = new CfxValueIsValidRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying data is owned by another object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsOwned {
            get {
                var call = new CfxValueIsOwnedRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the underlying data is read-only. Some APIs may expose
        /// read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var call = new CfxValueIsReadOnlyRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value type.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType Type {
            get {
                var call = new CfxValueGetTypeRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return (CfxValueType)call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Bool {
            get {
                var call = new CfxValueGetBoolRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int Int {
            get {
                var call = new CfxValueGetIntRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double Double {
            get {
                var call = new CfxValueGetDoubleRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string String {
            get {
                var call = new CfxValueGetStringRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the underlying value as type binary. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_binary().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrBinaryValue Binary {
            get {
                var call = new CfxValueGetBinaryRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return CfrBinaryValue.Wrap(call.__retval);
            }
        }

        /// <summary>
        /// Returns the underlying value as type dictionary. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_dictionary().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue Dictionary {
            get {
                var call = new CfxValueGetDictionaryRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return CfrDictionaryValue.Wrap(call.__retval);
            }
        }

        /// <summary>
        /// Returns the underlying value as type list. The returned reference may
        /// become invalid if the value is owned by another object or if ownership is
        /// transferred to another object in the future. To maintain a reference to the
        /// value after assigning ownership to a dictionary or list pass this object to
        /// the set_value() function instead of passing the returned reference to
        /// set_list().
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue List {
            get {
                var call = new CfxValueGetListRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return CfrListValue.Wrap(call.__retval);
            }
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have the same underlying
        /// data. If true (1) modifications to this object will also affect |that|
        /// object and vice-versa.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsSame(CfrValue that) {
            var call = new CfxValueIsSameRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.that = CfrObject.Unwrap(that);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns true (1) if this object and |that| object have an equivalent
        /// underlying value but are not necessarily the same object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsEqual(CfrValue that) {
            var call = new CfxValueIsEqualRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.that = CfrObject.Unwrap(that);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns a copy of this object. The underlying data will also be copied.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrValue Copy() {
            var call = new CfxValueCopyRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return CfrValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Sets the underlying value as type null. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetNull() {
            var call = new CfxValueSetNullRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type bool. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBool(bool value) {
            var call = new CfxValueSetBoolRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type int. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetInt(int value) {
            var call = new CfxValueSetIntRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type double. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDouble(double value) {
            var call = new CfxValueSetDoubleRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type string. Returns true (1) if the value was
        /// set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetString(string value) {
            var call = new CfxValueSetStringRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type binary. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBinary(CfrBinaryValue value) {
            var call = new CfxValueSetBinaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type dict. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDictionary(CfrDictionaryValue value) {
            var call = new CfxValueSetDictionaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the underlying value as type list. Returns true (1) if the value was
        /// set successfully. This object keeps a reference to |value| and ownership of
        /// the underlying data remains unchanged.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetList(CfrListValue value) {
            var call = new CfxValueSetListRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
