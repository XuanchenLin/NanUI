// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;

namespace Chromium {

    public partial class CfxZipReader {
        /// <summary>
        /// Read uncompressed file contents into the specified buffer. Returns 
        /// 0 if at the end of file, or the number of bytes read.
        /// Throws an exception if an error occurred.
        /// </summary>
        public int ReadFile(byte[] buffer) {
            if(buffer == null || buffer.Length == 0)
                throw new ArgumentException("Buffer can't be null or zero length.", "buffer");
            var pb = new PinnedObject(buffer);
            var retval = CfxApi.ZipReader.cfx_zip_reader_read_file(NativePtr, pb.PinnedPtr, (UIntPtr)buffer.LongLength);
            pb.Free();
            if(retval < 0)
                throw new CfxException("Failed to read from zip file");
            return retval;
        }
    }
}
