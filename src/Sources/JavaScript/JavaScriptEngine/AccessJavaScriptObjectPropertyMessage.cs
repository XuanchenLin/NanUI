// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.JavaScript;

internal record AccessJavaScriptObjectPropertyMessage
{
    public required Guid ObjectUuid { get; init; }
    public required Guid PropertyUuid { get; init; }
    public required string PropertyName { get; init; }
    public string? Data { get; set; }
}