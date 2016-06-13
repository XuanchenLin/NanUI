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
	/// Structure representing a list value. Can be used on any process and thread.
	/// </summary>
	/// <remarks>
	/// See also the original CEF documentation in
	/// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
	/// </remarks>
	public class CfrListValue : CfrBase {

        internal static CfrListValue Wrap(IntPtr proxyId) {
            if(proxyId == IntPtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrListValue)weakCache.Get(proxyId);
                if(cfrObj == null) {
                    cfrObj = new CfrListValue(proxyId);
                    weakCache.Add(proxyId, cfrObj);
                }
                return cfrObj;
            }
        }


        /// <summary>
        /// Creates a new object that is not owned by any other object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public static CfrListValue Create() {
            var call = new CfxListValueCreateRenderProcessCall();
            call.RequestExecution(CfxRemoteCallContext.CurrentContext.connection);
            return CfrListValue.Wrap(call.__retval);
        }


        private CfrListValue(IntPtr proxyId) : base(proxyId) {}

        /// <summary>
        /// Returns true (1) if this object is valid. This object may become invalid if
        /// the underlying data is owned by another object (e.g. list or dictionary)
        /// and that other object is then modified or destroyed. Do not call any other
        /// functions if this function returns false (0).
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsValid {
            get {
                var call = new CfxListValueIsValidRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if this object is currently owned by another object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsOwned {
            get {
                var call = new CfxListValueIsOwnedRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns true (1) if the values of this object are read-only. Some APIs may
        /// expose read-only objects.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool IsReadOnly {
            get {
                var call = new CfxListValueIsReadOnlyRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
            }
        }

        /// <summary>
        /// Returns the number of values.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int Size {
            get {
                var call = new CfxListValueGetSizeRenderProcessCall();
                call.self = CfrObject.Unwrap(this);
                call.RequestExecution(this);
                return call.__retval;
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
        public bool IsSame(CfrListValue that) {
            var call = new CfxListValueIsSameRenderProcessCall();
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
        public bool IsEqual(CfrListValue that) {
            var call = new CfxListValueIsEqualRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.that = CfrObject.Unwrap(that);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns a writable copy of this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue Copy() {
            var call = new CfxListValueCopyRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return CfrListValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Sets the number of values. If the number of values is expanded all new
        /// value slots will default to type null. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetSize(int size) {
            var call = new CfxListValueSetSizeRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.size = size;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Removes all values. Returns true (1) on success.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Clear() {
            var call = new CfxListValueClearRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Removes the value at the specified index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool Remove(int index) {
            var call = new CfxListValueRemoveRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value type at the specified index.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfxValueType GetType(int index) {
            var call = new CfxListValueGetTypeRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return (CfxValueType)call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index. For simple types the returned
        /// value will copy existing data and modifications to the value will not
        /// modify this object. For complex types (binary, dictionary and list) the
        /// returned value will reference existing data and modifications to the value
        /// will modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrValue GetValue(int index) {
            var call = new CfxListValueGetValueRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return CfrValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Returns the value at the specified index as type bool.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool GetBool(int index) {
            var call = new CfxListValueGetBoolRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type int.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public int GetInt(int index) {
            var call = new CfxListValueGetIntRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type double.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public double GetDouble(int index) {
            var call = new CfxListValueGetDoubleRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type string.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public string GetString(int index) {
            var call = new CfxListValueGetStringRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Returns the value at the specified index as type binary. The returned value
        /// will reference existing data.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrBinaryValue GetBinary(int index) {
            var call = new CfxListValueGetBinaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return CfrBinaryValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Returns the value at the specified index as type dictionary. The returned
        /// value will reference existing data and modifications to the value will
        /// modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrDictionaryValue GetDictionary(int index) {
            var call = new CfxListValueGetDictionaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return CfrDictionaryValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Returns the value at the specified index as type list. The returned value
        /// will reference existing data and modifications to the value will modify
        /// this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public CfrListValue GetList(int index) {
            var call = new CfxListValueGetListRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return CfrListValue.Wrap(call.__retval);
        }

        /// <summary>
        /// Sets the value at the specified index. Returns true (1) if the value was
        /// set successfully. If |value| represents simple data then the underlying
        /// data will be copied and modifications to |value| will not modify this
        /// object. If |value| represents complex data (binary, dictionary or list)
        /// then the underlying data will be referenced and modifications to |value|
        /// will modify this object.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetValue(int index, CfrValue value) {
            var call = new CfxListValueSetValueRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type null. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetNull(int index) {
            var call = new CfxListValueSetNullRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type bool. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBool(int index, bool value) {
            var call = new CfxListValueSetBoolRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type int. Returns true (1) if the
        /// value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetInt(int index, int value) {
            var call = new CfxListValueSetIntRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type double. Returns true (1) if
        /// the value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDouble(int index, double value) {
            var call = new CfxListValueSetDoubleRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type string. Returns true (1) if
        /// the value was set successfully.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetString(int index, string value) {
            var call = new CfxListValueSetStringRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = value;
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type binary. Returns true (1) if
        /// the value was set successfully. If |value| is currently owned by another
        /// object then the value will be copied and the |value| reference will not
        /// change. Otherwise, ownership will be transferred to this object and the
        /// |value| reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetBinary(int index, CfrBinaryValue value) {
            var call = new CfxListValueSetBinaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type dict. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetDictionary(int index, CfrDictionaryValue value) {
            var call = new CfxListValueSetDictionaryRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        /// <summary>
        /// Sets the value at the specified index as type list. Returns true (1) if the
        /// value was set successfully. If |value| is currently owned by another object
        /// then the value will be copied and the |value| reference will not change.
        /// Otherwise, ownership will be transferred to this object and the |value|
        /// reference will be invalidated.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_values_capi.h">cef/include/capi/cef_values_capi.h</see>.
        /// </remarks>
        public bool SetList(int index, CfrListValue value) {
            var call = new CfxListValueSetListRenderProcessCall();
            call.self = CfrObject.Unwrap(this);
            call.index = index;
            call.value = CfrObject.Unwrap(value);
            call.RequestExecution(this);
            return call.__retval;
        }

        internal override void OnDispose(IntPtr proxyId) {
            connection.weakCache.Remove(proxyId);
        }
    }
}
