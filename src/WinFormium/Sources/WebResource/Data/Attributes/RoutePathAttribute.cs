// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public class RoutePathAttribute : Attribute
{
    public string Path { get; init; }
    public RoutePathAttribute(string path)
    {
        Path = path;
    }
}
