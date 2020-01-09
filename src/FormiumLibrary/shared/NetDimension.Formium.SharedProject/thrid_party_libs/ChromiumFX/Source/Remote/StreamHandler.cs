// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Chromium.Remote {
    internal unsafe class StreamHandler {

        private PipeStream pipeIn;
        private PipeStream pipeOut;

        // for 81920, see https://referencesource.microsoft.com/#mscorlib/system/io/stream.cs,50
        internal const int bufferLength = 81920;

        internal readonly byte[] readBuffer;
        /// <summary>
        /// index of the first valid byte in the buffer
        /// </summary>
        private int readBufferStart;
        /// <summary>
        /// index after the last valid byte in the buffer
        /// number of valid bytes = readBufferEnd - readBufferStart
        /// </summary>
        private int readBufferEnd;

        internal readonly byte[] writeBuffer;
        /// <summary>
        /// number of valid bytes in the buffer
        /// </summary>
        private int writeBufferCount;

        // in order to minimize pinning overhead,
        // the buffers are fixed from outside
        // before every read/write cycle
        internal byte* fixedReadBuffer;
        internal byte* fixedWriteBuffer;

        public StreamHandler(PipeStream pipeIn, PipeStream pipeOut) {
            this.pipeIn = pipeIn;
            this.pipeOut = pipeOut;
            readBuffer = new byte[bufferLength];
            writeBuffer = new byte[bufferLength];
        }

        internal void FillReadBuffer(int count) {

            Debug.Assert(count <= 8);

            if(count <= readBufferEnd - readBufferStart) return;

            if(readBufferStart == readBufferEnd && readBufferStart > 0) {
                readBufferStart = 0;
                readBufferEnd = 0;
            }

            if(bufferLength - readBufferStart < count) {
                // if the needed count doesn't fit in the remaining buffer,
                // then move the bytes to the beginning of the read buffer.
                // this is rare and count is always <= 8, so this is also fast
                var i = 0;
                while(readBufferStart < readBufferEnd) {
                    readBuffer[i++] = readBuffer[readBufferStart++];
                }
                readBufferEnd = i;
                readBufferStart = 0;
            }

            while(readBufferEnd - readBufferStart < count) {
                var bytesRead = pipeIn.Read(readBuffer, readBufferEnd, bufferLength - readBufferEnd);
                if(bytesRead == 0) {
                    throw new EndOfStreamException("Unexpected end of stream.");
                }
                readBufferEnd += bytesRead;
            }
        }


        // this is for reading/writing between render/browser processes
        // so we can read/write raw data regardless encoding, endianness etc.

        public void Write(byte value) {
            if(1 > bufferLength - writeBufferCount) Flush();
            writeBuffer[writeBufferCount++] = value;
        }

        public void Read(out byte value) {
            FillReadBuffer(1);
            value = readBuffer[readBufferStart++];
        }


        public void Write(bool value) {
            if(1 > bufferLength - writeBufferCount) Flush();
            writeBuffer[writeBufferCount++] = value ? (byte)1 : (byte)0;
        }

        public void Read(out bool value) {
            FillReadBuffer(1);
            value = readBuffer[readBufferStart++] != 0;
        }


        public void Write(int value) {
            if(sizeof(int) > bufferLength - writeBufferCount) Flush();
            *(int*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(int);
        }

        public void Read(out int value) {
            FillReadBuffer(sizeof(int));
            value = *(int*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(int);
        }


        public void Write(uint value) {
            if(sizeof(uint) > bufferLength - writeBufferCount) Flush();
            *(uint*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(uint);
        }

        public void Read(out uint value) {
            FillReadBuffer(sizeof(uint));
            value = *(uint*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(uint);
        }

        public void Write(ushort value) {
            if(sizeof(ushort) > bufferLength - writeBufferCount) Flush();
            *(ushort*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(ushort);
        }

        public void Read(out ushort value) {
            FillReadBuffer(sizeof(ushort));
            value = *(ushort*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(ushort);
        }


        public void Write(long value) {
            if(sizeof(long) > bufferLength - writeBufferCount) Flush();
            *(long*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(long);
        }

        public void Read(out long value) {
            FillReadBuffer(sizeof(long));
            value = *(long*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(long);
        }


        public void Write(ulong value) {
            if(sizeof(ulong) > bufferLength - writeBufferCount) Flush();
            *(ulong*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(ulong);
        }

        public void Read(out ulong value) {
            FillReadBuffer(sizeof(ulong));
            value = *(ulong*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(ulong);
        }


        public void Write(double value) {
            if(sizeof(double) > bufferLength - writeBufferCount) Flush();
            *(double*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(double);
        }

        public void Read(out double value) {
            FillReadBuffer(sizeof(double));
            value = *(double*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(double);
        }


        public void Write(IntPtr value) {
            if(sizeof(IntPtr) > bufferLength - writeBufferCount) Flush();
            *(IntPtr*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(IntPtr);
        }

        public void Read(out IntPtr value) {
            FillReadBuffer(sizeof(IntPtr));
            value = *(IntPtr*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(IntPtr);
        }


        public void Write(UIntPtr value) {
            if(sizeof(UIntPtr) > bufferLength - writeBufferCount) Flush();
            *(UIntPtr*)(fixedWriteBuffer + writeBufferCount) = value;
            writeBufferCount += sizeof(UIntPtr);
        }

        public void Read(out UIntPtr value) {
            FillReadBuffer(sizeof(UIntPtr));
            value = *(UIntPtr*)(fixedReadBuffer + readBufferStart);
            readBufferStart += sizeof(UIntPtr);
        }


        public void Write(byte[] value) {
            WriteArrayHeader(value);
            if(value != null && value.Length > 0) {
                fixed (byte* ptr = &value[0]) {
                    WriteArray(ptr, value.Length);
                }
            }
        }

        public void Read(out byte[] value) {
            ReadArrayHeader(out value);
            if(value != null && value.Length > 0) {
                fixed (byte* ptr = &value[0]) {
                    ReadArray(ptr, value.Length);
                }
            }
        }


        public void Write(int[] value) {
            WriteArrayHeader(value);
            if(value != null && value.Length > 0) {
                fixed (int* ptr = &value[0]) {
                    WriteArray((byte*)ptr, value.Length * sizeof(int));
                }
            }
        }

        public void Read(out int[] value) {
            ReadArrayHeader(out value);
            if(value != null && value.Length > 0) {
                fixed (int* ptr = &value[0]) {
                    ReadArray((byte*)ptr, value.Length * sizeof(int));
                }
            }
        }


        public void Write(long[] value) {
            WriteArrayHeader(value);
            if(value != null && value.Length > 0) {
                fixed (long* ptr = &value[0]) {
                    WriteArray((byte*)ptr, value.Length * sizeof(long));
                }
            }
        }

        public void Read(out long[] value) {
            ReadArrayHeader(out value);
            if(value != null && value.Length > 0) {
                fixed (long* ptr = &value[0]) {
                    ReadArray((byte*)ptr, value.Length * sizeof(long));
                }
            }
        }


        public void Write(ulong[] value) {
            WriteArrayHeader(value);
            if(value != null && value.Length > 0) {
                fixed (ulong* ptr = &value[0]) {
                    WriteArray((byte*)ptr, value.Length * sizeof(ulong));
                }
            }
        }

        public void Read(out ulong[] value) {
            ReadArrayHeader(out value);
            if(value != null && value.Length > 0) {
                fixed (ulong* ptr = &value[0]) {
                    ReadArray((byte*)ptr, value.Length * sizeof(ulong));
                }
            }
        }


        public void Write(IntPtr[] value) {
            WriteArrayHeader(value);
            if(value != null && value.Length > 0) {
                fixed (IntPtr* ptr = &value[0]) {
                    WriteArray((byte*)ptr, value.Length * sizeof(IntPtr));
                }
            }
        }

        public void Read(out IntPtr[] value) {
            ReadArrayHeader(out value);
            if(value != null && value.Length > 0) {
                fixed (IntPtr* ptr = &value[0]) {
                    ReadArray((byte*)ptr, value.Length * sizeof(IntPtr));
                }
            }
        }


        public void Write(string value) {
            if(value == null) {
                Write(-1);
                return;
            }
            Write(value.Length);
            if(value.Length == 0) {
                return;
            }
            fixed (char* ptr = value) {
                WriteArray((byte*)ptr, value.Length * sizeof(char));
            }
        }

        public void Read(out string value) {
            int length;
            Read(out length);
            if(length == -1) {
                value = null;
                return;
            }
            if(length == 0) {
                value = string.Empty;
                return;
            }
            value = new string('\0', length);
            fixed (char* ptr = value) {
                ReadArray((byte*)ptr, value.Length * sizeof(char));
            }
        }


        public void Write(string[] value) {
            if(value == null) {
                Write(-1);
                return;
            }
            Write(value.Length);
            foreach(string s in value)
                Write(s);
        }

        public void Read(out string[] value) {
            int length;
            Read(out length);
            if(length == -1) {
                value = null;
                return;
            }
            value = new string[length];
            for(int i = 0; i < length; ++i)
                Read(out value[i]);
        }


        public void Write(List<string> value) {
            Write(value.ToArray());
        }

        public void Read(out List<string> value) {
            string[] array;
            Read(out array);
            if(array == null)
                value = null;
            else
                value = new List<string>(array);
        }


        public void Write(List<string[]> value) {
            if(value == null) {
                Write(-1);
                return;
            }
            Write(value.Count);
            foreach(string[] s in value)
                Write(s);
        }

        public void Read(out List<string[]> value) {
            int count;
            Read(out count);
            if(count == -1) {
                value = null;
                return;
            }
            value = new List<string[]>(count);
            for(int i = 0; i < count; ++i) {
                string[] array;
                Read(out array);
                value.Add(array);
            }
        }


        public void Write(DateTime value) {
            Write(value.ToBinary());
        }

        public void Read(out DateTime value) {
            long binary;
            Read(out binary);
            value = DateTime.FromBinary(binary);
        }


        public void Write(Chromium.CfxColor c) {
            Write(c.color);
        }

        public void Read(out Chromium.CfxColor c) {
            Read(out c.color);
        }


        public void Flush() {
            if(CfxApi.PlatformOS == CfxPlatformOS.Windows) {
                WriteNativeWindows(fixedWriteBuffer, writeBufferCount);
            } else {
                pipeOut.Write(writeBuffer, 0, writeBufferCount);
            }
            writeBufferCount = 0;
        }


        private void WriteArrayHeader<T>(T[] array) {
            if(array == null) {
                Write(-1);
                return;
            }
            Write(array.Length);
        }

        private void ReadArrayHeader<T>(out T[] array) {
            int length;
            Read(out length);
            if(length == -1) {
                array = null;
            }
            array = new T[length];
        }

        private void WriteArray(byte* array, int count) {

            if(count > bufferLength && CfxApi.PlatformOS == CfxPlatformOS.Windows) {
                // for large writes on windows, flush the write buffer and write directly to the safe pipe handle
                Flush();
                WriteNativeWindows(array, count);
                return;
            }

            while(count > 0) {
                var copycount = bufferLength - writeBufferCount;
                if(copycount > count) copycount = count;
                Copy(fixedWriteBuffer + writeBufferCount, array, copycount);
                writeBufferCount += copycount;
                array += copycount;
                count -= copycount;
                if(writeBufferCount == bufferLength) Flush();
            }
        }

        private void ReadArray(byte* array, int count) {

            if(count > bufferLength && CfxApi.PlatformOS == CfxPlatformOS.Windows) {
                // for large reads on windows, flush the read buffer and read directly from the safe pipe handle
                var copycount = readBufferEnd - readBufferStart;
                if(copycount > 0) {
                    byte* buf = fixedReadBuffer + readBufferStart;
                    Copy(array, buf, copycount);
                    array += copycount;
                    count -= copycount;
                    readBufferStart = 0;
                    readBufferEnd = 0;
                }
                ReadAllNativeWindows(array, count);
                return;
            }

            while(count > 0) {
                if(readBufferStart == readBufferEnd) {
                    readBufferStart = 0;
                    readBufferEnd = pipeIn.Read(readBuffer, 0, bufferLength);
                    if(readBufferEnd == 0) {
                        throw new EndOfStreamException("Unexpected end of stream.");
                    }
                }
                var copycount = readBufferEnd - readBufferStart;
                if(copycount > count) copycount = count;
                Copy(array, fixedReadBuffer + readBufferStart, copycount);
                readBufferStart += copycount;
                array += copycount;
                count -= copycount;
            }
        }

        private void Copy(byte* dest, byte* source, int count) {
            // some benchmarking results:
            // copying words (long) instead of bytes is a huge gain
            // aligning the destination buffer is a huge gain
            // copying 8 words in a row is a small gain
            // trying to keep the source buffer aligned would be another small gain,
            // but it's not worth it (had to use padding in writes etc.)

            Debug.Assert(sizeof(long) == 8);
            while(0 != ((long)dest & 7)) {
                *(dest++) = *(source++);
                --count;
                if(count == 0) return;
            }
            long* sl = (long*)source;
            long* dl = (long*)dest;
            while(count >= 64) {
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                *(dl++) = *(sl++);
                count -= 64;
            }
            while(count >= 8) {
                *(dl++) = *(sl++);
                count -= 8;
            }
            source = (byte*)sl;
            dest = (byte*)dl;
            while(count > 0) {
                *(dest++) = *(source++);
                --count;
            }
        }


        [DllImport("kernel32", SetLastError = false)]
        private static extern int WriteFile(SafePipeHandle handle, byte* dataPtr, int bytesToWrite, out int bytesWritten, byte* overlapped);

        private void WriteNativeWindows(byte* dataPtr, int count) {
            var h = pipeOut.SafePipeHandle;
            int bytesWritten = 0;
            if(0 == WriteFile(h, dataPtr, count, out bytesWritten, null)) {
                throw new IOException("Write to safe pipe handle failed.");
            }
            Debug.Assert(bytesWritten == count);
        }

        [DllImport("kernel32", SetLastError = false)]
        private static extern int ReadFile(SafePipeHandle handle, byte* dataPtr, int bytesToRead, out int bytesRead, byte* overlapped);

        private int ReadNativeWindows(byte* dataPtr, int count) {
            var h = pipeIn.SafePipeHandle;
            int bytesRead = 0;
            if(0 == ReadFile(h, dataPtr, count, out bytesRead, null)) {
                throw new IOException("Read from safe pipe handle failed.");
            }
            return bytesRead;
        }

        private void ReadAllNativeWindows(byte* dataPtr, int count) {
            while(count > 0) {
                int bytesRead = ReadNativeWindows(dataPtr, count);
                if(bytesRead == 0) {
                    throw new EndOfStreamException("Unexpected end of stream.");
                }
                dataPtr += bytesRead;
                count -= bytesRead;
            }
        }
    }
}
