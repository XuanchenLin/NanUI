// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// V8 access control values.
/// </summary>
[Flags]
public enum CefV8AccessControl
{
    Default = 0,
    AllCanRead = 1,
    AllCanWrite = 1 << 1,
    ProhibitsOverwriting = 1 << 2,
}
