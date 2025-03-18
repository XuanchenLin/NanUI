// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class HttpMethodAttribute : Attribute
{
    public ResourceRequestMethod Method { get; init; }
    public string? Path { get; init; }

    public HttpMethodAttribute(ResourceRequestMethod method, string? path = null)
    {
        Method = method;
        Path = path;
    }
}

