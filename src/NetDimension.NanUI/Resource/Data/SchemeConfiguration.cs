using NetDimension.NanUI.Browser.ResourceHandler;
using Xilium.CefGlue;

namespace NetDimension.NanUI.Resource.Data;

internal class SchemeConfiguration : ResourceSchemeConfiguration
{
    public SchemeConfiguration(string scheme, string domainName, Action<DataServiceProvider> buildDataService)
        : base(scheme, domainName)
    {
        BuildDataService = buildDataService;
    }

    protected internal override void OnResourceHandlerRegister()
    {
        if (BuildDataService != null)
        {
            var provider = DataServiceProvider.Create(this);

            BuildDataService.Invoke(provider);
        }
    }

    public Action<DataServiceProvider> BuildDataService { get; }

    protected override ResourceHandlerBase GetResourceHandler(CefBrowser browser, CefFrame frame, CefRequest request)
    {
        var handler = new ResourceHandler(this);

        return handler;
    }
}
