// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.CefGlue;

/// <summary>
/// XML node types.
/// </summary>
public enum CefXmlNodeType
{
    Unsupported = 0,
    ProcessingInstruction,
    DocumentType,
    ElementStart,
    ElementEnd,
    Attribute,
    Text,
    CData,
    EntityReference,
    WhiteSpace,
    Comment,
}
