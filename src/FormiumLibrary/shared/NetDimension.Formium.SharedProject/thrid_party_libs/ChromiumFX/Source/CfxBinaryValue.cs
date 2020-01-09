// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {
    public partial class CfxBinaryValue {

        /// <summary>
        /// Creates a new object that is not owned by any other object. The specified
        /// |data| will be copied.
        /// </summary>
        public static CfxBinaryValue Create(byte[] data) {
            if(data == null || data.Length == 0) {
                throw new ArgumentException("Data is null or zero length", "data");
            }
            var po = new PinnedObject(data);
            var retval = CfxBinaryValue.Create(po.PinnedPtr, (ulong)data.LongLength);
            po.Free();
            return retval;
        }

        /// <summary>
        /// Read up to (buffer.Length - bufferOffset) bytes into |buffer|. Reading begins at
        /// the specified byte dataOffset. Writing begins at the
        /// specified byte bufferOffset.
        /// Returns the number of bytes read.
        /// </summary>
        public int GetData(byte[] buffer, int bufferOffset, int dataOffset) {
            
            if(buffer == null || buffer.Length == 0) {
                throw new ArgumentException("Buffer is null or zero length.", "buffer");
            }

            var maxBytes = buffer.Length - bufferOffset;
            if(maxBytes <= 0)
                throw new ArgumentException("bufferOffset >= buffer.Length.", "bufferOffset");

            var po = new PinnedObject(buffer);

            var retval = CfxApi.BinaryValue.cfx_binary_value_get_data(NativePtr, po.PinnedPtr + bufferOffset, (UIntPtr)maxBytes, (UIntPtr)dataOffset);
            po.Free();
            return (int)retval;
        }

    }
}

