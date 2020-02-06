// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium.Remote {
    public partial class CfrBinaryValue {

        /// <summary>
        /// Creates a new object that is not owned by any other object. The specified
        /// |data| will be copied.
        /// </summary>
        public static CfrBinaryValue Create(byte[] data) {
            var call = new CfxBinaryValueCreateFromArrayRemoteCall();
            call.data = data;
            call.RequestExecution();
            return CfrBinaryValue.Wrap(new RemotePtr(CfxRemoteCallContext.CurrentContext.connection, call.__retval));
        }
    }


    internal class CfxBinaryValueCreateFromArrayRemoteCall : RemoteCall {

        internal CfxBinaryValueCreateFromArrayRemoteCall()
            : base(RemoteCallId.CfxBinaryValueCreateFromArrayRemoteCall) { }

        internal byte[] data;
        internal IntPtr __retval;

        protected override void WriteArgs(StreamHandler h) {
            h.Write(data);
        }

        protected override void ReadArgs(StreamHandler h) {
            h.Read(out data);
        }

        protected override void WriteReturn(StreamHandler h) {
            h.Write(__retval);
        }

        protected override void ReadReturn(StreamHandler h) {
            h.Read(out __retval);
        }

        protected override void RemoteProcedure() {
            if(data == null || data.Length == 0) {
                throw new ArgumentException("Data is null or zero length", "data");
            }
            var po = new PinnedObject(data);
            __retval = CfxApi.BinaryValue.cfx_binary_value_create(po.PinnedPtr, (UIntPtr)data.Length);
            po.Free();
        }
    }

}
