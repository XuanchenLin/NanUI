using NetDimension.NanUI.Browser.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Resource.LocalFile;

internal class SchemeConfiguration : ResourceSchemeConfiguration
{
    public string LocalResourceDiretory { get; }
    public Func<string, string> OnFallback { get; }


    public SchemeConfiguration(string scheme, string domainName, string localResourceDiretory, Func<string, string> onFallback = null)
        : base(scheme, domainName)
    {
        LocalResourceDiretory = localResourceDiretory;
        OnFallback = onFallback;

    }


    protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);
}
