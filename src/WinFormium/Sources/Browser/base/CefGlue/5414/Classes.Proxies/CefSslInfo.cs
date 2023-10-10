// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI


using WinFormium.CefGlue.Interop;

namespace WinFormium.CefGlue;
/// <summary>
/// Class representing SSL information.
/// </summary>
public sealed unsafe partial class CefSslInfo
{
    /// <summary>
    /// Returns a bitmask containing any and all problems verifying the server
    /// certificate.
    /// </summary>
    public CefCertStatus CertStatus
    {
        get { return cef_sslinfo_t.get_cert_status(_self); }
    }

    /// <summary>
    /// Returns the X.509 certificate.
    /// </summary>
    public CefX509Certificate GetX509Certificate()
    {
        return CefX509Certificate.FromNative(
            cef_sslinfo_t.get_x509certificate(_self)
            );
    }
}
