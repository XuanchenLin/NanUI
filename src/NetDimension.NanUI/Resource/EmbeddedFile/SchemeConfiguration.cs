using NetDimension.NanUI.Browser.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Resource.EmbeddedFile;

internal class SchemeConfiguration : ResourceSchemeConfiguration
{
    public Assembly ResourceAssebmly { get; }

    public string RootPath { get; }
    public Func<string, string> OnFallback { get; }
    public string DefaultNameSpace { get; }

    protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request) => new ResourceHandler(this);

    public SchemeConfiguration(Assembly resourceAssebmly, string scheme, string domainName, string rootPath = null, Func<string, string> onFallback = null, string defaultNameSpace = null)
        : base(scheme, domainName)
    {
        ResourceAssebmly = resourceAssebmly;
        RootPath = rootPath;
        OnFallback = onFallback;
        DefaultNameSpace = defaultNameSpace;
    }
}
