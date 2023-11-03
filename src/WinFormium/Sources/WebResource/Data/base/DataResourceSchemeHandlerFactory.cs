// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
internal class DataResourceSchemeHandlerFactory : ResourceSchemeHandlerFactory
{
    public DataResourceOptions Options { get; }

    public DataResourceSchemeHandlerFactory(string scheme, string domainName, Action<DataResourceProvider> configureDataResourceProvider)
        : base(scheme, domainName)
    {
        Options = new DataResourceOptions
        {
            DomainName = domainName,
            Scheme = scheme,
            ConfigureDataResourceProvider = configureDataResourceProvider
        };
    }

    protected internal override void ResourceSchemeHandlerRegister(IServiceProvider services)
    {
        Options.ConfigureDataResourceProvider?.Invoke(DataResourceProvider.Create(Options));
    }

    protected override CefResourceHandler? GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        return new DataResourceHandler(browser, frame, request, Options);
    }
}
