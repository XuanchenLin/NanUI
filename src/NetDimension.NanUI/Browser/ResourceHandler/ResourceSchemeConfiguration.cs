using Xilium.CefGlue;

namespace NetDimension.NanUI.Browser.ResourceHandler;

public abstract class ResourceSchemeConfiguration : CefSchemeHandlerFactory, IDisposable
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



    private ResourceHandlerBase _resourceHandler;

    public ResourceSchemeConfiguration(string scheme, string domainName)
    {
        _gcHandler = GCHandle.Alloc(this);

        Scheme = scheme;
        DomainName = domainName;
    }

    protected abstract ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request);

    protected override CefResourceHandler Create(CefBrowser browser, CefFrame frame, string schemeName, CefRequest request)
    {
        _resourceHandler = GetResourceHandler(browser, frame, request);
        return _resourceHandler;
    }

    internal protected virtual void OnResourceHandlerRegister()
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
