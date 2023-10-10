// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Callback interface used to select a client certificate for authentication.
/// </summary>
public sealed unsafe partial class CefSelectClientCertificateCallback
{
    /// <summary>
    /// Chooses the specified certificate for client certificate authentication.
    /// NULL value means that no client certificate should be used.
    /// </summary>
    public void Select(CefX509Certificate cert)
    {
        cef_select_client_certificate_callback_t.select(_self, cert != null ? cert.ToNative() : null);
    }
}
