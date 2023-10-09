// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
//
// GITHUB: https://github.com/XuanchenLin/WinFormium
// EMail: xuanchenlin(at)msn.com QQ:19843266 WECHAT:linxuanchen1985

namespace WinFormium.CefGlue;
/// <summary>
/// DOM node types.
/// </summary>
public enum CefDomNodeType
{
   Unsupported = 0,
   Element,
   Attribute,
   Text,
   CDataSection,
   ProcessingInstruction,
   Comment,
   Document,
   DocumentType,
   DocumentFragment,
}
