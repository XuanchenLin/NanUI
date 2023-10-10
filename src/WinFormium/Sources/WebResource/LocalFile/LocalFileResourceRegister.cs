// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public static class LocalFileResourceRegister
{
    public static AppBuilder UseLocalFileResource(this AppBuilder appBuilder, LocalFileResourceOptions options)
    {
        if (appBuilder.ProcessType == ProcessType.Renderer) return appBuilder;

        appBuilder.Services.AddScoped<ResourceSchemeHandlerFactory, LocalFileResourceSchemeHandlerFactory>(provider =>
        {
            return new LocalFileResourceSchemeHandlerFactory(options);
        });

        return appBuilder;
    }

    public static IServiceCollection AddLocalFileResource(this IServiceCollection services, LocalFileResourceOptions options)
    {
        services.AddScoped<ResourceSchemeHandlerFactory, LocalFileResourceSchemeHandlerFactory>(provider =>
        {
            return new LocalFileResourceSchemeHandlerFactory(options);
        });

        return services;
    }
}
