// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;

/// <summary>
/// A delegate that will be called when the resource file is not found.
/// </summary>
/// <param name="requestUrl">
/// The request url.
/// </param>
/// <returns>
/// Returns a <see cref="string"/> value indicating a exist path that will handle this request url.
/// </returns>
public delegate string ResourceFileFallbackDelegate(string requestUrl);

public abstract class ResourceOptions
{
    public string Scheme { get; init; } = "http";
    public required string DomainName { get; init; }
    public ResourceFileFallbackDelegate? OnFallback { get; init; }

}
