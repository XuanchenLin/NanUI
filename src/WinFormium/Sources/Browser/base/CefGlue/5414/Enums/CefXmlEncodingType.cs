// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Supported XML encoding types. The parser supports ASCII, ISO-8859-1, and
/// UTF16 (LE and BE) by default. All other types must be translated to UTF8
/// before being passed to the parser. If a BOM is detected and the correct
/// decoder is available then that decoder will be used automatically.
/// </summary>
public enum CefXmlEncoding
{
   None = 0,
   Utf8,
   Utf16LE,
   Utf16BE,
   Ascii,
}
