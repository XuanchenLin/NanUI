// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public abstract class ResourceSchemeHandlerFactory : CefSchemeHandlerFactory, IDisposable
{
    private GCHandle _gcHandler;
    public string Scheme { get; }
    public string DomainName { get; }
    public bool IsStandardScheme
    {
        get
        {
            return (Scheme?.ToLower()) switch
            {
                "http" or "https" or "file" or "ftp" or "about" or "data" => true,
                _ => false,
            };
        }
    }

    private CefResourceHandler? _resourceHandler;

    public ResourceSchemeHandlerFactory(string scheme, string domainName)
    {
        _gcHandler = GCHandle.Alloc(this);

        Scheme = scheme;
        DomainName = domainName;
    }

    protected abstract CefResourceHandler? GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request);

    protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
    {

        _resourceHandler = GetResourceHandler(browser, frame, request);
        return _resourceHandler!;
    }

    internal protected virtual void ResourceSchemeHandlerRegister(IServiceProvider services)
    {
    }

    protected override void Dispose(bool isDisposing)
    {
        if (isDisposing)
        {
            _gcHandler.Free();
        }

        base.Dispose(isDisposing);

    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
