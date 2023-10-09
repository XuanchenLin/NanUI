// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.CefGlue;

/// <summary>
/// Device information for a MediaSink object.
/// </summary>
public readonly struct CefMediaSinkDeviceInfo
{
    private readonly string _ipAddress;
    private readonly int _port;
    private readonly string _modelName;

    public CefMediaSinkDeviceInfo(string ipAddress, int port, string modelName)
    {
        _ipAddress = ipAddress;
        _port = port;
        _modelName = modelName;
    }

    public readonly string IPAddress => _ipAddress;

    public readonly int Port => _port;

    public readonly string ModelName => _modelName;
}
