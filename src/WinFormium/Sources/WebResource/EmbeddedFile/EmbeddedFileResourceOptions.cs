// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;



public sealed class EmbeddedFileResourceOptions : ResourceOptions
{
    public string? EmbeddedResourceDirectoryName { get; init; }
    public string? DefaultNamespace { get; init; }
    public required Assembly ResourceAssembly { get; init; }
}
