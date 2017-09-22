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



using System;
using System.IO;

internal class StreamHandler {

    private BinaryReader reader;
    private BinaryWriter writer;
    
    public StreamHandler(Stream stream)
        : this(stream, stream) {
    }

    public StreamHandler(Stream inputStream, Stream outputStream) {
        reader = new BinaryReader(inputStream);
        writer = new BinaryWriter(outputStream);
    }

    public Stream InputStream {
        get { return reader.BaseStream; }
    }

    public Stream OutputStream {
        get { return writer.BaseStream; }
    }
        

    public void Write(byte value) {
        writer.Write(value);
    }

    public byte ReadByte() {
        return reader.ReadByte();
    }

    public void Read(out byte value) {
        value = reader.ReadByte();
    }



    public void Write(bool value) {
        writer.Write(value);
    }

    public bool ReadBoolean() {
        return reader.ReadBoolean();
    }

    public void Read(out bool value) {
        value = reader.ReadBoolean();
    }



    public void Write(int value) {
        writer.Write(value);
    }

    public int ReadInt32() {
        return reader.ReadInt32();
    }

    public void Read(out int value) {
        value = reader.ReadInt32();
    }

    
    
    public void Write(uint value) {
        writer.Write(value);
    }

    public uint ReadUInt32() {
        return reader.ReadUInt32();
    }

    public void Read(out uint value) {
        value = reader.ReadUInt32();
    }



    public void Write(ushort value) {
        writer.Write(value);
    }

    public ushort ReadUInt16() {
        return reader.ReadUInt16();
    }

    public void Read(out ushort value) {
        value = reader.ReadUInt16();
    }



    public void Write(long value) {
        writer.Write(value);
    }

    public long ReadInt64() {
        return reader.ReadInt64();
    }

    public void Read(out long value) {
        value = reader.ReadInt64();
    }


    public void Write(ulong value) {
        writer.Write(value);
    }

    public ulong ReadUInt64() {
        return reader.ReadUInt64();
    }

    public void Read(out ulong value) {
        value = reader.ReadUInt64();
    }



    public void Write(double value) {
        writer.Write(value);
    }

    public double ReadDouble() {
        return reader.ReadDouble();
    }

    public void Read(out double value) {
        value = reader.ReadDouble();
    }



    public void Write(IntPtr value) {
        if(IntPtr.Size == 4)
            writer.Write(value.ToInt32());
        else
            writer.Write(value.ToInt64());
    }

    public IntPtr ReadIntPtr() {
        if(IntPtr.Size == 4)
            return new IntPtr(reader.ReadInt32());
        else
            return new IntPtr(reader.ReadInt64());
    }

    public void Read(out IntPtr value) {
        value = ReadIntPtr();
    }



    public void Write(string value) {
        if(string.IsNullOrEmpty(value)) {
            writer.Write(string.Empty);
            if(value == null) {
                writer.Write('n');
            } else {
                writer.Write('e');
            }
        } else {
            writer.Write(value);
        }
    }

    public string ReadString() {
        var str = reader.ReadString();
        if(str.Length == 0) {
            var ch = reader.ReadChar();
            if(ch.Equals('n')) {
                return null;
            } else {
                return string.Empty;
            }
        } else {
            return str;
        }
    }

    public void Read(out string value) {
        value = ReadString();
    }


    public void Write(string[] value) {
        if(value == null) {
            writer.Write(-1);
            return;
        }
        writer.Write(value.Length);
        foreach(string s in value)
            Write(s);
    }

    public string[] ReadStringArray() {
        var length = reader.ReadInt32();
        if(length == -1) return null;
        var retval = new string[length];
        for(int i = 0; i < length; ++i)
            retval[i] = ReadString();
        return retval;
    }

    public void Read(out string[] value) {
        value = ReadStringArray();
    }



    public void Write(System.Collections.Generic.List<string> value) {
        Write(value.ToArray());
    }

    public System.Collections.Generic.List<string> ReadStringList() {
        var arr = ReadStringArray();
        if(arr == null) return null;
        return new System.Collections.Generic.List<string>(arr);
    }

    public void Read(out System.Collections.Generic.List<string> value) {
        value = ReadStringList();
    }



    public void Write(System.Collections.Generic.List<string[]> value) {
        if(value == null) {
            writer.Write(-1);
            return;
        }
        writer.Write(value.Count);
        foreach(string[] s in value)
            Write(s);
    }

    public System.Collections.Generic.List<string[]> ReadStringArrayList() {
        var count = reader.ReadInt32();
        if(count == -1) return null;
        var retval = new System.Collections.Generic.List<string[]>(count);
        for(int i = 0; i < count; ++i)
            retval.Add(ReadStringArray());
        return retval;
    }

    public void Read(out System.Collections.Generic.List<string[]> value) {
        value = ReadStringArrayList();
    }



    public void Write(byte[] value) {
        if(value == null) {
            writer.Write(-1);
        } else {
            writer.Write(value.Length);
            writer.Write(value);
        }
    }

    public byte[] ReadByteArray()
	{
		var length = reader.ReadInt32();
		if (length == -1)
			return null;
		if (length == 0)
			return new byte[0];
		return reader.ReadBytes(length);
	}

    public void Read(out byte[] value) {
        value = ReadByteArray();
    }



    public void Write(int[] value) {
        if(value == null) {
            writer.Write(-1);
        } else {
            writer.Write(value.Length);
            for(int i = 0; i < value.Length; ++i) {
                writer.Write(value[i]);
            }
        }
    }

    public int[] ReadIntegerArray() {
        var length = reader.ReadInt32();
        if(length == -1)
            return null;
        int[] value = new int[length];
        for(int i = 0; i < length; ++i) {
            value[i] = reader.ReadInt32();
        }
        return value;
    }

    public void Read(out int[] value) {
        value = ReadIntegerArray();
    }




    public void Write(long[] value) {
        if(value == null) {
            writer.Write(-1);
        } else {
            writer.Write(value.Length);
            for(int i = 0; i < value.Length; ++i) {
                writer.Write(value[i]);
            }
        }
    }

    public long[] ReadLongArray() {
        var length = reader.ReadInt32();
        if(length == -1)
            return null;
        long[] value = new long[length];
        for(int i = 0; i < length; ++i) {
            value[i] = reader.ReadInt64();
        }
        return value;
    }

    public void Read(out long[] value) {
        value = ReadLongArray();
    }



    public void Write(ulong[] value) {
        if(value == null) {
            writer.Write(-1);
        } else {
            writer.Write(value.Length);
            for(int i = 0; i < value.Length; ++i) {
                writer.Write(value[i]);
            }
        }
    }

    public ulong[] ReadULongArray() {
        var length = reader.ReadInt32();
        if(length == -1)
            return null;
        ulong[] value = new ulong[length];
        for(int i = 0; i < length; ++i) {
            value[i] = reader.ReadUInt64();
        }
        return value;
    }

    public void Read(out ulong[] value) {
        value = ReadULongArray();
    }



    public void Write(IntPtr[] value) {
        if(value == null) {
            writer.Write(-1);
        } else {
            writer.Write(value.Length);
            for(int i = 0; i < value.Length; ++i) {
                Write(value[i]);
            }
        }
    }

    public IntPtr[] ReadIntPtrArray() {
        var length = reader.ReadInt32();
        if(length == -1)
            return null;
        IntPtr[] value = new IntPtr[length];
        for(int i = 0; i < length; ++i) {
            value[i] = ReadIntPtr();
        }
        return value;
    }

    public void Read(out IntPtr[] value) {
        value = ReadIntPtrArray();
    }


    public void Write(DateTime value) {
        writer.Write(value.ToBinary());
    }

    public DateTime ReadDateTime() {
        return DateTime.FromBinary(reader.ReadInt64());
    }

    public void Read(out DateTime value) {
        value = DateTime.FromBinary(reader.ReadInt64());
    }

    public void Write(Chromium.CfxColor c) {
        Write(c.color);
    }

    public void Read(out Chromium.CfxColor c) {
        Read(out c.color);
    }

    public void Flush() {
        writer.Flush();
    }

}