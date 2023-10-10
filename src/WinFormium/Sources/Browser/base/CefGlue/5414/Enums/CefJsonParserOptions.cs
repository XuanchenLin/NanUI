// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;
/// <summary>
/// Options that can be passed to CefParseJSON.
/// </summary>
[Flags]
public enum CefJsonParserOptions
{
    /// <summary>
    /// Parses the input strictly according to RFC 4627. See comments in
    /// Chromium's base/json/json_reader.h file for known limitations/
    /// deviations from the RFC.
    /// </summary>
    Rfc = 0,

    /// <summary>
    /// Allows commas to exist after the last element in structures.
    /// </summary>
    AllowTrailingCommas = 1 << 0,
}
