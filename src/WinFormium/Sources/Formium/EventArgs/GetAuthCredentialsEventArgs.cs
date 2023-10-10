// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium;

public class GetAuthCredentialsEventArgs : EventArgs
{
    public GetAuthCredentialsEventArgs(CefBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, CefAuthCallback callback)
    {
        Browser = browser;
        OriginUrl = originUrl;
        IsProxy = isProxy;
        Host = host;
        Port = port;
        Realm = realm;
        Scheme = scheme;
        Callback = callback;
    }

    public CefBrowser Browser { get; }
    public string OriginUrl { get; }
    public bool IsProxy { get; }
    public string Host { get; }
    public int Port { get; }
    public string Realm { get; }
    public string Scheme { get; }
    public CefAuthCallback Callback { get; }

    public bool Handled { get; set; }
}
