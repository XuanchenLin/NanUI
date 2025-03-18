// THIS FILE IS PART OF NanUI PROJECT
// THE NanUI PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace NetDimension.NanUI.WebResource;
public static class ProxyResourceRegister
{
    public static AppBuilder UseProxyResource(this AppBuilder appBuilder, string scheme, string domainName, string proxy)
    {
        if (appBuilder.ProcessType == ProcessType.Renderer) return appBuilder;

        appBuilder.Services.AddScoped<ResourceSchemeHandlerFactory, ProxyResourceSchemeHandlerFactory>(provider =>
        {
            return new ProxyResourceSchemeHandlerFactory(scheme, domainName, proxy);
        });

        return appBuilder;
    }

    public static IServiceCollection AddProxyResource(this IServiceCollection services, string scheme, string domainName, string proxy)
    {
        services.AddScoped<ResourceSchemeHandlerFactory, ProxyResourceSchemeHandlerFactory>(provider =>
        {
            return new ProxyResourceSchemeHandlerFactory(scheme, domainName, proxy);
        });

        return services;
    }
}
