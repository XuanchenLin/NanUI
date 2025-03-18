// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.JavaScript;

internal record JavaScriptWindowBindingObjectMessage
{

    public required string ObjectName { get; set; }
    public required Guid Uuid { get; set; }
    public required string FunctionName { get; set; }
    public required string Arguments { get; set; }
};