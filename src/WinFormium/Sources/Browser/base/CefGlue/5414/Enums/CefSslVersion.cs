// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Supported SSL version values. See net/ssl/ssl_connection_status_flags.h
/// for more information.
/// </summary>
public enum CefSslVersion
{
    /// <summary>
    /// Unknown SSL version.
    /// </summary>
    Unknown = 0,
    Ssl2 = 1,
    Ssl3 = 2,
    Tls1 = 3,
    Tls1_1 = 4,
    Tls1_2 = 5,
    Tls1_3 = 6,
    Quic = 7,
}
