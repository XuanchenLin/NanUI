// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.JavaScript;

internal class JavaScriptValueDefinition
{
    public required Guid Uuid { get; init; }
    public required string Name { get; init; }
    public required JavaScriptValueType ValueType { get; init; }
    public string ValueTypeName => Enum.GetName(ValueType.GetType(), ValueType)!;
    public object? ValueDefinition { get; init; }
}
