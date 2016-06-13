using System;
using System.IO;
using System.IO.Pipes;

namespace Chromium.Remote
{
	/// <summary>
	/// Buffer data until Flush() or until the buffer is full 
	/// and read data into a buffer in an attempt to bundle 
	/// several pipe read/write operations into one.
	/// </summary>
	class PipeBufferStream : Stream {

        internal const int bufferLength = 1024;

        internal readonly PipeStream pipe;
        
        private readonly byte[] writeBuffer;
        private int writeBufferCount;

        private readonly byte[] readBuffer;
        private int readBufferOffset;
        private int readBufferCount;

        internal PipeBufferStream(PipeStream pipe) {
            this.pipe = pipe;
            writeBuffer = new byte[bufferLength];
            readBuffer = new byte[bufferLength];
        }

        public override void Write(byte[] buffer, int offset, int count) {
            do {
                
                var bytes = count > bufferLength - writeBufferCount ?
                    bufferLength - writeBufferCount : count;

                Array.Copy(buffer, offset, this.writeBuffer, writeBufferCount, bytes);
                writeBufferCount += bytes;
                offset += bytes;
                count -= bytes;

                
                if(writeBufferCount == bufferLength) {
                    pipe.Write(this.writeBuffer, 0, writeBufferCount);
                    writeBufferCount = 0;
                }

            } while(count > 0);
        }

        public override void WriteByte(byte value) {
            writeBuffer[writeBufferCount] = (byte)value;
            ++writeBufferCount;
            if(writeBufferCount == bufferLength) {
                pipe.Write(this.writeBuffer, 0, writeBufferCount);
                writeBufferCount = 0;
            }
        }

        public override int Read(byte[] buffer, int offset, int count) {
            if(readBufferCount == 0) {
                readBufferOffset = 0;
                readBufferCount = pipe.Read(readBuffer, 0, bufferLength);
                if(readBufferCount == 0) return 0;
            }
            int bytes = count < readBufferCount ? count : readBufferCount;
            Array.Copy(readBuffer, readBufferOffset, buffer, offset, bytes);
            readBufferOffset += bytes;
            readBufferCount -= bytes;
            return bytes;
        }

        public override int ReadByte() {
            if(readBufferCount == 0) {
                readBufferOffset = 0;
                readBufferCount = pipe.Read(readBuffer, 0, bufferLength);
                if(readBufferCount == 0) return -1;
            }
            var retval = readBuffer[readBufferOffset];
            ++readBufferOffset;
            --readBufferCount;
            return retval;
        }

        public override void Flush() {
            if(writeBufferCount > 0) {
                pipe.Write(this.writeBuffer, 0, writeBufferCount);
                writeBufferCount = 0;
            }
        }

        public override bool CanRead {
            get { return pipe.CanRead; }
        }

        public override bool CanSeek {
            get { return false; }
        }

        public override bool CanWrite {
            get { return pipe.CanWrite; }
        }

        public override long Length {
            get { throw new NotSupportedException(); }
        }

        public override long Position {
            get {
                throw new NotSupportedException();
            }
            set {
                throw new NotSupportedException();
            }
        }

        public override long Seek(long offset, SeekOrigin origin) {
            throw new NotSupportedException();
        }

        public override void SetLength(long value) {
            throw new NotSupportedException();
        }
    }
}
