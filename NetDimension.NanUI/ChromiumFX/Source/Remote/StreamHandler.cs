// Copyright (c) 2014-2017 Wolfgang Borgsmüller
// All rights reserved.
// 
// This software may be modified and distributed under the terms
// of the BSD license. See the License.txt file for details.

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


    public void Write(UIntPtr value) {
        if(UIntPtr.Size == 4)
            writer.Write(value.ToUInt32());
        else
            writer.Write(value.ToUInt64());
    }

    public UIntPtr ReadUIntPtr() {
        if(UIntPtr.Size == 4)
            return new UIntPtr(reader.ReadUInt32());
        else
            return new UIntPtr(reader.ReadUInt64());
    }

    public void Read(out UIntPtr value) {
        value = ReadUIntPtr();
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