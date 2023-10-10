// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.Browser;
internal class MessageBridgePipeStream : IDisposable
{
    private readonly Stream _stream;
    private readonly UnicodeEncoding _streamEncoding;


    public MessageBridgePipeStream(Stream stream)
    {
        _stream = stream;
        _streamEncoding = new UnicodeEncoding();
    }

    public void WriteMessage(string message)
    {
        using var writer = new BinaryWriter(_stream, _streamEncoding, true);
        var messageBytes = _streamEncoding.GetBytes(message);
        var length = Convert.ToInt32(messageBytes.Length);
        writer.Write(length);
        writer.Write(messageBytes);

    }

    public string ReadMessage()
    {
        if(!_stream.CanRead) return string.Empty;

        using var reader = new BinaryReader(_stream, _streamEncoding, true);
        var length = reader.ReadInt32();
        var message = reader.ReadBytes(length);
        return _streamEncoding.GetString(message);
    }

    public void Dispose()
    {
        _stream?.Dispose();
    }
}
