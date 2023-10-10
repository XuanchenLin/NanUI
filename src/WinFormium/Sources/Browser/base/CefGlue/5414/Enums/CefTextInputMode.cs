// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// Input mode of a virtual keyboard. These constants match their equivalents
/// in Chromium's text_input_mode.h and should not be renumbered.
/// See https://html.spec.whatwg.org/#input-modalities:-the-inputmode-attribute
/// </summary>
public enum CefTextInputMode
{
    Default,
    None,
    Text,
    Tel,
    Url,
    Email,
    Numeric,
    Decimal,
    Search,

    Max = Search,
}
