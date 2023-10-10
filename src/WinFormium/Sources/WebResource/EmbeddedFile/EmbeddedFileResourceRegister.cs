// THIS FILE IS PART OF WinFormium PROJECT
// THE WinFormium PROJECT IS AN OPENSOURCE LIBRARY LICENSED UNDER THE MIT License.
// COPYRIGHTS (C) Xuanchen Lin. ALL RIGHTS RESERVED.
// GITHUB: https://github.com/XuanchenLin/NanUI

namespace WinFormium.WebResource;
public static class EmbeddedFileResourceRegister
{
    public static AppBuilder UseEmbeddedFileResource(this AppBuilder appBuilder, EmbeddedFileResourceOptions options)
    {

        if(appBuilder.ProcessType == ProcessType.Renderer) return appBuilder;

        appBuilder.Services.AddScoped<ResourceSchemeHandlerFactory, EmbeddedFileResourceSchemeHandlerFactory>(provider =>
        {
            return new EmbeddedFileResourceSchemeHandlerFactory(options);
        });

        return appBuilder;
    }

    public static IServiceCollection AddEmbeddedFileResource(this IServiceCollection services, EmbeddedFileResourceOptions options)
    {

        services.AddScoped<ResourceSchemeHandlerFactory, EmbeddedFileResourceSchemeHandlerFactory>(provider =>
        {
            return new EmbeddedFileResourceSchemeHandlerFactory(options);
        });

        return services;
    }
}
